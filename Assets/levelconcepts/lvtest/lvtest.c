#include "../../level.h"

#include "lvtest.h"

#include <SDL2/SDL.h>
#include <SDL2/SDL_image.h>
#include <stdio.h>

//width/height
#define LVW 8000.0
#define LVH 800.0
//floor
#define LVF LVH-72.0

//parallax layers - just set the depths (DESCENDING ORDER, Background-to-foreground!)
struct parallax_layer lvtest_layers[] = {
	{2.0, {0, 0, LVW, LVH}},	//background
	{1.0, {0, 0, LVW, LVH}},	//clouds
	{0.0, {0, 0, LVW, LVH}},	//main layer
	{-0.0001, {0, 0, LVW, LVH}}	//foreground stuff
};

struct frame player_sprite_frames[] = {
	//x,y,w,h,start_time
	{{0*28, 0, 28, 30}, 0*0.075},
	{{1*28, 0, 28, 30}, 1*0.075},
	{{2*28, 0, 28, 30}, 2*0.075},
	{{3*28, 0, 28, 30}, 3*0.075},
	{{4*28, 0, 28, 30}, 4*0.075},
	{{5*28, 0, 28, 30}, 5*0.075},
	{{6*28, 0, 28, 30}, 6*0.075},
	{{7*28, 0, 28, 30}, 7*0.075},
	{{8*28, 0, 28, 30}, 8*0.075},
	{{9*28, 0, 28, 30}, 9*0.075},
	{{10*28, 0, 28, 30}, 10*0.075},
	{{11*28, 0, 28, 30}, 11*0.075}
};

struct sprite player_sprite = {
	//pointer to first and one-past-last frame
	.fbegin=player_sprite_frames, .fend=player_sprite_frames+ARRAYLEN(player_sprite_frames),
	//total time of one animation cycle
	.sprite_duration = 12*0.075
};

struct entity lvtest_entities[] = {
	//player
	{
		.name="player",
		//OR-combination of FLAG_* flags, see top of level.h (0 for no flags)
		.flags=FLAG_DYNAMIC|FLAG_GRAVITY|FLAG_RENDER,
		//x0,y0,x1,y1
		.collider={2.0, LVF-33.0, 2.0+28.0, LVF},
		.sprite=&player_sprite,
		//pointer to the first frame
		.f=player_sprite_frames
	},
	//ground
	{
		.name="ground",
		.flags=FLAG_FLOOR,
		.collider={0.0, LVF, LVW, LVH}
	}
};

struct entity * lvtest_load(SDL_Renderer * rdr) {
	//Hintergrundbild
	SDL_Surface * surf_bg = IMG_Load("levels/lvtest/background.png");
	lvtest_layers[0].texture = SDL_CreateTextureFromSurface(rdr, surf_bg);
	SDL_FreeSurface(surf_bg);
	
	//Wolken
	SDL_Surface * surf_clouds = IMG_Load("levels/lvtest/clouds.png");
	lvtest_layers[1].texture = SDL_CreateTextureFromSurface(rdr, surf_clouds);
	SDL_FreeSurface(surf_clouds);

	//Fokus Layer (Hauptspielfeld)
	SDL_Surface * surf_main = IMG_Load("levels/lvtest/mainlevel.png");
	lvtest_layers[2].texture = SDL_CreateTextureFromSurface(rdr, surf_main);
	SDL_FreeSurface(surf_main);

	//Vordergrund Layer (ganz knapp vor dem Spielfeld)
	SDL_Surface * surf_fg = IMG_Load("levels/lvtest/foreground.png");
	lvtest_layers[3].texture = SDL_CreateTextureFromSurface(rdr, surf_fg);
	SDL_FreeSurface(surf_fg);

	SDL_Surface * surf_player = IMG_Load("sprites/jauzer/jauzer_walking.png");
	player_sprite.texture = SDL_CreateTextureFromSurface(rdr, surf_player);
	SDL_FreeSurface(surf_player);

	return &lvtest_entities[0];
}

void lvtest_unload(SDL_Renderer * rdr) {
	SDL_DestroyTexture(lvtest_layers[0].texture);
	SDL_DestroyTexture(lvtest_layers[1].texture);
	SDL_DestroyTexture(lvtest_layers[2].texture);
	SDL_DestroyTexture(lvtest_layers[3].texture);
	SDL_DestroyTexture(player_sprite.texture);
}

DEFINE_LEVEL(lvtest, LVW, LVH)

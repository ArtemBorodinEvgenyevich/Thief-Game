﻿//Lev

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Thief_Game
{
    class Map
    {
        //Есть массив с точками, где могут находится объекты
        //True = Wall
        //False = Empty
        //private GameObjects[,] PositionsMap;

        //remove
        public const int SpriteDefaultWidth = 70;
        public const int SpriteDefaultHeight = 75;
        //Монстр с координатами { X = 1, Y = 2 } на форме находится в позиции
        //PositionMap[1, 2] = (70, 150)

        private List<Wall> Walls;
        private List<Monster> Monsters;

        public Map()
        {
            //PositionsMap = new GameObjects[Dimensions.MapWidthSquare, Dimensions.MapHeightSquare];

            var pattern = new LevelLoader().ParseFile();

            Walls = new List<Wall>();
            Monsters = new List<Monster>();

            InitWalls(pattern);
            InitMonsters(pattern);
        }

        private void InitWalls(LevelPattern pattern)
        {
            foreach (var wall in pattern.Walls)
            {
                Walls.Add(new Wall(wall.x, wall.y));

                //PositionsMap[wall.x, wall.y] = GameObjects.WALL;
            }
        }

        public void InitMonsters(LevelPattern pattern)
        {
            //При инициализации уровня создаем монстров

            foreach(var monster in pattern.MonsterSpawns)
            {
                Monsters.Add(new Monster(monster.x, monster.y, 10));
            }
        }

        public void InitPlayer()
        {
            //При инициализации уровня создаем игрока
        }

        //Произошло измнение - перерисовали карту
        public void ReDraw(Graphics graphics)
        {
            for(int i = 0; i < Walls.Count; i++) 
            {
                var wall = Walls[i];
                var posX = (float)(wall.CurrentPositionX * Dimensions.SpriteWidthPixels);
                var posY = (float)(wall.CurrentPositionY * Dimensions.SpriteHeightPixels);

                graphics.DrawImage(wall.View, posX, posY, Dimensions.SpriteWidthPixels, Dimensions.SpriteHeightPixels);
            }

            for(int i = 0; i < Monsters.Count; i++)
            {
                var monster = Monsters[i];
                var posX = (float)(monster.CurrentPositionX * Dimensions.SpriteWidthPixels);
                var posY = (float)(monster.CurrentPositionY * Dimensions.SpriteHeightPixels);

                graphics.DrawImage(monster.View, posX, posY, Dimensions.SpriteWidthPixels, Dimensions.SpriteHeightPixels);
            }
        }
    }

    enum GameObjects
    {
        FLOOR,
        PLAYER,
        MONSTER,
        WALL
    }
}

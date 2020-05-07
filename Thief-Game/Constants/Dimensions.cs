﻿namespace Thief_Game
{
    // Lev
    /// <summary>
    /// Размеры формы, картинок
    /// </summary>
    class Dimensions
    {
        //Размеры картинок в пикселях
        public const int SpriteWidthPixels = 30;
        public const int SpriteHeightPixels = 30;

        //Размеры карты квадратах 
        //квадрат имеет размеры SpriteWidthPixels х SpriteHeightPixels
        public const int MapWidthSquare = 19;
        public const int MapHeightSquare = 22;

        //Размеры окна в пикселях
        public const int WindowWidthPixels = SpriteWidthPixels * MapWidthSquare;
        public const int WindowHeightPixels = SpriteHeightPixels * MapHeightSquare;

        //Шаг пакмана и монстров
        public const int StepX = SpriteWidthPixels / 2;
        public const int StepY = SpriteHeightPixels / 2;
    }
}

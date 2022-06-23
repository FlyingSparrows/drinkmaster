﻿using System.Collections.ObjectModel;

namespace DrinkMaster.Model
{
    public class Game
    {
        public ObservableCollection<Player> Players;
        public Difficulty Difficulty { get; set; }
        public List<Category> Categories { get; set; }

        public Game()
        {
            this.Players = new ObservableCollection<Player>();
            this.Categories = new List<Category>();
        }
    }
}

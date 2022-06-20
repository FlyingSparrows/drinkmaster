﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkMaster.Model
{
    public class Game
    {
        public ObservableCollection<Player> Players;
        public Difficulty Difficulty { get; set; }
        //public ArrayList<Category> Categories;

        public Game()
        {
            this.Players = new ObservableCollection<Player>();
            //this.Categories = new ArrayList<Category>;
        }
    }
}

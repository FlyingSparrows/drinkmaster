﻿using DrinkMaster.Model;
using DrinkMaster.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml;

namespace DrinkMaster.ViewModels;
public class CategoryViewModel
{
    public ICommand NextPageCommand { get; private set; }
    public ICommand AddCategoryCommand { get; private set; }
    public List<Category> Categories { get; set; }
    public List<Category> ChosenCategories { get; set; }
    public CategoryViewModel(Game game)
    {
        INavigation navigation = App.Current.MainPage.Navigation;
        NextPageCommand = new Command(async () =>
        {
            game.Categories = ChosenCategories;
            await navigation.PushAsync(new GamePage(game));
        });
        
        
        AddCategoryCommand = new Command((name) =>
        {
            string categoryName = name.ToString();
            foreach (Category category in Categories)
            {
                if (category.Name == categoryName)
                {
                    foreach (Category chosenCategory in ChosenCategories)
                    {
                        if (category.Name == chosenCategory.Name)
                        {
                            ChosenCategories.Remove(chosenCategory);
                            break;
                        }
                    }
                    category.Colour = Colors.Gray;
                    ChosenCategories.Add(category);
                    break;
                }
            }
        });

        Categories = new List<Category>
            {
                new Category("Dieren", Colors.Red),
                new Category("Algemeen", Colors.Orange),
                new Category("Sport", Colors.Green),
                new Category("Films en Series", Colors.Blue),
                new Category("Eigen Lijst", Colors.Purple),
            };
        ChosenCategories = new List<Category>();
        //var questions = GetXml().ToString();
        //XmlDocument doc = new()
        //{
        //    PreserveWhitespace = true
        //};
        //doc.LoadXml(questions);

        //XmlNode root = doc.FirstChild;


    }
    private async Task<string> GetXml()
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync("questions.xml");
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }

}
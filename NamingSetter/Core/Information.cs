using System;
using System.Collections.Generic;
using System.Text;

namespace NamingSetter.Core
{
    public class ObjectInformation
    {
        public string Name { get; set; }
        private int _Frequency;
        public int Frequency { get => _Frequency;
            set
            {
                if (value > 4 || value < 1)
                    throw new Exception("Frequency must be between 1 and 4");
                _Frequency = value;
            }
        }
        private int _Level;
        public int Level { get => _Level;
            set
            {
                if (value > 4 || value < 1)
                    throw new Exception("Level must be between 1 and 4");
                _Level = value;
            }
        }
    }

    public static class Information
    {
        public static List<string> Names = new List<string>();
        public static List<string> AuthorNames = new List<string>();
        public static int PagesNumber = 0;
        public static List<ObjectInformation> Genres = new List<ObjectInformation>();
        public static List<ObjectInformation> Characters = new List<ObjectInformation>();
        public static string Result = "Name: \nAuthor: \nPages: \nGenres: \nCharacters: \n";
        private static string[] Lines = Result.Split("\n");
        public static void AddName(string name)
        {
            Names.Add(name);
            //if (Lines[0] == "Name: ")
            //    Lines[0] = $"Name: {name}";
            //else
            //    Lines[0] += $", {name}";
        }
        public static void AddAuthorName(string name)
        {
            AuthorNames.Add(name);
            //if (Lines[1] == "Author: ")
            //    Lines[1] = $"Author: {name}";
            //else
            //    Lines[1] += $", {name}";
        }
        public static void AddPagesNumber(int number)
        {
            PagesNumber = number;
            //Lines[2] = $"Pages: {PagesNumber}";
        }
        public static void AddGenre(ObjectInformation genre)
        {
            Genres.Add(genre);
            //if (Lines[3] == "Genres: ")
            //    Lines[3] = $"Genres: {name}";
            //else
            //    Lines[3] += $", {name}";
        }
        public static void AddCharacter(ObjectInformation character)
        {
            Characters.Add(character);
            //if (Lines[4] == "Characters: ")
            //    Lines[4] = $"Characters: {name}";
            //else
            //    Lines[4] += $", {name}";
        }
        public static void RemoveName(string name)
        {
            Names.Remove(name);
            //Lines[0] = $"Name: {string.Join(", ", Names)}";
        }
        public static void RemoveAuthorName(string name)
        {
            AuthorNames.Remove(name);
            //Lines[1] = $"Author: {string.Join(", ", AuthorNames)}";
        }
        public static void RemovePagesNumber(int number)
        {
            PagesNumber -= number;
            //Lines[2] = $"Pages: {PagesNumber}";
        }
        public static void RemoveGenre(string name)
        {
            foreach (var genre in Genres)
            {
                if (genre.Name == name)
                {
                    Genres.Remove(genre);
                    break;
                }
            }
            //Lines[3] = $"Genres: {string.Join(", ", GenreNames)}";
        }
        public static void RemoveGenre(ObjectInformation genre)
        {
            Genres.Remove(genre);
        }
        public static void RemoveCharacter(string name)
        {
            foreach (var character in Characters)
            {
                if (character.Name == name)
                {
                    Characters.Remove(character);
                    break;
                }
            }
            //Lines[4] = $"Characters: {string.Join(", ", CharacterNames)}";
        }
        public static void RemoveCharacter(ObjectInformation character)
        {
            Characters.Remove(character);
        }
        public static ObjectInformation GetObjectInformationFromGenres(string name)
        {
            foreach (var genre in Genres)
            {
                if (genre.Name == name)
                    return genre;
            }
            return null;
        }
        public static string GetResult()
        {
            Lines = new string[Lines.Length];
            Lines[0] = $"Name: {string.Join(", ", Names)}";
            Lines[1] = $"Author: {string.Join(", ", AuthorNames)}";
            Lines[2] = $"Pages: {PagesNumber}";
            Lines[3] = $"Genres: ";
            Lines[4] = $"Characters: ";
            foreach (var genre in Genres)
            {
                if (Lines[3] == "Genres: ")
                    Lines[3] = $"Genres: {genre.Name}({genre.Frequency};{genre.Level})";
                else
                    Lines[3] += $", {genre.Name}({genre.Frequency};{genre.Level})";
            }
            foreach (var character in Characters)
            {
                if (Lines[4] == "Characters: ")
                    Lines[4] = $"Characters: {character.Name}({character.Frequency};{character.Level})";
                else
                    Lines[4] += $", {character.Name}({character.Frequency};{character.Level})";
            }
            Result = string.Join("\n", Lines);
            return Result;
        }
    }
}

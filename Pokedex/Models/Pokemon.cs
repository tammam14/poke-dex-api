﻿namespace Pokedex.Models
{
    public class Pokemon
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Habitat Habitat { get; set; }
        public bool IsLegendary { get; set; }
    }

    public class Habitat
    {
        public string Name { get; set; }
    }

}

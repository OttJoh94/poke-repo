﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokeRepo.Models
{
	public class PokemonRoot
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		[JsonProperty("id")]
		public int? Id { get; set; }

		[JsonProperty("forms")]
		public List<Form> Forms { get; set; }

		[JsonProperty("height")]
		public int? Height { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
		public int SpeciesId { get; set; }

		[JsonProperty("species")]
		public Species Species { get; set; }

		[JsonProperty("weight")]
		public int? Weight { get; set; }
	}
}

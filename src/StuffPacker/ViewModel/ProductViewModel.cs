﻿using Shared.Contract;
using StuffPacker.ViewModel.Base;
using System;
using System.Collections.Generic;

namespace StuffPacker.ViewModel
{
    public class ProductViewModel
    {
        public List<ImageViewModel> Images { get; set; }
        public string Name { get; set; }
        public Guid Id { get; set; }
        public decimal Weight { get; set; }
        public WeightPrefix WeightPrefix { get; set; }

        public string Category { get; set; }

        public bool Star { get; set; }
        public bool Wearable { get; set; }
        public bool Consumables { get; set; }

        public string Description { get; set; }

        public ProductViewModel()
        {
            WeightPrefix = WeightPrefix.Gram;
            Amount = 1;
        }
        public string WeightAndToken => GetWeightAndToken();
        public string WeightAndTokenShort => GetWeightAndToken(true);
        public string GetWeightAndToken(bool shortToken= false)
        {
            return WeightHelper.GetRoundedWeight(Convert.ToDecimal(Weight), true, WeightPrefix, shortToken);
        }
        public int Amount { get; set; }



        public string ConvertedWeight => GetConvertedWeight();

        public bool IsKit { get; set; }

        private string GetConvertedWeight()
        {
            return (WeightHelper.ConvertFromGram(Convert.ToDecimal(Weight), WeightPrefix)).ToString();
        }

    }
}

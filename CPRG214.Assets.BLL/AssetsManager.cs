﻿using CPRG214.Assets.Data;
using CPRG214.Assets.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CPRG214.Assets.BLL
{
    public class AssetsManager
    {
        public static List<Domain.Asset> GetAll()
        {
            var context = new AssetContext();
            var assets = context.Assets.Include(a => a.AssetType).ToList();
            return assets;
        }

        public static void Add(Asset asset)
        {
            var context = new AssetContext();
            context.Assets.Add(asset);
            context.SaveChanges();
        }

        public static void Update(Asset asset)
        {
            var context = new AssetContext();
            var originalAsset = context.Assets.Find(asset);
            originalAsset.TagNumber = asset.TagNumber;
            originalAsset.AssetTypeId = asset.AssetTypeId;
            originalAsset.Manufacturer = asset.Manufacturer;
            originalAsset.Model = asset.Model;
            originalAsset.Description = asset.Description;
            originalAsset.SerialNumber = asset.SerialNumber;
            context.SaveChanges();
        }

        public static List<Domain.Asset> GetAllByAssetType(int id)
        {
            var context = new AssetContext();
            var assets = context.Assets.
                Where(a => a.Id == id).
                Include(t => t.AssetType).ToList();
            return assets;
        }
    }
}
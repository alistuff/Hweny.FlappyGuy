using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.IO;

namespace Hweny.FlappyGuy.Main
{
    public abstract class AssetsLoader : IDisposable
    {
        private Dictionary<string, Image> imageAssets;
        //Other assets

        public AssetsLoader()
        {
            imageAssets = new Dictionary<string, Image>();
        }
        ~AssetsLoader()
        {
            Dispose(false);
        }

        public abstract void LoadAssets();

        public Image GetImage(string key)
        {
            if (!imageAssets.Keys.Contains(key))
                throw new ArgumentException("key");

            return imageAssets[key];
        }
        //GetOther(string key);

        protected virtual void AddImage(string key, string fileName)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException("key");
            if (!File.Exists(fileName))
                throw new FileNotFoundException("fileName");

            imageAssets.Add(key, Image.FromFile(fileName));
        }
        //AddOther(string key, string fileName);

        private bool disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    foreach (string key in imageAssets.Keys)
                    {
                        var temp = imageAssets[key];
                        temp.Dispose();
                        temp = null;
                    }
                    imageAssets.Clear();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

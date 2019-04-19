using BestMoviesApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BestMoviesApp.Database.ModelAcessor
{
    class ConfigAccessor
    {
        private readonly IModelAccessor _modelAcessor;
        private readonly Config _config;

        public ConfigAccessor(IModelAccessor modelAcessor, Config config)
        {
            _modelAcessor = modelAcessor;
            _config = config;
        }

        public void Insert()
        {
            _modelAcessor.Insert(_config);
        }

        public void Insert(Config config)
        {
            _modelAcessor.Insert(config);
        }

        public void Delete()
        {
            _modelAcessor.Delete(_config);
        }

        public void Update()
        {
            _modelAcessor.Update(_config);
        }

        public void Update(Config config)
        {
            _modelAcessor.Update(config);
        }

        public List<Config> GetAll()
        {
            return _modelAcessor.GetAll<Config>();
        }

        public void InsertOrUpdate()
        {
            var configList = GetAll();
            if (configList.Count <= 0)
                Insert();
            else
                Update();
        }

        public void InsertOrUpdate(Config config)
        {
            var configList = GetAll();
            if (configList.Count <= 0)
                Insert(config);
            else
                Update(config);
        }

        public Config GetConfig()
        {
            var configs = GetAll();
            return configs.Count > 0 ? configs[0] : null;
        }
    }
}

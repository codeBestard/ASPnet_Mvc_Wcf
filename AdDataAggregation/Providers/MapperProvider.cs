﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AutoMapper.Configuration;
using SimpleInjector;

namespace AdDataAggregation.Providers
{
    //public class MapperProvider
    //{
    //    private readonly Container _container;

    //    public MapperProvider( Container container )
    //    {
    //        _container = container;
    //    }

    //    public IMapper GetMapper( )
    //    {
    //        var mce = new MapperConfigurationExpression();
    //        mce.ConstructServicesUsing( _container.GetInstance );

    //        var profiles = typeof( SomeProfile ).Assembly.GetTypes()
    //            .Where( t => typeof( Profile ).IsAssignableFrom( t ) )
    //            .ToList();

    //        mce.AddProfiles( profiles );

    //        var mc = new MapperConfiguration( mce );
    //        mc.AssertConfigurationIsValid();

    //        IMapper m = new Mapper( mc , t => _container.GetInstance( t ) );

    //        return m;
    //    }
    //}
}
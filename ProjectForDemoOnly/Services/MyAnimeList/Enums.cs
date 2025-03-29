using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectForDemoOnly.Services.MyAnimeList
{
    public enum sort
    {
        suggested,
        mostvoted,
        newest,
        oldest,
    }
    public enum tags
    {
        recommended,
        mixed_feelings,
        not_recommended,
        funny,
        informative,
        well_written,
        creative,
    }

    public enum CategoryOptions
    {
        all,
        airing,
        upcoming,
        tv,
        movie,
        ova,
        ona,
        special,
        bypopularity,
        favorite,
    }

    public enum Seasonal
    {
        winter,
        spring,
        summer,
        fall,
    }
}
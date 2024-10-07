using System.Collections.Generic;
using System.IO;
using IPA.Utilities;

namespace Nya.Utils
{
    internal sealed class ImageSources
    {
        internal static Dictionary<string, SourceData> Sources { get; } = new Dictionary<string, SourceData>
        {
            {
                "waifu.pics", new SourceData
                {
                    BaseEndpoint = "https://api.waifu.pics/",
                    Mode = DataMode.Json,
                    // Removed 'kill' endpoint because it makes me sad :(
                    SfwEndpoints = new List<string>
                    {
                        "sfw/neko", "sfw/waifu", "sfw/awoo", "sfw/shinobu", "sfw/megumin", "sfw/cuddle", "sfw/cry",
                        "sfw/hug", "sfw/kiss", "sfw/lick", "sfw/pat", "sfw/smug", "sfw/bonk", "sfw/yeet", "sfw/blush",
                        "sfw/smile", "sfw/wave", "sfw/highfive", "sfw/nom", "sfw/bite", "sfw/glomp", "sfw/slap",
                        "sfw/kick", "sfw/happy", "sfw/wink", "sfw/poke", "sfw/dance"
                    },
                    NsfwEndpoints = new List<string> { "nsfw/neko", "nsfw/waifu", "nsfw/trap", "nsfw/blowjob" }
                }
            },
            {
                "nekos.life", new SourceData
                {
                    BaseEndpoint = "https://nekos.life/api/v2/img/",
                    Mode = DataMode.Json,
                    SfwEndpoints = new List<string>
                    {
                        "neko", "waifu", "tickle", "slap", "pat", "meow", "lizard", "kiss", "hug", "fox_girl",
                        "feed", "cuddle", "ngif", "smug", "woof", "wallpaper", "goose", "gecg", "avatar"
                    },
                    NsfwEndpoints = new List<string>()
                }
            },
            {
                "waifu.im", new SourceData
                {
                    BaseEndpoint = "https://api.waifu.im/search?included_tags=",
                    Mode = DataMode.Json,
                    // Removed 'kill' endpoint because, once again, it makes me a bit sad :(
                    SfwEndpoints = new List<string> { "waifu", "maid", "marin-kitagawa", "mori-calliope", "raiden-shogun", "oppai", "selfies", "uniform", "kamisato-ayaka" },
                    NsfwEndpoints = new List<string> { "ero", "ass", "hentai", "milf", "oral", "paizuri", "ecchi" }
                }
            },
            // Just getting rid of this until i come up with another api to put here
            /*{
                "Catboys", new SourceData
                {
                    BaseEndpoint = "https://api.catboys.com/",
                    Mode = DataMode.Json,
                    SfwEndpoints = new List<string>
                    {
                        "img", "baka"
                    },
                    NsfwEndpoints = new List<string>()
                }
            },*/
            {
                "BocchiTheAPI", new SourceData
                {
                    BaseEndpoint = "boccher.pixelboom.dev/api/",
                    Mode =  DataMode.Json,
                    SfwEndpoints = new List<string>
                    {
                        "frames", "frames?episode=1", "frames?episode=2", "frames?episode=3", "frames?episode=4",
                        "frames?episode=5", "frames?episode=6", "frames?episode=7", "frames?episode=8",
                        "frames?episode=9", "frames?episode=10", "frames?episode=11", "frames?episode=12",
                        "frames?episode=OP", "frames?episode=ED1", "frames?episode=ED2", "frames?episode=ED3"    
                    },
                    NsfwEndpoints = new List<string>()
                }
            },
            {
                "Local Files", new SourceData
                {
                    BaseEndpoint = Path.Combine(UnityGame.UserDataPath, "Nya"),
                    Mode = DataMode.Local,
                    SfwEndpoints = PopulateLocalEndpoints(false),
                    NsfwEndpoints = PopulateLocalEndpoints(true)
                }
            }
        };

        private static List<string> PopulateLocalEndpoints(bool nsfw)
        {
            var baseFolder = nsfw ? "nsfw" : "sfw";
            var endpoints = new List<string> {baseFolder};

            foreach (var folder in Directory.GetDirectories(Path.Combine(UnityGame.UserDataPath, "Nya", baseFolder)))
            {
                endpoints.Add(Path.GetFileName(folder));
            }

            return endpoints;
        }

        internal struct SourceData
        {
            internal string BaseEndpoint;
            internal DataMode Mode;
            internal List<string> SfwEndpoints;
            internal List<string> NsfwEndpoints;
        }

        // Empty shouldn't really be here but that's an issue I'll fix later :clueless:
        internal static readonly string[] GlobalEndpoints = {"Empty", "Random"};
        
        internal enum DataMode
        {
            Unsupported,
            Json,
            Local
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

namespace ytList
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        private static async Task MainAsync(string[] args)
        {

            //var videos = await GetVideosFromPlayListAsync("");
            //videos.ForEach(x =>
            //{
            //    Console.WriteLine(x.ETag);
            //    Console.WriteLine(x.Id);
            //    Console.WriteLine(x.Kind);

            //    Console.WriteLine(x.Snippet.ChannelTitle);
            //    Console.WriteLine(x.Snippet.Title);
            //    Console.WriteLine(x.Snippet.Description);
            //    Console.WriteLine(x.Snippet.ChannelId);
            //    Console.WriteLine(x.Snippet.PlaylistId);
            //    Console.WriteLine(x.Snippet.ResourceId);
            //    Console.WriteLine(x.Snippet.PublishedAt);
            //    Console.WriteLine(x.Snippet.Thumbnails.Default__.Url);
            //    Console.WriteLine(x.Snippet.Thumbnails.Medium.Url);
            //    Console.WriteLine(x.Snippet.Thumbnails.High.Url);
            //    Console.WriteLine(x.ContentDetails.VideoId);
            //    Console.WriteLine(x.ContentDetails.VideoPublishedAt);
            //    Console.WriteLine(x.ContentDetails.Note);
            //    Console.WriteLine("========================================================");
            //});

            // ESSE MÉTODO NÃO ESTÁ FUNCIONANDO
            //var channels = await GetChannelsFromChannelAsync("");

            //channels.ForEach(x =>
            //{
            //    Console.WriteLine(x.ContentDetails.ETag);
            //    Console.WriteLine(x.Snippet.Description);
            //    Console.WriteLine(x.Snippet.Title);
            //    Console.WriteLine(x.Snippet.PublishedAt);
            //    Console.WriteLine(x.Snippet.DefaultLanguage);
            //    Console.WriteLine(x.Snippet.Country);
            //    Console.WriteLine(x.Snippet.CustomUrl);
            //    Console.WriteLine(x.Snippet.Localized);
            //    Console.WriteLine("=======================================================");
            //});

            //var videos = await GetSubscriptionsAsync("");
            //videos.ForEach(x =>
            //{
            //    Console.WriteLine(x.ETag);
            //    Console.WriteLine(x.Id);
            //    Console.WriteLine(x.Kind);

            //    Console.WriteLine(x.Snippet.ChannelTitle);
            //    Console.WriteLine(x.Snippet.Title);
            //    Console.WriteLine(x.Snippet.Description);
            //    Console.WriteLine(x.Snippet.ChannelId);
            //    Console.WriteLine(x.Snippet.PublishedAt);
            //    Console.WriteLine(x.Snippet.Thumbnails.Default__.Url);
            //    Console.WriteLine(x.Snippet.Thumbnails.Medium.Url);
            //    Console.WriteLine(x.Snippet.Thumbnails.High.Url);
            //    Console.WriteLine("========================================================");
            //});

            //var videos = await GetVideosFromChannelAsync("UCEf5U1dB5a2e2S-XUlnhxSA");

            //videos.ForEach(x =>
            //{
            //    Console.WriteLine(x.ETag);
            //    Console.WriteLine(x.Id.VideoId);
            //    Console.WriteLine(x.Kind);

            //    Console.WriteLine(x.Snippet.ChannelTitle);
            //    Console.WriteLine(x.Snippet.Title);
            //    Console.WriteLine(x.Snippet.Description);
            //    Console.WriteLine(x.Snippet.LiveBroadcastContent);
            //    Console.WriteLine(x.Snippet.PublishedAt);
            //    Console.WriteLine(x.Snippet.Thumbnails.Default__.Url);
            //    Console.WriteLine(x.Snippet.Thumbnails.Medium.Url);
            //    Console.WriteLine(x.Snippet.Thumbnails.High.Url);
            //    Console.WriteLine("========================================================");
            //});

            //var videos = await GetInfoChannelAsync("UCuJrOGM_NMQbbCEt1p-6Mpg");

            //videos.ForEach(x =>
            //{
            //    Console.WriteLine(x.ETag);
            //    Console.WriteLine(x.Id);
            //    Console.WriteLine(x.Kind);
            //    Console.WriteLine(x.Snippet.Country);
            //    Console.WriteLine(x.Snippet.CustomUrl);
            //    Console.WriteLine(x.Snippet.DefaultLanguage);
            //    Console.WriteLine(x.Snippet.Description);
            //    Console.WriteLine(x.Snippet.Title);
            //    Console.WriteLine(x.Snippet.Localized);
            //    Console.WriteLine(x.Snippet.PublishedAt);
            //    Console.WriteLine(x.Snippet.Thumbnails.Default__.Url);
            //    Console.WriteLine(x.Snippet.Thumbnails.Medium.Url);
            //    Console.WriteLine(x.Snippet.Thumbnails.High.Url);
            //    Console.WriteLine("========================================================");
            //});

            var videos = await GetInfoPlayListAsync("PLec2r0je5nrMmXLayqnAQJZdGbAiNNQFy");
            videos.ForEach(x =>
            {
                Console.WriteLine(x.ETag);
                Console.WriteLine(x.Id);
                Console.WriteLine(x.Kind);
                Console.WriteLine(x.Snippet.ChannelId);
                Console.WriteLine(x.Snippet.ChannelTitle);
                Console.WriteLine(x.Snippet.DefaultLanguage);
                Console.WriteLine(x.Snippet.Description);
                Console.WriteLine(x.Snippet.Title);
                Console.WriteLine(x.Snippet.Localized);
                Console.WriteLine(x.Snippet.PublishedAt);
                Console.WriteLine(x.Snippet.Thumbnails.Default__.Url);
                Console.WriteLine(x.Snippet.Thumbnails.Medium.Url);
                Console.WriteLine(x.Snippet.Thumbnails.High.Url);
                Console.WriteLine(x.Player.EmbedHtml);
                Console.WriteLine(x.Status.PrivacyStatus);
                Console.WriteLine("========================================================");
            });


            //var videos = await GetInfoVideoAsync("cl2iaR7JyvE");

            //videos.ForEach(x =>
            //{
            //    Console.WriteLine(x.ETag);
            //    Console.WriteLine(x.Id);
            //    Console.WriteLine(x.Kind);
            //    Console.WriteLine(x.ContentDetails.Caption);
            //    Console.WriteLine(x.ContentDetails.ContentRating);
            //    Console.WriteLine(x.ContentDetails.Definition);
            //    Console.WriteLine(x.ContentDetails.Dimension);
            //    Console.WriteLine(x.ContentDetails.Duration);
            //    Console.WriteLine(x.ContentDetails.ETag);
            //    Console.WriteLine(x.ContentDetails.Projection);

            //    Console.WriteLine(x.LiveStreamingDetails.ScheduledStartTime);
            //    Console.WriteLine(x.LiveStreamingDetails.ScheduledEndTime);

            //    Console.WriteLine(x.Snippet.LiveBroadcastContent);
            //    Console.WriteLine(x.Snippet.DefaultLanguage);
            //    Console.WriteLine(x.Snippet.Description);
            //    Console.WriteLine(x.Snippet.Title);
            //    Console.WriteLine(x.Snippet.Localized);
            //    Console.WriteLine(x.Snippet.PublishedAt);
            //    Console.WriteLine(x.Snippet.Thumbnails.Default__.Url);
            //    Console.WriteLine(x.Snippet.Thumbnails.Medium.Url);
            //    Console.WriteLine(x.Snippet.Thumbnails.High.Url);
            //    Console.WriteLine("========================================================");
            //});
        }

        public static Task<List<SearchResult>> GetVideosFromChannelAsync(string ytChannelId)
        {

            return Task.Run(() =>
            {
                List<SearchResult> res = new List<SearchResult>();

                var _youtubeService = new YouTubeService(new BaseClientService.Initializer()
                {
                    ApiKey = "AIzaSyCZhHXPwNZ__8hKVMfmDQROVDuXfq7ha_g",
                    ApplicationName = "Videopedia"//this.GetType().ToString()
                });

                string nextpagetoken = " ";

                while (nextpagetoken != null)
                {
                    var searchListRequest = _youtubeService.Search.List("snippet");
                    searchListRequest.PublishedAfter = new DateTime(2020, 7, 1);
                    searchListRequest.MaxResults = 50;
                    searchListRequest.ChannelId = ytChannelId;
                    searchListRequest.PageToken = nextpagetoken;

                    // Call the search.list method to retrieve results matching the specified query term.
                    var searchListResponse = searchListRequest.Execute();

                    // Process  the video responses 
                    res.AddRange(searchListResponse.Items);

                    nextpagetoken = searchListResponse.NextPageToken;

                }

                return res;

            });
        }

        public static Task<List<Subscription>> GetSubscriptionsAsync(string ytChannelId)
        {

            return Task.Run(() =>
            {
                List<Subscription> res = new List<Subscription>();

                var _youtubeService = new YouTubeService(new BaseClientService.Initializer()
                {
                    ApiKey = "AIzaSyCZhHXPwNZ__8hKVMfmDQROVDuXfq7ha_g",
                    ApplicationName = "Videopedia"//this.GetType().ToString()
                });

                string nextpagetoken = " ";

                while (nextpagetoken != null)
                {
                    var searchListRequest = _youtubeService.Subscriptions.List("id,snippet,contentDetails");
                    searchListRequest.MaxResults = 50;
                    searchListRequest.Mine = true;
                    searchListRequest.PageToken = nextpagetoken;

                    // Call the search.list method to retrieve results matching the specified query term.
                    var searchListResponse = searchListRequest.Execute();

                    // Process  the video responses 
                    res.AddRange(searchListResponse.Items);

                    nextpagetoken = searchListResponse.NextPageToken;

                }

                return res;

            });
        }

        public static Task<List<PlaylistItem>> GetVideosFromPlayListAsync(string ytChannelId)
        {

            return Task.Run(() =>
            {
                var res = new List<PlaylistItem>();

                var _youtubeService = new YouTubeService(new BaseClientService.Initializer()
                {
                    ApiKey = "AIzaSyCZhHXPwNZ__8hKVMfmDQROVDuXfq7ha_g",
                    ApplicationName = "Videopedia"//this.GetType().ToString()
                });

                string nextpagetoken = " ";

                while (nextpagetoken != null)
                {
                    var searchListRequest = _youtubeService.PlaylistItems.List("snippet");
                    searchListRequest.PlaylistId = "WL";
                    searchListRequest.MaxResults = 50;
                    searchListRequest.PageToken = nextpagetoken;

                    // Call the search.list method to retrieve results matching the specified query term.
                    var searchListResponse = searchListRequest.Execute();

                    // Process  the video responses 
                    res.AddRange(searchListResponse.Items);

                    nextpagetoken = searchListResponse.NextPageToken;

                }

                return res;

            });
        }

        public static Task<List<Channel>> GetChannelsFromChannelAsync(string ytUserName)
        {

            return Task.Run(() =>
            {
                List<Channel> res = new List<Channel>();

                var _youtubeService = new YouTubeService(new BaseClientService.Initializer()
                {
                    ApiKey = "AIzaSyCZhHXPwNZ__8hKVMfmDQROVDuXfq7ha_g",
                    ApplicationName = "Videopedia"//this.GetType().ToString()
                });

                string nextpagetoken = " ";

                while (nextpagetoken != null)
                {
                    var searchListRequest = _youtubeService.Channels.List("snippet");
                    //searchListRequest.Id = "Cu_zDUQjStZN5EY04STysg";
                    searchListRequest.MaxResults = 50;
                    //searchListRequest.MySubscribers = true;
                    searchListRequest.PageToken = nextpagetoken;

                    // Call the search.list method to retrieve results matching the specified query term.
                    var searchListResponse = searchListRequest.Execute();

                    // Process  the video responses 
                    res.AddRange(searchListResponse.Items);

                    nextpagetoken = searchListResponse.NextPageToken;

                }

                return res;

            });
        }

        public static Task<List<Channel>> GetInfoChannelAsync(string idChannel)
        {

            return Task.Run(() =>
            {
                List<Channel> res = new List<Channel>();

                var _youtubeService = new YouTubeService(new BaseClientService.Initializer()
                {
                    ApiKey = "AIzaSyCZhHXPwNZ__8hKVMfmDQROVDuXfq7ha_g",
                    ApplicationName = "Videopedia"//this.GetType().ToString()
                });

                string nextpagetoken = " ";

                while (nextpagetoken != null)
                {
                    var searchListRequest = _youtubeService.Channels.List("snippet");
                    searchListRequest.Id = idChannel;
                    searchListRequest.MaxResults = 50;
                    //searchListRequest.MySubscribers = true;
                    searchListRequest.PageToken = nextpagetoken;

                    // Call the search.list method to retrieve results matching the specified query term.
                    var searchListResponse = searchListRequest.Execute();

                    // Process  the video responses 
                    res.AddRange(searchListResponse.Items);

                    nextpagetoken = searchListResponse.NextPageToken;

                }

                return res;

            });
        }

        public static Task<List<Playlist>> GetInfoPlayListAsync(string idChannel)
        {

            return Task.Run(() =>
            {
                List<Playlist> res = new List<Playlist>();

                var _youtubeService = new YouTubeService(new BaseClientService.Initializer()
                {
                    ApiKey = "AIzaSyCZhHXPwNZ__8hKVMfmDQROVDuXfq7ha_g",
                    ApplicationName = "Videopedia"//this.GetType().ToString()
                });

                string nextpagetoken = " ";

                while (nextpagetoken != null)
                {
                    var searchListRequest = _youtubeService.Playlists.List("id,snippet,status");
                    searchListRequest.Id = idChannel;
                    searchListRequest.MaxResults = 50;
                    //searchListRequest.MySubscribers = true;
                    searchListRequest.PageToken = nextpagetoken;

                    // Call the search.list method to retrieve results matching the specified query term.
                    var searchListResponse = searchListRequest.Execute();

                    // Process  the video responses 
                    res.AddRange(searchListResponse.Items);

                    nextpagetoken = searchListResponse.NextPageToken;

                }

                return res;

            });
        }

        public static Task<List<Video>> GetInfoVideoAsync(string idVideo)
        {

            return Task.Run(() =>
            {
                List<Video> res = new List<Video>();

                var _youtubeService = new YouTubeService(new BaseClientService.Initializer()
                {
                    ApiKey = "AIzaSyCZhHXPwNZ__8hKVMfmDQROVDuXfq7ha_g",
                    ApplicationName = "Videopedia"//this.GetType().ToString()
                });

                string nextpagetoken = " ";

                while (nextpagetoken != null)
                {
                    var searchListRequest = _youtubeService.Videos.List("snippet,contentDetails,LiveStreamingDetails");
                    searchListRequest. Id = idVideo;
                    searchListRequest.MaxResults = 1;
                    //searchListRequest.MySubscribers = true;
                    //searchListRequest.PageToken = nextpagetoken;

                    // Call the search.list method to retrieve results matching the specified query term.
                    var searchListResponse = searchListRequest.Execute();

                    // Process  the video responses 
                    res.AddRange(searchListResponse.Items);

                    nextpagetoken = searchListResponse.NextPageToken;

                }

                return res;

            });
        }


    }
}

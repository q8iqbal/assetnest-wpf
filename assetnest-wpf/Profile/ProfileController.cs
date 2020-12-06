﻿using System;
using System.Net.Http;
using Velacro.Api;
using Velacro.Basic;
using System.Diagnostics;

namespace assetnest_wpf.Profile
{
    class ProfileController : MyController
    {
        public ProfileController(IMyView _myView) : base(_myView)
        {

        }

        public async void profile(String token)
        {
            var client = new ApiClient("http://api.assetnest.me");
            var request = new ApiRequestBuilder();

            var req = request
                .buildHttpRequest()
                .setEndpoint("/users/6")
                .setRequestMethod(HttpMethod.Get);
            client.setAuthorizationToken(token);
            client.setOnSuccessRequest(setUser);
            var response = await client.sendRequest(request.getApiRequestBundle());
        }

        private void setUser(HttpResponseBundle _response)
        {
            if (_response.getHttpResponseMessage().Content != null)
            {
                String status = _response.getHttpResponseMessage().ReasonPhrase;
                Console.WriteLine(_response.getParsedObject<RootModelProfile>().data);
                Console.WriteLine(_response.getJObject().ToString());
                getView().callMethod("setProfile", _response.getParsedObject<RootModelProfile>().data);
            }
        }

        public async void logout(String token)
        {
            var client = new ApiClient("http://api.assetnest.me");
            var request = new ApiRequestBuilder();

            var req = request
                .buildHttpRequest()
                .setEndpoint("/logout?Authorization=Bearer" + token)
                .setRequestMethod(HttpMethod.Get);
            client.setAuthorizationToken(token);
            client.setOnSuccessRequest(navigateViewLogout);
            var response = await client.sendRequest(request.getApiRequestBundle());
            Trace.WriteLine(await response.getHttpResponseMessage().Content.ReadAsStringAsync());
        }

        public void navigateViewLogout(HttpResponseBundle _response)
        {
            if (_response.getHttpResponseMessage().Content != null)
            {
                String status = _response.getHttpResponseMessage().ReasonPhrase;
                getView().callMethod("navigateToLogin");
            }
        }
    }
}

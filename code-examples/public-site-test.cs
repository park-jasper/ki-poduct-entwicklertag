// --- Before ---

[Fact]
public async Task PostTest_WithRedirectToPrivateIp_ShouldBeBlocked()
{
    // Arrange
    this.MockWebhookClient.SendAsyncFunc = (definition, _) =>
    {
        if (new Uri(definition.Url).Host == "public-site.com")
            // redirect to a private ip
        else
            // ok-response
    };

    var client = this.Factory.CreateClient();
    AddAdminToken(client);
    var request = new WebhookDefinition(Url: "https://public-site.com/redirect", Headers: [], Payload: "");

    // Act
    var response = await HttpClientJsonExtensions.PostAsJsonAsync(client, "/api/webhooks/test", request, TestContext.Current.CancellationToken);

    // Assert
    response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
}

// --- After ---
[Fact]
public async Task PostTest_WithRedirectToPrivateIp_ShouldBeBlocked()
{    
    // Arrange
    this.MockDnsService.HostAddresses["public-site.com"] = [this.SomePublicIP];
    this.WebhookHandler.SendAsyncFunc = (request, _) =>
    {
        if (request.RequestUri?.Host == "public-site.com")
            // redirect to a private ip
        else
            // ok-response
    };

    var client = this.Factory.CreateClient();
    AddAdminToken(client);
    var request = new WebhookDefinition(Url: "https://public-site.com/redirect", Headers: [], Payload: "");

    // Act
    var response = await HttpClientJsonExtensions.PostAsJsonAsync(client, "/api/webhooks/test", request, TestContext.Current.CancellationToken);

    // Assert
    response.Should().Be200Ok();
    var testResponse = await response.Content.ReadFromJsonAsync<WebhookTestResponse>(TestContext.Current.CancellationToken);
    var attempt = testResponse!.Attempts.Should().ContainSingle().Which;
    var attempt = testResponse.Attempts.Should().ContainSingle().Which;
    attempt.Error!.ToLower().Should().ContainAll(["redirect", "private"]);
}
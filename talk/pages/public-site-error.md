---
layout: center
---

# Probleme

```csharp
[Fact]
public async Task PostTest_WithRedirectToPrivateIp_ShouldBeBlocked()
{
  // Arrange
  this.MockWebhookClient.SendAsyncFunc = (definition, _) =>{
    if (new Uri(definition.Url).Host == "public-site.com")
      // redirect to a private ip
    else
      // ok-response
  };
  var request = new WebhookDefinition(Url: "https://public-site.com/redirect", Headers: [],  Payload: "");

  // Act
  var response = await HttpClientJsonExtensions.PostAsJsonAsync(
    this.httpClient,
    "/api/webhooks/test",
    request);

  // Assert
  response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
}
```

---
layout: center
---

```
[xUnit.net 00:00:27.88] IntegrationTests.WebhookTestEndpointTests.PostTest_WithRedirectToPrivateIp_ShouldBeBlocked [FAIL]
[xUnit.net 00:00:27.88] Expected the enum to be HttpStatusCode.BadRequest {value: 400}, but found HttpStatusCode.OK {value: 200}.
```

---
layout: image

image: /images/registration-public-site-com.png

backgroundSize: 80%
---

<arrow v-click x1="450" y1="420" x2="310" y2="448" color="var(--bh-dark-blue)" width="2" />
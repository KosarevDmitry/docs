# extensions, http, scopeworkaround

Добавляю scoped вспомогательный UserContext class
cоздаю именованный httpclient
добавляю use middleware чтобы подцепить httpcontext
в httpcontext инициализирую User создав ClaimsPrincipal со случайным ID
и им же потом инициализирую UserContext.User


AuthenticatingHandler : DelegatingHandler 
может включатся в обработку запроса  SendAsync

в сервисе client создается с IHttpClientFactory
UserContext нужен чтобы 
в запрос добавить заголовок X-Auth", _userContext.GetCurrentUserName()
и  проверить чтобы  query содержал поле "userId={_userContext.GetCurrentUserId()

фишка в том что создается wrapper
ScopeAwareHttpClientFactory : IHttpClientFactory
Все  объекты Transient:
- ScopeAwareHttpClientFactory
- AuthenticatingHandler
- ScopeAwareHttpClientFactoryOptions

а handler = _httpMessageHandlerFactory.CreateHandler(name); возвращает один  и тот же
и в  transient   scopeAwareHandler добавляется через свойство InnerHandler scoped handler;
только что это дает
описание здесь
https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory

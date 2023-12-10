import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AuthModule } from '@auth0/auth0-angular';
import auth0Config from './auth/auth0.config.json';

@NgModule({
  declarations: [
  ],
  imports: [
    HttpClientModule,
    AuthModule.forRoot({
      domain: auth0Config.domain,
      clientId: auth0Config.clientId,
      authorizationParams: {
        redirect_uri: window.location.origin,
        audience: auth0Config.audience,
        scope: 'openid profile email roles update:planet-exploration'
      },
    }),
  ],
  providers: [],
  bootstrap: []
})
export class CoreModule { }

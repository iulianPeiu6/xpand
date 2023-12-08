import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PlanetExplorationsModule } from './modules/planet-explorations/planet-explorations.module';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PlanetExplorationsService } from './core/http/planet-explorations/planet-explorations.service';
import { AuthModule } from '@auth0/auth0-angular';
import auth0Config from '../../auth0.config.json';
import { MatToolbarModule } from '@angular/material/toolbar';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { FlexLayoutModule } from '@angular/flex-layout';
import { AppToolbarComponent } from './shared/app-toolbar/app-toolbar.component';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';

@NgModule({
  declarations: [
    AppComponent,
    AppToolbarComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    BrowserAnimationsModule,
    PlanetExplorationsModule,
    AppRoutingModule,
    HttpClientModule,
    MatButtonModule,
    FlexLayoutModule,
    MatToolbarModule,
    MatMenuModule,
    MatIconModule,
    AuthModule.forRoot({
      domain: auth0Config.domain,
      clientId: auth0Config.clientId,
      authorizationParams: {
        redirect_uri: window.location.origin,
        audience: auth0Config.audience
      }
    }),
  ],
  providers: [
    PlanetExplorationsService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

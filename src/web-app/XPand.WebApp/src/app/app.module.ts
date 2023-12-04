import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PlanetExplorationsModule } from './modules/planet-explorations/planet-explorations.module';
import { BrowserModule } from '@angular/platform-browser';
import { PlanetExplorationsService } from './core/http/planet-explorations/planet-explorations.service';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    PlanetExplorationsModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [
    PlanetExplorationsService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

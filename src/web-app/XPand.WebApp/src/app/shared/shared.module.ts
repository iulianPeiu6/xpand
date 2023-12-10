import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule } from '@angular/material/toolbar';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatMenuModule } from '@angular/material/menu';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { AppToolbarComponent } from './components/app-toolbar/app-toolbar.component';
import { MatIconModule } from '@angular/material/icon';


@NgModule({
  declarations: [
    AppToolbarComponent,
    PageNotFoundComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    BrowserAnimationsModule,
    FlexLayoutModule,
    MatButtonModule,
    MatToolbarModule,
    MatMenuModule,
    MatIconModule
  ],
  exports: [
    AppToolbarComponent,
    PageNotFoundComponent
  ],
  providers: [],
  bootstrap: []
})
export class SharedModule { }

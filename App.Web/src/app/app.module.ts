import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavmenuComponent } from './components/navmenu/navmenu.component';
import { ContentComponent } from './components/content/content.component';
import { LookupComponent } from './components/lookup/lookup.component';
import { HomeComponent } from './components/home/home.component';
import { ContentListComponent } from './components/content-list/content-list.component';

@NgModule({
  declarations: [
    AppComponent,
    NavmenuComponent,
    ContentComponent,
    LookupComponent,
    HomeComponent,
    ContentListComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot([
        { path: '', redirectTo: 'home', pathMatch: 'full' },
        { path: 'home', component: HomeComponent },
        { path: 'content', component: ContentListComponent },
        { path: 'content/:id', component: ContentComponent },
        { path: 'lookup/:id', component: LookupComponent },
        { path: '**', redirectTo: 'home' }
    ])
  ],
  providers: [
    { provide: 'BASE_URL', useFactory: getBaseUrl }
  ],
  bootstrap: [
    AppComponent,
    NavmenuComponent
  ]
})
export class AppModule { }

export function getBaseUrl() {
  return document.getElementsByTagName('base')[0].href;
}

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavmenuComponent } from './components/navmenu/navmenu.component';
import { ContentComponent } from './components/admin/content/content.component';
import { LookupComponent } from './components/admin/lookup/lookup.component';
import { HomeComponent } from './components/home/home.component';
import { ContentListComponent } from './components/content-list/content-list.component';
import { ContentService } from './services/content.service';
import { LookupService } from './services/lookup.service';
import { AdminComponent } from './components/admin/admin.component';
import { SideMenuComponent } from './components/admin/sidemenu/sidemenu.component';
import { LookupListComponent } from './components/admin/lookup-list/lookup-list.component';

@NgModule({
  declarations: [
    AppComponent,
    NavmenuComponent,
    ContentComponent,
    LookupComponent,
    HomeComponent,
    ContentListComponent,
    AdminComponent,
    SideMenuComponent,
    LookupListComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot([
        { path: '', redirectTo: 'home', pathMatch: 'full' },
        { path: 'home', component: HomeComponent },
        { path: 'admin', component: AdminComponent,
          children: [
            {
              path: '',
              redirectTo: 'lookup/new',
              pathMatch: 'full'
            },
            {
              path: '',
              outlet: 'sidemenu',
              component: SideMenuComponent
            },
            {
              path: 'content/new',
              component: ContentComponent
            },
            {
              path: 'lookup',
              children: [
                {
                  path: '',
                  component: LookupListComponent
                },
                {
                  path: ':id',
                  component: LookupComponent
                },
                {
                  path: 'new',
                  component: LookupComponent
                }
              ]
            }
          ]
        },
        { path: 'content', component: ContentListComponent,
          children: [
            { path: ':id', component: ContentComponent }
          ]
        },
        { path: 'lookup/:id', component: LookupComponent },
        { path: '**', redirectTo: 'home' }
    ])
  ],
  providers: [
    { provide: 'BASE_URL', useFactory: getBaseUrl },
    ContentService,
    LookupService
  ],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }

export function getBaseUrl() {
  return document.getElementsByTagName('base')[0].href;
}

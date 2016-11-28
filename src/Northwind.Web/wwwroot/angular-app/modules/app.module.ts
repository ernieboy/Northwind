import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent }  from '../components/app.component';
import { WelcomeComponent } from '../components/welcome/welcome.component';

/* Feature Modules */
import { CustomerModule } from './customer.module';

@NgModule({
    imports: [
        BrowserModule,
        HttpModule,
        RouterModule.forRoot([
            { path: 'welcome', component: WelcomeComponent },
            { path: '', redirectTo: 'welcome', pathMatch: 'full' },
            { path: '**', redirectTo: 'welcome', pathMatch: 'full' }
        ]),
        CustomerModule
    ],
    declarations: [
        AppComponent,
        WelcomeComponent
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }

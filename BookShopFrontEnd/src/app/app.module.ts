import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatSidenavModule } from '@angular/material/sidenav';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatMenuModule } from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatTreeModule } from '@angular/material/tree';
import { MatListModule } from '@angular/material/list';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTableModule } from '@angular/material/table';
import { MatBadgeModule } from '@angular/material/badge';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HeaderComponent } from './shared/header/header.component';
import { HomeComponent } from './pages/home/home.component';
import { ProductsHeaderComponent } from './pages/home/components/products-header/products-header.component';
import { FiltersComponent } from './pages/home/components/filters/filters.component';
import { CartComponent } from './pages/cart/cart.component';
import { PublicationBoxComponent } from './pages/home/components/publication-box/publication-box.component';
import { GameBoxComponent } from './pages/home/components/game-box/game-box.component';
import { FormsModule } from '@angular/forms';
import { AdminModule } from './admin/admin.module';
import { HttpErrorInterceptor } from './error-handling/HttpErrorInterceptor';
import { UtensilBoxComponent } from './pages/home/components/utensil-box/utensil-box.component';
import { OrderCompletedComponent } from './pages/home/components/order-completed/order-completed.component';
import { MsalGuard, MsalInterceptor, MsalModule } from '@azure/msal-angular';
import { InteractionType, PublicClientApplication } from '@azure/msal-browser';

const isIE = window.navigator.userAgent.indexOf('MSIE ') > -1 || window.navigator.userAgent.indexOf('Trident/') > -1;

@NgModule({
    declarations: [
        AppComponent,
        HeaderComponent,
        HomeComponent,
        ProductsHeaderComponent,
        FiltersComponent,
        CartComponent,
        PublicationBoxComponent,
        GameBoxComponent,
        UtensilBoxComponent,
        OrderCompletedComponent
    ],   
    bootstrap: [AppComponent],
    imports: [
        BrowserModule,
        AppRoutingModule,
        BrowserAnimationsModule,
        MatSidenavModule,
        MatGridListModule,
        MatMenuModule,
        MatButtonModule,
        MatCardModule,
        MatIconModule,
        MatExpansionModule,
        MatTreeModule,
        MatListModule,
        MatToolbarModule,
        MatTableModule,
        MatBadgeModule,
        MatSnackBarModule,
        HttpClientModule,
        FormsModule,
        AdminModule,
        MsalModule.forRoot(new PublicClientApplication(
          {
            auth: {
              clientId: '1b7cd469-6fbe-4ebb-8ecb-160079a2d9f4',
              redirectUri: 'http://localhost:4200',
              authority: 'https://login.microsoftonline.com/4a06d40c-e447-42be-baef-dd0421ed10bd'
            },
            cache: {
              cacheLocation: 'localStorage',
              storeAuthStateInCookie: isIE,
            }
          }
        ),
          {
            interactionType: InteractionType.Redirect,
            authRequest: {
              scopes: ['user.read']
            }
          },
          {
            interactionType: InteractionType.Redirect,
            protectedResourceMap: new Map(
              [
                ['https://graph.microsoft.com/v1.0/me', ['user.read']],
                ['localhost',['api://3f614ec4-af01-40fb-a9b3-d6878cef83d0/api.scope']]
              ]
            )
          }
        )
    ],
    providers: [
      {
          provide: HTTP_INTERCEPTORS,
          useClass: HttpErrorInterceptor,
          multi: true
      },
      {
        provide: HTTP_INTERCEPTORS,
        useClass: MsalInterceptor,
        multi: true
      }, MsalGuard],
})
export class AppModule { }

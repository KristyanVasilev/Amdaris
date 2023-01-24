import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MsalGuard } from '@azure/msal-angular';
import { AddGameQuantityComponent } from './admin/addQuantity/add-game-quantity/add-game-quantity.component';
import { CreateGameComponent } from './admin/create/create-game/create-game.component';
import { CreatePublicationComponent } from './admin/create/create-publication/create-publication.component';
import { CreateUtensilComponent } from './admin/create/create-utensil/create-utensil.component';
import { DeleteGameComponent } from './admin/delete/delete-game/delete-game.component';
import { DeletePublicationComponent } from './admin/delete/delete-publication/delete-publication.component';
import { DeleteUtensilComponent } from './admin/delete/delete-utensil/delete-utensil.component';
import { UndeleteGameComponent } from './admin/unDelete/undelete-game/undelete-game.component';
import { UndeletePublicationComponent } from './admin/unDelete/undelete-publication/undelete-publication.component';
import { UndeleteUtensilComponent } from './admin/unDelete/undelete-utensil/undelete-utensil.component';
import { UpdateGameComponent } from './admin/update/update-game/update-game.component';
import { UpdatePublicationComponent } from './admin/update/update-publication/update-publication.component';
import { UpdateUtensilComponent } from './admin/update/update-utensil/update-utensil.component';
import { CartComponent } from './pages/cart/cart.component';
import { OrderCompletedComponent } from './pages/home/components/order-completed/order-completed.component';
import { HomeComponent } from './pages/home/home.component';

const routes: Routes = [{
  path: 'home',
  component: HomeComponent, canActivate: [MsalGuard]
},
{
  path: 'cart',
  component: CartComponent, canActivate: [MsalGuard]
},
{
  path: 'create/game',
  component: CreateGameComponent, canActivate: [MsalGuard]
},
{
  path: 'create/publication',
  component: CreatePublicationComponent, canActivate: [MsalGuard]
},
{
  path: 'create/utensil',
  component: CreateUtensilComponent, canActivate: [MsalGuard]
},
{
  path: 'add/game',
  component: AddGameQuantityComponent, canActivate: [MsalGuard]
},
{
  path: 'delete/game',
  component: DeleteGameComponent, canActivate: [MsalGuard]
},
{
  path: 'delete/publication',
  component: DeletePublicationComponent, canActivate: [MsalGuard]
},
{
  path: 'delete/utensil',
  component: DeleteUtensilComponent, canActivate: [MsalGuard]
},
{
  path: 'undelete/game',
  component: UndeleteGameComponent, canActivate: [MsalGuard]
},
{
  path: 'undelete/publication',
  component: UndeletePublicationComponent, canActivate: [MsalGuard]
},
{
  path: 'undelete/utensil',
  component: UndeleteUtensilComponent, canActivate: [MsalGuard]
},
{
  path: 'update/game',
  component: UpdateGameComponent, canActivate: [MsalGuard]
},
{
  path: 'update/publication',
  component: UpdatePublicationComponent, canActivate: [MsalGuard]
},
{
  path: 'update/utensil',
  component: UpdateUtensilComponent, canActivate: [MsalGuard]
},
{
  path: 'order-completed',
  component: OrderCompletedComponent, canActivate: [MsalGuard]
},
{
  path: '', redirectTo: 'home', pathMatch: 'full'
}];

@NgModule({
  imports: [RouterModule.forRoot(routes, {
   initialNavigation: 'enabledNonBlocking'
  })],
  exports: [RouterModule]
})
export class AppRoutingModule { }

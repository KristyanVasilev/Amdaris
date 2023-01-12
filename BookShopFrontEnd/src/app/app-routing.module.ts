import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateGameComponent } from './admin/create/create-game/create-game.component';
import { CreatePublicationComponent } from './admin/create/create-publication/create-publication.component';
import { DeleteGameComponent } from './admin/delete/delete-game/delete-game.component';
import { DeletePublicationComponent } from './admin/delete/delete-publication/delete-publication.component';
import { UndeleteGameComponent } from './admin/unDelete/undelete-game/undelete-game.component';
import { UndeletePublicationComponent } from './admin/unDelete/undelete-publication/undelete-publication.component';
import { CartComponent } from './pages/cart/cart.component';
import { HomeComponent } from './pages/home/home.component';

const routes: Routes = [{
  path: 'home',
  component: HomeComponent,
},
{
  path: 'cart',
  component: CartComponent,
},
{
  path: 'create/game',
  component: CreateGameComponent,
},
{
  path: 'create/publication',
  component: CreatePublicationComponent,
},
{
  path: 'delete/game',
  component: DeleteGameComponent,
},
{
  path: 'delete/publication',
  component: DeletePublicationComponent,
},
{
  path: 'undelete/game',
  component: UndeleteGameComponent,
},
{
  path: 'undelete/publication',
  component: UndeletePublicationComponent,
},
{
  path: '', redirectTo: 'home', pathMatch: 'full'
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateComponent } from './admin/create/create.component';
import { DeleteComponent } from './admin/delete/delete.component';
import { UpdateComponent } from './admin/update/update.component';
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
  path: 'create',
  component: CreateComponent,
},
{
  path: 'update',
  component: UpdateComponent,
},
{
  path: 'delete',
  component: DeleteComponent,
},
{
  path: '', redirectTo: 'home', pathMatch: 'full'
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

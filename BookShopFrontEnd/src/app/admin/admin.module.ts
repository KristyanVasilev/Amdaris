import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateGameComponent } from './create/create-game/create-game.component';
import { CreatePublicationComponent } from './create/create-publication/create-publication.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DeleteGameComponent } from './delete/delete-game/delete-game.component';
import { DeletePublicationComponent } from './delete/delete-publication/delete-publication.component';
import { MatCardModule } from '@angular/material/card';
import { UndeletePublicationComponent } from './unDelete/undelete-publication/undelete-publication.component';
import { UndeleteGameComponent } from './unDelete/undelete-game/undelete-game.component';
import { UpdateGameComponent } from './update/update-game/update-game.component';
import { UpdatePublicationComponent } from './update/update-publication/update-publication.component';
import { UpdateUtensilComponent } from './update/update-utensil/update-utensil.component';
import { CreateUtensilComponent } from './create/create-utensil/create-utensil.component';
import { DeleteUtensilComponent } from './delete/delete-utensil/delete-utensil.component';
import { UndeleteUtensilComponent } from './unDelete/undelete-utensil/undelete-utensil.component';
import { AddGameQuantityComponent } from './addQuantity/add-game-quantity/add-game-quantity.component';
import { AddPublicationQuantityComponent } from './addQuantity/add-publication-quantity/add-publication-quantity.component';
import { AddUtensilQuantityComponent } from './addQuantity/add-utensil-quantity/add-utensil-quantity.component';

@NgModule({
  declarations: [
    CreateGameComponent,
    CreatePublicationComponent,
    DeleteGameComponent,
    DeletePublicationComponent,
    UndeletePublicationComponent,
    UndeleteGameComponent,
    UpdateGameComponent,
    UpdatePublicationComponent,
    UpdateUtensilComponent,
    CreateUtensilComponent,
    DeleteUtensilComponent,
    UndeleteUtensilComponent,
    AddGameQuantityComponent,
    AddPublicationQuantityComponent,
    AddUtensilQuantityComponent,
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MatCardModule
  ],
  exports: [
    CreateGameComponent,
    CreatePublicationComponent,
    DeleteGameComponent,
    DeletePublicationComponent
  ]
})
export class AdminModule { }

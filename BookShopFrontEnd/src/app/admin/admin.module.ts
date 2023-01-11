import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateGameComponent } from './create/create-game/create-game.component';
import { CreatePublicationComponent } from './create/create-publication/create-publication.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    CreateGameComponent,
    CreatePublicationComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
  ],
  exports: [
    CreateGameComponent,
    CreatePublicationComponent
  ]
})
export class AdminModule { }

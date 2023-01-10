import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateComponent } from './create/create.component';
import { DeleteComponent } from './delete/delete.component';
import { UpdateComponent } from './update/update.component';



@NgModule({
  declarations: [
    CreateComponent,
    DeleteComponent,
    UpdateComponent
  ],
  imports: [
    CommonModule
  ]
})
export class AdminModule { }

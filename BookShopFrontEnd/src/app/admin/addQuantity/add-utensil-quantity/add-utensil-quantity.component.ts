import { Component, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Utensil } from 'src/app/models/utensil';
import { UtensilService } from 'src/app/services/utensil.service';

@Component({
  selector: 'app-add-utensil-quantity',
  templateUrl: './add-utensil-quantity.component.html',
  styleUrls: ['./add-utensil-quantity.component.css']
})
export class AddUtensilQuantityComponent {
  @ViewChild('utensilFindForm') utensilFindForm: any;
  submitted: boolean = false;
  utensilSubsription: Subscription | undefined;
  utensil: Utensil = { id: 0, name: '', price: 0, color: '', writingUtensilsType: '', manufacturer: '', images: [], quantity: 0, keyWords: '' };
  utensilId = {
    id: 0,
    quantity: 0
  };
  utensilName = {
    name: '',
  };

  constructor(
    private utensilService: UtensilService,
    private router: Router) {

  }

  addUtensilQuantity() {
    this.utensilSubsription = this.utensilService
    .addUtensilQuantity(this.utensilId.id, this.utensilId.quantity)
    .subscribe(res => {
      console.log(res);
      window.alert(res)
    })
  }
  
  findUtensil() {
    this.utensilSubsription = this.utensilService
      .findUtensil(this.utensilName.name)
      .subscribe((_utensil) => {
        this.utensil = _utensil;
        console.log(this.utensil)
      });
    this.resetForm();
  }

  resetForm() {
    this.utensilName = { name: "" };
    this.utensil = { id: 0, name: '', price: 0, color: '', writingUtensilsType: '', manufacturer: '', images: [], quantity: 0, keyWords: '' };
    this.utensilFindForm.resetForm();
    this.submitted = false;
  }

  ngOnDestroy(): void {
    if (this.utensilSubsription) {
      this.utensilSubsription.unsubscribe();
    }
  }
}

import { Component, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Utensil } from 'src/app/models/utensil';
import { UtensilService } from 'src/app/services/utensil.service';

@Component({
  selector: 'app-delete-utensil',
  templateUrl: './delete-utensil.component.html',
  styleUrls: ['./delete-utensil.component.css']
})
export class DeleteUtensilComponent {
  @ViewChild('utensilFindForm') utensilFindForm: any;
  submitted: boolean = false;
  utensilSubsription: Subscription | undefined;
  utensil: Utensil = { id: 0, name: '', price: 0, color: '', writingUtensilsType: '', manufacturer: '', images: [] };
  utensilId = {
    id: 0,
  };
  utensilName = {
    name: '',
  };

  constructor(
    private utensilService: UtensilService,
    private router: Router) {

  }
  deleteGame() {
    this.utensilSubsription = this.utensilService
      .deleteUtensil(this.utensilId.id)
      .subscribe((res) => {
        console.log(res)
      });
    this.router.navigate(['home']);
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
    this.utensil = { id: 0, name: '', price: 0, color: '', writingUtensilsType: '', manufacturer: '', images: [] };
    this.utensilFindForm.resetForm();
    this.submitted = false;
  }

  ngOnDestroy(): void {
    if (this.utensilSubsription) {
      this.utensilSubsription.unsubscribe();
    }
  }
}

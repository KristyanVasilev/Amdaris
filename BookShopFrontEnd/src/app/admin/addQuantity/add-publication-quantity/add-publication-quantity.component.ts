import { Component, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Publication } from 'src/app/models/publication';
import { PublicationService } from 'src/app/services/publication.service';

@Component({
  selector: 'app-add-publication-quantity',
  templateUrl: './add-publication-quantity.component.html',
  styleUrls: ['./add-publication-quantity.component.css']
})
export class AddPublicationQuantityComponent {
  @ViewChild('publicationFindForm') publicationFindForm: any;
  submitted: boolean = false;
  publicationSubsription: Subscription | undefined;
  publication: Publication = { id: 0, name: '', author: '', price: 0, pageCount: 0, description: '', genre: '', images: [], keyWords: '', quantity: 0 };
  publicationId = {
    id: 0,
    quantity: 0
  };
  publicationName = {
    name: '',
  };

  constructor(
    private publicationService: PublicationService,
    private router: Router) {

  }

  addPublicationQuantity() {
    this.publicationSubsription = this.publicationService
    .addPublicationQuantity(this.publicationId.id, this.publicationId.quantity)
    .subscribe(res => {
      console.log(res);
      window.alert(res)
    })
  }

  FindPublication() {
    this.publicationSubsription = this.publicationService
      .findPublication(this.publicationName.name)
      .subscribe((_publication) => {
        this.publication = _publication;
        console.log(_publication)
      });
    this.resetForm();
  }

  resetForm() {
    this.publicationName = { name: "" };
    this.publication = { id: 0, name: '', author: '', price: 0, pageCount: 0, description: '', genre: '', images: [] as string[], keyWords: '', quantity: 0 };
    this.publicationFindForm.resetForm();
    this.submitted = false;
  }

  ngOnDestroy(): void {
    if (this.publicationSubsription) {
      this.publicationSubsription.unsubscribe();
    }
  }
}

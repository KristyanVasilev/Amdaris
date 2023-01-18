import { HttpClient } from '@angular/common/http';
import { Component, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import { Publication } from 'src/app/models/publication';
import { PublicationService } from 'src/app/services/publication.service';

@Component({
  selector: 'app-update-publication',
  templateUrl: './update-publication.component.html',
  styleUrls: ['./update-publication.component.css']
})
export class UpdatePublicationComponent {
  @ViewChild('publicationFindForm') publicationFindForm: any;
  shortLink: string = "";
  loading: boolean = false; // Flag variable
  submitted: boolean = false;
  isUploaded = false;
  publicationSubsription: Subscription | undefined;
  publication: Publication = {id: 0,  name: '', author: '', price: 0, pageCount: 0, description: '', genre: '', images: [] as string[], keyWords: '', quantity: 0 };
  publicationToUpdate: Publication = {id: 0,  name: '', author: '', price: 0, pageCount: 0, description: '', genre: '', images: [] as string[], keyWords: '', quantity: 0 };
  publicationId = {
    id: 0,
  };
  publicationName = {
    name: '',
  };

  constructor(
    private publicationService: PublicationService,
    private router: Router,
    private http: HttpClient,) {
  }

  findPublication() {
    this.publicationSubsription = this.publicationService
      .findPublication(this.publicationName.name)
      .subscribe((_game) => {
        this.publication = _game;
        console.log(_game)
      });
    this.resetForm();
  }

  resetForm() {
    this.publicationName = { name: "" };
    this.publication = {id: 0,  name: '', author: '', price: 0, pageCount: 0, description: '', genre: '', images: [] as string[], keyWords: '', quantity: 0 };
    this.publicationFindForm.resetForm();
    this.submitted = false;
  }

  ngOnDestroy(): void {
    if (this.publicationSubsription) {
      this.publicationSubsription.unsubscribe();
    }
  }

  file?: File; // Variable to store file
  upload(file: any): Observable<any> {
    const formData = new FormData();
    formData.append("file", file, file.name);
    this.isUploaded = true;
    return this.http.post('https://localhost:7201/api/Files/Images', formData)
  }

  onChange(event: any) {
    this.file = event.target.files[0];
  }

  onUpload() {

    this.loading = !this.loading;
    console.log(this.file);

    this.upload(this.file).subscribe(
      (event: any) => {
        console.log(event);
        console.log(JSON.stringify(event).substring(10, JSON.stringify(event).length - 3));
        this.publicationToUpdate.images.push(JSON.stringify(event).substring(10, JSON.stringify(event).length - 3));
        if (typeof (event) === 'object') {
          this.shortLink = event.link;
          this.loading = false; // Flag variable
        }
      }
    );
  }

  updatePublication() {
    this.publicationService.UpdatePublication(this.publicationToUpdate, this.publication.id).subscribe(res => console.log(res));
    this.router.navigate(['/home']);
  }
}

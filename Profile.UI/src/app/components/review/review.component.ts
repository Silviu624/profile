import { Component } from '@angular/core';
import { Review } from '../../models/review';

@Component({
  selector: 'app-review',
  standalone: false,
  templateUrl: './review.component.html',
  styleUrl: './review.component.css'
})
export class ReviewComponent {
  formData: Review = {
    name: '',
    review: '',
    date: ''
  };

  reviews: Review[] = [];

  onSubmit(form: any) {
    this.formData.date = new Date().toLocaleDateString();
    this.reviews.push({ ...this.formData });
  }
}

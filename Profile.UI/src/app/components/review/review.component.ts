import { Component, OnInit } from '@angular/core';
import { Review } from '../../models/review';
import { AuthService } from '../../services/auth.service';
import { ReviewService } from '../../services/review.service';

@Component({
  selector: 'app-review',
  standalone: false,
  templateUrl: './review.component.html',
  styleUrl: './review.component.css'
})
export class ReviewComponent implements OnInit {
  formData: Review = {
    id: '',
    name: '',
    reviewComment: '',
    date: new Date()
  };

  reviews: Review[] = [];

  constructor(private authService: AuthService, private reviewService: ReviewService) { }

  ngOnInit() {
    this.reviewService.getReviews().subscribe({
      next: (data) => this.reviews = data,
      error: (err) => console.error("Error fetching reviews", err)
    });
  }

  public isLoggedInFunction(): boolean {
    return this.authService.isLoggedIn();
  }

  onSubmit(form: any) {
    if (form.invalid) return;
    this.formData.date = new Date(Date.now());

    this.reviewService.addReview(this.formData).subscribe({
      next: (newReview) => {
        console.log("Review added successfully", newReview);
        this.reviews.push({ ...this.formData });
        form.resetForm();
      },
      error: (err) => console.error("Error adding review", err)
    });
  }

  deleteReview(id: string) {
    this.reviewService.deleteReview(id).subscribe({
      next: () => {
        console.log("Review deleted successfully");
        this.reviews = this.reviews.filter(r => r.id !== id);
      },
      error: (err) => console.error("Error deleting review", err)
    });
  }
}

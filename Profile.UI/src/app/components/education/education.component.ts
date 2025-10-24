import { Component, OnInit } from '@angular/core';
import { Education } from '../../models/education';
import { AuthService } from '../../services/auth.service';
import { EducationService } from '../../services/education.service';

@Component({
  selector: 'app-education',
  standalone: false,
  templateUrl: './education.component.html',
  styleUrl: './education.component.css'
})
export class EducationComponent implements OnInit {
  public educations: Education[] = [];
  public editMode: boolean = false;
  public editingIndex: number | null = null;
  public editBuffer: Education = null as any;

  constructor(private _authService: AuthService, private _educationService: EducationService) { }

  ngOnInit(): void {
    this._educationService.getEducations().subscribe({
      next: educations => this.educations = educations,
      error: err => console.error('Error fetching educations', err)
    });
  }

  public isLoggedInFunction(): boolean {
    return this._authService.isLoggedIn();
  }

  public addNewEducation() {
    this.educations.push(new Education("", "", "", "", "", ""));
    this.editingIndex = this.educations.length - 1;
    this.editBuffer = { ...this.educations[this.editingIndex] };
  }

  public isEditing(i: number): boolean {
    return this.editingIndex === i;
  }

  public toggleEdit(i: number, education: Education) {
    if (this.isEditing(i)) {
      const newEdu = { ...education, ...this.editBuffer };

      if (this.editBuffer.id === "") {
        this.createEducation(newEdu);
      } else {
        this.saveEducation(newEdu);
      }

      this.educations[i] = newEdu;
      this.editingIndex = null;
      this.editBuffer = null as any;
    } else {
      this.editingIndex = i;
      this.editBuffer = { ...education };
    }
  }

  public createEducation(education: Education) {
    this._educationService.addEducation(education).subscribe({
      next: createdEdu => {
        console.log('Education created successfully', createdEdu);
      },
      error: err => console.error('Error creating education', err)
    });
  }

  public saveEducation(education: Education) {
    this._educationService.updateEducation(education.id, education).subscribe({
      next: updatedEdu => console.log('Education updated successfully', updatedEdu),
      error: err => console.error('Error updating education', err)
    });
  }

  public cancelEdit() {
    this.editingIndex = null;
    this.editBuffer = null as any;
  }

  public delete(i: number, education: Education) {
    if (education.id === "") {
      this.educations.splice(i, 1);
      return;
    }

    this._educationService.deleteEducation(education.id).subscribe({
      next: () => {
        this.educations = this.educations.filter(e => e.id !== education.id);
      },
      error: err => console.error('Error deleting education', err)
    });
  }
}
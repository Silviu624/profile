import { Component, OnInit } from '@angular/core';
import { Experience } from '../../models/experience';
import { AuthService } from '../../services/auth.service';
import { ExperienceService } from '../../services/experience.service';

@Component({
  selector: 'app-experience',
  standalone: false,
  templateUrl: './experience.component.html',
  styleUrl: './experience.component.css'
})
export class ExperienceComponent implements OnInit {
  public experiences: Experience[] = [];
  public editMode: boolean = false;
  public editingIndex: number | null = null;
  public editBuffer: Experience = null as any;

  constructor(private _authService: AuthService, private _experienceService: ExperienceService) { }

  ngOnInit(): void {
    this._experienceService.getExperiences().subscribe({
      next: experiences => this.experiences = experiences,
      error: err => console.error('Error fetching experiences', err)
    })
  }

  public isLoggedInFunction(): boolean {
    return this._authService.isLoggedIn();
  }

  public addNewExperience() {
    this.experiences.push(new Experience("", "", "", "", "", "", ""));
    this.editingIndex = this.experiences.length - 1;
    this.editBuffer = { ...this.experiences[this.editingIndex] };
  }

  public isEditing(i: number): boolean {
    return this.editingIndex === i;
  }

  public toggleEdit(i: number, experience: Experience) {
    if (this.isEditing(i)) {
      const newExp = { ...experience, ...this.editBuffer };

      if (this.editBuffer.id === "") {
        this.createExperience(newExp);
      } else {
        this.saveExperience(newExp);
      }

      this.experiences[i] = newExp;
      this.editingIndex = null;
      this.editBuffer = null as any;
    } else {
      this.editingIndex = i;
      this.editBuffer = { ...experience };
    }
  }

  public createExperience(experience: Experience) {
    this._experienceService.addExperience(experience).subscribe({
      next: createdExp => {
        console.log('Experience created successfully', createdExp);
      },
      error: err => console.error('Error creating experience', err)
    });
  }

  public saveExperience(experience: Experience) {
    this._experienceService.updateExperience(experience.id, experience).subscribe({
      next: updatedExp => console.log('Experience updated successfully', updatedExp),
      error: err => console.error('Error updating experience', err)
    });
  }

  public cancelEdit() {
    this.editingIndex = null;
    this.editBuffer = null as any;
  }

  public delete(i: number, experience: Experience) {
    if (experience.id === "") {
      this.experiences.splice(i, 1);
      return;
    }
    this._experienceService.deleteExperience(experience.id).subscribe({
      next: () => {
        this.experiences = this.experiences.filter(e => e.id !== experience.id);
      },
      error: err => console.error('Error deleting experience', err)
    });
  }
}

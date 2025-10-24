export class Experience {
    id: string = "";
    companyName: string = "";
    role: string = "";
    startDate: string = "";
    endDate: string = "";
    description: string = "";
    technologies: string = "";

    constructor(id: string, companyName: string, role: string, startDate: string, endDate: string, description: string, technologies: string) {
        this.id = id;
        this.companyName = companyName;
        this.role = role;
        this.startDate = startDate;
        this.endDate = endDate;
        this.description = description;
        this.technologies = technologies;
    }
}
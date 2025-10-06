export class Experience {
    companyName: string = "";
    role: string = "";
    startDate: string = "";
    endDate: string = "";
    description: string = "";
    technologies: string[] = [];

    constructor(companyName: string, role: string, startDate: string, endDate: string, description: string, technologies: string[]) {
        this.companyName = companyName;
        this.role = role;
        this.startDate = startDate;
        this.endDate = endDate;
        this.description = description;
        this.technologies = technologies;
    }
}
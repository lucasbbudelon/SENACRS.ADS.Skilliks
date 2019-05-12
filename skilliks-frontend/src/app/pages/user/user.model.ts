export interface User {
    isEnable: boolean;
    name: string;
    email: string;
    type: UserType;
    category: UserCategory;
    skills: any[];
}

export enum UserType {
    employee = 1,
    applicant = 2
}

export enum UserCategory {
    technical = 1,
    humanResources = 2
}

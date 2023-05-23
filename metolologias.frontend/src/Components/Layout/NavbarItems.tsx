export class NavbarItem {
    public readonly label: string;
    public readonly path: string;
    public readonly requiredRoles?: string[];

    constructor(label: string, path: string, requiredRoles?: string[]) {
        this.label = label;
        this.path = path;
        this.requiredRoles = requiredRoles;
    }
}

export const NavbarItems: NavbarItem[] = [
    new NavbarItem("Sinais", "/"),
];

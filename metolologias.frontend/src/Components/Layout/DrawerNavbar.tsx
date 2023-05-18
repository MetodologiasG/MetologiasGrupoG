import { NavLink, useLocation, useNavigate } from 'react-router-dom';

import { NavbarItems } from './NavbarItems';

export type DrawerNavbarProps = {
    close: () => void;
}

export default function DrawerNavbar(props: DrawerNavbarProps) {

    const history = useNavigate();
    const location = useLocation();

    const amISelected = (path: string): boolean => {
        const samePath: boolean = (location.pathname.toLowerCase() === path.toLowerCase());
        return samePath;
    }


    return (
        <div className='drawer' onClick={props.close}>
            <div className='drawerContent' onClick={(e) => { e.stopPropagation(); }}>
                <div className='drawerOptions'>
                    <div className="drawerClose" onClick={props.close}>x</div>
                </div>

                {NavbarItems.map(r => {
                    return (
                        <div key={r.path} className='drawerItem'>
                            <NavLink to={r.path} className={amISelected(r.path) ? 'selected' : ''}>
                                {r.label}
                            </NavLink>
                        </div>
                    );
                })}
            </div>
        </div>
    )
}


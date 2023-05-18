import { useState } from 'react';
import { GiHamburgerMenu } from "react-icons/gi";
import { Link, Navigate, useLocation, useNavigate } from 'react-router-dom';
import { Col, Row } from 'reactstrap';
import "../../Styles/header.css";
import DrawerNavbar from './DrawerNavbar';
import { NavbarItem, NavbarItems } from './NavbarItems';

export default function Layout(props: any) {

    const navigate = useNavigate();
    const location = useLocation();

    const NavLink = (navbarItem: NavbarItem) => {

        const samePath: boolean = (location.pathname.toLowerCase() === navbarItem.path.toLowerCase());
        return <Link key={navbarItem.path} to={navbarItem.path} className={`item ${samePath === true ? "selected" : ""}`}>{navbarItem.label}</Link>;
    }

    const currentSelectedNavItem = () => {
        const pathName = location.pathname.toLowerCase();
        var item = NavbarItems.find(r => r.path.toLowerCase() === pathName);
        if (item != null) return item.label;
        return "";
    }

    const [seeMenu, setSeeMenu] = useState(false);

    return (
        <div className="parent">
            <Row className="header">
                <Col className="mobileItems" xs={6} sm={6}>
                    <div style={{ display: "flex", flexDirection: "row", gap: "1rem" }}>
                        <span className="hamburguerIcon"><GiHamburgerMenu style={{ fontSize: "1.3rem", transform: seeMenu ? "rotate(-90deg)" : "none" }} onClick={() => setSeeMenu(!seeMenu)} /></span>
                        <span className='selectedNavItem'>{currentSelectedNavItem()}</span>
                        {seeMenu && (
                            <DrawerNavbar close={() => setSeeMenu(false)} />
                        )}
                    </div>
                </Col>

                <Col className='items' xl={8} lg={10} md={9} sm={9} xs={6}>
                    {NavbarItems.map(ni => {
                        return NavLink(ni);
                    })}
                </Col>

            </Row>
            <div className="body">
                {props.children}
            </div>
        </div>
    )
}

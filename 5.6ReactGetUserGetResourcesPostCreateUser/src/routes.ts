// pages
import GetUser from "./pages/GetUser";
import Resources from "./pages/Resources";
import Products from "./pages/Post-Create";

// other
import {FC} from "react";

// interface
interface Route {
    key: string,
    title: string,
    path: string,
    enabled: boolean,
    component: FC<{}>
}

export const routes: Array<Route> = [
    {
        key: 'home-route',
        title: 'GetUser',
        path: '/',
        enabled: true,
        component: GetUser
    },
    {
        key: 'about-route',
        title: 'Resources',
        path: '/resources',
        enabled: true,
        component: Resources
    },
    {
        key: 'products-route',
        title: 'PostCreate',
        path: '/postCreate',
        enabled: true,
        component: Products
    }
]
import Layout, { Content, Footer, Header } from "antd/es/layout/layout";
import "./globals.css";
import { Menu } from "antd";
import Link from "next/link";

const items = [
  { key: "home", label: <Link href={"/"}>home</Link> },
  { key: "items", label: <Link href={"/items"}>items</Link> },
];

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <body>
        <Layout style={{ minHeight: "100vh" }}>
          <Header>
            <Menu
              theme="dark"
              mode="horizontal"
              items={items}
              style={{ flex: 1, minWidth: 0 }}
            ></Menu>
          </Header>
          <Content style={{ padding: "0,40px" }}>{children}</Content>
          <Footer style={{textAlign: "center"}} >
            itemshop 
          </Footer>
        </Layout>
      </body>
    </html>
  );
}

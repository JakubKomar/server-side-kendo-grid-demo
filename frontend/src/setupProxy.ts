import { createProxyMiddleware } from "http-proxy-middleware";

module.exports = function (app: any) {
    app.use(
        "/api",
        createProxyMiddleware({
            target: "https://127.0.0.1:7079",
            secure: false,
            changeOrigin: true,
        })
    );
};

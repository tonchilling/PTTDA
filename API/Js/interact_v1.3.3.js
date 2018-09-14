﻿/* interact.js v1.3.3 | https://raw.github.com/taye/interact.js/master/LICENSE */ ! function(t) {
    if ("object" == typeof exports && "undefined" != typeof module) module.exports = t();
    else if ("function" == typeof define && define.amd) define([], t);
    else {
        var e;
        e = "undefined" != typeof window ? window : "undefined" != typeof global ? global : "undefined" != typeof self ? self : this, e.interact = t()
    }
}(function() {
    return function t(e, n, r) {
        function i(s, a) {
            if (!n[s]) {
                if (!e[s]) {
                    var c = "function" == typeof require && require;
                    if (!a && c) return c(s, !0);
                    if (o) return o(s, !0);
                    var l = new Error("Cannot find module '" + s + "'");
                    throw l.code = "MODULE_NOT_FOUND", l
                }
                var p = n[s] = {
                    exports: {}
                };
                e[s][0].call(p.exports, function(t) {
                    var n = e[s][1][t];
                    return i(n || t)
                }, p, p.exports, t, e, n, r)
            }
            return n[s].exports
        }
        for (var o = "function" == typeof require && require, s = 0; s < r.length; s++) i(r[s]);
        return i
    }({
        1: [function(t, e, n) {
            "use strict";
            "undefined" == typeof window ? e.exports = function(e) {
                return t("./src/utils/window").init(e), t("./src/index")
            } : e.exports = t("./src/index")
        }, {
            "./src/index": 19,
            "./src/utils/window": 52
        }],
        2: [function(t, e, n) {
            "use strict";

            function r(t, e) {
                if (!(t instanceof e)) throw new TypeError("Cannot call a class as a function")
            }

            function i(t, e) {
                for (var n = 0; n < e.length; n++) {
                    var r;
                    r = e[n];
                    var i = r;
                    if (t.immediatePropagationStopped) break;
                    i(t)
                }
            }
            var o = t("./utils/extend.js"),
                s = function() {
                    function t(e) {
                        r(this, t), this.options = o({}, e || {})
                    }
                    return t.prototype.fire = function(t) {
                        var e = void 0,
                            n = "on" + t.type,
                            r = this.global;
                        (e = this[t.type]) && i(t, e), this[n] && this[n](t), !t.propagationStopped && r && (e = r[t.type]) && i(t, e)
                    }, t.prototype.on = function(t, e) {
                        this[t] ? this[t].push(e) : this[t] = [e]
                    }, t.prototype.off = function(t, e) {
                        var n = this[t],
                            r = n ? n.indexOf(e) : -1; - 1 !== r && n.splice(r, 1), (n && 0 === n.length || !e) && (this[t] = void 0)
                    }, t
                }();
            e.exports = s
        }, {
            "./utils/extend.js": 41
        }],
        3: [function(t, e, n) {
            "use strict";

            function r(t, e) {
                if (!(t instanceof e)) throw new TypeError("Cannot call a class as a function")
            }
            var i = t("./utils/extend"),
                o = t("./utils/getOriginXY"),
                s = t("./defaultOptions"),
                a = t("./utils/Signals").new(),
                c = function() {
                    function t(e, n, c, l, p, u) {
                        var d = arguments.length > 6 && void 0 !== arguments[6] && arguments[6];
                        r(this, t);
                        var f = e.target,
                            v = (f && f.options || s).deltaSource,
                            g = o(f, p, c),
                            h = "start" === l,
                            m = "end" === l,
                            y = h ? e.startCoords : e.curCoords,
                            x = e.prevEvent;
                        p = p || e.element;
                        var b = i({}, y.page),
                            w = i({}, y.client);
                        b.x -= g.x, b.y -= g.y, w.x -= g.x, w.y -= g.y, this.ctrlKey = n.ctrlKey, this.altKey = n.altKey, this.shiftKey = n.shiftKey, this.metaKey = n.metaKey, this.button = n.button, this.buttons = n.buttons, this.target = p, this.currentTarget = p, this.relatedTarget = u || null, this.preEnd = d, this.type = c + (l || ""), this.interaction = e, this.interactable = f, this.t0 = h ? e.downTimes[e.downTimes.length - 1] : x.t0;
                        var E = {
                            interaction: e,
                            event: n,
                            action: c,
                            phase: l,
                            element: p,
                            related: u,
                            page: b,
                            client: w,
                            coords: y,
                            starting: h,
                            ending: m,
                            deltaSource: v,
                            iEvent: this
                        };
                        a.fire("set-xy", E), m ? (this.pageX = x.pageX, this.pageY = x.pageY, this.clientX = x.clientX, this.clientY = x.clientY) : (this.pageX = b.x, this.pageY = b.y, this.clientX = w.x, this.clientY = w.y), this.x0 = e.startCoords.page.x - g.x, this.y0 = e.startCoords.page.y - g.y, this.clientX0 = e.startCoords.client.x - g.x, this.clientY0 = e.startCoords.client.y - g.y, a.fire("set-delta", E), this.timeStamp = y.timeStamp, this.dt = e.pointerDelta.timeStamp, this.duration = this.timeStamp - this.t0, this.speed = e.pointerDelta[v].speed, this.velocityX = e.pointerDelta[v].vx, this.velocityY = e.pointerDelta[v].vy, this.swipe = m || "inertiastart" === l ? this.getSwipe() : null, a.fire("new", E)
                    }
                    return t.prototype.getSwipe = function() {
                        var t = this.interaction;
                        if (t.prevEvent.speed < 600 || this.timeStamp - t.prevEvent.timeStamp > 150) return null;
                        var e = 180 * Math.atan2(t.prevEvent.velocityY, t.prevEvent.velocityX) / Math.PI;
                        e < 0 && (e += 360);
                        var n = 112.5 <= e && e < 247.5,
                            r = 202.5 <= e && e < 337.5,
                            i = !n && (292.5 <= e || e < 67.5);
                        return {
                            up: r,
                            down: !r && 22.5 <= e && e < 157.5,
                            left: n,
                            right: i,
                            angle: e,
                            speed: t.prevEvent.speed,
                            velocity: {
                                x: t.prevEvent.velocityX,
                                y: t.prevEvent.velocityY
                            }
                        }
                    }, t.prototype.preventDefault = function() {}, t.prototype.stopImmediatePropagation = function() {
                        this.immediatePropagationStopped = this.propagationStopped = !0
                    }, t.prototype.stopPropagation = function() {
                        this.propagationStopped = !0
                    }, t
                }();
            a.on("set-delta", function(t) {
                var e = t.iEvent,
                    n = t.interaction,
                    r = t.starting,
                    i = t.deltaSource,
                    o = r ? e : n.prevEvent;
                "client" === i ? (e.dx = e.clientX - o.clientX, e.dy = e.clientY - o.clientY) : (e.dx = e.pageX - o.pageX, e.dy = e.pageY - o.pageY)
            }), c.signals = a, e.exports = c
        }, {
            "./defaultOptions": 18,
            "./utils/Signals": 34,
            "./utils/extend": 41,
            "./utils/getOriginXY": 42
        }],
        4: [function(t, e, n) {
            "use strict";

            function r(t, e) {
                if (!(t instanceof e)) throw new TypeError("Cannot call a class as a function")
            }
            var i = t("./utils/clone"),
                o = t("./utils/is"),
                s = t("./utils/events"),
                a = t("./utils/extend"),
                c = t("./actions/base"),
                l = t("./scope"),
                p = t("./Eventable"),
                u = t("./defaultOptions"),
                d = t("./utils/Signals").new(),
                f = t("./utils/domUtils"),
                v = f.getElementRect,
                g = f.nodeContains,
                h = f.trySelector,
                m = f.matchesSelector,
                y = t("./utils/window"),
                x = y.getWindow,
                b = t("./utils/arr"),
                w = b.contains,
                E = t("./utils/browser"),
                T = E.wheelEvent;
            l.interactables = [];
            var S = function() {
                function t(e, n) {
                    r(this, t), n = n || {}, this.target = e, this.events = new p, this._context = n.context || l.document, this._win = x(h(e) ? this._context : e), this._doc = this._win.document, d.fire("new", {
                        target: e,
                        options: n,
                        interactable: this,
                        win: this._win
                    }), l.addDocument(this._doc, this._win), l.interactables.push(this), this.set(n)
                }
                return t.prototype.setOnEvents = function(t, e) {
                    var n = "on" + t;
                    return o.function(e.onstart) && (this.events[n + "start"] = e.onstart), o.function(e.onmove) && (this.events[n + "move"] = e.onmove), o.function(e.onend) && (this.events[n + "end"] = e.onend), o.function(e.oninertiastart) && (this.events[n + "inertiastart"] = e.oninertiastart), this
                }, t.prototype.setPerAction = function(t, e) {
                    for (var n in e) n in u[t] && (o.object(e[n]) ? (this.options[t][n] = i(this.options[t][n] || {}), a(this.options[t][n], e[n]), o.object(u.perAction[n]) && "enabled" in u.perAction[n] && (this.options[t][n].enabled = !1 !== e[n].enabled)) : o.bool(e[n]) && o.object(u.perAction[n]) ? this.options[t][n].enabled = e[n] : void 0 !== e[n] && (this.options[t][n] = e[n]))
                }, t.prototype.getRect = function(t) {
                    return t = t || this.target, o.string(this.target) && !o.element(t) && (t = this._context.querySelector(this.target)), v(t)
                }, t.prototype.rectChecker = function(t) {
                    return o.function(t) ? (this.getRect = t, this) : null === t ? (delete this.options.getRect, this) : this.getRect
                }, t.prototype._backCompatOption = function(t, e) {
                    if (h(e) || o.object(e)) {
                        this.options[t] = e;
                        for (var n = 0; n < c.names.length; n++) {
                            var r;
                            r = c.names[n];
                            var i = r;
                            this.options[i][t] = e
                        }
                        return this
                    }
                    return this.options[t]
                }, t.prototype.origin = function(t) {
                    return this._backCompatOption("origin", t)
                }, t.prototype.deltaSource = function(t) {
                    return "page" === t || "client" === t ? (this.options.deltaSource = t, this) : this.options.deltaSource
                }, t.prototype.context = function() {
                    return this._context
                }, t.prototype.inContext = function(t) {
                    return this._context === t.ownerDocument || g(this._context, t)
                }, t.prototype.fire = function(t) {
                    return this.events.fire(t), this
                }, t.prototype._onOffMultiple = function(t, e, n, r) {
                    if (o.string(e) && -1 !== e.search(" ") && (e = e.trim().split(/ +/)), o.array(e)) {
                        for (var i = 0; i < e.length; i++) {
                            var s;
                            s = e[i];
                            var a = s;
                            this[t](a, n, r)
                        }
                        return !0
                    }
                    if (o.object(e)) {
                        for (var c in e) this[t](c, e[c], n);
                        return !0
                    }
                }, t.prototype.on = function(e, n, r) {
                    return this._onOffMultiple("on", e, n, r) ? this : ("wheel" === e && (e = T), w(t.eventTypes, e) ? this.events.on(e, n) : o.string(this.target) ? s.addDelegate(this.target, this._context, e, n, r) : s.add(this.target, e, n, r), this)
                }, t.prototype.off = function(e, n, r) {
                    return this._onOffMultiple("off", e, n, r) ? this : ("wheel" === e && (e = T), w(t.eventTypes, e) ? this.events.off(e, n) : o.string(this.target) ? s.removeDelegate(this.target, this._context, e, n, r) : s.remove(this.target, e, n, r), this)
                }, t.prototype.set = function(e) {
                    o.object(e) || (e = {}), this.options = i(u.base);
                    var n = i(u.perAction);
                    for (var r in c.methodDict) {
                        var s = c.methodDict[r];
                        this.options[r] = i(u[r]), this.setPerAction(r, n), this[s](e[r])
                    }
                    for (var a = 0; a < t.settingsMethods.length; a++) {
                        var l;
                        l = t.settingsMethods[a];
                        var p = l;
                        this.options[p] = u.base[p], p in e && this[p](e[p])
                    }
                    return d.fire("set", {
                        options: e,
                        interactable: this
                    }), this
                }, t.prototype.unset = function() {
                    if (s.remove(this.target, "all"), o.string(this.target))
                        for (var t in s.delegatedEvents) {
                            var e = s.delegatedEvents[t];
                            e.selectors[0] === this.target && e.contexts[0] === this._context && (e.selectors.splice(0, 1), e.contexts.splice(0, 1), e.listeners.splice(0, 1), e.selectors.length || (e[t] = null)), s.remove(this._context, t, s.delegateListener), s.remove(this._context, t, s.delegateUseCapture, !0)
                        } else s.remove(this, "all");
                    d.fire("unset", {
                        interactable: this
                    }), l.interactables.splice(l.interactables.indexOf(this), 1);
                    for (var n = 0; n < (l.interactions || []).length; n++) {
                        var r;
                        r = (l.interactions || [])[n];
                        var i = r;
                        i.target === this && i.interacting() && !i._ending && i.stop()
                    }
                    return l.interact
                }, t
            }();
            l.interactables.indexOfElement = function(t, e) {
                e = e || l.document;
                for (var n = 0; n < this.length; n++) {
                    var r = this[n];
                    if (r.target === t && r._context === e) return n
                }
                return -1
            }, l.interactables.get = function(t, e, n) {
                var r = this[this.indexOfElement(t, e && e.context)];
                return r && (o.string(t) || n || r.inContext(t)) ? r : null
            }, l.interactables.forEachMatch = function(t, e) {
                for (var n = 0; n < this.length; n++) {
                    var r;
                    r = this[n];
                    var i = r,
                        s = void 0;
                    if ((o.string(i.target) ? o.element(t) && m(t, i.target) : t === i.target) && i.inContext(t) && (s = e(i)), void 0 !== s) return s
                }
            }, S.eventTypes = l.eventTypes = [], S.signals = d, S.settingsMethods = ["deltaSource", "origin", "preventDefault", "rectChecker"], e.exports = S
        }, {
            "./Eventable": 2,
            "./actions/base": 6,
            "./defaultOptions": 18,
            "./scope": 33,
            "./utils/Signals": 34,
            "./utils/arr": 35,
            "./utils/browser": 36,
            "./utils/clone": 37,
            "./utils/domUtils": 39,
            "./utils/events": 40,
            "./utils/extend": 41,
            "./utils/is": 46,
            "./utils/window": 52
        }],
        5: [function(t, e, n) {
            "use strict";

            function r(t, e) {
                if (!(t instanceof e)) throw new TypeError("Cannot call a class as a function")
            }

            function i(t) {
                return function(e) {
                    var n = c.getPointerType(e),
                        r = c.getEventTargets(e),
                        i = r[0],
                        o = r[1],
                        s = [];
                    if (p.supportsTouch && /touch/.test(e.type)) {
                        h = (new Date).getTime();
                        for (var l = 0; l < e.changedTouches.length; l++) {
                            var u;
                            u = e.changedTouches[l];
                            var f = u,
                                v = f,
                                g = d.search(v, e.type, i);
                            s.push([v, g || new m({
                                pointerType: n
                            })])
                        }
                    } else {
                        var y = !1;
                        if (!p.supportsPointerEvent && /mouse/.test(e.type)) {
                            for (var x = 0; x < a.interactions.length && !y; x++) y = "mouse" !== a.interactions[x].pointerType && a.interactions[x].pointerIsDown;
                            y = y || (new Date).getTime() - h < 500 || 0 === e.timeStamp
                        }
                        if (!y) {
                            var b = d.search(e, e.type, i);
                            b || (b = new m({
                                pointerType: n
                            })), s.push([e, b])
                        }
                    }
                    for (var w = 0; w < s.length; w++) {
                        var E = s[w],
                            T = E[0],
                            S = E[1];
                        S._updateEventTargets(i, o), S[t](T, e, i, o)
                    }
                }
            }

            function o(t) {
                for (var e = 0; e < a.interactions.length; e++) {
                    var n;
                    n = a.interactions[e];
                    var r = n;
                    r.end(t), f.fire("endall", {
                        event: t,
                        interaction: r
                    })
                }
            }

            function s(t, e) {
                var n = t.doc,
                    r = 0 === e.indexOf("add") ? l.add : l.remove;
                for (var i in a.delegatedEvents) r(n, i, l.delegateListener), r(n, i, l.delegateUseCapture, !0);
                for (var o in b) r(n, o, b[o])
            }
            var a = t("./scope"),
                c = t("./utils"),
                l = t("./utils/events"),
                p = t("./utils/browser"),
                u = t("./utils/domObjects"),
                d = t("./utils/interactionFinder"),
                f = t("./utils/Signals").new(),
                v = {},
                g = ["pointerDown", "pointerMove", "pointerUp", "updatePointer", "removePointer"],
                h = 0;
            a.interactions = [];
            for (var m = function() {
                    function t(e) {
                        var n = e.pointerType;
                        r(this, t), this.target = null, this.element = null, this.prepared = {
                            name: null,
                            axis: null,
                            edges: null
                        }, this.pointers = [], this.pointerIds = [], this.downTargets = [], this.downTimes = [], this.prevCoords = {
                            page: {
                                x: 0,
                                y: 0
                            },
                            client: {
                                x: 0,
                                y: 0
                            },
                            timeStamp: 0
                        }, this.curCoords = {
                            page: {
                                x: 0,
                                y: 0
                            },
                            client: {
                                x: 0,
                                y: 0
                            },
                            timeStamp: 0
                        }, this.startCoords = {
                            page: {
                                x: 0,
                                y: 0
                            },
                            client: {
                                x: 0,
                                y: 0
                            },
                            timeStamp: 0
                        }, this.pointerDelta = {
                            page: {
                                x: 0,
                                y: 0,
                                vx: 0,
                                vy: 0,
                                speed: 0
                            },
                            client: {
                                x: 0,
                                y: 0,
                                vx: 0,
                                vy: 0,
                                speed: 0
                            },
                            timeStamp: 0
                        }, this.downEvent = null, this.downPointer = {}, this._eventTarget = null, this._curEventTarget = null, this.prevEvent = null, this.pointerIsDown = !1, this.pointerWasMoved = !1, this._interacting = !1, this._ending = !1, this.pointerType = n, f.fire("new", this), a.interactions.push(this)
                    }
                    return t.prototype.pointerDown = function(t, e, n) {
                        var r = this.updatePointer(t, e, !0);
                        f.fire("down", {
                            pointer: t,
                            event: e,
                            eventTarget: n,
                            pointerIndex: r,
                            interaction: this
                        })
                    }, t.prototype.start = function(t, e, n) {
                        this.interacting() || !this.pointerIsDown || this.pointerIds.length < ("gesture" === t.name ? 2 : 1) || (-1 === a.interactions.indexOf(this) && a.interactions.push(this), c.copyAction(this.prepared, t), this.target = e, this.element = n, f.fire("action-start", {
                            interaction: this,
                            event: this.downEvent
                        }))
                    }, t.prototype.pointerMove = function(e, n, r) {
                        this.simulation || (this.updatePointer(e), c.setCoords(this.curCoords, this.pointers));
                        var i = this.curCoords.page.x === this.prevCoords.page.x && this.curCoords.page.y === this.prevCoords.page.y && this.curCoords.client.x === this.prevCoords.client.x && this.curCoords.client.y === this.prevCoords.client.y,
                            o = void 0,
                            s = void 0;
                        this.pointerIsDown && !this.pointerWasMoved && (o = this.curCoords.client.x - this.startCoords.client.x, s = this.curCoords.client.y - this.startCoords.client.y, this.pointerWasMoved = c.hypot(o, s) > t.pointerMoveTolerance);
                        var a = {
                            pointer: e,
                            pointerIndex: this.getPointerIndex(e),
                            event: n,
                            eventTarget: r,
                            dx: o,
                            dy: s,
                            duplicate: i,
                            interaction: this,
                            interactingBeforeMove: this.interacting()
                        };
                        i || c.setCoordDeltas(this.pointerDelta, this.prevCoords, this.curCoords), f.fire("move", a), i || (this.interacting() && this.doMove(a), this.pointerWasMoved && c.copyCoords(this.prevCoords, this.curCoords))
                    }, t.prototype.doMove = function(t) {
                        t = c.extend({
                            pointer: this.pointers[0],
                            event: this.prevEvent,
                            eventTarget: this._eventTarget,
                            interaction: this
                        }, t || {}), f.fire("before-action-move", t), this._dontFireMove || f.fire("action-move", t), this._dontFireMove = !1
                    }, t.prototype.pointerUp = function(t, e, n, r) {
                        var i = this.getPointerIndex(t);
                        f.fire(/cancel$/i.test(e.type) ? "cancel" : "up", {
                            pointer: t,
                            pointerIndex: i,
                            event: e,
                            eventTarget: n,
                            curEventTarget: r,
                            interaction: this
                        }), this.simulation || this.end(e), this.pointerIsDown = !1, this.removePointer(t, e)
                    }, t.prototype.end = function(t) {
                        this._ending = !0, t = t || this.prevEvent, this.interacting() && f.fire("action-end", {
                            event: t,
                            interaction: this
                        }), this.stop(), this._ending = !1
                    }, t.prototype.currentAction = function() {
                        return this._interacting ? this.prepared.name : null
                    }, t.prototype.interacting = function() {
                        return this._interacting
                    }, t.prototype.stop = function() {
                        f.fire("stop", {
                            interaction: this
                        }), this._interacting && (f.fire("stop-active", {
                            interaction: this
                        }), f.fire("stop-" + this.prepared.name, {
                            interaction: this
                        })), this.target = this.element = null, this._interacting = !1, this.prepared.name = this.prevEvent = null
                    }, t.prototype.getPointerIndex = function(t) {
                        return "mouse" === this.pointerType || "pen" === this.pointerType ? 0 : this.pointerIds.indexOf(c.getPointerId(t))
                    }, t.prototype.updatePointer = function(t, e) {
                        var n = arguments.length > 2 && void 0 !== arguments[2] ? arguments[2] : e && /(down|start)$/i.test(e.type),
                            r = c.getPointerId(t),
                            i = this.getPointerIndex(t);
                        return -1 === i && (i = this.pointerIds.length, this.pointerIds[i] = r), n && f.fire("update-pointer-down", {
                            pointer: t,
                            event: e,
                            down: n,
                            pointerId: r,
                            pointerIndex: i,
                            interaction: this
                        }), this.pointers[i] = t, i
                    }, t.prototype.removePointer = function(t, e) {
                        var n = this.getPointerIndex(t); - 1 !== n && (f.fire("remove-pointer", {
                            pointer: t,
                            event: e,
                            pointerIndex: n,
                            interaction: this
                        }), this.pointers.splice(n, 1), this.pointerIds.splice(n, 1), this.downTargets.splice(n, 1), this.downTimes.splice(n, 1))
                    }, t.prototype._updateEventTargets = function(t, e) {
                        this._eventTarget = t, this._curEventTarget = e
                    }, t
                }(), y = 0; y < g.length; y++) {
                var x = g[y];
                v[x] = i(x)
            }
            var b = {},
                w = p.pEventTypes;
            u.PointerEvent ? (b[w.down] = v.pointerDown, b[w.move] = v.pointerMove, b[w.up] = v.pointerUp, b[w.cancel] = v.pointerUp) : (b.mousedown = v.pointerDown, b.mousemove = v.pointerMove, b.mouseup = v.pointerUp, b.touchstart = v.pointerDown, b.touchmove = v.pointerMove, b.touchend = v.pointerUp, b.touchcancel = v.pointerUp), b.blur = o, f.on("update-pointer-down", function(t) {
                var e = t.interaction,
                    n = t.pointer,
                    r = t.pointerId,
                    i = t.pointerIndex,
                    o = t.event,
                    s = t.eventTarget,
                    a = t.down;
                e.pointerIds[i] = r, e.pointers[i] = n, a && (e.pointerIsDown = !0), e.interacting() || (c.setCoords(e.startCoords, e.pointers), c.copyCoords(e.curCoords, e.startCoords), c.copyCoords(e.prevCoords, e.startCoords), e.downEvent = o, e.downTimes[i] = e.curCoords.timeStamp, e.downTargets[i] = s || o && c.getEventTargets(o)[0], e.pointerWasMoved = !1, c.pointerExtend(e.downPointer, n))
            }), a.signals.on("add-document", s), a.signals.on("remove-document", s), m.pointerMoveTolerance = 1, m.doOnInteractions = i, m.endAll = o, m.signals = f, m.docEvents = b, a.endAllInteractions = o, e.exports = m
        }, {
            "./scope": 33,
            "./utils": 44,
            "./utils/Signals": 34,
            "./utils/browser": 36,
            "./utils/domObjects": 38,
            "./utils/events": 40,
            "./utils/interactionFinder": 45
        }],
        6: [function(t, e, n) {
            "use strict";

            function r(t, e, n, r) {
                var i = t.prepared.name,
                    s = new o(t, e, i, n, t.element, null, r);
                t.target.fire(s), t.prevEvent = s
            }
            var i = t("../Interaction"),
                o = t("../InteractEvent"),
                s = {
                    firePrepared: r,
                    names: [],
                    methodDict: {}
                };
            i.signals.on("action-start", function(t) {
                var e = t.interaction,
                    n = t.event;
                e._interacting = !0, r(e, n, "start")
            }), i.signals.on("action-move", function(t) {
                var e = t.interaction;
                if (r(e, t.event, "move", t.preEnd), !e.interacting()) return !1
            }), i.signals.on("action-end", function(t) {
                r(t.interaction, t.event, "end")
            }), e.exports = s
        }, {
            "../InteractEvent": 3,
            "../Interaction": 5
        }],
        7: [function(t, e, n) {
            "use strict";
            var r = t("./base"),
                i = t("../utils"),
                o = t("../InteractEvent"),
                s = t("../Interactable"),
                a = t("../Interaction"),
                c = t("../defaultOptions"),
                l = {
                    defaults: {
                        enabled: !1,
                        mouseButtons: null,
                        origin: null,
                        snap: null,
                        restrict: null,
                        inertia: null,
                        autoScroll: null,
                        startAxis: "xy",
                        lockAxis: "xy"
                    },
                    checker: function(t, e, n) {
                        var r = n.options.drag;
                        return r.enabled ? {
                            name: "drag",
                            axis: "start" === r.lockAxis ? r.startAxis : r.lockAxis
                        } : null
                    },
                    getCursor: function() {
                        return "move"
                    }
                };
            a.signals.on("before-action-move", function(t) {
                var e = t.interaction;
                if ("drag" === e.prepared.name) {
                    var n = e.prepared.axis;
                    "x" === n ? (e.curCoords.page.y = e.startCoords.page.y, e.curCoords.client.y = e.startCoords.client.y, e.pointerDelta.page.speed = Math.abs(e.pointerDelta.page.vx), e.pointerDelta.client.speed = Math.abs(e.pointerDelta.client.vx), e.pointerDelta.client.vy = 0, e.pointerDelta.page.vy = 0) : "y" === n && (e.curCoords.page.x = e.startCoords.page.x, e.curCoords.client.x = e.startCoords.client.x, e.pointerDelta.page.speed = Math.abs(e.pointerDelta.page.vy), e.pointerDelta.client.speed = Math.abs(e.pointerDelta.client.vy), e.pointerDelta.client.vx = 0, e.pointerDelta.page.vx = 0)
                }
            }), o.signals.on("new", function(t) {
                var e = t.iEvent,
                    n = t.interaction;
                if ("dragmove" === e.type) {
                    var r = n.prepared.axis;
                    "x" === r ? (e.pageY = n.startCoords.page.y, e.clientY = n.startCoords.client.y, e.dy = 0) : "y" === r && (e.pageX = n.startCoords.page.x, e.clientX = n.startCoords.client.x, e.dx = 0)
                }
            }), s.prototype.draggable = function(t) {
                return i.is.object(t) ? (this.options.drag.enabled = !1 !== t.enabled, this.setPerAction("drag", t), this.setOnEvents("drag", t), /^(xy|x|y|start)$/.test(t.lockAxis) && (this.options.drag.lockAxis = t.lockAxis), /^(xy|x|y)$/.test(t.startAxis) && (this.options.drag.startAxis = t.startAxis), this) : i.is.bool(t) ? (this.options.drag.enabled = t, t || (this.ondragstart = this.ondragstart = this.ondragend = null), this) : this.options.drag
            }, r.drag = l, r.names.push("drag"), i.merge(s.eventTypes, ["dragstart", "dragmove", "draginertiastart", "draginertiaresume", "dragend"]), r.methodDict.drag = "draggable", c.drag = l.defaults, e.exports = l
        }, {
            "../InteractEvent": 3,
            "../Interactable": 4,
            "../Interaction": 5,
            "../defaultOptions": 18,
            "../utils": 44,
            "./base": 6
        }],
        8: [function(t, e, n) {
            "use strict";

            function r(t, e) {
                for (var n = [], r = [], i = 0; i < u.interactables.length; i++) {
                    var o;
                    o = u.interactables[i];
                    var s = o;
                    if (s.options.drop.enabled) {
                        var a = s.options.drop.accept;
                        if (!(p.is.element(a) && a !== e || p.is.string(a) && !p.matchesSelector(e, a)))
                            for (var c = p.is.string(s.target) ? s._context.querySelectorAll(s.target) : [s.target], l = 0; l < c.length; l++) {
                                var d;
                                d = c[l];
                                var f = d;
                                f !== e && (n.push(s), r.push(f))
                            }
                    }
                }
                return {
                    elements: r,
                    dropzones: n
                }
            }

            function i(t, e) {
                for (var n = void 0, r = 0; r < t.dropzones.length; r++) {
                    var i = t.dropzones[r],
                        o = t.elements[r];
                    o !== n && (e.target = o, i.fire(e)), n = o
                }
            }

            function o(t, e) {
                var n = r(t, e);
                t.dropzones = n.dropzones, t.elements = n.elements, t.rects = [];
                for (var i = 0; i < t.dropzones.length; i++) t.rects[i] = t.dropzones[i].getRect(t.elements[i])
            }

            function s(t, e, n) {
                var r = t.interaction,
                    i = [];
                y && o(r.activeDrops, n);
                for (var s = 0; s < r.activeDrops.dropzones.length; s++) {
                    var a = r.activeDrops.dropzones[s],
                        c = r.activeDrops.elements[s],
                        l = r.activeDrops.rects[s];
                    i.push(a.dropCheck(t, e, r.target, n, c, l) ? c : null)
                }
                var u = p.indexOfDeepestElement(i);
                return {
                    dropzone: r.activeDrops.dropzones[u] || null,
                    element: r.activeDrops.elements[u] || null
                }
            }

            function a(t, e, n) {
                var r = {
                        enter: null,
                        leave: null,
                        activate: null,
                        deactivate: null,
                        move: null,
                        drop: null
                    },
                    i = {
                        dragEvent: n,
                        interaction: t,
                        target: t.dropElement,
                        dropzone: t.dropTarget,
                        relatedTarget: n.target,
                        draggable: n.interactable,
                        timeStamp: n.timeStamp
                    };
                return t.dropElement !== t.prevDropElement && (t.prevDropTarget && (r.leave = p.extend({
                    type: "dragleave"
                }, i), n.dragLeave = r.leave.target = t.prevDropElement, n.prevDropzone = r.leave.dropzone = t.prevDropTarget), t.dropTarget && (r.enter = {
                    dragEvent: n,
                    interaction: t,
                    target: t.dropElement,
                    dropzone: t.dropTarget,
                    relatedTarget: n.target,
                    draggable: n.interactable,
                    timeStamp: n.timeStamp,
                    type: "dragenter"
                }, n.dragEnter = t.dropElement, n.dropzone = t.dropTarget)), "dragend" === n.type && t.dropTarget && (r.drop = p.extend({
                    type: "drop"
                }, i), n.dropzone = t.dropTarget, n.relatedTarget = t.dropElement), "dragstart" === n.type && (r.activate = p.extend({
                    type: "dropactivate"
                }, i), r.activate.target = null, r.activate.dropzone = null), "dragend" === n.type && (r.deactivate = p.extend({
                    type: "dropdeactivate"
                }, i), r.deactivate.target = null, r.deactivate.dropzone = null), "dragmove" === n.type && t.dropTarget && (r.move = p.extend({
                    dragmove: n,
                    type: "dropmove"
                }, i), n.dropzone = t.dropTarget), r
            }

            function c(t, e) {
                var n = t.activeDrops,
                    r = t.prevDropTarget,
                    o = t.dropTarget,
                    s = t.dropElement;
                e.leave && r.fire(e.leave), e.move && o.fire(e.move), e.enter && o.fire(e.enter), e.drop && o.fire(e.drop), e.deactivate && i(n, e.deactivate), t.prevDropTarget = o, t.prevDropElement = s
            }
            var l = t("./base"),
                p = t("../utils"),
                u = t("../scope"),
                d = t("../interact"),
                f = t("../InteractEvent"),
                v = t("../Interactable"),
                g = t("../Interaction"),
                h = t("../defaultOptions"),
                m = {
                    defaults: {
                        enabled: !1,
                        accept: null,
                        overlap: "pointer"
                    }
                },
                y = !1;
            g.signals.on("action-start", function(t) {
                var e = t.interaction,
                    n = t.event;
                if ("drag" === e.prepared.name) {
                    e.activeDrops.dropzones = [], e.activeDrops.elements = [], e.activeDrops.rects = [], e.dropEvents = null, e.dynamicDrop || o(e.activeDrops, e.element);
                    var r = e.prevEvent,
                        s = a(e, n, r);
                    s.activate && i(e.activeDrops, s.activate)
                }
            }), f.signals.on("new", function(t) {
                var e = t.interaction,
                    n = t.iEvent,
                    r = t.event;
                if ("dragmove" === n.type || "dragend" === n.type) {
                    var i = e.element,
                        o = n,
                        c = s(o, r, i);
                    e.dropTarget = c.dropzone, e.dropElement = c.element, e.dropEvents = a(e, r, o)
                }
            }), g.signals.on("action-move", function(t) {
                var e = t.interaction;
                "drag" === e.prepared.name && c(e, e.dropEvents)
            }), g.signals.on("action-end", function(t) {
                var e = t.interaction;
                "drag" === e.prepared.name && c(e, e.dropEvents)
            }), g.signals.on("stop-drag", function(t) {
                var e = t.interaction;
                e.activeDrops = {
                    dropzones: null,
                    elements: null,
                    rects: null
                }, e.dropEvents = null
            }), v.prototype.dropzone = function(t) {
                return p.is.object(t) ? (this.options.drop.enabled = !1 !== t.enabled, p.is.function(t.ondrop) && (this.events.ondrop = t.ondrop), p.is.function(t.ondropactivate) && (this.events.ondropactivate = t.ondropactivate), p.is.function(t.ondropdeactivate) && (this.events.ondropdeactivate = t.ondropdeactivate), p.is.function(t.ondragenter) && (this.events.ondragenter = t.ondragenter), p.is.function(t.ondragleave) && (this.events.ondragleave = t.ondragleave), p.is.function(t.ondropmove) && (this.events.ondropmove = t.ondropmove), /^(pointer|center)$/.test(t.overlap) ? this.options.drop.overlap = t.overlap : p.is.number(t.overlap) && (this.options.drop.overlap = Math.max(Math.min(1, t.overlap), 0)), "accept" in t && (this.options.drop.accept = t.accept), "checker" in t && (this.options.drop.checker = t.checker), this) : p.is.bool(t) ? (this.options.drop.enabled = t, t || (this.ondragenter = this.ondragleave = this.ondrop = this.ondropactivate = this.ondropdeactivate = null), this) : this.options.drop
            }, v.prototype.dropCheck = function(t, e, n, r, i, o) {
                var s = !1;
                if (!(o = o || this.getRect(i))) return !!this.options.drop.checker && this.options.drop.checker(t, e, s, this, i, n, r);
                var a = this.options.drop.overlap;
                if ("pointer" === a) {
                    var c = p.getOriginXY(n, r, "drag"),
                        l = p.getPageXY(t);
                    l.x += c.x, l.y += c.y;
                    var u = l.x > o.left && l.x < o.right,
                        d = l.y > o.top && l.y < o.bottom;
                    s = u && d
                }
                var f = n.getRect(r);
                if (f && "center" === a) {
                    var v = f.left + f.width / 2,
                        g = f.top + f.height / 2;
                    s = v >= o.left && v <= o.right && g >= o.top && g <= o.bottom
                }
                if (f && p.is.number(a)) {
                    s = Math.max(0, Math.min(o.right, f.right) - Math.max(o.left, f.left)) * Math.max(0, Math.min(o.bottom, f.bottom) - Math.max(o.top, f.top)) / (f.width * f.height) >= a
                }
                return this.options.drop.checker && (s = this.options.drop.checker(t, e, s, this, i, n, r)), s
            }, v.signals.on("unset", function(t) {
                t.interactable.dropzone(!1)
            }), v.settingsMethods.push("dropChecker"), g.signals.on("new", function(t) {
                t.dropTarget = null, t.dropElement = null, t.prevDropTarget = null, t.prevDropElement = null, t.dropEvents = null, t.activeDrops = {
                    dropzones: [],
                    elements: [],
                    rects: []
                }
            }), g.signals.on("stop", function(t) {
                var e = t.interaction;
                e.dropTarget = e.dropElement = e.prevDropTarget = e.prevDropElement = null
            }), d.dynamicDrop = function(t) {
                return p.is.bool(t) ? (y = t, d) : y
            }, p.merge(v.eventTypes, ["dragenter", "dragleave", "dropactivate", "dropdeactivate", "dropmove", "drop"]), l.methodDict.drop = "dropzone", h.drop = m.defaults, e.exports = m
        }, {
            "../InteractEvent": 3,
            "../Interactable": 4,
            "../Interaction": 5,
            "../defaultOptions": 18,
            "../interact": 21,
            "../scope": 33,
            "../utils": 44,
            "./base": 6
        }],
        9: [function(t, e, n) {
            "use strict";
            var r = t("./base"),
                i = t("../utils"),
                o = t("../InteractEvent"),
                s = t("../Interactable"),
                a = t("../Interaction"),
                c = t("../defaultOptions"),
                l = {
                    defaults: {
                        enabled: !1,
                        origin: null,
                        restrict: null
                    },
                    checker: function(t, e, n, r, i) {
                        return i.pointerIds.length >= 2 ? {
                            name: "gesture"
                        } : null
                    },
                    getCursor: function() {
                        return ""
                    }
                };
            o.signals.on("new", function(t) {
                var e = t.iEvent,
                    n = t.interaction;
                "gesturestart" === e.type && (e.ds = 0, n.gesture.startDistance = n.gesture.prevDistance = e.distance, n.gesture.startAngle = n.gesture.prevAngle = e.angle, n.gesture.scale = 1)
            }), o.signals.on("new", function(t) {
                var e = t.iEvent,
                    n = t.interaction;
                "gesturemove" === e.type && (e.ds = e.scale - n.gesture.scale, n.target.fire(e), n.gesture.prevAngle = e.angle, n.gesture.prevDistance = e.distance, e.scale === 1 / 0 || null === e.scale || void 0 === e.scale || isNaN(e.scale) || (n.gesture.scale = e.scale))
            }), s.prototype.gesturable = function(t) {
                return i.is.object(t) ? (this.options.gesture.enabled = !1 !== t.enabled, this.setPerAction("gesture", t), this.setOnEvents("gesture", t), this) : i.is.bool(t) ? (this.options.gesture.enabled = t, t || (this.ongesturestart = this.ongesturestart = this.ongestureend = null), this) : this.options.gesture
            }, o.signals.on("set-delta", function(t) {
                var e = t.interaction,
                    n = t.iEvent,
                    r = t.action,
                    s = t.event,
                    a = t.starting,
                    c = t.ending,
                    l = t.deltaSource;
                if ("gesture" === r) {
                    var p = e.pointers;
                    n.touches = [p[0], p[1]], a ? (n.distance = i.touchDistance(p, l), n.box = i.touchBBox(p), n.scale = 1, n.ds = 0, n.angle = i.touchAngle(p, void 0, l), n.da = 0) : c || s instanceof o ? (n.distance = e.prevEvent.distance, n.box = e.prevEvent.box, n.scale = e.prevEvent.scale, n.ds = n.scale - 1, n.angle = e.prevEvent.angle, n.da = n.angle - e.gesture.startAngle) : (n.distance = i.touchDistance(p, l), n.box = i.touchBBox(p), n.scale = n.distance / e.gesture.startDistance, n.angle = i.touchAngle(p, e.gesture.prevAngle, l), n.ds = n.scale - e.gesture.prevScale, n.da = n.angle - e.gesture.prevAngle)
                }
            }), a.signals.on("new", function(t) {
                t.gesture = {
                    start: {
                        x: 0,
                        y: 0
                    },
                    startDistance: 0,
                    prevDistance: 0,
                    distance: 0,
                    scale: 1,
                    startAngle: 0,
                    prevAngle: 0
                }
            }), r.gesture = l, r.names.push("gesture"), i.merge(s.eventTypes, ["gesturestart", "gesturemove", "gestureend"]), r.methodDict.gesture = "gesturable", c.gesture = l.defaults, e.exports = l
        }, {
            "../InteractEvent": 3,
            "../Interactable": 4,
            "../Interaction": 5,
            "../defaultOptions": 18,
            "../utils": 44,
            "./base": 6
        }],
        10: [function(t, e, n) {
            "use strict";

            function r(t, e, n, r, i, s, a) {
                if (!e) return !1;
                if (!0 === e) {
                    var c = o.is.number(s.width) ? s.width : s.right - s.left,
                        l = o.is.number(s.height) ? s.height : s.bottom - s.top;
                    if (c < 0 && ("left" === t ? t = "right" : "right" === t && (t = "left")), l < 0 && ("top" === t ? t = "bottom" : "bottom" === t && (t = "top")), "left" === t) return n.x < (c >= 0 ? s.left : s.right) + a;
                    if ("top" === t) return n.y < (l >= 0 ? s.top : s.bottom) + a;
                    if ("right" === t) return n.x > (c >= 0 ? s.right : s.left) - a;
                    if ("bottom" === t) return n.y > (l >= 0 ? s.bottom : s.top) - a
                }
                return !!o.is.element(r) && (o.is.element(e) ? e === r : o.matchesUpTo(r, e, i))
            }
            var i = t("./base"),
                o = t("../utils"),
                s = t("../utils/browser"),
                a = t("../InteractEvent"),
                c = t("../Interactable"),
                l = t("../Interaction"),
                p = t("../defaultOptions"),
                u = s.supportsTouch || s.supportsPointerEvent ? 20 : 10,
                d = {
                    defaults: {
                        enabled: !1,
                        mouseButtons: null,
                        origin: null,
                        snap: null,
                        restrict: null,
                        inertia: null,
                        autoScroll: null,
                        square: !1,
                        preserveAspectRatio: !1,
                        axis: "xy",
                        margin: NaN,
                        edges: null,
                        invert: "none"
                    },
                    checker: function(t, e, n, i, s, a) {
                        if (!a) return null;
                        var c = o.extend({}, s.curCoords.page),
                            l = n.options;
                        if (l.resize.enabled) {
                            var p = l.resize,
                                d = {
                                    left: !1,
                                    right: !1,
                                    top: !1,
                                    bottom: !1
                                };
                            if (o.is.object(p.edges)) {
                                for (var f in d) d[f] = r(f, p.edges[f], c, s._eventTarget, i, a, p.margin || u);
                                if (d.left = d.left && !d.right, d.top = d.top && !d.bottom, d.left || d.right || d.top || d.bottom) return {
                                    name: "resize",
                                    edges: d
                                }
                            } else {
                                var v = "y" !== l.resize.axis && c.x > a.right - u,
                                    g = "x" !== l.resize.axis && c.y > a.bottom - u;
                                if (v || g) return {
                                    name: "resize",
                                    axes: (v ? "x" : "") + (g ? "y" : "")
                                }
                            }
                        }
                        return null
                    },
                    cursors: s.isIe9 ? {
                        x: "e-resize",
                        y: "s-resize",
                        xy: "se-resize",
                        top: "n-resize",
                        left: "w-resize",
                        bottom: "s-resize",
                        right: "e-resize",
                        topleft: "se-resize",
                        bottomright: "se-resize",
                        topright: "ne-resize",
                        bottomleft: "ne-resize"
                    } : {
                        x: "ew-resize",
                        y: "ns-resize",
                        xy: "nwse-resize",
                        top: "ns-resize",
                        left: "ew-resize",
                        bottom: "ns-resize",
                        right: "ew-resize",
                        topleft: "nwse-resize",
                        bottomright: "nwse-resize",
                        topright: "nesw-resize",
                        bottomleft: "nesw-resize"
                    },
                    getCursor: function(t) {
                        if (t.axis) return d.cursors[t.name + t.axis];
                        if (t.edges) {
                            for (var e = "", n = ["top", "bottom", "left", "right"], r = 0; r < 4; r++) t.edges[n[r]] && (e += n[r]);
                            return d.cursors[e]
                        }
                    }
                };
            a.signals.on("new", function(t) {
                    var e = t.iEvent,
                        n = t.interaction;
                    if ("resizestart" === e.type && n.prepared.edges) {
                        var r = n.target.getRect(n.element),
                            i = n.target.options.resize;
                        if (i.square || i.preserveAspectRatio) {
                            var s = o.extend({}, n.prepared.edges);
                            s.top = s.top || s.left && !s.bottom, s.left = s.left || s.top && !s.right, s.bottom = s.bottom || s.right && !s.top, s.right = s.right || s.bottom && !s.left, n.prepared._linkedEdges = s
                        } else n.prepared._linkedEdges = null;
                        i.preserveAspectRatio && (n.resizeStartAspectRatio = r.width / r.height), n.resizeRects = {
                            start: r,
                            current: o.extend({}, r),
                            inverted: o.extend({}, r),
                            previous: o.extend({}, r),
                            delta: {
                                left: 0,
                                right: 0,
                                width: 0,
                                top: 0,
                                bottom: 0,
                                height: 0
                            }
                        }, e.rect = n.resizeRects.inverted, e.deltaRect = n.resizeRects.delta
                    }
                }), a.signals.on("new", function(t) {
                    var e = t.iEvent,
                        n = t.phase,
                        r = t.interaction;
                    if ("move" === n && r.prepared.edges) {
                        var i = r.target.options.resize,
                            s = i.invert,
                            a = "reposition" === s || "negate" === s,
                            c = r.prepared.edges,
                            l = r.resizeRects.start,
                            p = r.resizeRects.current,
                            u = r.resizeRects.inverted,
                            d = r.resizeRects.delta,
                            f = o.extend(r.resizeRects.previous, u),
                            v = c,
                            g = e.dx,
                            h = e.dy;
                        if (i.preserveAspectRatio || i.square) {
                            var m = i.preserveAspectRatio ? r.resizeStartAspectRatio : 1;
                            c = r.prepared._linkedEdges, v.left && v.bottom || v.right && v.top ? h = -g / m : v.left || v.right ? h = g / m : (v.top || v.bottom) && (g = h * m)
                        }
                        if (c.top && (p.top += h), c.bottom && (p.bottom += h), c.left && (p.left += g), c.right && (p.right += g), a) {
                            if (o.extend(u, p), "reposition" === s) {
                                var y = void 0;
                                u.top > u.bottom && (y = u.top, u.top = u.bottom, u.bottom = y), u.left > u.right && (y = u.left, u.left = u.right, u.right = y)
                            }
                        } else u.top = Math.min(p.top, l.bottom), u.bottom = Math.max(p.bottom, l.top), u.left = Math.min(p.left, l.right), u.right = Math.max(p.right, l.left);
                        u.width = u.right - u.left, u.height = u.bottom - u.top;
                        for (var x in u) d[x] = u[x] - f[x];
                        e.edges = r.prepared.edges, e.rect = u, e.deltaRect = d
                    }
                }), c.prototype.resizable = function(t) {
                    return o.is.object(t) ? (this.options.resize.enabled = !1 !== t.enabled, this.setPerAction("resize", t), this.setOnEvents("resize", t), /^x$|^y$|^xy$/.test(t.axis) ? this.options.resize.axis = t.axis : null === t.axis && (this.options.resize.axis = p.resize.axis), o.is.bool(t.preserveAspectRatio) ? this.options.resize.preserveAspectRatio = t.preserveAspectRatio : o.is.bool(t.square) && (this.options.resize.square = t.square), this) : o.is.bool(t) ? (this.options.resize.enabled = t, t || (this.onresizestart = this.onresizestart = this.onresizeend = null), this) : this.options.resize
                }, l.signals.on("new", function(t) {
                    t.resizeAxes = "xy"
                }), a.signals.on("set-delta", function(t) {
                    var e = t.interaction,
                        n = t.iEvent;
                    "resize" === t.action && e.resizeAxes && (e.target.options.resize.square ? ("y" === e.resizeAxes ? n.dx = n.dy : n.dy = n.dx, n.axes = "xy") : (n.axes = e.resizeAxes, "x" === e.resizeAxes ? n.dy = 0 : "y" === e.resizeAxes && (n.dx = 0)))
                }), i.resize = d, i.names.push("resize"),
                o.merge(c.eventTypes, ["resizestart", "resizemove", "resizeinertiastart", "resizeinertiaresume", "resizeend"]), i.methodDict.resize = "resizable", p.resize = d.defaults, e.exports = d
        }, {
            "../InteractEvent": 3,
            "../Interactable": 4,
            "../Interaction": 5,
            "../defaultOptions": 18,
            "../utils": 44,
            "../utils/browser": 36,
            "./base": 6
        }],
        11: [function(t, e, n) {
            "use strict";
            var r = t("./utils/raf"),
                i = t("./utils/window").getWindow,
                o = t("./utils/is"),
                s = t("./utils/domUtils"),
                a = t("./Interaction"),
                c = t("./defaultOptions"),
                l = {
                    defaults: {
                        enabled: !1,
                        container: null,
                        margin: 60,
                        speed: 300
                    },
                    interaction: null,
                    i: null,
                    x: 0,
                    y: 0,
                    isScrolling: !1,
                    prevTime: 0,
                    start: function(t) {
                        l.isScrolling = !0, r.cancel(l.i), l.interaction = t, l.prevTime = (new Date).getTime(), l.i = r.request(l.scroll)
                    },
                    stop: function() {
                        l.isScrolling = !1, r.cancel(l.i)
                    },
                    scroll: function() {
                        var t = l.interaction.target.options[l.interaction.prepared.name].autoScroll,
                            e = t.container || i(l.interaction.element),
                            n = (new Date).getTime(),
                            s = (n - l.prevTime) / 1e3,
                            a = t.speed * s;
                        a >= 1 && (o.window(e) ? e.scrollBy(l.x * a, l.y * a) : e && (e.scrollLeft += l.x * a, e.scrollTop += l.y * a), l.prevTime = n), l.isScrolling && (r.cancel(l.i), l.i = r.request(l.scroll))
                    },
                    check: function(t, e) {
                        var n = t.options;
                        return n[e].autoScroll && n[e].autoScroll.enabled
                    },
                    onInteractionMove: function(t) {
                        var e = t.interaction,
                            n = t.pointer;
                        if (e.interacting() && l.check(e.target, e.prepared.name)) {
                            if (e.simulation) return void(l.x = l.y = 0);
                            var r = void 0,
                                a = void 0,
                                c = void 0,
                                p = void 0,
                                u = e.target.options[e.prepared.name].autoScroll,
                                d = u.container || i(e.element);
                            if (o.window(d)) p = n.clientX < l.margin, r = n.clientY < l.margin, a = n.clientX > d.innerWidth - l.margin, c = n.clientY > d.innerHeight - l.margin;
                            else {
                                var f = s.getElementClientRect(d);
                                p = n.clientX < f.left + l.margin, r = n.clientY < f.top + l.margin, a = n.clientX > f.right - l.margin, c = n.clientY > f.bottom - l.margin
                            }
                            l.x = a ? 1 : p ? -1 : 0, l.y = c ? 1 : r ? -1 : 0, l.isScrolling || (l.margin = u.margin, l.speed = u.speed, l.start(e))
                        }
                    }
                };
            a.signals.on("stop-active", function() {
                l.stop()
            }), a.signals.on("action-move", l.onInteractionMove), c.perAction.autoScroll = l.defaults, e.exports = l
        }, {
            "./Interaction": 5,
            "./defaultOptions": 18,
            "./utils/domUtils": 39,
            "./utils/is": 46,
            "./utils/raf": 50,
            "./utils/window": 52
        }],
        12: [function(t, e, n) {
            "use strict";
            var r = t("../Interactable"),
                i = t("../actions/base"),
                o = t("../utils/is"),
                s = t("../utils/domUtils"),
                a = t("../utils"),
                c = a.warnOnce;
            r.prototype.getAction = function(t, e, n, r) {
                var i = this.defaultActionChecker(t, e, n, r);
                return this.options.actionChecker ? this.options.actionChecker(t, e, i, this, r, n) : i
            }, r.prototype.ignoreFrom = c(function(t) {
                return this._backCompatOption("ignoreFrom", t)
            }, "Interactable.ignoreForm() has been deprecated. Use Interactble.draggable({ignoreFrom: newValue})."), r.prototype.allowFrom = c(function(t) {
                return this._backCompatOption("allowFrom", t)
            }, "Interactable.allowForm() has been deprecated. Use Interactble.draggable({allowFrom: newValue})."), r.prototype.testIgnore = function(t, e, n) {
                return !(!t || !o.element(n)) && (o.string(t) ? s.matchesUpTo(n, t, e) : !!o.element(t) && s.nodeContains(t, n))
            }, r.prototype.testAllow = function(t, e, n) {
                return !t || !!o.element(n) && (o.string(t) ? s.matchesUpTo(n, t, e) : !!o.element(t) && s.nodeContains(t, n))
            }, r.prototype.testIgnoreAllow = function(t, e, n) {
                return !this.testIgnore(t.ignoreFrom, e, n) && this.testAllow(t.allowFrom, e, n)
            }, r.prototype.actionChecker = function(t) {
                return o.function(t) ? (this.options.actionChecker = t, this) : null === t ? (delete this.options.actionChecker, this) : this.options.actionChecker
            }, r.prototype.styleCursor = function(t) {
                return o.bool(t) ? (this.options.styleCursor = t, this) : null === t ? (delete this.options.styleCursor, this) : this.options.styleCursor
            }, r.prototype.defaultActionChecker = function(t, e, n, r) {
                for (var o = this.getRect(r), s = e.buttons || {
                        0: 1,
                        1: 4,
                        3: 8,
                        4: 16
                    }[e.button], a = null, c = 0; c < i.names.length; c++) {
                    var l;
                    l = i.names[c];
                    var p = l;
                    if ((!n.pointerIsDown || !/mouse|pointer/.test(n.pointerType) || 0 != (s & this.options[p].mouseButtons)) && (a = i[p].checker(t, e, this, r, n, o))) return a
                }
            }
        }, {
            "../Interactable": 4,
            "../actions/base": 6,
            "../utils": 44,
            "../utils/domUtils": 39,
            "../utils/is": 46
        }],
        13: [function(t, e, n) {
            "use strict";

            function r(t, e, n, r) {
                return v.is.object(t) && e.testIgnoreAllow(e.options[t.name], n, r) && e.options[t.name].enabled && a(e, n, t) ? t : null
            }

            function i(t, e, n, i, o, s) {
                for (var a = 0, c = i.length; a < c; a++) {
                    var l = i[a],
                        p = o[a],
                        u = r(l.getAction(e, n, t, p), l, p, s);
                    if (u) return {
                        action: u,
                        target: l,
                        element: p
                    }
                }
                return {}
            }

            function o(t, e, n, r) {
                function o(t) {
                    s.push(t), a.push(c)
                }
                for (var s = [], a = [], c = r; v.is.element(c);) {
                    s = [], a = [], f.interactables.forEachMatch(c, o);
                    var l = i(t, e, n, s, a, r);
                    if (l.action && !l.target.options[l.action.name].manualStart) return l;
                    c = v.parentNode(c)
                }
                return {}
            }

            function s(t, e) {
                var n = e.action,
                    r = e.target,
                    i = e.element;
                if (n = n || {}, t.target && t.target.options.styleCursor && (t.target._doc.documentElement.style.cursor = ""), t.target = r, t.element = i, v.copyAction(t.prepared, n), r && r.options.styleCursor) {
                    var o = n ? u[n.name].getCursor(n) : "";
                    t.target._doc.documentElement.style.cursor = o
                }
                g.fire("prepared", {
                    interaction: t
                })
            }

            function a(t, e, n) {
                var r = t.options,
                    i = r[n.name].max,
                    o = r[n.name].maxPerElement,
                    s = 0,
                    a = 0,
                    c = 0;
                if (i && o && h.maxInteractions) {
                    for (var l = 0; l < f.interactions.length; l++) {
                        var p;
                        p = f.interactions[l];
                        var u = p,
                            d = u.prepared.name;
                        if (u.interacting()) {
                            if (++s >= h.maxInteractions) return !1;
                            if (u.target === t) {
                                if ((a += d === n.name | 0) >= i) return !1;
                                if (u.element === e && (c++, d !== n.name || c >= o)) return !1
                            }
                        }
                    }
                    return h.maxInteractions > 0
                }
            }
            var c = t("../interact"),
                l = t("../Interactable"),
                p = t("../Interaction"),
                u = t("../actions/base"),
                d = t("../defaultOptions"),
                f = t("../scope"),
                v = t("../utils"),
                g = t("../utils/Signals").new();
            t("./InteractableMethods");
            var h = {
                signals: g,
                withinInteractionLimit: a,
                maxInteractions: 1 / 0,
                defaults: {
                    perAction: {
                        manualStart: !1,
                        max: 1 / 0,
                        maxPerElement: 1,
                        allowFrom: null,
                        ignoreFrom: null,
                        mouseButtons: 1
                    }
                },
                setActionDefaults: function(t) {
                    v.extend(t.defaults, h.defaults.perAction)
                },
                validateAction: r
            };
            p.signals.on("down", function(t) {
                var e = t.interaction,
                    n = t.pointer,
                    r = t.event,
                    i = t.eventTarget;
                if (!e.interacting()) {
                    s(e, o(e, n, r, i))
                }
            }), p.signals.on("move", function(t) {
                var e = t.interaction,
                    n = t.pointer,
                    r = t.event,
                    i = t.eventTarget;
                if ("mouse" === e.pointerType && !e.pointerIsDown && !e.interacting()) {
                    s(e, o(e, n, r, i))
                }
            }), p.signals.on("move", function(t) {
                var e = t.interaction,
                    n = t.event;
                if (e.pointerIsDown && !e.interacting() && e.pointerWasMoved && e.prepared.name) {
                    g.fire("before-start", t);
                    var r = e.target;
                    e.prepared.name && r && (r.options[e.prepared.name].manualStart || !a(r, e.element, e.prepared) ? e.stop(n) : e.start(e.prepared, r, e.element))
                }
            }), p.signals.on("stop", function(t) {
                var e = t.interaction,
                    n = e.target;
                n && n.options.styleCursor && (n._doc.documentElement.style.cursor = "")
            }), c.maxInteractions = function(t) {
                return v.is.number(t) ? (h.maxInteractions = t, c) : h.maxInteractions
            }, l.settingsMethods.push("styleCursor"), l.settingsMethods.push("actionChecker"), l.settingsMethods.push("ignoreFrom"), l.settingsMethods.push("allowFrom"), d.base.actionChecker = null, d.base.styleCursor = !0, v.extend(d.perAction, h.defaults.perAction), e.exports = h
        }, {
            "../Interactable": 4,
            "../Interaction": 5,
            "../actions/base": 6,
            "../defaultOptions": 18,
            "../interact": 21,
            "../scope": 33,
            "../utils": 44,
            "../utils/Signals": 34,
            "./InteractableMethods": 12
        }],
        14: [function(t, e, n) {
            "use strict";

            function r(t, e) {
                if (!e) return !1;
                var n = e.options.drag.startAxis;
                return "xy" === t || "xy" === n || n === t
            }
            var i = t("./base"),
                o = t("../scope"),
                s = t("../utils/is"),
                a = t("../utils/domUtils"),
                c = a.parentNode;
            i.setActionDefaults(t("../actions/drag")), i.signals.on("before-start", function(t) {
                var e = t.interaction,
                    n = t.eventTarget,
                    a = t.dx,
                    l = t.dy;
                if ("drag" === e.prepared.name) {
                    var p = Math.abs(a),
                        u = Math.abs(l),
                        d = e.target.options.drag,
                        f = d.startAxis,
                        v = p > u ? "x" : p < u ? "y" : "xy";
                    if (e.prepared.axis = "start" === d.lockAxis ? v[0] : d.lockAxis, "xy" !== v && "xy" !== f && f !== v) {
                        e.prepared.name = null;
                        for (var g = n, h = function(t) {
                                if (t !== e.target) {
                                    var o = e.target.options.drag;
                                    if (!o.manualStart && t.testIgnoreAllow(o, g, n)) {
                                        var s = t.getAction(e.downPointer, e.downEvent, e, g);
                                        if (s && "drag" === s.name && r(v, t) && i.validateAction(s, t, g, n)) return t
                                    }
                                }
                            }; s.element(g);) {
                            var m = o.interactables.forEachMatch(g, h);
                            if (m) {
                                e.prepared.name = "drag", e.target = m, e.element = g;
                                break
                            }
                            g = c(g)
                        }
                    }
                }
            })
        }, {
            "../actions/drag": 7,
            "../scope": 33,
            "../utils/domUtils": 39,
            "../utils/is": 46,
            "./base": 13
        }],
        15: [function(t, e, n) {
            "use strict";
            t("./base").setActionDefaults(t("../actions/gesture"))
        }, {
            "../actions/gesture": 9,
            "./base": 13
        }],
        16: [function(t, e, n) {
            "use strict";

            function r(t) {
                var e = t.prepared && t.prepared.name;
                if (!e) return null;
                var n = t.target.options;
                return n[e].hold || n[e].delay
            }
            var i = t("./base"),
                o = t("../Interaction");
            i.defaults.perAction.hold = 0, i.defaults.perAction.delay = 0, o.signals.on("new", function(t) {
                t.autoStartHoldTimer = null
            }), i.signals.on("prepared", function(t) {
                var e = t.interaction,
                    n = r(e);
                n > 0 && (e.autoStartHoldTimer = setTimeout(function() {
                    e.start(e.prepared, e.target, e.element)
                }, n))
            }), o.signals.on("move", function(t) {
                var e = t.interaction,
                    n = t.duplicate;
                e.pointerWasMoved && !n && clearTimeout(e.autoStartHoldTimer)
            }), i.signals.on("before-start", function(t) {
                var e = t.interaction;
                r(e) > 0 && (e.prepared.name = null)
            }), e.exports = {
                getHoldDuration: r
            }
        }, {
            "../Interaction": 5,
            "./base": 13
        }],
        17: [function(t, e, n) {
            "use strict";
            t("./base").setActionDefaults(t("../actions/resize"))
        }, {
            "../actions/resize": 10,
            "./base": 13
        }],
        18: [function(t, e, n) {
            "use strict";
            e.exports = {
                base: {
                    accept: null,
                    preventDefault: "auto",
                    deltaSource: "page"
                },
                perAction: {
                    origin: {
                        x: 0,
                        y: 0
                    },
                    inertia: {
                        enabled: !1,
                        resistance: 10,
                        minSpeed: 100,
                        endSpeed: 10,
                        allowResume: !0,
                        smoothEndDuration: 300
                    }
                }
            }
        }, {}],
        19: [function(t, e, n) {
            "use strict";
            t("./inertia"), t("./modifiers/snap"), t("./modifiers/restrict"), t("./pointerEvents/base"), t("./pointerEvents/holdRepeat"), t("./pointerEvents/interactableTargets"), t("./autoStart/hold"), t("./actions/gesture"), t("./actions/resize"), t("./actions/drag"), t("./actions/drop"), t("./modifiers/snapSize"), t("./modifiers/restrictEdges"), t("./modifiers/restrictSize"), t("./autoStart/gesture"), t("./autoStart/resize"), t("./autoStart/drag"), t("./interactablePreventDefault.js"), t("./autoScroll"), e.exports = t("./interact")
        }, {
            "./actions/drag": 7,
            "./actions/drop": 8,
            "./actions/gesture": 9,
            "./actions/resize": 10,
            "./autoScroll": 11,
            "./autoStart/drag": 14,
            "./autoStart/gesture": 15,
            "./autoStart/hold": 16,
            "./autoStart/resize": 17,
            "./inertia": 20,
            "./interact": 21,
            "./interactablePreventDefault.js": 22,
            "./modifiers/restrict": 24,
            "./modifiers/restrictEdges": 25,
            "./modifiers/restrictSize": 26,
            "./modifiers/snap": 27,
            "./modifiers/snapSize": 28,
            "./pointerEvents/base": 30,
            "./pointerEvents/holdRepeat": 31,
            "./pointerEvents/interactableTargets": 32
        }],
        20: [function(t, e, n) {
            "use strict";

            function r(t, e) {
                var n = t.target.options[t.prepared.name].inertia,
                    r = n.resistance,
                    i = -Math.log(n.endSpeed / e.v0) / r;
                e.x0 = t.prevEvent.pageX, e.y0 = t.prevEvent.pageY, e.t0 = e.startEvent.timeStamp / 1e3, e.sx = e.sy = 0, e.modifiedXe = e.xe = (e.vx0 - i) / r, e.modifiedYe = e.ye = (e.vy0 - i) / r, e.te = i, e.lambda_v0 = r / e.v0, e.one_ve_v0 = 1 - n.endSpeed / e.v0
            }

            function i() {
                s(this), p.setCoordDeltas(this.pointerDelta, this.prevCoords, this.curCoords);
                var t = this.inertiaStatus,
                    e = this.target.options[this.prepared.name].inertia,
                    n = e.resistance,
                    r = (new Date).getTime() / 1e3 - t.t0;
                if (r < t.te) {
                    var i = 1 - (Math.exp(-n * r) - t.lambda_v0) / t.one_ve_v0;
                    if (t.modifiedXe === t.xe && t.modifiedYe === t.ye) t.sx = t.xe * i, t.sy = t.ye * i;
                    else {
                        var o = p.getQuadraticCurvePoint(0, 0, t.xe, t.ye, t.modifiedXe, t.modifiedYe, i);
                        t.sx = o.x, t.sy = o.y
                    }
                    this.doMove(), t.i = u.request(this.boundInertiaFrame)
                } else t.sx = t.modifiedXe, t.sy = t.modifiedYe, this.doMove(), this.end(t.startEvent), t.active = !1, this.simulation = null;
                p.copyCoords(this.prevCoords, this.curCoords)
            }

            function o() {
                s(this);
                var t = this.inertiaStatus,
                    e = (new Date).getTime() - t.t0,
                    n = this.target.options[this.prepared.name].inertia.smoothEndDuration;
                e < n ? (t.sx = p.easeOutQuad(e, 0, t.xe, n), t.sy = p.easeOutQuad(e, 0, t.ye, n), this.pointerMove(t.startEvent, t.startEvent), t.i = u.request(this.boundSmoothEndFrame)) : (t.sx = t.xe, t.sy = t.ye, this.pointerMove(t.startEvent, t.startEvent), this.end(t.startEvent), t.smoothEnd = t.active = !1, this.simulation = null)
            }

            function s(t) {
                var e = t.inertiaStatus;
                if (e.active) {
                    var n = e.upCoords.page,
                        r = e.upCoords.client;
                    p.setCoords(t.curCoords, [{
                        pageX: n.x + e.sx,
                        pageY: n.y + e.sy,
                        clientX: r.x + e.sx,
                        clientY: r.y + e.sy
                    }])
                }
            }
            var a = t("./InteractEvent"),
                c = t("./Interaction"),
                l = t("./modifiers/base"),
                p = t("./utils"),
                u = t("./utils/raf");
            c.signals.on("new", function(t) {
                t.inertiaStatus = {
                    active: !1,
                    smoothEnd: !1,
                    allowResume: !1,
                    startEvent: null,
                    upCoords: {},
                    xe: 0,
                    ye: 0,
                    sx: 0,
                    sy: 0,
                    t0: 0,
                    vx0: 0,
                    vys: 0,
                    duration: 0,
                    lambda_v0: 0,
                    one_ve_v0: 0,
                    i: null
                }, t.boundInertiaFrame = function() {
                    return i.apply(t)
                }, t.boundSmoothEndFrame = function() {
                    return o.apply(t)
                }
            }), c.signals.on("down", function(t) {
                var e = t.interaction,
                    n = t.event,
                    r = t.pointer,
                    i = t.eventTarget,
                    o = e.inertiaStatus;
                if (o.active)
                    for (var s = i; p.is.element(s);) {
                        if (s === e.element) {
                            u.cancel(o.i), o.active = !1, e.simulation = null, e.updatePointer(r), p.setCoords(e.curCoords, e.pointers);
                            var d = {
                                interaction: e
                            };
                            c.signals.fire("before-action-move", d), c.signals.fire("action-resume", d);
                            var f = new a(e, n, e.prepared.name, "inertiaresume", e.element);
                            e.target.fire(f), e.prevEvent = f, l.resetStatuses(e.modifierStatuses), p.copyCoords(e.prevCoords, e.curCoords);
                            break
                        }
                        s = p.parentNode(s)
                    }
            }), c.signals.on("up", function(t) {
                var e = t.interaction,
                    n = t.event,
                    i = e.inertiaStatus;
                if (e.interacting() && !i.active) {
                    var o = e.target,
                        s = o && o.options,
                        c = s && e.prepared.name && s[e.prepared.name].inertia,
                        d = (new Date).getTime(),
                        f = {},
                        v = p.extend({}, e.curCoords.page),
                        g = e.pointerDelta.client.speed,
                        h = !1,
                        m = void 0,
                        y = c && c.enabled && "gesture" !== e.prepared.name && n !== i.startEvent,
                        x = y && d - e.curCoords.timeStamp < 50 && g > c.minSpeed && g > c.endSpeed,
                        b = {
                            interaction: e,
                            pageCoords: v,
                            statuses: f,
                            preEnd: !0,
                            requireEndOnly: !0
                        };
                    y && !x && (l.resetStatuses(f), m = l.setAll(b), m.shouldMove && m.locked && (h = !0)), (x || h) && (p.copyCoords(i.upCoords, e.curCoords), e.pointers[0] = i.startEvent = new a(e, n, e.prepared.name, "inertiastart", e.element), i.t0 = d, i.active = !0, i.allowResume = c.allowResume, e.simulation = i, o.fire(i.startEvent), x ? (i.vx0 = e.pointerDelta.client.vx, i.vy0 = e.pointerDelta.client.vy, i.v0 = g, r(e, i), p.extend(v, e.curCoords.page), v.x += i.xe, v.y += i.ye, l.resetStatuses(f), m = l.setAll(b), i.modifiedXe += m.dx, i.modifiedYe += m.dy, i.i = u.request(e.boundInertiaFrame)) : (i.smoothEnd = !0, i.xe = m.dx, i.ye = m.dy, i.sx = i.sy = 0, i.i = u.request(e.boundSmoothEndFrame)))
                }
            }), c.signals.on("stop-active", function(t) {
                var e = t.interaction,
                    n = e.inertiaStatus;
                n.active && (u.cancel(n.i), n.active = !1, e.simulation = null)
            })
        }, {
            "./InteractEvent": 3,
            "./Interaction": 5,
            "./modifiers/base": 23,
            "./utils": 44,
            "./utils/raf": 50
        }],
        21: [function(t, e, n) {
            "use strict";

            function r(t, e) {
                var n = a.interactables.get(t, e);
                return n || (n = new c(t, e), n.events.global = p), n
            }
            var i = t("./utils/browser"),
                o = t("./utils/events"),
                s = t("./utils"),
                a = t("./scope"),
                c = t("./Interactable"),
                l = t("./Interaction"),
                p = {};
            r.isSet = function(t, e) {
                return -1 !== a.interactables.indexOfElement(t, e && e.context)
            }, r.on = function(t, e, n) {
                if (s.is.string(t) && -1 !== t.search(" ") && (t = t.trim().split(/ +/)), s.is.array(t)) {
                    for (var i = 0; i < t.length; i++) {
                        var l;
                        l = t[i];
                        var u = l;
                        r.on(u, e, n)
                    }
                    return r
                }
                if (s.is.object(t)) {
                    for (var d in t) r.on(d, t[d], e);
                    return r
                }
                return s.contains(c.eventTypes, t) ? p[t] ? p[t].push(e) : p[t] = [e] : o.add(a.document, t, e, {
                    options: n
                }), r
            }, r.off = function(t, e, n) {
                if (s.is.string(t) && -1 !== t.search(" ") && (t = t.trim().split(/ +/)), s.is.array(t)) {
                    for (var i = 0; i < t.length; i++) {
                        var l;
                        l = t[i];
                        var u = l;
                        r.off(u, e, n)
                    }
                    return r
                }
                if (s.is.object(t)) {
                    for (var d in t) r.off(d, t[d], e);
                    return r
                }
                if (s.contains(c.eventTypes, t)) {
                    var f = void 0;
                    t in p && -1 !== (f = p[t].indexOf(e)) && p[t].splice(f, 1)
                } else o.remove(a.document, t, e, n);
                return r
            }, r.debug = function() {
                return a
            }, r.getPointerAverage = s.pointerAverage, r.getTouchBBox = s.touchBBox, r.getTouchDistance = s.touchDistance, r.getTouchAngle = s.touchAngle, r.getElementRect = s.getElementRect, r.getElementClientRect = s.getElementClientRect, r.matchesSelector = s.matchesSelector, r.closest = s.closest, r.supportsTouch = function() {
                return i.supportsTouch
            }, r.supportsPointerEvent = function() {
                return i.supportsPointerEvent
            }, r.stop = function(t) {
                for (var e = a.interactions.length - 1; e >= 0; e--) a.interactions[e].stop(t);
                return r
            }, r.pointerMoveTolerance = function(t) {
                return s.is.number(t) ? (l.pointerMoveTolerance = t, r) : l.pointerMoveTolerance
            }, r.addDocument = a.addDocument, r.removeDocument = a.removeDocument, a.interact = r, e.exports = r
        }, {
            "./Interactable": 4,
            "./Interaction": 5,
            "./scope": 33,
            "./utils": 44,
            "./utils/browser": 36,
            "./utils/events": 40
        }],
        22: [function(t, e, n) {
            "use strict";

            function r(t) {
                var e = t.interaction,
                    n = t.event;
                e.target && e.target.checkAndPreventDefault(n)
            }
            var i = t("./Interactable"),
                o = t("./Interaction"),
                s = t("./scope"),
                a = t("./utils/is"),
                c = t("./utils/events"),
                l = t("./utils/browser"),
                p = t("./utils/domUtils"),
                u = p.nodeContains,
                d = p.matchesSelector;
            i.prototype.preventDefault = function(t) {
                return /^(always|never|auto)$/.test(t) ? (this.options.preventDefault = t, this) : a.bool(t) ? (this.options.preventDefault = t ? "always" : "never", this) : this.options.preventDefault
            }, i.prototype.checkAndPreventDefault = function(t) {
                var e = this.options.preventDefault;
                if ("never" !== e) return "always" === e ? void t.preventDefault() : void(c.supportsPassive && /^touch(start|move)$/.test(t.type) && !l.isIOS || /^(mouse|pointer|touch)*(down|start)/i.test(t.type) || a.element(t.target) && d(t.target, "input,select,textarea,[contenteditable=true],[contenteditable=true] *") || t.preventDefault())
            };
            for (var f = ["down", "move", "up", "cancel"], v = 0; v < f.length; v++) {
                var g = f[v];
                o.signals.on(g, r)
            }
            o.docEvents.dragstart = function(t) {
                for (var e = 0; e < s.interactions.length; e++) {
                    var n;
                    n = s.interactions[e];
                    var r = n;
                    if (r.element && (r.element === t.target || u(r.element, t.target))) return void r.target.checkAndPreventDefault(t)
                }
            }
        }, {
            "./Interactable": 4,
            "./Interaction": 5,
            "./scope": 33,
            "./utils/browser": 36,
            "./utils/domUtils": 39,
            "./utils/events": 40,
            "./utils/is": 46
        }],
        23: [function(t, e, n) {
            "use strict";

            function r(t, e, n) {
                return t && t.enabled && (e || !t.endOnly) && (!n || t.endOnly)
            }
            var i = t("../InteractEvent"),
                o = t("../Interaction"),
                s = t("../utils/extend"),
                a = {
                    names: [],
                    setOffsets: function(t) {
                        var e = t.interaction,
                            n = t.pageCoords,
                            r = e.target,
                            i = e.element,
                            o = e.startOffset,
                            s = r.getRect(i);
                        s ? (o.left = n.x - s.left, o.top = n.y - s.top, o.right = s.right - n.x, o.bottom = s.bottom - n.y, "width" in s || (s.width = s.right - s.left), "height" in s || (s.height = s.bottom - s.top)) : o.left = o.top = o.right = o.bottom = 0, t.rect = s, t.interactable = r, t.element = i;
                        for (var c = 0; c < a.names.length; c++) {
                            var l;
                            l = a.names[c];
                            var p = l;
                            t.options = r.options[e.prepared.name][p], t.options && (e.modifierOffsets[p] = a[p].setOffset(t))
                        }
                    },
                    setAll: function(t) {
                        var e = t.interaction,
                            n = t.statuses,
                            i = t.preEnd,
                            o = t.requireEndOnly,
                            c = {
                                dx: 0,
                                dy: 0,
                                changed: !1,
                                locked: !1,
                                shouldMove: !0
                            };
                        t.modifiedCoords = s({}, t.pageCoords);
                        for (var l = 0; l < a.names.length; l++) {
                            var p;
                            p = a.names[l];
                            var u = p,
                                d = a[u],
                                f = e.target.options[e.prepared.name][u];
                            r(f, i, o) && (t.status = t.status = n[u], t.options = f, t.offset = t.interaction.modifierOffsets[u], d.set(t), t.status.locked && (t.modifiedCoords.x += t.status.dx, t.modifiedCoords.y += t.status.dy, c.dx += t.status.dx, c.dy += t.status.dy, c.locked = !0))
                        }
                        return c.shouldMove = !t.status || !c.locked || t.status.changed, c
                    },
                    resetStatuses: function(t) {
                        for (var e = 0; e < a.names.length; e++) {
                            var n;
                            n = a.names[e];
                            var r = n,
                                i = t[r] || {};
                            i.dx = i.dy = 0, i.modifiedX = i.modifiedY = NaN, i.locked = !1, i.changed = !0, t[r] = i
                        }
                        return t
                    },
                    start: function(t, e) {
                        var n = t.interaction,
                            r = {
                                interaction: n,
                                pageCoords: ("action-resume" === e ? n.curCoords : n.startCoords).page,
                                startOffset: n.startOffset,
                                statuses: n.modifierStatuses,
                                preEnd: !1,
                                requireEndOnly: !1
                            };
                        a.setOffsets(r), a.resetStatuses(r.statuses), r.pageCoords = s({}, n.startCoords.page), n.modifierResult = a.setAll(r)
                    },
                    beforeMove: function(t) {
                        var e = t.interaction,
                            n = t.preEnd,
                            r = t.interactingBeforeMove,
                            i = a.setAll({
                                interaction: e,
                                preEnd: n,
                                pageCoords: e.curCoords.page,
                                statuses: e.modifierStatuses,
                                requireEndOnly: !1
                            });
                        !i.shouldMove && r && (e._dontFireMove = !0), e.modifierResult = i
                    },
                    end: function(t) {
                        for (var e = t.interaction, n = t.event, i = 0; i < a.names.length; i++) {
                            var o;
                            o = a.names[i];
                            var s = o;
                            if (r(e.target.options[e.prepared.name][s], !0, !0)) {
                                e.doMove({
                                    event: n,
                                    preEnd: !0
                                });
                                break
                            }
                        }
                    },
                    setXY: function(t) {
                        for (var e = t.iEvent, n = t.interaction, r = s({}, t), i = 0; i < a.names.length; i++) {
                            var o = a.names[i];
                            if (r.options = n.target.options[n.prepared.name][o], r.options) {
                                var c = a[o];
                                r.status = n.modifierStatuses[o], e[o] = c.modifyCoords(r)
                            }
                        }
                    }
                };
            o.signals.on("new", function(t) {
                t.startOffset = {
                    left: 0,
                    right: 0,
                    top: 0,
                    bottom: 0
                }, t.modifierOffsets = {}, t.modifierStatuses = a.resetStatuses({}), t.modifierResult = null
            }), o.signals.on("action-start", a.start), o.signals.on("action-resume", a.start), o.signals.on("before-action-move", a.beforeMove), o.signals.on("action-end", a.end), i.signals.on("set-xy", a.setXY), e.exports = a
        }, {
            "../InteractEvent": 3,
            "../Interaction": 5,
            "../utils/extend": 41
        }],
        24: [function(t, e, n) {
            "use strict";

            function r(t, e, n) {
                return o.is.function(t) ? o.resolveRectLike(t, e.target, e.element, [n.x, n.y, e]) : o.resolveRectLike(t, e.target, e.element)
            }
            var i = t("./base"),
                o = t("../utils"),
                s = t("../defaultOptions"),
                a = {
                    defaults: {
                        enabled: !1,
                        endOnly: !1,
                        restriction: null,
                        elementRect: null
                    },
                    setOffset: function(t) {
                        var e = t.rect,
                            n = t.startOffset,
                            r = t.options,
                            i = r && r.elementRect,
                            o = {};
                        return e && i ? (o.left = n.left - e.width * i.left, o.top = n.top - e.height * i.top, o.right = n.right - e.width * (1 - i.right), o.bottom = n.bottom - e.height * (1 - i.bottom)) : o.left = o.top = o.right = o.bottom = 0, o
                    },
                    set: function(t) {
                        var e = t.modifiedCoords,
                            n = t.interaction,
                            i = t.status,
                            s = t.options;
                        if (!s) return i;
                        var a = i.useStatusXY ? {
                                x: i.x,
                                y: i.y
                            } : o.extend({}, e),
                            c = r(s.restriction, n, a);
                        if (!c) return i;
                        i.dx = 0, i.dy = 0, i.locked = !1;
                        var l = c,
                            p = a.x,
                            u = a.y,
                            d = n.modifierOffsets.restrict;
                        "x" in c && "y" in c ? (p = Math.max(Math.min(l.x + l.width - d.right, a.x), l.x + d.left), u = Math.max(Math.min(l.y + l.height - d.bottom, a.y), l.y + d.top)) : (p = Math.max(Math.min(l.right - d.right, a.x), l.left + d.left), u = Math.max(Math.min(l.bottom - d.bottom, a.y), l.top + d.top)), i.dx = p - a.x, i.dy = u - a.y, i.changed = i.modifiedX !== p || i.modifiedY !== u, i.locked = !(!i.dx && !i.dy), i.modifiedX = p, i.modifiedY = u
                    },
                    modifyCoords: function(t) {
                        var e = t.page,
                            n = t.client,
                            r = t.status,
                            i = t.phase,
                            o = t.options,
                            s = o && o.elementRect;
                        if (o && o.enabled && ("start" !== i || !s || !r.locked) && r.locked) return e.x += r.dx, e.y += r.dy, n.x += r.dx, n.y += r.dy, {
                            dx: r.dx,
                            dy: r.dy
                        }
                    },
                    getRestrictionRect: r
                };
            i.restrict = a, i.names.push("restrict"), s.perAction.restrict = a.defaults, e.exports = a
        }, {
            "../defaultOptions": 18,
            "../utils": 44,
            "./base": 23
        }],
        25: [function(t, e, n) {
            "use strict";
            var r = t("./base"),
                i = t("../utils"),
                o = t("../utils/rect"),
                s = t("../defaultOptions"),
                a = t("../actions/resize"),
                c = t("./restrict"),
                l = c.getRestrictionRect,
                p = {
                    top: 1 / 0,
                    left: 1 / 0,
                    bottom: -1 / 0,
                    right: -1 / 0
                },
                u = {
                    top: -1 / 0,
                    left: -1 / 0,
                    bottom: 1 / 0,
                    right: 1 / 0
                },
                d = {
                    defaults: {
                        enabled: !1,
                        endOnly: !1,
                        min: null,
                        max: null,
                        offset: null
                    },
                    setOffset: function(t) {
                        var e = t.interaction,
                            n = t.startOffset,
                            r = t.options;
                        if (!r) return i.extend({}, n);
                        var o = l(r.offset, e, e.startCoords.page);
                        return o ? {
                            top: n.top + o.y,
                            left: n.left + o.x,
                            bottom: n.bottom + o.y,
                            right: n.right + o.x
                        } : n
                    },
                    set: function(t) {
                        var e = t.modifiedCoords,
                            n = t.interaction,
                            r = t.status,
                            s = t.offset,
                            a = t.options,
                            c = n.prepared.linkedEdges || n.prepared.edges;
                        if (n.interacting() && c) {
                            var d = r.useStatusXY ? {
                                    x: r.x,
                                    y: r.y
                                } : i.extend({}, e),
                                f = o.xywhToTlbr(l(a.inner, n, d)) || p,
                                v = o.xywhToTlbr(l(a.outer, n, d)) || u,
                                g = d.x,
                                h = d.y;
                            r.dx = 0, r.dy = 0, r.locked = !1, c.top ? h = Math.min(Math.max(v.top + s.top, d.y), f.top + s.top) : c.bottom && (h = Math.max(Math.min(v.bottom - s.bottom, d.y), f.bottom - s.bottom)), c.left ? g = Math.min(Math.max(v.left + s.left, d.x), f.left + s.left) : c.right && (g = Math.max(Math.min(v.right - s.right, d.x), f.right - s.right)), r.dx = g - d.x, r.dy = h - d.y, r.changed = r.modifiedX !== g || r.modifiedY !== h, r.locked = !(!r.dx && !r.dy), r.modifiedX = g, r.modifiedY = h
                        }
                    },
                    modifyCoords: function(t) {
                        var e = t.page,
                            n = t.client,
                            r = t.status,
                            i = t.phase,
                            o = t.options;
                        if (o && o.enabled && ("start" !== i || !r.locked) && r.locked) return e.x += r.dx, e.y += r.dy, n.x += r.dx, n.y += r.dy, {
                            dx: r.dx,
                            dy: r.dy
                        }
                    },
                    noInner: p,
                    noOuter: u,
                    getRestrictionRect: l
                };
            r.restrictEdges = d, r.names.push("restrictEdges"), s.perAction.restrictEdges = d.defaults, a.defaults.restrictEdges = d.defaults, e.exports = d
        }, {
            "../actions/resize": 10,
            "../defaultOptions": 18,
            "../utils": 44,
            "../utils/rect": 51,
            "./base": 23,
            "./restrict": 24
        }],
        26: [function(t, e, n) {
            "use strict";
            var r = t("./base"),
                i = t("./restrictEdges"),
                o = t("../utils"),
                s = t("../utils/rect"),
                a = t("../defaultOptions"),
                c = t("../actions/resize"),
                l = {
                    width: -1 / 0,
                    height: -1 / 0
                },
                p = {
                    width: 1 / 0,
                    height: 1 / 0
                },
                u = {
                    defaults: {
                        enabled: !1,
                        endOnly: !1,
                        min: null,
                        max: null
                    },
                    setOffset: function(t) {
                        return t.interaction.startOffset
                    },
                    set: function(t) {
                        var e = t.interaction,
                            n = t.options,
                            r = e.prepared.linkedEdges || e.prepared.edges;
                        if (e.interacting() && r) {
                            var a = s.xywhToTlbr(e.resizeRects.inverted),
                                c = s.tlbrToXywh(i.getRestrictionRect(n.min, e)) || l,
                                u = s.tlbrToXywh(i.getRestrictionRect(n.max, e)) || p;
                            t.options = {
                                enabled: n.enabled,
                                endOnly: n.endOnly,
                                inner: o.extend({}, i.noInner),
                                outer: o.extend({}, i.noOuter)
                            }, r.top ? (t.options.inner.top = a.bottom - c.height, t.options.outer.top = a.bottom - u.height) : r.bottom && (t.options.inner.bottom = a.top + c.height, t.options.outer.bottom = a.top + u.height), r.left ? (t.options.inner.left = a.right - c.width, t.options.outer.left = a.right - u.width) : r.right && (t.options.inner.right = a.left + c.width, t.options.outer.right = a.left + u.width), i.set(t)
                        }
                    },
                    modifyCoords: i.modifyCoords
                };
            r.restrictSize = u, r.names.push("restrictSize"), a.perAction.restrictSize = u.defaults, c.defaults.restrictSize = u.defaults, e.exports = u
        }, {
            "../actions/resize": 10,
            "../defaultOptions": 18,
            "../utils": 44,
            "../utils/rect": 51,
            "./base": 23,
            "./restrictEdges": 25
        }],
        27: [function(t, e, n) {
            "use strict";
            var r = t("./base"),
                i = t("../interact"),
                o = t("../utils"),
                s = t("../defaultOptions"),
                a = {
                    defaults: {
                        enabled: !1,
                        endOnly: !1,
                        range: 1 / 0,
                        targets: null,
                        offsets: null,
                        relativePoints: null
                    },
                    setOffset: function(t) {
                        var e = t.interaction,
                            n = t.interactable,
                            r = t.element,
                            i = t.rect,
                            s = t.startOffset,
                            a = t.options,
                            c = [],
                            l = o.rectToXY(o.resolveRectLike(a.origin)),
                            p = l || o.getOriginXY(n, r, e.prepared.name);
                        a = a || n.options[e.prepared.name].snap || {};
                        var u = void 0;
                        if ("startCoords" === a.offset) u = {
                            x: e.startCoords.page.x - p.x,
                            y: e.startCoords.page.y - p.y
                        };
                        else {
                            var d = o.resolveRectLike(a.offset, n, r, [e]);
                            u = o.rectToXY(d) || {
                                x: 0,
                                y: 0
                            }
                        }
                        if (i && a.relativePoints && a.relativePoints.length)
                            for (var f = 0; f < a.relativePoints.length; f++) {
                                var v;
                                v = a.relativePoints[f];
                                var g = v,
                                    h = g.x,
                                    m = g.y;
                                c.push({
                                    x: s.left - i.width * h + u.x,
                                    y: s.top - i.height * m + u.y
                                })
                            } else c.push(u);
                        return c
                    },
                    set: function(t) {
                        var e = t.interaction,
                            n = t.modifiedCoords,
                            r = t.status,
                            i = t.options,
                            s = t.offset,
                            a = [],
                            c = void 0,
                            l = void 0,
                            p = void 0;
                        if (r.useStatusXY) l = {
                            x: r.x,
                            y: r.y
                        };
                        else {
                            var u = o.getOriginXY(e.target, e.element, e.prepared.name);
                            l = o.extend({}, n), l.x -= u.x, l.y -= u.y
                        }
                        r.realX = l.x, r.realY = l.y;
                        for (var d = i.targets ? i.targets.length : 0, f = 0; f < s.length; f++) {
                            var v;
                            v = s[f];
                            for (var g = v, h = g.x, m = g.y, y = l.x - h, x = l.y - m, b = 0; b < (i.targets || []).length; b++) {
                                var w;
                                w = (i.targets || [])[b];
                                var E = w;
                                c = o.is.function(E) ? E(y, x, e) : E, c && a.push({
                                    x: o.is.number(c.x) ? c.x + h : y,
                                    y: o.is.number(c.y) ? c.y + m : x,
                                    range: o.is.number(c.range) ? c.range : i.range
                                })
                            }
                        }
                        var T = {
                            target: null,
                            inRange: !1,
                            distance: 0,
                            range: 0,
                            dx: 0,
                            dy: 0
                        };
                        for (p = 0, d = a.length; p < d; p++) {
                            c = a[p];
                            var S = c.range,
                                C = c.x - l.x,
                                I = c.y - l.y,
                                D = o.hypot(C, I),
                                O = D <= S;
                            S === 1 / 0 && T.inRange && T.range !== 1 / 0 && (O = !1), T.target && !(O ? T.inRange && S !== 1 / 0 ? D / S < T.distance / T.range : S === 1 / 0 && T.range !== 1 / 0 || D < T.distance : !T.inRange && D < T.distance) || (T.target = c, T.distance = D, T.range = S, T.inRange = O, T.dx = C, T.dy = I, r.range = S)
                        }
                        var M = void 0;
                        T.target ? (M = r.modifiedX !== T.target.x || r.modifiedY !== T.target.y, r.modifiedX = T.target.x, r.modifiedY = T.target.y) : (M = !0, r.modifiedX = NaN, r.modifiedY = NaN), r.dx = T.dx, r.dy = T.dy, r.changed = M || T.inRange && !r.locked, r.locked = T.inRange
                    },
                    modifyCoords: function(t) {
                        var e = t.page,
                            n = t.client,
                            r = t.status,
                            i = t.phase,
                            o = t.options,
                            s = o && o.relativePoints;
                        if (o && o.enabled && ("start" !== i || !s || !s.length)) return r.locked && (e.x += r.dx, e.y += r.dy, n.x += r.dx, n.y += r.dy), {
                            range: r.range,
                            locked: r.locked,
                            x: r.modifiedX,
                            y: r.modifiedY,
                            realX: r.realX,
                            realY: r.realY,
                            dx: r.dx,
                            dy: r.dy
                        }
                    }
                };
            i.createSnapGrid = function(t) {
                return function(e, n) {
                    var r = t.limits || {
                            left: -1 / 0,
                            right: 1 / 0,
                            top: -1 / 0,
                            bottom: 1 / 0
                        },
                        i = 0,
                        s = 0;
                    o.is.object(t.offset) && (i = t.offset.x, s = t.offset.y);
                    var a = Math.round((e - i) / t.x),
                        c = Math.round((n - s) / t.y);
                    return {
                        x: Math.max(r.left, Math.min(r.right, a * t.x + i)),
                        y: Math.max(r.top, Math.min(r.bottom, c * t.y + s)),
                        range: t.range
                    }
                }
            }, r.snap = a, r.names.push("snap"), s.perAction.snap = a.defaults, e.exports = a
        }, {
            "../defaultOptions": 18,
            "../interact": 21,
            "../utils": 44,
            "./base": 23
        }],
        28: [function(t, e, n) {
            "use strict";
            var r = t("./base"),
                i = t("./snap"),
                o = t("../defaultOptions"),
                s = t("../actions/resize"),
                a = t("../utils/"),
                c = {
                    defaults: {
                        enabled: !1,
                        endOnly: !1,
                        range: 1 / 0,
                        targets: null,
                        offsets: null
                    },
                    setOffset: function(t) {
                        var e = t.interaction,
                            n = t.options,
                            r = e.prepared.edges;
                        if (r) {
                            t.options = {
                                relativePoints: [{
                                    x: r.left ? 0 : 1,
                                    y: r.top ? 0 : 1
                                }],
                                origin: {
                                    x: 0,
                                    y: 0
                                },
                                offset: "self",
                                range: n.range
                            };
                            var o = i.setOffset(t);
                            return t.options = n, o
                        }
                    },
                    set: function(t) {
                        var e = t.interaction,
                            n = t.options,
                            r = t.offset,
                            o = t.modifiedCoords,
                            s = a.extend({}, o),
                            c = s.x - r[0].x,
                            l = s.y - r[0].y;
                        t.options = a.extend({}, n), t.options.targets = [];
                        for (var p = 0; p < (n.targets || []).length; p++) {
                            var u;
                            u = (n.targets || [])[p];
                            var d = u,
                                f = void 0;
                            f = a.is.function(d) ? d(c, l, e) : d, f && ("width" in f && "height" in f && (f.x = f.width, f.y = f.height), t.options.targets.push(f))
                        }
                        i.set(t)
                    },
                    modifyCoords: function(t) {
                        var e = t.options;
                        t.options = a.extend({}, e), t.options.enabled = e.enabled, t.options.relativePoints = [null], i.modifyCoords(t)
                    }
                };
            r.snapSize = c, r.names.push("snapSize"), o.perAction.snapSize = c.defaults, s.defaults.snapSize = c.defaults, e.exports = c
        }, {
            "../actions/resize": 10,
            "../defaultOptions": 18,
            "../utils/": 44,
            "./base": 23,
            "./snap": 27
        }],
        29: [function(t, e, n) {
            "use strict";

            function r(t, e) {
                if (!(t instanceof e)) throw new TypeError("Cannot call a class as a function")
            }
            var i = t("../utils/pointerUtils");
            e.exports = function() {
                function t(e, n, o, s, a) {
                    if (r(this, t), i.pointerExtend(this, o), o !== n && i.pointerExtend(this, n), this.interaction = a, this.timeStamp = (new Date).getTime(), this.originalEvent = o, this.type = e, this.pointerId = i.getPointerId(n), this.pointerType = i.getPointerType(n), this.target = s, this.currentTarget = null, "tap" === e) {
                        var c = a.getPointerIndex(n);
                        this.dt = this.timeStamp - a.downTimes[c];
                        var l = this.timeStamp - a.tapTime;
                        this.double = !!(a.prevTap && "doubletap" !== a.prevTap.type && a.prevTap.target === this.target && l < 500)
                    } else "doubletap" === e && (this.dt = n.timeStamp - a.tapTime)
                }
                return t.prototype.subtractOrigin = function(t) {
                    var e = t.x,
                        n = t.y;
                    return this.pageX -= e, this.pageY -= n, this.clientX -= e, this.clientY -= n, this
                }, t.prototype.addOrigin = function(t) {
                    var e = t.x,
                        n = t.y;
                    return this.pageX += e, this.pageY += n, this.clientX += e, this.clientY += n, this
                }, t.prototype.preventDefault = function() {
                    this.originalEvent.preventDefault()
                }, t.prototype.stopPropagation = function() {
                    this.propagationStopped = !0
                }, t.prototype.stopImmediatePropagation = function() {
                    this.immediatePropagationStopped = this.propagationStopped = !0
                }, t
            }()
        }, {
            "../utils/pointerUtils": 49
        }],
        30: [function(t, e, n) {
            "use strict";

            function r(t) {
                for (var e = t.interaction, n = t.pointer, s = t.event, c = t.eventTarget, p = t.type, u = void 0 === p ? t.pointerEvent.type : p, d = t.targets, f = void 0 === d ? i(t) : d, v = t.pointerEvent, g = void 0 === v ? new o(u, n, s, c, e) : v, h = {
                        interaction: e,
                        pointer: n,
                        event: s,
                        eventTarget: c,
                        targets: f,
                        type: u,
                        pointerEvent: g
                    }, m = 0; m < f.length; m++) {
                    var y = f[m];
                    for (var x in y.props || {}) g[x] = y.props[x];
                    var b = a.getOriginXY(y.eventable, y.element);
                    if (g.subtractOrigin(b), g.eventable = y.eventable, g.currentTarget = y.element, y.eventable.fire(g), g.addOrigin(b), g.immediatePropagationStopped || g.propagationStopped && m + 1 < f.length && f[m + 1].element !== g.currentTarget) break
                }
                if (l.fire("fired", h), "tap" === u) {
                    var w = g.double ? r({
                        interaction: e,
                        pointer: n,
                        event: s,
                        eventTarget: c,
                        type: "doubletap"
                    }) : g;
                    e.prevTap = w, e.tapTime = w.timeStamp
                }
                return g
            }

            function i(t) {
                var e = t.interaction,
                    n = t.pointer,
                    r = t.event,
                    i = t.eventTarget,
                    o = t.type,
                    s = e.getPointerIndex(n);
                if ("tap" === o && (e.pointerWasMoved || !e.downTargets[s] || e.downTargets[s] !== i)) return [];
                for (var c = a.getPath(i), p = {
                        interaction: e,
                        pointer: n,
                        event: r,
                        eventTarget: i,
                        type: o,
                        path: c,
                        targets: [],
                        element: null
                    }, u = 0; u < c.length; u++) {
                    var d;
                    d = c[u];
                    var f = d;
                    p.element = f, l.fire("collect-targets", p)
                }
                return "hold" === o && (p.targets = p.targets.filter(function(t) {
                    return t.eventable.options.holdDuration === e.holdTimers[s].duration
                })), p.targets
            }
            var o = t("./PointerEvent"),
                s = t("../Interaction"),
                a = t("../utils"),
                c = t("../defaultOptions"),
                l = t("../utils/Signals").new(),
                p = ["down", "up", "cancel"],
                u = ["down", "up", "cancel"],
                d = {
                    PointerEvent: o,
                    fire: r,
                    collectEventTargets: i,
                    signals: l,
                    defaults: {
                        holdDuration: 600,
                        ignoreFrom: null,
                        allowFrom: null,
                        origin: {
                            x: 0,
                            y: 0
                        }
                    },
                    types: ["down", "move", "up", "cancel", "tap", "doubletap", "hold"]
                };
            s.signals.on("update-pointer-down", function(t) {
                    var e = t.interaction,
                        n = t.pointerIndex;
                    e.holdTimers[n] = {
                        duration: 1 / 0,
                        timeout: null
                    }
                }), s.signals.on("remove-pointer", function(t) {
                    var e = t.interaction,
                        n = t.pointerIndex;
                    e.holdTimers.splice(n, 1)
                }),
                s.signals.on("move", function(t) {
                    var e = t.interaction,
                        n = t.pointer,
                        i = t.event,
                        o = t.eventTarget,
                        s = t.duplicateMove,
                        a = e.getPointerIndex(n);
                    s || e.pointerIsDown && !e.pointerWasMoved || (e.pointerIsDown && clearTimeout(e.holdTimers[a].timeout), r({
                        interaction: e,
                        pointer: n,
                        event: i,
                        eventTarget: o,
                        type: "move"
                    }))
                }), s.signals.on("down", function(t) {
                    for (var e = t.interaction, n = t.pointer, i = t.event, o = t.eventTarget, s = t.pointerIndex, c = e.holdTimers[s], p = a.getPath(o), u = {
                            interaction: e,
                            pointer: n,
                            event: i,
                            eventTarget: o,
                            type: "hold",
                            targets: [],
                            path: p,
                            element: null
                        }, d = 0; d < p.length; d++) {
                        var f;
                        f = p[d];
                        var v = f;
                        u.element = v, l.fire("collect-targets", u)
                    }
                    if (u.targets.length) {
                        for (var g = 1 / 0, h = 0; h < u.targets.length; h++) {
                            var m;
                            m = u.targets[h];
                            var y = m,
                                x = y.eventable.options.holdDuration;
                            x < g && (g = x)
                        }
                        c.duration = g, c.timeout = setTimeout(function() {
                            r({
                                interaction: e,
                                eventTarget: o,
                                pointer: n,
                                event: i,
                                type: "hold"
                            })
                        }, g)
                    }
                }), s.signals.on("up", function(t) {
                    var e = t.interaction,
                        n = t.pointer,
                        i = t.event,
                        o = t.eventTarget;
                    e.pointerWasMoved || r({
                        interaction: e,
                        eventTarget: o,
                        pointer: n,
                        event: i,
                        type: "tap"
                    })
                });
            for (var f = ["up", "cancel"], v = 0; v < f.length; v++) {
                var g = f[v];
                s.signals.on(g, function(t) {
                    var e = t.interaction,
                        n = t.pointerIndex;
                    e.holdTimers[n] && clearTimeout(e.holdTimers[n].timeout)
                })
            }
            for (var h = 0; h < p.length; h++) s.signals.on(p[h], function(t) {
                return function(e) {
                    var n = e.interaction,
                        i = e.pointer,
                        o = e.event;
                    r({
                        interaction: n,
                        eventTarget: e.eventTarget,
                        pointer: i,
                        event: o,
                        type: t
                    })
                }
            }(u[h]));
            s.signals.on("new", function(t) {
                t.prevTap = null, t.tapTime = 0, t.holdTimers = []
            }), c.pointerEvents = d.defaults, e.exports = d
        }, {
            "../Interaction": 5,
            "../defaultOptions": 18,
            "../utils": 44,
            "../utils/Signals": 34,
            "./PointerEvent": 29
        }],
        31: [function(t, e, n) {
            "use strict";

            function r(t) {
                var e = t.pointerEvent;
                "hold" === e.type && (e.count = (e.count || 0) + 1)
            }

            function i(t) {
                var e = t.interaction,
                    n = t.pointerEvent,
                    r = t.eventTarget,
                    i = t.targets;
                if ("hold" === n.type && i.length) {
                    var o = i[0].eventable.options.holdRepeatInterval;
                    o <= 0 || (e.holdIntervalHandle = setTimeout(function() {
                        s.fire({
                            interaction: e,
                            eventTarget: r,
                            type: "hold",
                            pointer: n,
                            event: n
                        })
                    }, o))
                }
            }

            function o(t) {
                var e = t.interaction;
                e.holdIntervalHandle && (clearInterval(e.holdIntervalHandle), e.holdIntervalHandle = null)
            }
            var s = t("./base"),
                a = t("../Interaction");
            s.signals.on("new", r), s.signals.on("fired", i);
            for (var c = ["move", "up", "cancel", "endall"], l = 0; l < c.length; l++) {
                var p = c[l];
                a.signals.on(p, o)
            }
            s.defaults.holdRepeatInterval = 0, s.types.push("holdrepeat"), e.exports = {
                onNew: r,
                onFired: i,
                endHoldRepeat: o
            }
        }, {
            "../Interaction": 5,
            "./base": 30
        }],
        32: [function(t, e, n) {
            "use strict";
            var r = t("./base"),
                i = t("../Interactable"),
                o = t("../utils/is"),
                s = t("../scope"),
                a = t("../utils/extend"),
                c = t("../utils/arr"),
                l = c.merge;
            r.signals.on("collect-targets", function(t) {
                var e = t.targets,
                    n = t.element,
                    r = t.type,
                    i = t.eventTarget;
                s.interactables.forEachMatch(n, function(t) {
                    var s = t.events,
                        a = s.options;
                    s[r] && o.element(n) && t.testIgnoreAllow(a, n, i) && e.push({
                        element: n,
                        eventable: s,
                        props: {
                            interactable: t
                        }
                    })
                })
            }), i.signals.on("new", function(t) {
                var e = t.interactable;
                e.events.getRect = function(t) {
                    return e.getRect(t)
                }
            }), i.signals.on("set", function(t) {
                var e = t.interactable,
                    n = t.options;
                a(e.events.options, r.defaults), a(e.events.options, n)
            }), l(i.eventTypes, r.types), i.prototype.pointerEvents = function(t) {
                return a(this.events.options, t), this
            };
            var p = i.prototype._backCompatOption;
            i.prototype._backCompatOption = function(t, e) {
                var n = p.call(this, t, e);
                return n === this && (this.events.options[t] = e), n
            }, i.settingsMethods.push("pointerEvents")
        }, {
            "../Interactable": 4,
            "../scope": 33,
            "../utils/arr": 35,
            "../utils/extend": 41,
            "../utils/is": 46,
            "./base": 30
        }],
        33: [function(t, e, n) {
            "use strict";
            var r = t("./utils"),
                i = t("./utils/events"),
                o = t("./utils/Signals").new(),
                s = t("./utils/window"),
                a = s.getWindow,
                c = {
                    signals: o,
                    events: i,
                    utils: r,
                    document: t("./utils/domObjects").document,
                    documents: [],
                    addDocument: function(t, e) {
                        if (r.contains(c.documents, t)) return !1;
                        e = e || a(t), c.documents.push(t), i.documents.push(t), t !== c.document && i.add(e, "unload", c.onWindowUnload), o.fire("add-document", {
                            doc: t,
                            win: e
                        })
                    },
                    removeDocument: function(t, e) {
                        var n = c.documents.indexOf(t);
                        e = e || a(t), i.remove(e, "unload", c.onWindowUnload), c.documents.splice(n, 1), i.documents.splice(n, 1), o.fire("remove-document", {
                            win: e,
                            doc: t
                        })
                    },
                    onWindowUnload: function() {
                        c.removeDocument(this.document, this)
                    }
                };
            e.exports = c
        }, {
            "./utils": 44,
            "./utils/Signals": 34,
            "./utils/domObjects": 38,
            "./utils/events": 40,
            "./utils/window": 52
        }],
        34: [function(t, e, n) {
            "use strict";

            function r(t, e) {
                if (!(t instanceof e)) throw new TypeError("Cannot call a class as a function")
            }
            var i = function() {
                function t() {
                    r(this, t), this.listeners = {}
                }
                return t.prototype.on = function(t, e) {
                    if (!this.listeners[t]) return void(this.listeners[t] = [e]);
                    this.listeners[t].push(e)
                }, t.prototype.off = function(t, e) {
                    if (this.listeners[t]) {
                        var n = this.listeners[t].indexOf(e); - 1 !== n && this.listeners[t].splice(n, 1)
                    }
                }, t.prototype.fire = function(t, e) {
                    var n = this.listeners[t];
                    if (n)
                        for (var r = 0; r < n.length; r++) {
                            var i;
                            i = n[r];
                            var o = i;
                            if (!1 === o(e, t)) return
                        }
                }, t
            }();
            i.new = function() {
                return new i
            }, e.exports = i
        }, {}],
        35: [function(t, e, n) {
            "use strict";

            function r(t, e) {
                return -1 !== t.indexOf(e)
            }

            function i(t, e) {
                for (var n = 0; n < e.length; n++) {
                    var r;
                    r = e[n];
                    var i = r;
                    t.push(i)
                }
                return t
            }
            e.exports = {
                contains: r,
                merge: i
            }
        }, {}],
        36: [function(t, e, n) {
            "use strict";
            var r = t("./window"),
                i = r.window,
                o = t("./is"),
                s = t("./domObjects"),
                a = s.Element,
                c = i.navigator,
                l = {
                    supportsTouch: !!("ontouchstart" in i || o.function(i.DocumentTouch) && s.document instanceof i.DocumentTouch),
                    supportsPointerEvent: !!s.PointerEvent,
                    isIOS: /iP(hone|od|ad)/.test(c.platform),
                    isIOS7: /iP(hone|od|ad)/.test(c.platform) && /OS 7[^\d]/.test(c.appVersion),
                    isIe9: /MSIE 9/.test(c.userAgent),
                    prefixedMatchesSelector: "matches" in a.prototype ? "matches" : "webkitMatchesSelector" in a.prototype ? "webkitMatchesSelector" : "mozMatchesSelector" in a.prototype ? "mozMatchesSelector" : "oMatchesSelector" in a.prototype ? "oMatchesSelector" : "msMatchesSelector",
                    pEventTypes: s.PointerEvent ? s.PointerEvent === i.MSPointerEvent ? {
                        up: "MSPointerUp",
                        down: "MSPointerDown",
                        over: "mouseover",
                        out: "mouseout",
                        move: "MSPointerMove",
                        cancel: "MSPointerCancel"
                    } : {
                        up: "pointerup",
                        down: "pointerdown",
                        over: "pointerover",
                        out: "pointerout",
                        move: "pointermove",
                        cancel: "pointercancel"
                    } : null,
                    wheelEvent: "onmousewheel" in s.document ? "mousewheel" : "wheel"
                };
            l.isOperaMobile = "Opera" === c.appName && l.supportsTouch && c.userAgent.match("Presto"), e.exports = l
        }, {
            "./domObjects": 38,
            "./is": 46,
            "./window": 52
        }],
        37: [function(t, e, n) {
            "use strict";
            var r = t("./is");
            e.exports = function t(e) {
                var n = {};
                for (var i in e) r.plainObject(e[i]) ? n[i] = t(e[i]) : n[i] = e[i];
                return n
            }
        }, {
            "./is": 46
        }],
        38: [function(t, e, n) {
            "use strict";

            function r() {}
            var i = {},
                o = t("./window").window;
            i.document = o.document, i.DocumentFragment = o.DocumentFragment || r, i.SVGElement = o.SVGElement || r, i.SVGSVGElement = o.SVGSVGElement || r, i.SVGElementInstance = o.SVGElementInstance || r, i.Element = o.Element || r, i.HTMLElement = o.HTMLElement || i.Element, i.Event = o.Event, i.Touch = o.Touch || r, i.PointerEvent = o.PointerEvent || o.MSPointerEvent, e.exports = i
        }, {
            "./window": 52
        }],
        39: [function(t, e, n) {
            "use strict";
            var r = t("./window"),
                i = t("./browser"),
                o = t("./is"),
                s = t("./domObjects"),
                a = {
                    nodeContains: function(t, e) {
                        for (; e;) {
                            if (e === t) return !0;
                            e = e.parentNode
                        }
                        return !1
                    },
                    closest: function(t, e) {
                        for (; o.element(t);) {
                            if (a.matchesSelector(t, e)) return t;
                            t = a.parentNode(t)
                        }
                        return null
                    },
                    parentNode: function(t) {
                        var e = t.parentNode;
                        if (o.docFrag(e)) {
                            for (;
                                (e = e.host) && o.docFrag(e););
                            return e
                        }
                        return e
                    },
                    matchesSelector: function(t, e) {
                        return r.window !== r.realWindow && (e = e.replace(/\/deep\//g, " ")), t[i.prefixedMatchesSelector](e)
                    },
                    indexOfDeepestElement: function(t) {
                        var e = [],
                            n = [],
                            r = void 0,
                            i = t[0],
                            o = i ? 0 : -1,
                            a = void 0,
                            c = void 0,
                            l = void 0,
                            p = void 0;
                        for (l = 1; l < t.length; l++)
                            if ((r = t[l]) && r !== i)
                                if (i) {
                                    if (r.parentNode !== r.ownerDocument)
                                        if (i.parentNode !== r.ownerDocument) {
                                            if (!e.length)
                                                for (a = i; a.parentNode && a.parentNode !== a.ownerDocument;) e.unshift(a), a = a.parentNode;
                                            if (i instanceof s.HTMLElement && r instanceof s.SVGElement && !(r instanceof s.SVGSVGElement)) {
                                                if (r === i.parentNode) continue;
                                                a = r.ownerSVGElement
                                            } else a = r;
                                            for (n = []; a.parentNode !== a.ownerDocument;) n.unshift(a), a = a.parentNode;
                                            for (p = 0; n[p] && n[p] === e[p];) p++;
                                            var u = [n[p - 1], n[p], e[p]];
                                            for (c = u[0].lastChild; c;) {
                                                if (c === u[1]) {
                                                    i = r, o = l, e = [];
                                                    break
                                                }
                                                if (c === u[2]) break;
                                                c = c.previousSibling
                                            }
                                        } else i = r, o = l
                                } else i = r, o = l;
                        return o
                    },
                    matchesUpTo: function(t, e, n) {
                        for (; o.element(t);) {
                            if (a.matchesSelector(t, e)) return !0;
                            if ((t = a.parentNode(t)) === n) return a.matchesSelector(t, e)
                        }
                        return !1
                    },
                    getActualElement: function(t) {
                        return t instanceof s.SVGElementInstance ? t.correspondingUseElement : t
                    },
                    getScrollXY: function(t) {
                        return t = t || r.window, {
                            x: t.scrollX || t.document.documentElement.scrollLeft,
                            y: t.scrollY || t.document.documentElement.scrollTop
                        }
                    },
                    getElementClientRect: function(t) {
                        var e = t instanceof s.SVGElement ? t.getBoundingClientRect() : t.getClientRects()[0];
                        return e && {
                            left: e.left,
                            right: e.right,
                            top: e.top,
                            bottom: e.bottom,
                            width: e.width || e.right - e.left,
                            height: e.height || e.bottom - e.top
                        }
                    },
                    getElementRect: function(t) {
                        var e = a.getElementClientRect(t);
                        if (!i.isIOS7 && e) {
                            var n = a.getScrollXY(r.getWindow(t));
                            e.left += n.x, e.right += n.x, e.top += n.y, e.bottom += n.y
                        }
                        return e
                    },
                    getPath: function(t) {
                        for (var e = []; t;) e.push(t), t = a.parentNode(t);
                        return e
                    },
                    trySelector: function(t) {
                        return !!o.string(t) && (s.document.querySelector(t), !0)
                    }
                };
            e.exports = a
        }, {
            "./browser": 36,
            "./domObjects": 38,
            "./is": 46,
            "./window": 52
        }],
        40: [function(t, e, n) {
            "use strict";

            function r(t, e, n, r) {
                var i = p(r),
                    o = x.indexOf(t),
                    s = b[o];
                s || (s = {
                    events: {},
                    typeCount: 0
                }, o = x.push(t) - 1, b.push(s)), s.events[e] || (s.events[e] = [], s.typeCount++), y(s.events[e], n) || (t.addEventListener(e, n, T ? i : !!i.capture), s.events[e].push(n))
            }

            function i(t, e, n, r) {
                var o = p(r),
                    s = x.indexOf(t),
                    a = b[s];
                if (a && a.events)
                    if ("all" !== e) {
                        if (a.events[e]) {
                            var c = a.events[e].length;
                            if ("all" === n) {
                                for (var l = 0; l < c; l++) i(t, e, a.events[e][l], o);
                                return
                            }
                            for (var u = 0; u < c; u++)
                                if (a.events[e][u] === n) {
                                    t.removeEventListener("on" + e, n, T ? o : !!o.capture), a.events[e].splice(u, 1);
                                    break
                                }
                            a.events[e] && 0 === a.events[e].length && (a.events[e] = null, a.typeCount--)
                        }
                        a.typeCount || (b.splice(s, 1), x.splice(s, 1))
                    } else
                        for (e in a.events) a.events.hasOwnProperty(e) && i(t, e, "all")
            }

            function o(t, e, n, i, o) {
                var s = p(o);
                if (!w[n]) {
                    w[n] = {
                        selectors: [],
                        contexts: [],
                        listeners: []
                    };
                    for (var l = 0; l < E.length; l++) {
                        var u = E[l];
                        r(u, n, a), r(u, n, c, !0)
                    }
                }
                var d = w[n],
                    f = void 0;
                for (f = d.selectors.length - 1; f >= 0 && (d.selectors[f] !== t || d.contexts[f] !== e); f--); - 1 === f && (f = d.selectors.length, d.selectors.push(t), d.contexts.push(e), d.listeners.push([])), d.listeners[f].push([i, !!s.capture, s.passive])
            }

            function s(t, e, n, r, o) {
                var s = p(o),
                    l = w[n],
                    u = !1,
                    d = void 0;
                if (l)
                    for (d = l.selectors.length - 1; d >= 0; d--)
                        if (l.selectors[d] === t && l.contexts[d] === e) {
                            for (var f = l.listeners[d], v = f.length - 1; v >= 0; v--) {
                                var g = f[v],
                                    h = g[0],
                                    m = g[1],
                                    y = g[2];
                                if (h === r && m === !!s.capture && y === s.passive) {
                                    f.splice(v, 1), f.length || (l.selectors.splice(d, 1), l.contexts.splice(d, 1), l.listeners.splice(d, 1), i(e, n, a), i(e, n, c, !0), l.selectors.length || (w[n] = null)), u = !0;
                                    break
                                }
                            }
                            if (u) break
                        }
            }

            function a(t, e) {
                var n = p(e),
                    r = {},
                    i = w[t.type],
                    o = f.getEventTargets(t),
                    s = o[0],
                    a = s;
                for (v(r, t), r.originalEvent = t, r.preventDefault = l; u.element(a);) {
                    for (var c = 0; c < i.selectors.length; c++) {
                        var g = i.selectors[c],
                            h = i.contexts[c];
                        if (d.matchesSelector(a, g) && d.nodeContains(h, s) && d.nodeContains(h, a)) {
                            var m = i.listeners[c];
                            r.currentTarget = a;
                            for (var y = 0; y < m.length; y++) {
                                var x = m[y],
                                    b = x[0],
                                    E = x[1],
                                    T = x[2];
                                E === !!n.capture && T === n.passive && b(r)
                            }
                        }
                    }
                    a = d.parentNode(a)
                }
            }

            function c(t) {
                return a.call(this, t, !0)
            }

            function l() {
                this.originalEvent.preventDefault()
            }

            function p(t) {
                return u.object(t) ? t : {
                    capture: t
                }
            }
            var u = t("./is"),
                d = t("./domUtils"),
                f = t("./pointerUtils"),
                v = t("./pointerExtend"),
                g = t("./window"),
                h = g.window,
                m = t("./arr"),
                y = m.contains,
                x = [],
                b = [],
                w = {},
                E = [],
                T = function() {
                    var t = !1;
                    return h.document.createElement("div").addEventListener("test", null, {
                        get capture() {
                            t = !0
                        }
                    }), t
                }();
            e.exports = {
                add: r,
                remove: i,
                addDelegate: o,
                removeDelegate: s,
                delegateListener: a,
                delegateUseCapture: c,
                delegatedEvents: w,
                documents: E,
                supportsOptions: T,
                _elements: x,
                _targets: b
            }
        }, {
            "./arr": 35,
            "./domUtils": 39,
            "./is": 46,
            "./pointerExtend": 48,
            "./pointerUtils": 49,
            "./window": 52
        }],
        41: [function(t, e, n) {
            "use strict";
            e.exports = function(t, e) {
                for (var n in e) t[n] = e[n];
                return t
            }
        }, {}],
        42: [function(t, e, n) {
            "use strict";
            var r = t("./rect"),
                i = r.resolveRectLike,
                o = r.rectToXY;
            e.exports = function(t, e, n) {
                var r = t.options[n],
                    s = r && r.origin,
                    a = s || t.options.origin,
                    c = i(a, t, e, [t && e]);
                return o(c) || {
                    x: 0,
                    y: 0
                }
            }
        }, {
            "./rect": 51
        }],
        43: [function(t, e, n) {
            "use strict";
            e.exports = function(t, e) {
                return Math.sqrt(t * t + e * e)
            }
        }, {}],
        44: [function(t, e, n) {
            "use strict";
            var r = t("./extend"),
                i = t("./window"),
                o = {
                    warnOnce: function(t, e) {
                        var n = !1;
                        return function() {
                            return n || (i.window.console.warn(e), n = !0), t.apply(this, arguments)
                        }
                    },
                    _getQBezierValue: function(t, e, n, r) {
                        var i = 1 - t;
                        return i * i * e + 2 * i * t * n + t * t * r
                    },
                    getQuadraticCurvePoint: function(t, e, n, r, i, s, a) {
                        return {
                            x: o._getQBezierValue(a, t, n, i),
                            y: o._getQBezierValue(a, e, r, s)
                        }
                    },
                    easeOutQuad: function(t, e, n, r) {
                        return t /= r, -n * t * (t - 2) + e
                    },
                    copyAction: function(t, e) {
                        return t.name = e.name, t.axis = e.axis, t.edges = e.edges, t
                    },
                    is: t("./is"),
                    extend: r,
                    hypot: t("./hypot"),
                    getOriginXY: t("./getOriginXY")
                };
            r(o, t("./arr")), r(o, t("./domUtils")), r(o, t("./pointerUtils")), r(o, t("./rect")), e.exports = o
        }, {
            "./arr": 35,
            "./domUtils": 39,
            "./extend": 41,
            "./getOriginXY": 42,
            "./hypot": 43,
            "./is": 46,
            "./pointerUtils": 49,
            "./rect": 51,
            "./window": 52
        }],
        45: [function(t, e, n) {
            "use strict";
            var r = t("../scope"),
                i = t("./index"),
                o = {
                    methodOrder: ["simulationResume", "mouseOrPen", "hasPointer", "idle"],
                    search: function(t, e, n) {
                        for (var r = i.getPointerType(t), s = i.getPointerId(t), a = {
                                pointer: t,
                                pointerId: s,
                                pointerType: r,
                                eventType: e,
                                eventTarget: n
                            }, c = 0; c < o.methodOrder.length; c++) {
                            var l;
                            l = o.methodOrder[c];
                            var p = l,
                                u = o[p](a);
                            if (u) return u
                        }
                    },
                    simulationResume: function(t) {
                        var e = t.pointerType,
                            n = t.eventType,
                            o = t.eventTarget;
                        if (!/down|start/i.test(n)) return null;
                        for (var s = 0; s < r.interactions.length; s++) {
                            var a;
                            a = r.interactions[s];
                            var c = a,
                                l = o;
                            if (c.simulation && c.simulation.allowResume && c.pointerType === e)
                                for (; l;) {
                                    if (l === c.element) return c;
                                    l = i.parentNode(l)
                                }
                        }
                        return null
                    },
                    mouseOrPen: function(t) {
                        var e = t.pointerId,
                            n = t.pointerType,
                            o = t.eventType;
                        if ("mouse" !== n && "pen" !== n) return null;
                        for (var s = void 0, a = 0; a < r.interactions.length; a++) {
                            var c;
                            c = r.interactions[a];
                            var l = c;
                            if (l.pointerType === n) {
                                if (l.simulation && !i.contains(l.pointerIds, e)) continue;
                                if (l.interacting()) return l;
                                s || (s = l)
                            }
                        }
                        if (s) return s;
                        for (var p = 0; p < r.interactions.length; p++) {
                            var u;
                            u = r.interactions[p];
                            var d = u;
                            if (!(d.pointerType !== n || /down/i.test(o) && d.simulation)) return d
                        }
                        return null
                    },
                    hasPointer: function(t) {
                        for (var e = t.pointerId, n = 0; n < r.interactions.length; n++) {
                            var o;
                            o = r.interactions[n];
                            var s = o;
                            if (i.contains(s.pointerIds, e)) return s
                        }
                    },
                    idle: function(t) {
                        for (var e = t.pointerType, n = 0; n < r.interactions.length; n++) {
                            var i;
                            i = r.interactions[n];
                            var o = i;
                            if (1 === o.pointerIds.length) {
                                var s = o.target;
                                if (s && !s.options.gesture.enabled) continue
                            } else if (o.pointerIds.length >= 2) continue;
                            if (!o.interacting() && e === o.pointerType) return o
                        }
                        return null
                    }
                };
            e.exports = o
        }, {
            "../scope": 33,
            "./index": 44
        }],
        46: [function(t, e, n) {
            "use strict";
            var r = "function" == typeof Symbol && "symbol" == typeof Symbol.iterator ? function(t) {
                    return typeof t
                } : function(t) {
                    return t && "function" == typeof Symbol && t.constructor === Symbol && t !== Symbol.prototype ? "symbol" : typeof t
                },
                i = t("./window"),
                o = t("./isWindow"),
                s = {
                    array: function() {},
                    window: function(t) {
                        return t === i.window || o(t)
                    },
                    docFrag: function(t) {
                        return s.object(t) && 11 === t.nodeType
                    },
                    object: function(t) {
                        return !!t && "object" === (void 0 === t ? "undefined" : r(t))
                    },
                    function: function(t) {
                        return "function" == typeof t
                    },
                    number: function(t) {
                        return "number" == typeof t
                    },
                    bool: function(t) {
                        return "boolean" == typeof t
                    },
                    string: function(t) {
                        return "string" == typeof t
                    },
                    element: function(t) {
                        if (!t || "object" !== (void 0 === t ? "undefined" : r(t))) return !1;
                        var e = i.getWindow(t) || i.window;
                        return /object|function/.test(r(e.Element)) ? t instanceof e.Element : 1 === t.nodeType && "string" == typeof t.nodeName
                    },
                    plainObject: function(t) {
                        return s.object(t) && "Object" === t.constructor.name
                    }
                };
            s.array = function(t) {
                return s.object(t) && void 0 !== t.length && s.function(t.splice)
            }, e.exports = s
        }, {
            "./isWindow": 47,
            "./window": 52
        }],
        47: [function(t, e, n) {
            "use strict";
            e.exports = function(t) {
                return !(!t || !t.Window) && t instanceof t.Window
            }
        }, {}],
        48: [function(t, e, n) {
            "use strict";

            function r(t, n) {
                for (var r in n) {
                    var i = e.exports.prefixedPropREs,
                        o = !1;
                    for (var s in i)
                        if (0 === r.indexOf(s) && i[s].test(r)) {
                            o = !0;
                            break
                        }
                    o || "function" == typeof n[r] || (t[r] = n[r])
                }
                return t
            }
            r.prefixedPropREs = {
                webkit: /(Movement[XY]|Radius[XY]|RotationAngle|Force)$/
            }, e.exports = r
        }, {}],
        49: [function(t, e, n) {
            "use strict";
            var r = t("./hypot"),
                i = t("./browser"),
                o = t("./domObjects"),
                s = t("./domUtils"),
                a = t("./domObjects"),
                c = t("./is"),
                l = t("./pointerExtend"),
                p = {
                    copyCoords: function(t, e) {
                        t.page = t.page || {}, t.page.x = e.page.x, t.page.y = e.page.y, t.client = t.client || {}, t.client.x = e.client.x, t.client.y = e.client.y, t.timeStamp = e.timeStamp
                    },
                    setCoordDeltas: function(t, e, n) {
                        t.page.x = n.page.x - e.page.x, t.page.y = n.page.y - e.page.y, t.client.x = n.client.x - e.client.x, t.client.y = n.client.y - e.client.y, t.timeStamp = n.timeStamp - e.timeStamp;
                        var i = Math.max(t.timeStamp / 1e3, .001);
                        t.page.speed = r(t.page.x, t.page.y) / i, t.page.vx = t.page.x / i, t.page.vy = t.page.y / i, t.client.speed = r(t.client.x, t.page.y) / i, t.client.vx = t.client.x / i, t.client.vy = t.client.y / i
                    },
                    isNativePointer: function(t) {
                        return t instanceof o.Event || t instanceof o.Touch
                    },
                    getXY: function(t, e, n) {
                        return n = n || {}, t = t || "page", n.x = e[t + "X"], n.y = e[t + "Y"], n
                    },
                    getPageXY: function(t, e) {
                        return e = e || {}, i.isOperaMobile && p.isNativePointer(t) ? (p.getXY("screen", t, e), e.x += window.scrollX, e.y += window.scrollY) : p.getXY("page", t, e), e
                    },
                    getClientXY: function(t, e) {
                        return e = e || {}, i.isOperaMobile && p.isNativePointer(t) ? p.getXY("screen", t, e) : p.getXY("client", t, e), e
                    },
                    getPointerId: function(t) {
                        return c.number(t.pointerId) ? t.pointerId : t.identifier
                    },
                    setCoords: function(t, e, n) {
                        var r = e.length > 1 ? p.pointerAverage(e) : e[0],
                            i = {};
                        p.getPageXY(r, i), t.page.x = i.x, t.page.y = i.y, p.getClientXY(r, i), t.client.x = i.x, t.client.y = i.y, t.timeStamp = c.number(n) ? n : (new Date).getTime()
                    },
                    pointerExtend: l,
                    getTouchPair: function(t) {
                        var e = [];
                        return c.array(t) ? (e[0] = t[0], e[1] = t[1]) : "touchend" === t.type ? 1 === t.touches.length ? (e[0] = t.touches[0], e[1] = t.changedTouches[0]) : 0 === t.touches.length && (e[0] = t.changedTouches[0], e[1] = t.changedTouches[1]) : (e[0] = t.touches[0], e[1] = t.touches[1]), e
                    },
                    pointerAverage: function(t) {
                        for (var e = {
                                pageX: 0,
                                pageY: 0,
                                clientX: 0,
                                clientY: 0,
                                screenX: 0,
                                screenY: 0
                            }, n = 0; n < t.length; n++) {
                            var r;
                            r = t[n];
                            var i = r;
                            for (var o in e) e[o] += i[o]
                        }
                        for (var s in e) e[s] /= t.length;
                        return e
                    },
                    touchBBox: function(t) {
                        if (t.length || t.touches && t.touches.length > 1) {
                            var e = p.getTouchPair(t),
                                n = Math.min(e[0].pageX, e[1].pageX),
                                r = Math.min(e[0].pageY, e[1].pageY);
                            return {
                                x: n,
                                y: r,
                                left: n,
                                top: r,
                                width: Math.max(e[0].pageX, e[1].pageX) - n,
                                height: Math.max(e[0].pageY, e[1].pageY) - r
                            }
                        }
                    },
                    touchDistance: function(t, e) {
                        var n = e + "X",
                            i = e + "Y",
                            o = p.getTouchPair(t),
                            s = o[0][n] - o[1][n],
                            a = o[0][i] - o[1][i];
                        return r(s, a)
                    },
                    touchAngle: function(t, e, n) {
                        var r = n + "X",
                            i = n + "Y",
                            o = p.getTouchPair(t),
                            s = o[1][r] - o[0][r],
                            a = o[1][i] - o[0][i];
                        return 180 * Math.atan2(a, s) / Math.PI
                    },
                    getPointerType: function(t) {
                        return c.string(t.pointerType) ? t.pointerType : c.number(t.pointerType) ? [void 0, void 0, "touch", "pen", "mouse"][t.pointerType] : /touch/.test(t.type) || t instanceof a.Touch ? "touch" : "mouse"
                    },
                    getEventTargets: function(t) {
                        var e = c.function(t.composedPath) ? t.composedPath() : t.path;
                        return [s.getActualElement(e ? e[0] : t.target), s.getActualElement(t.currentTarget)]
                    }
                };
            e.exports = p
        }, {
            "./browser": 36,
            "./domObjects": 38,
            "./domUtils": 39,
            "./hypot": 43,
            "./is": 46,
            "./pointerExtend": 48
        }],
        50: [function(t, e, n) {
            "use strict";
            for (var r = t("./window"), i = r.window, o = ["ms", "moz", "webkit", "o"], s = 0, a = void 0, c = void 0, l = 0; l < o.length && !i.requestAnimationFrame; l++) a = i[o[l] + "RequestAnimationFrame"], c = i[o[l] + "CancelAnimationFrame"] || i[o[l] + "CancelRequestAnimationFrame"];
            a || (a = function(t) {
                var e = (new Date).getTime(),
                    n = Math.max(0, 16 - (e - s)),
                    r = setTimeout(function() {
                        t(e + n)
                    }, n);
                return s = e + n, r
            }), c || (c = function(t) {
                clearTimeout(t)
            }), e.exports = {
                request: a,
                cancel: c
            }
        }, {
            "./window": 52
        }],
        51: [function(t, e, n) {
            "use strict";
            var r = t("./extend"),
                i = t("./is"),
                o = t("./domUtils"),
                s = o.closest,
                a = o.parentNode,
                c = o.getElementRect,
                l = {
                    getStringOptionResult: function(t, e, n) {
                        return i.string(t) ? t = "parent" === t ? a(n) : "self" === t ? e.getRect(n) : s(n, t) : null
                    },
                    resolveRectLike: function(t, e, n, r) {
                        return t = l.getStringOptionResult(t, e, n) || t, i.function(t) && (t = t.apply(null, r)), i.element(t) && (t = c(t)), t
                    },
                    rectToXY: function(t) {
                        return t && {
                            x: "x" in t ? t.x : t.left,
                            y: "y" in t ? t.y : t.top
                        }
                    },
                    xywhToTlbr: function(t) {
                        return !t || "left" in t && "top" in t || (t = r({}, t), t.left = t.x || 0, t.top = t.y || 0, t.right = t.right || t.left + t.width, t.bottom = t.bottom || t.top + t.height), t
                    },
                    tlbrToXywh: function(t) {
                        return !t || "x" in t && "y" in t || (t = r({}, t), t.x = t.left || 0, t.top = t.top || 0, t.width = t.width || t.right - t.x, t.height = t.height || t.bottom - t.y), t
                    }
                };
            e.exports = l
        }, {
            "./domUtils": 39,
            "./extend": 41,
            "./is": 46
        }],
        52: [function(t, e, n) {
            "use strict";

            function r(t) {
                i.realWindow = t;
                var e = t.document.createTextNode("");
                e.ownerDocument !== t.document && "function" == typeof t.wrap && t.wrap(e) === e && (t = t.wrap(t)), i.window = t
            }
            var i = e.exports,
                o = t("./isWindow");
            "undefined" == typeof window ? (i.window = void 0, i.realWindow = void 0) : r(window), i.getWindow = function(t) {
                if (o(t)) return t;
                var e = t.ownerDocument || t;
                return e.defaultView || e.parentWindow || i.window
            }, i.init = r
        }, {
            "./isWindow": 47
        }]
    }, {}, [1])(1)
});

//# sourceMappingURL=interact.min.js.map
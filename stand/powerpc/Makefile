# $FreeBSD$

NO_OBJ=t

.include <bsd.init.mk>

SUBDIR.yes=		boot1.chrp ofw uboot

.if "${TARGET_ARCH}" == "powerpc64"
SUBDIR.${MK_FDT}+=	kboot
.endif

.include <bsd.subdir.mk>

.subsections_via_symbols
.section __DWARF, __debug_line,regular,debug
Ldebug_line_section_start:
Ldebug_line_start:
.section __DWARF, __debug_abbrev,regular,debug

	.byte 1,17,1,37,8,3,8,27,8,19,11,17,1,18,1,16,6,0,0,2,46,1,3,8,135,64,8,58,15,59,15,17
	.byte 1,18,1,64,10,0,0,3,5,0,3,8,73,19,2,10,0,0,15,5,0,3,8,73,19,2,6,0,0,4,36,0
	.byte 11,11,62,11,3,8,0,0,5,2,1,3,8,11,15,0,0,17,2,0,3,8,11,15,0,0,6,13,0,3,8,73
	.byte 19,56,10,0,0,7,22,0,3,8,73,19,0,0,8,4,1,3,8,11,15,73,19,0,0,9,40,0,3,8,28,13
	.byte 0,0,10,57,1,3,8,0,0,11,52,0,3,8,73,19,2,10,0,0,12,52,0,3,8,73,19,2,6,0,0,13
	.byte 15,0,73,19,0,0,14,16,0,73,19,0,0,16,28,0,73,19,56,10,0,0,18,46,0,3,8,17,1,18,1,0
	.byte 0,0
.section __DWARF, __debug_info,regular,debug
Ldebug_info_start:

LDIFF_SYM0=Ldebug_info_end - Ldebug_info_begin
	.long LDIFF_SYM0
Ldebug_info_begin:

	.short 2
	.long 0
	.byte 8,1
	.asciz "Mono AOT Compiler 4.6.1 (tarball Mon Oct  3 15:04:52 EDT 2016)"
	.asciz "Microsoft.WindowsAzure.Messaging.iOS.dll"
	.asciz ""

	.byte 2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
LDIFF_SYM1=Ldebug_line_start - Ldebug_line_section_start
	.long LDIFF_SYM1
LDIE_I1:

	.byte 4,1,5
	.asciz "sbyte"
LDIE_U1:

	.byte 4,1,7
	.asciz "byte"
LDIE_I2:

	.byte 4,2,5
	.asciz "short"
LDIE_U2:

	.byte 4,2,7
	.asciz "ushort"
LDIE_I4:

	.byte 4,4,5
	.asciz "int"
LDIE_U4:

	.byte 4,4,7
	.asciz "uint"
LDIE_I8:

	.byte 4,8,5
	.asciz "long"
LDIE_U8:

	.byte 4,8,7
	.asciz "ulong"
LDIE_I:

	.byte 4,8,5
	.asciz "intptr"
LDIE_U:

	.byte 4,8,7
	.asciz "uintptr"
LDIE_R4:

	.byte 4,4,4
	.asciz "float"
LDIE_R8:

	.byte 4,8,4
	.asciz "double"
LDIE_BOOLEAN:

	.byte 4,1,2
	.asciz "boolean"
LDIE_CHAR:

	.byte 4,2,8
	.asciz "char"
LDIE_STRING:

	.byte 4,8,1
	.asciz "string"
LDIE_OBJECT:

	.byte 4,8,1
	.asciz "object"
LDIE_SZARRAY:

	.byte 4,8,1
	.asciz "object"
.section __DWARF, __debug_loc,regular,debug
Ldebug_loc_start:
.section __DWARF, __debug_frame,regular,debug
	.align 3

LDIFF_SYM2=Lcie0_end - Lcie0_start
	.long LDIFF_SYM2
Lcie0_start:

	.long -1
	.byte 3
	.asciz ""

	.byte 1,120,30
	.align 3
Lcie0_end:
.text
	.align 3
jit_code_start:

	.byte 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
.text
	.align 4
	.no_dead_strip ApiDefinition_Messaging__ctor
ApiDefinition_Messaging__ctor:
.file 1 "<unknown>"
.loc 1 1 0
.word 0xa9bd7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #112]
.word 0xf9000fb0
.word 0xf9400a11
.word 0xf90013b1
.word 0xf9400fb1
.word 0xf9403231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9405231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fb1
.word 0xf9406631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9407631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9408631
.word 0xb4000051
.word 0xd63f0220
.word 0x910003bf
.word 0xa8c37bfd
.word 0xd65f03c0

Lme_0:
.text
	.align 4
	.no_dead_strip ApiDefinition_Messaging__cctor
ApiDefinition_Messaging__cctor:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #120]
.word 0xf9000bb0
.word 0xf9400a11
.word 0xf9000fb1
.word 0xf9400bb1
.word 0xf9402e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb1
.word 0xf9404e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x1, [x16, #128]
.word 0xaa0103e0
.word 0xf9400021
.word 0xf943c430
.word 0xd63f0200
.word 0xf9001ba0
.word 0xf9400bb1
.word 0xf9407e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #136]
.word 0xf9000001
.word 0xf9400bb1
.word 0xf940a231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220
.word 0x910003bf
.word 0xa8c47bfd
.word 0xd65f03c0

Lme_25:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBConnectionString__ctor
WindowsAzure_Messaging_SBConnectionString__ctor:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000bba
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #144]
.word 0xf9000fb0
.word 0xf9400a11
.word 0xf90013b1
.word 0xf9400fb1
.word 0xf9403631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9405631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #152]
.word 0xf9400001
.word 0xaa1a03e0
bl _p_1
.word 0xf9400fb1
.word 0xf9408231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0xf9400340
.word 0xf9400c00
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf940b631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a1
.word 0xaa0103e0
.word 0xf9400021
.word 0xf943c430
.word 0xd63f0200
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf940de31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x1, [x16, #136]
.word 0xf9400021
bl _p_2
.word 0x53001c00
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf9410e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa1
.word 0xaa1a03e0
bl _p_3
.word 0xf9400fb1
.word 0xf9412a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9413a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_4
.word 0x53001c00
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf9415e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0x340005a0
.word 0xf9400fb1
.word 0xf9417631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_5
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf9419a31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_0@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_0@PAGEOFF
ldr x0, [x0]
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf941ba31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
.word 0xf94023a1
bl _p_6
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf941da31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x2, [x16, #160]
.word 0xaa1a03e0
bl _p_7
.word 0xf9400fb1
.word 0xf9420231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9421231
.word 0xb4000051
.word 0xd63f0220
.word 0x14000028
.word 0xf9400fb1
.word 0xf9422631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_8
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf9424a31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_0@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_0@PAGEOFF
ldr x0, [x0]
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9426a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
.word 0xf94023a1
bl _p_9
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf9428a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x2, [x16, #160]
.word 0xaa1a03e0
bl _p_7
.word 0xf9400fb1
.word 0xf942b231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf942d231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf942e231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bba
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_26:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBConnectionString__ctor_Foundation_NSObjectFlag
WindowsAzure_Messaging_SBConnectionString__ctor_Foundation_NSObjectFlag:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bb9
.word 0xaa0003f9
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #168]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xf94013b1
.word 0xf9403a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9405a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xf9400fa1
.word 0xaa1903e0
bl _p_1
.word 0xf94013b1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9408a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0xf9400320
.word 0xf9400c00
.word 0xf9002ba0
.word 0xf94013b1
.word 0xf940ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba1
.word 0xaa0103e0
.word 0xf9400021
.word 0xf943c430
.word 0xd63f0200
.word 0xf90027a0
.word 0xf94013b1
.word 0xf940d631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x1, [x16, #136]
.word 0xf9400021
bl _p_2
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a1
.word 0xaa1903e0
bl _p_3
.word 0xf94013b1
.word 0xf9412231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9414231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb9
.word 0x910003bf
.word 0xa8c67bfd
.word 0xd65f03c0

Lme_27:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBConnectionString__ctor_intptr
WindowsAzure_Messaging_SBConnectionString__ctor_intptr:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bb9
.word 0xaa0003f9
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #176]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xf94013b1
.word 0xf9403a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9405a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xf9400fa1
.word 0xaa1903e0
bl _p_10
.word 0xf94013b1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9408a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0xf9400320
.word 0xf9400c00
.word 0xf9002ba0
.word 0xf94013b1
.word 0xf940ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba1
.word 0xaa0103e0
.word 0xf9400021
.word 0xf943c430
.word 0xd63f0200
.word 0xf90027a0
.word 0xf94013b1
.word 0xf940d631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x1, [x16, #136]
.word 0xf9400021
bl _p_2
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a1
.word 0xaa1903e0
bl _p_3
.word 0xf94013b1
.word 0xf9412231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9414231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb9
.word 0x910003bf
.word 0xa8c67bfd
.word 0xd65f03c0

Lme_28:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBConnectionString_get_ClassHandle
WindowsAzure_Messaging_SBConnectionString_get_ClassHandle:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #184]
.word 0xf9000fb0
.word 0xf9400a11
.word 0xf90013b1
.word 0xf9400fb1
.word 0xf9403231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9405231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #192]
.word 0xf9400000
.word 0xf9001ba0
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9408631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xf9400fb1
.word 0xf9409a31
.word 0xb4000051
.word 0xd63f0220
.word 0x910003bf
.word 0xa8c47bfd
.word 0xd65f03c0

Lme_29:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBConnectionString_CreateByIssuer_Foundation_NSUrl_string_string
WindowsAzure_Messaging_SBConnectionString_CreateByIssuer_Foundation_NSUrl_string_string:
.loc 1 1 0
.word 0xa9b67bfd
.word 0x910003fd
.word 0xa9015bb5
.word 0xa90263b7
.word 0xa9036bb9
.word 0xaa0003f8
.word 0xaa0103f9
.word 0xaa0203fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #200]
.word 0xf90023b0
.word 0xf9400a11
.word 0xf90027b1
.word 0xd2800017
.word 0xd2800016
.word 0xd2800015
.word 0xf94023b1
.word 0xf9405231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9407231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xb5000258
.word 0xf94023b1
.word 0xf9408a31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd2800161
.word 0xd2800161
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf94023b1
.word 0xf940ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xb5000259
.word 0xf94023b1
.word 0xf940e631
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd28003a1
.word 0xd28003a1
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf94023b1
.word 0xf9412a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xb500025a
.word 0xf94023b1
.word 0xf9414231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd2800561
.word 0xd2800561
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf94023b1
.word 0xf9418631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_13
.word 0xf9004fa0
.word 0xf94023b1
.word 0xf941a631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9404fa0
.word 0xaa0003f7
.word 0xf94023b1
.word 0xf941be31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_13
.word 0xf9004ba0
.word 0xf94023b1
.word 0xf941de31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9404ba0
.word 0xaa0003f6
.word 0xf94023b1
.word 0xf941f631
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #192]
.word 0xf9400000
.word 0xf9003fa0
adrp x0, L_OBJC_SELECTOR_REFERENCES_1@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_1@PAGEOFF
ldr x0, [x0]
.word 0xf90043a0
.word 0xf94023b1
.word 0xf9422a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
.word 0xf940031e
bl _p_5
.word 0xf90047a0
.word 0xf94023b1
.word 0xf9424e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403fa0
.word 0xf94043a1
.word 0xf94047a2
.word 0xaa1703e3
.word 0xaa1603e4
bl _p_14
.word 0xf9003ba0
.word 0xf94023b1
.word 0xf9427a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403ba0
bl _p_15
.word 0xf90037a0
.word 0xf94023b1
.word 0xf9429631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94037a0
.word 0xaa0003f5
.word 0xf94023b1
.word 0xf942ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
bl _p_16
.word 0xf94023b1
.word 0xf942c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf942d631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
bl _p_16
.word 0xf94023b1
.word 0xf942ee31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf942fe31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1503e0
.word 0xf90033a0
.word 0xf94027b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9432631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a0
.word 0xf94023b1
.word 0xf9433a31
.word 0xb4000051
.word 0xd63f0220
.word 0xa9415bb5
.word 0xa94263b7
.word 0xa9436bb9
.word 0x910003bf
.word 0xa8ca7bfd
.word 0xd65f03c0

Lme_2a:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBConnectionString_CreateByKeyName_Foundation_NSUrl_string_string
WindowsAzure_Messaging_SBConnectionString_CreateByKeyName_Foundation_NSUrl_string_string:
.loc 1 1 0
.word 0xa9b67bfd
.word 0x910003fd
.word 0xa9015bb5
.word 0xa90263b7
.word 0xa9036bb9
.word 0xaa0003f8
.word 0xaa0103f9
.word 0xaa0203fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #208]
.word 0xf90023b0
.word 0xf9400a11
.word 0xf90027b1
.word 0xd2800017
.word 0xd2800016
.word 0xd2800015
.word 0xf94023b1
.word 0xf9405231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9407231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xb5000258
.word 0xf94023b1
.word 0xf9408a31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd2800161
.word 0xd2800161
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf94023b1
.word 0xf940ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xb5000259
.word 0xf94023b1
.word 0xf940e631
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd2801121
.word 0xd2801121
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf94023b1
.word 0xf9412a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xb500025a
.word 0xf94023b1
.word 0xf9414231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd2800561
.word 0xd2800561
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf94023b1
.word 0xf9418631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_13
.word 0xf9004fa0
.word 0xf94023b1
.word 0xf941a631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9404fa0
.word 0xaa0003f7
.word 0xf94023b1
.word 0xf941be31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_13
.word 0xf9004ba0
.word 0xf94023b1
.word 0xf941de31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9404ba0
.word 0xaa0003f6
.word 0xf94023b1
.word 0xf941f631
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #192]
.word 0xf9400000
.word 0xf9003fa0
adrp x0, L_OBJC_SELECTOR_REFERENCES_2@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_2@PAGEOFF
ldr x0, [x0]
.word 0xf90043a0
.word 0xf94023b1
.word 0xf9422a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
.word 0xf940031e
bl _p_5
.word 0xf90047a0
.word 0xf94023b1
.word 0xf9424e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403fa0
.word 0xf94043a1
.word 0xf94047a2
.word 0xaa1703e3
.word 0xaa1603e4
bl _p_14
.word 0xf9003ba0
.word 0xf94023b1
.word 0xf9427a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403ba0
bl _p_15
.word 0xf90037a0
.word 0xf94023b1
.word 0xf9429631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94037a0
.word 0xaa0003f5
.word 0xf94023b1
.word 0xf942ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
bl _p_16
.word 0xf94023b1
.word 0xf942c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf942d631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
bl _p_16
.word 0xf94023b1
.word 0xf942ee31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf942fe31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1503e0
.word 0xf90033a0
.word 0xf94027b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9432631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a0
.word 0xf94023b1
.word 0xf9433a31
.word 0xb4000051
.word 0xd63f0220
.word 0xa9415bb5
.word 0xa94263b7
.word 0xa9436bb9
.word 0x910003bf
.word 0xa8ca7bfd
.word 0xd65f03c0

Lme_2b:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBConnectionString_CreateFullAccess_Foundation_NSUrl_string
WindowsAzure_Messaging_SBConnectionString_CreateFullAccess_Foundation_NSUrl_string:
.loc 1 1 0
.word 0xa9b77bfd
.word 0x910003fd
.word 0xa90163b7
.word 0xa9026bb9
.word 0xaa0003f9
.word 0xaa0103fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #216]
.word 0xf9001bb0
.word 0xf9400a11
.word 0xf9001fb1
.word 0xd2800018
.word 0xd2800017
.word 0xf9401bb1
.word 0xf9404631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9406631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xb5000259
.word 0xf9401bb1
.word 0xf9407e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd2800161
.word 0xd2800161
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf9401bb1
.word 0xf940c231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xb500025a
.word 0xf9401bb1
.word 0xf940da31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd2802061
.word 0xd2802061
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf9401bb1
.word 0xf9411e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_13
.word 0xf90043a0
.word 0xf9401bb1
.word 0xf9413e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94043a0
.word 0xaa0003f8
.word 0xf9401bb1
.word 0xf9415631
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #192]
.word 0xf9400000
.word 0xf90037a0
adrp x0, L_OBJC_SELECTOR_REFERENCES_3@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_3@PAGEOFF
ldr x0, [x0]
.word 0xf9003ba0
.word 0xf9401bb1
.word 0xf9418a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0xf940033e
bl _p_5
.word 0xf9003fa0
.word 0xf9401bb1
.word 0xf941ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94037a0
.word 0xf9403ba1
.word 0xf9403fa2
.word 0xaa1803e3
bl _p_17
.word 0xf90033a0
.word 0xf9401bb1
.word 0xf941d631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a0
bl _p_15
.word 0xf9002fa0
.word 0xf9401bb1
.word 0xf941f231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fa0
.word 0xaa0003f7
.word 0xf9401bb1
.word 0xf9420a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
bl _p_16
.word 0xf9401bb1
.word 0xf9422231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9423231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xf9002ba0
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9425a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
.word 0xf9401bb1
.word 0xf9426e31
.word 0xb4000051
.word 0xd63f0220
.word 0xa94163b7
.word 0xa9426bb9
.word 0x910003bf
.word 0xa8c97bfd
.word 0xd65f03c0

Lme_2c:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBConnectionString_CreateListenAccess_Foundation_NSUrl_string
WindowsAzure_Messaging_SBConnectionString_CreateListenAccess_Foundation_NSUrl_string:
.loc 1 1 0
.word 0xa9b77bfd
.word 0x910003fd
.word 0xa90163b7
.word 0xa9026bb9
.word 0xaa0003f9
.word 0xaa0103fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #224]
.word 0xf9001bb0
.word 0xf9400a11
.word 0xf9001fb1
.word 0xd2800018
.word 0xd2800017
.word 0xf9401bb1
.word 0xf9404631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9406631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xb5000259
.word 0xf9401bb1
.word 0xf9407e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd2800161
.word 0xd2800161
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf9401bb1
.word 0xf940c231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xb500025a
.word 0xf9401bb1
.word 0xf940da31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd2802de1
.word 0xd2802de1
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf9401bb1
.word 0xf9411e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_13
.word 0xf90043a0
.word 0xf9401bb1
.word 0xf9413e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94043a0
.word 0xaa0003f8
.word 0xf9401bb1
.word 0xf9415631
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #192]
.word 0xf9400000
.word 0xf90037a0
adrp x0, L_OBJC_SELECTOR_REFERENCES_4@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_4@PAGEOFF
ldr x0, [x0]
.word 0xf9003ba0
.word 0xf9401bb1
.word 0xf9418a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0xf940033e
bl _p_5
.word 0xf9003fa0
.word 0xf9401bb1
.word 0xf941ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94037a0
.word 0xf9403ba1
.word 0xf9403fa2
.word 0xaa1803e3
bl _p_17
.word 0xf90033a0
.word 0xf9401bb1
.word 0xf941d631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a0
bl _p_15
.word 0xf9002fa0
.word 0xf9401bb1
.word 0xf941f231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fa0
.word 0xaa0003f7
.word 0xf9401bb1
.word 0xf9420a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
bl _p_16
.word 0xf9401bb1
.word 0xf9422231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9423231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xf9002ba0
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9425a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
.word 0xf9401bb1
.word 0xf9426e31
.word 0xb4000051
.word 0xd63f0220
.word 0xa94163b7
.word 0xa9426bb9
.word 0x910003bf
.word 0xa8c97bfd
.word 0xd65f03c0

Lme_2d:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBConnectionString__cctor
WindowsAzure_Messaging_SBConnectionString__cctor:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #232]
.word 0xf9000bb0
.word 0xf9400a11
.word 0xf9000fb1
.word 0xf9400bb1
.word 0xf9402e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb1
.word 0xf9404e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #240]
bl _p_18
.word 0xf9001ba0
.word 0xf9400bb1
.word 0xf9407231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #192]
.word 0xf9000001
.word 0xf9400bb1
.word 0xf9409631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb1
.word 0xf940a631
.word 0xb4000051
.word 0xd63f0220
.word 0x910003bf
.word 0xa8c47bfd
.word 0xd65f03c0

Lme_2e:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBLocalStorage__ctor
WindowsAzure_Messaging_SBLocalStorage__ctor:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000bba
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #248]
.word 0xf9000fb0
.word 0xf9400a11
.word 0xf90013b1
.word 0xf9400fb1
.word 0xf9403631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9405631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #152]
.word 0xf9400001
.word 0xaa1a03e0
bl _p_1
.word 0xf9400fb1
.word 0xf9408231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0xf9400340
.word 0xf9400c00
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf940b631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a1
.word 0xaa0103e0
.word 0xf9400021
.word 0xf943c430
.word 0xd63f0200
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf940de31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x1, [x16, #136]
.word 0xf9400021
bl _p_2
.word 0x53001c00
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf9410e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa1
.word 0xaa1a03e0
bl _p_3
.word 0xf9400fb1
.word 0xf9412a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9413a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_4
.word 0x53001c00
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf9415e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0x340005a0
.word 0xf9400fb1
.word 0xf9417631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_5
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf9419a31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_0@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_0@PAGEOFF
ldr x0, [x0]
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf941ba31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
.word 0xf94023a1
bl _p_6
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf941da31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x2, [x16, #160]
.word 0xaa1a03e0
bl _p_7
.word 0xf9400fb1
.word 0xf9420231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9421231
.word 0xb4000051
.word 0xd63f0220
.word 0x14000028
.word 0xf9400fb1
.word 0xf9422631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_8
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf9424a31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_0@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_0@PAGEOFF
ldr x0, [x0]
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9426a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
.word 0xf94023a1
bl _p_9
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf9428a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x2, [x16, #160]
.word 0xaa1a03e0
bl _p_7
.word 0xf9400fb1
.word 0xf942b231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf942d231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf942e231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bba
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_2f:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBLocalStorage__ctor_Foundation_NSObjectFlag
WindowsAzure_Messaging_SBLocalStorage__ctor_Foundation_NSObjectFlag:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bb9
.word 0xaa0003f9
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #256]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xf94013b1
.word 0xf9403a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9405a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xf9400fa1
.word 0xaa1903e0
bl _p_1
.word 0xf94013b1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9408a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0xf9400320
.word 0xf9400c00
.word 0xf9002ba0
.word 0xf94013b1
.word 0xf940ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba1
.word 0xaa0103e0
.word 0xf9400021
.word 0xf943c430
.word 0xd63f0200
.word 0xf90027a0
.word 0xf94013b1
.word 0xf940d631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x1, [x16, #136]
.word 0xf9400021
bl _p_2
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a1
.word 0xaa1903e0
bl _p_3
.word 0xf94013b1
.word 0xf9412231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9414231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb9
.word 0x910003bf
.word 0xa8c67bfd
.word 0xd65f03c0

Lme_30:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBLocalStorage__ctor_intptr
WindowsAzure_Messaging_SBLocalStorage__ctor_intptr:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bb9
.word 0xaa0003f9
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #264]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xf94013b1
.word 0xf9403a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9405a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xf9400fa1
.word 0xaa1903e0
bl _p_10
.word 0xf94013b1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9408a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0xf9400320
.word 0xf9400c00
.word 0xf9002ba0
.word 0xf94013b1
.word 0xf940ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba1
.word 0xaa0103e0
.word 0xf9400021
.word 0xf943c430
.word 0xd63f0200
.word 0xf90027a0
.word 0xf94013b1
.word 0xf940d631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x1, [x16, #136]
.word 0xf9400021
bl _p_2
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a1
.word 0xaa1903e0
bl _p_3
.word 0xf94013b1
.word 0xf9412231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9414231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb9
.word 0x910003bf
.word 0xa8c67bfd
.word 0xd65f03c0

Lme_31:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBLocalStorage__ctor_string
WindowsAzure_Messaging_SBLocalStorage__ctor_string:
.loc 1 1 0
.word 0xa9b97bfd
.word 0x910003fd
.word 0xa90167b8
.word 0xf90013ba
.word 0xaa0003f9
.word 0xaa0103fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #272]
.word 0xf90017b0
.word 0xf9400a11
.word 0xf9001bb1
.word 0xd2800018
.word 0xf94017b1
.word 0xf9404231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9406231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #152]
.word 0xf9400001
.word 0xaa1903e0
bl _p_1
.word 0xf94017b1
.word 0xf9408e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9409e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xb500025a
.word 0xf94017b1
.word 0xf940b631
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd2804121
.word 0xd2804121
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf94017b1
.word 0xf940fa31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_13
.word 0xf90033a0
.word 0xf94017b1
.word 0xf9411a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a0
.word 0xaa0003f8
.word 0xf94017b1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0xf9400320
.word 0xf9400c00
.word 0xf9002fa0
.word 0xf94017b1
.word 0xf9415631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fa1
.word 0xaa0103e0
.word 0xf9400021
.word 0xf943c430
.word 0xd63f0200
.word 0xf9002ba0
.word 0xf94017b1
.word 0xf9417e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x1, [x16, #136]
.word 0xf9400021
bl _p_2
.word 0x53001c00
.word 0xf90027a0
.word 0xf94017b1
.word 0xf941ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a1
.word 0xaa1903e0
bl _p_3
.word 0xf94017b1
.word 0xf941ca31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf941da31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_4
.word 0x53001c00
.word 0xf90023a0
.word 0xf94017b1
.word 0xf941fe31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0x340005e0
.word 0xf94017b1
.word 0xf9421631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_5
.word 0xf90027a0
.word 0xf94017b1
.word 0xf9423a31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_5@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_5@PAGEOFF
ldr x0, [x0]
.word 0xf9002ba0
.word 0xf94017b1
.word 0xf9425a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0
.word 0xf9402ba1
.word 0xaa1803e2
.word 0xaa1803e2
bl _p_19
.word 0xf90023a0
.word 0xf94017b1
.word 0xf9428231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x2, [x16, #280]
.word 0xaa1903e0
bl _p_7
.word 0xf94017b1
.word 0xf942aa31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf942ba31
.word 0xb4000051
.word 0xd63f0220
.word 0x1400002a
.word 0xf94017b1
.word 0xf942ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_8
.word 0xf90027a0
.word 0xf94017b1
.word 0xf942f231
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_5@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_5@PAGEOFF
ldr x0, [x0]
.word 0xf9002ba0
.word 0xf94017b1
.word 0xf9431231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0
.word 0xf9402ba1
.word 0xaa1803e2
.word 0xaa1803e2
bl _p_20
.word 0xf90023a0
.word 0xf94017b1
.word 0xf9433a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x2, [x16, #280]
.word 0xaa1903e0
bl _p_7
.word 0xf94017b1
.word 0xf9436231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9438231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
bl _p_16
.word 0xf94017b1
.word 0xf9439e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf943ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf943be31
.word 0xb4000051
.word 0xd63f0220
.word 0xa94167b8
.word 0xf94013ba
.word 0x910003bf
.word 0xa8c77bfd
.word 0xd65f03c0

Lme_32:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBLocalStorage_get_ClassHandle
WindowsAzure_Messaging_SBLocalStorage_get_ClassHandle:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #288]
.word 0xf9000fb0
.word 0xf9400a11
.word 0xf90013b1
.word 0xf9400fb1
.word 0xf9403231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9405231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #296]
.word 0xf9400000
.word 0xf9001ba0
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9408631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xf9400fb1
.word 0xf9409a31
.word 0xb4000051
.word 0xd63f0220
.word 0x910003bf
.word 0xa8c47bfd
.word 0xd65f03c0

Lme_33:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBLocalStorage_Delete_string
WindowsAzure_Messaging_SBLocalStorage_Delete_string:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xa90167b8
.word 0xf90013ba
.word 0xaa0003f9
.word 0xaa0103fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #304]
.word 0xf90017b0
.word 0xf9400a11
.word 0xf9001bb1
.word 0xd2800018
.word 0xf94017b1
.word 0xf9404231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9406231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xb500025a
.word 0xf94017b1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd2804d61
.word 0xd2804d61
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf94017b1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_13
.word 0xf90027a0
.word 0xf94017b1
.word 0xf940de31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0
.word 0xaa0003f8
.word 0xf94017b1
.word 0xf940f631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_4
.word 0x53001c00
.word 0xf90023a0
.word 0xf94017b1
.word 0xf9411a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0x34000460
.word 0xf94017b1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_5
.word 0xf90023a0
.word 0xf94017b1
.word 0xf9415231
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_6@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_6@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf94017b1
.word 0xf9417231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
.word 0xaa1803e2
.word 0xaa1803e2
bl _p_21
.word 0xf94017b1
.word 0xf9419631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf941a631
.word 0xb4000051
.word 0xd63f0220
.word 0x1400001e
.word 0xf94017b1
.word 0xf941ba31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_8
.word 0xf90023a0
.word 0xf94017b1
.word 0xf941da31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_6@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_6@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf94017b1
.word 0xf941fa31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
.word 0xaa1803e2
.word 0xaa1803e2
bl _p_22
.word 0xf94017b1
.word 0xf9421e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9423e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
bl _p_16
.word 0xf94017b1
.word 0xf9425a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9426a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9427a31
.word 0xb4000051
.word 0xd63f0220
.word 0xa94167b8
.word 0xf94013ba
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_34:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBLocalStorage_DeleteAllRegistrations
WindowsAzure_Messaging_SBLocalStorage_DeleteAllRegistrations:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd
.word 0xf9000bba
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #312]
.word 0xf9000fb0
.word 0xf9400a11
.word 0xf90013b1
.word 0xf9400fb1
.word 0xf9403631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9405631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_4
.word 0x53001c00
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0x34000420
.word 0xf9400fb1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_5
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_7@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_7@PAGEOFF
ldr x0, [x0]
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf940d231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xf9401fa1
bl _p_23
.word 0xf9400fb1
.word 0xf940ee31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf940fe31
.word 0xb4000051
.word 0xd63f0220
.word 0x1400001c
.word 0xf9400fb1
.word 0xf9411231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_8
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_7@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_7@PAGEOFF
ldr x0, [x0]
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf9415231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xf9401fa1
bl _p_24
.word 0xf9400fb1
.word 0xf9416e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9418e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9419e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bba
.word 0x910003bf
.word 0xa8c47bfd
.word 0xd65f03c0

Lme_35:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBLocalStorage_GetStoredRegistrationEntry_string
WindowsAzure_Messaging_SBLocalStorage_GetStoredRegistrationEntry_string:
.loc 1 1 0
.word 0xa9b97bfd
.word 0x910003fd
.word 0xa90163b7
.word 0xa9026bb9
.word 0xaa0003f9
.word 0xaa0103fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #320]
.word 0xf9001bb0
.word 0xf9400a11
.word 0xf9001fb1
.word 0xd2800018
.word 0xd2800017
.word 0xf9401bb1
.word 0xf9404631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9406631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xb500025a
.word 0xf9401bb1
.word 0xf9407e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd2804d61
.word 0xd2804d61
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf9401bb1
.word 0xf940c231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_13
.word 0xf9002fa0
.word 0xf9401bb1
.word 0xf940e231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fa0
.word 0xaa0003f8
.word 0xf9401bb1
.word 0xf940fa31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_4
.word 0x53001c00
.word 0xf9002ba0
.word 0xf9401bb1
.word 0xf9411e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
.word 0x34000600
.word 0xf9401bb1
.word 0xf9413631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_5
.word 0xf90033a0
.word 0xf9401bb1
.word 0xf9415631
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_8@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_8@PAGEOFF
ldr x0, [x0]
.word 0xf90037a0
.word 0xf9401bb1
.word 0xf9417631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a0
.word 0xf94037a1
.word 0xaa1803e2
.word 0xaa1803e2
bl _p_19
.word 0xf9002fa0
.word 0xf9401bb1
.word 0xf9419e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fa0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x15, [x16, #328]
bl _p_25
.word 0xf9002ba0
.word 0xf9401bb1
.word 0xf941c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
.word 0xaa0003f7
.word 0xf9401bb1
.word 0xf941de31
.word 0xb4000051
.word 0xd63f0220
.word 0x1400002b
.word 0xf9401bb1
.word 0xf941f231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_8
.word 0xf90033a0
.word 0xf9401bb1
.word 0xf9421231
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_8@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_8@PAGEOFF
ldr x0, [x0]
.word 0xf90037a0
.word 0xf9401bb1
.word 0xf9423231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a0
.word 0xf94037a1
.word 0xaa1803e2
.word 0xaa1803e2
bl _p_20
.word 0xf9002fa0
.word 0xf9401bb1
.word 0xf9425a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fa0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x15, [x16, #328]
bl _p_25
.word 0xf9002ba0
.word 0xf9401bb1
.word 0xf9428231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
.word 0xaa0003f7
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf942aa31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
bl _p_16
.word 0xf9401bb1
.word 0xf942c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf942d631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf942fa31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xf9401bb1
.word 0xf9430e31
.word 0xb4000051
.word 0xd63f0220
.word 0xa94163b7
.word 0xa9426bb9
.word 0x910003bf
.word 0xa8c77bfd
.word 0xd65f03c0

Lme_36:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBLocalStorage_RefreshFinished_string
WindowsAzure_Messaging_SBLocalStorage_RefreshFinished_string:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xa90167b8
.word 0xf90013ba
.word 0xaa0003f9
.word 0xaa0103fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #336]
.word 0xf90017b0
.word 0xf9400a11
.word 0xf9001bb1
.word 0xd2800018
.word 0xf94017b1
.word 0xf9404231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9406231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xb500025a
.word 0xf94017b1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd2806a61
.word 0xd2806a61
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf94017b1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_13
.word 0xf90027a0
.word 0xf94017b1
.word 0xf940de31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0
.word 0xaa0003f8
.word 0xf94017b1
.word 0xf940f631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_4
.word 0x53001c00
.word 0xf90023a0
.word 0xf94017b1
.word 0xf9411a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0x34000460
.word 0xf94017b1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_5
.word 0xf90023a0
.word 0xf94017b1
.word 0xf9415231
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_9@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_9@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf94017b1
.word 0xf9417231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
.word 0xaa1803e2
.word 0xaa1803e2
bl _p_21
.word 0xf94017b1
.word 0xf9419631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf941a631
.word 0xb4000051
.word 0xd63f0220
.word 0x1400001e
.word 0xf94017b1
.word 0xf941ba31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_8
.word 0xf90023a0
.word 0xf94017b1
.word 0xf941da31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_9@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_9@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf94017b1
.word 0xf941fa31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
.word 0xaa1803e2
.word 0xaa1803e2
bl _p_22
.word 0xf94017b1
.word 0xf9421e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9423e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
bl _p_16
.word 0xf94017b1
.word 0xf9425a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9426a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9427a31
.word 0xb4000051
.word 0xd63f0220
.word 0xa94167b8
.word 0xf94013ba
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_37:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBLocalStorage_Update_string_WindowsAzure_Messaging_SBRegistration
WindowsAzure_Messaging_SBLocalStorage_Update_string_WindowsAzure_Messaging_SBRegistration:
.loc 1 1 0
.word 0xa9b97bfd
.word 0x910003fd
.word 0xa90163b7
.word 0xa9026bb9
.word 0xaa0003f8
.word 0xaa0103f9
.word 0xaa0203fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #344]
.word 0xf9001bb0
.word 0xf9400a11
.word 0xf9001fb1
.word 0xd2800017
.word 0xf9401bb1
.word 0xf9404631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9406631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xb5000259
.word 0xf9401bb1
.word 0xf9407e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd2804d61
.word 0xd2804d61
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf9401bb1
.word 0xf940c231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xb500025a
.word 0xf9401bb1
.word 0xf940da31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd2807621
.word 0xd2807621
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf9401bb1
.word 0xf9411e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_13
.word 0xf9002fa0
.word 0xf9401bb1
.word 0xf9413e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fa0
.word 0xaa0003f7
.word 0xf9401bb1
.word 0xf9415631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
bl _p_4
.word 0x53001c00
.word 0xf9002ba0
.word 0xf9401bb1
.word 0xf9417a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
.word 0x340005a0
.word 0xf9401bb1
.word 0xf9419231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
bl _p_5
.word 0xf9002ba0
.word 0xf9401bb1
.word 0xf941b231
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_10@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_10@PAGEOFF
ldr x0, [x0]
.word 0xf9002fa0
.word 0xf9401bb1
.word 0xf941d231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0xf940035e
bl _p_5
.word 0xf90033a0
.word 0xf9401bb1
.word 0xf941fa31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
.word 0xf9402fa1
.word 0xf94033a3
.word 0xaa1703e2
bl _p_26
.word 0xf9401bb1
.word 0xf9421e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9422e31
.word 0xb4000051
.word 0xd63f0220
.word 0x14000028
.word 0xf9401bb1
.word 0xf9424231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
bl _p_8
.word 0xf9002ba0
.word 0xf9401bb1
.word 0xf9426231
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_10@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_10@PAGEOFF
ldr x0, [x0]
.word 0xf9002fa0
.word 0xf9401bb1
.word 0xf9428231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0xf940035e
bl _p_5
.word 0xf90033a0
.word 0xf9401bb1
.word 0xf942aa31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
.word 0xf9402fa1
.word 0xf94033a3
.word 0xaa1703e2
bl _p_27
.word 0xf9401bb1
.word 0xf942ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf942ee31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xaa1703e0
bl _p_16
.word 0xf9401bb1
.word 0xf9430a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9431a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9432a31
.word 0xb4000051
.word 0xd63f0220
.word 0xa94163b7
.word 0xa9426bb9
.word 0x910003bf
.word 0xa8c77bfd
.word 0xd65f03c0

Lme_38:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBLocalStorage_Update_string_string_string_string
WindowsAzure_Messaging_SBLocalStorage_Update_string_string_string_string:
.loc 1 1 0
.word 0xa9b67bfd
.word 0x910003fd
.word 0xa90153b3
.word 0xa9025bb5
.word 0xa90363b7
.word 0xa9046bb9
.word 0xaa0003f6
.word 0xaa0103f7
.word 0xaa0203f8
.word 0xaa0303f9
.word 0xaa0403fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #352]
.word 0xf9002bb0
.word 0xf9400a11
.word 0xf9002fb1
.word 0xd2800015
.word 0xd2800014
.word 0xd2800013
.word 0xf90037bf
.word 0xf9402bb1
.word 0xf9406231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9408231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xb5000257
.word 0xf9402bb1
.word 0xf9409a31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd2804d61
.word 0xd2804d61
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf9402bb1
.word 0xf940de31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xb5000258
.word 0xf9402bb1
.word 0xf940f631
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd28083a1
.word 0xd28083a1
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf9402bb1
.word 0xf9413a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xb5000259
.word 0xf9402bb1
.word 0xf9415231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd2808761
.word 0xd2808761
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf9402bb1
.word 0xf9419631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xb500025a
.word 0xf9402bb1
.word 0xf941ae31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd28088a1
.word 0xd28088a1
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf9402bb1
.word 0xf941f231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xaa1703e0
bl _p_13
.word 0xf9004ba0
.word 0xf9402bb1
.word 0xf9421231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9404ba0
.word 0xaa0003f5
.word 0xf9402bb1
.word 0xf9422a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
bl _p_13
.word 0xf90047a0
.word 0xf9402bb1
.word 0xf9424a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94047a0
.word 0xaa0003f4
.word 0xf9402bb1
.word 0xf9426231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_13
.word 0xf90043a0
.word 0xf9402bb1
.word 0xf9428231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94043a0
.word 0xaa0003f3
.word 0xf9402bb1
.word 0xf9429a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_13
.word 0xf9003fa0
.word 0xf9402bb1
.word 0xf942ba31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403fa0
.word 0xf90037a0
.word 0xf9402bb1
.word 0xf942d231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0xaa1603e0
bl _p_4
.word 0x53001c00
.word 0xf9003ba0
.word 0xf9402bb1
.word 0xf942f631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403ba0
.word 0x34000500
.word 0xf9402bb1
.word 0xf9430e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0xaa1603e0
bl _p_5
.word 0xf9003ba0
.word 0xf9402bb1
.word 0xf9432e31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_11@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_11@PAGEOFF
ldr x0, [x0]
.word 0xf9003fa0
.word 0xf9402bb1
.word 0xf9434e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403ba0
.word 0xf9403fa1
.word 0xaa1503e2
.word 0xaa1403e2
.word 0xaa1303e2
.word 0xf94037a5
.word 0xaa1503e2
.word 0xaa1403e3
.word 0xaa1303e4
bl _p_28
.word 0xf9402bb1
.word 0xf9438631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9439631
.word 0xb4000051
.word 0xd63f0220
.word 0x14000023
.word 0xf9402bb1
.word 0xf943aa31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0xaa1603e0
bl _p_8
.word 0xf9003ba0
.word 0xf9402bb1
.word 0xf943ca31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_11@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_11@PAGEOFF
ldr x0, [x0]
.word 0xf9003fa0
.word 0xf9402bb1
.word 0xf943ea31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403ba0
.word 0xf9403fa1
.word 0xaa1503e2
.word 0xaa1403e2
.word 0xaa1303e2
.word 0xf94037a5
.word 0xaa1503e2
.word 0xaa1403e3
.word 0xaa1303e4
bl _p_29
.word 0xf9402bb1
.word 0xf9442231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9444231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1503e0
.word 0xaa1503e0
bl _p_16
.word 0xf9402bb1
.word 0xf9445e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9446e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1403e0
.word 0xaa1403e0
bl _p_16
.word 0xf9402bb1
.word 0xf9448a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9449a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1303e0
.word 0xaa1303e0
bl _p_16
.word 0xf9402bb1
.word 0xf944b631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf944c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94037a0
bl _p_16
.word 0xf9402bb1
.word 0xf944de31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf944ee31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf944fe31
.word 0xb4000051
.word 0xd63f0220
.word 0xa94153b3
.word 0xa9425bb5
.word 0xa94363b7
.word 0xa9446bb9
.word 0x910003bf
.word 0xa8ca7bfd
.word 0xd65f03c0

Lme_39:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBLocalStorage_Update_string
WindowsAzure_Messaging_SBLocalStorage_Update_string:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xa90167b8
.word 0xf90013ba
.word 0xaa0003f9
.word 0xaa0103fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #360]
.word 0xf90017b0
.word 0xf9400a11
.word 0xf9001bb1
.word 0xd2800018
.word 0xf94017b1
.word 0xf9404231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9406231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xb500025a
.word 0xf94017b1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd2804d61
.word 0xd2804d61
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf94017b1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_13
.word 0xf90027a0
.word 0xf94017b1
.word 0xf940de31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0
.word 0xaa0003f8
.word 0xf94017b1
.word 0xf940f631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_4
.word 0x53001c00
.word 0xf90023a0
.word 0xf94017b1
.word 0xf9411a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0x34000460
.word 0xf94017b1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_5
.word 0xf90023a0
.word 0xf94017b1
.word 0xf9415231
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_12@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_12@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf94017b1
.word 0xf9417231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
.word 0xaa1803e2
.word 0xaa1803e2
bl _p_21
.word 0xf94017b1
.word 0xf9419631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf941a631
.word 0xb4000051
.word 0xd63f0220
.word 0x1400001e
.word 0xf94017b1
.word 0xf941ba31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_8
.word 0xf90023a0
.word 0xf94017b1
.word 0xf941da31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_12@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_12@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf94017b1
.word 0xf941fa31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
.word 0xaa1803e2
.word 0xaa1803e2
bl _p_22
.word 0xf94017b1
.word 0xf9421e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9423e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
bl _p_16
.word 0xf94017b1
.word 0xf9425a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9426a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9427a31
.word 0xb4000051
.word 0xd63f0220
.word 0xa94167b8
.word 0xf94013ba
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_3a:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBLocalStorage_Update_WindowsAzure_Messaging_SBRegistration
WindowsAzure_Messaging_SBLocalStorage_Update_WindowsAzure_Messaging_SBRegistration:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xa9016bb9
.word 0xaa0003f9
.word 0xaa0103fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #368]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xf94013b1
.word 0xf9403a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9405a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xb500025a
.word 0xf94013b1
.word 0xf9407231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd2807621
.word 0xd2807621
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf94013b1
.word 0xf940b631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_4
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf940da31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0x34000560
.word 0xf94013b1
.word 0xf940f231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_5
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9411231
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_13@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_13@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf94013b1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0xf940035e
bl _p_5
.word 0xf9002ba0
.word 0xf94013b1
.word 0xf9415631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
.word 0xf9402ba2
bl _p_21
.word 0xf94013b1
.word 0xf9417631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9418631
.word 0xb4000051
.word 0xd63f0220
.word 0x14000026
.word 0xf94013b1
.word 0xf9419a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_8
.word 0xf90023a0
.word 0xf94013b1
.word 0xf941ba31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_13@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_13@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf94013b1
.word 0xf941da31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0xf940035e
bl _p_5
.word 0xf9002ba0
.word 0xf94013b1
.word 0xf941fe31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
.word 0xf9402ba2
bl _p_22
.word 0xf94013b1
.word 0xf9421e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9423e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9424e31
.word 0xb4000051
.word 0xd63f0220
.word 0xa9416bb9
.word 0x910003bf
.word 0xa8c67bfd
.word 0xd65f03c0

Lme_3b:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBLocalStorage_get_DeviceToken
WindowsAzure_Messaging_SBLocalStorage_get_DeviceToken:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000bba
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #376]
.word 0xf9000fb0
.word 0xf9400a11
.word 0xf90013b1
.word 0xf9400fb1
.word 0xf9403631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9405631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_4
.word 0x53001c00
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0x340005c0
.word 0xf9400fb1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_5
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_14@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_14@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf940d231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
bl _p_6
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf940f231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
bl _p_15
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf9410e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9412e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0x1400002d
.word 0xf9400fb1
.word 0xf9414631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_8
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9416631
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_14@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_14@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf9418631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
bl _p_9
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf941a631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
bl _p_15
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf941c231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf941e231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xf9400fb1
.word 0xf941f631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bba
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_3c:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBLocalStorage_set_DeviceToken_string
WindowsAzure_Messaging_SBLocalStorage_set_DeviceToken_string:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xa90167b8
.word 0xf90013ba
.word 0xaa0003f9
.word 0xaa0103fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #384]
.word 0xf90017b0
.word 0xf9400a11
.word 0xf9001bb1
.word 0xd2800018
.word 0xf94017b1
.word 0xf9404231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9406231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xb500025a
.word 0xf94017b1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd280a7a1
.word 0xd280a7a1
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf94017b1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_13
.word 0xf90027a0
.word 0xf94017b1
.word 0xf940de31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0
.word 0xaa0003f8
.word 0xf94017b1
.word 0xf940f631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_4
.word 0x53001c00
.word 0xf90023a0
.word 0xf94017b1
.word 0xf9411a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0x34000460
.word 0xf94017b1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_5
.word 0xf90023a0
.word 0xf94017b1
.word 0xf9415231
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_15@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_15@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf94017b1
.word 0xf9417231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
.word 0xaa1803e2
.word 0xaa1803e2
bl _p_21
.word 0xf94017b1
.word 0xf9419631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf941a631
.word 0xb4000051
.word 0xd63f0220
.word 0x1400001e
.word 0xf94017b1
.word 0xf941ba31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_8
.word 0xf90023a0
.word 0xf94017b1
.word 0xf941da31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_15@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_15@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf94017b1
.word 0xf941fa31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
.word 0xaa1803e2
.word 0xaa1803e2
bl _p_22
.word 0xf94017b1
.word 0xf9421e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9423e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
bl _p_16
.word 0xf94017b1
.word 0xf9425a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9426a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9427a31
.word 0xb4000051
.word 0xd63f0220
.word 0xa94167b8
.word 0xf94013ba
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_3d:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBLocalStorage_get_IsRefreshNeeded
WindowsAzure_Messaging_SBLocalStorage_get_IsRefreshNeeded:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000bba
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #392]
.word 0xf9000fb0
.word 0xf9400a11
.word 0xf90013b1
.word 0xf9400fb1
.word 0xf9403631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9405631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_4
.word 0x53001c00
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0x34000500
.word 0xf9400fb1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_5
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_16@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_16@PAGEOFF
ldr x0, [x0]
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf940d231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
.word 0xf94023a1
bl _p_30
.word 0x53001c00
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf940f631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9411631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0x14000027
.word 0xf9400fb1
.word 0xf9412e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_8
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf9414e31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_16@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_16@PAGEOFF
ldr x0, [x0]
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9416e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
.word 0xf94023a1
bl _p_31
.word 0x53001c00
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf9419231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf941b231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xf9400fb1
.word 0xf941c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bba
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_3e:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBLocalStorage_set_IsRefreshNeeded_bool
WindowsAzure_Messaging_SBLocalStorage_set_IsRefreshNeeded_bool:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xa9016bb9
.word 0xaa0003f9
.word 0xaa0103fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #400]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xf94013b1
.word 0xf9403a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9405a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_4
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9407e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0x34000460
.word 0xf94013b1
.word 0xf9409631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_5
.word 0xf90023a0
.word 0xf94013b1
.word 0xf940b631
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_17@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_17@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf94013b1
.word 0xf940d631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
.word 0xaa1a03e2
.word 0xaa1a03e2
bl _p_32
.word 0xf94013b1
.word 0xf940fa31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9410a31
.word 0xb4000051
.word 0xd63f0220
.word 0x1400001e
.word 0xf94013b1
.word 0xf9411e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_8
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9413e31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_17@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_17@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf94013b1
.word 0xf9415e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
.word 0xaa1a03e2
.word 0xaa1a03e2
bl _p_33
.word 0xf94013b1
.word 0xf9418231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf941a231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf941b231
.word 0xb4000051
.word 0xd63f0220
.word 0xa9416bb9
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_3f:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBLocalStorage__cctor
WindowsAzure_Messaging_SBLocalStorage__cctor:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #408]
.word 0xf9000bb0
.word 0xf9400a11
.word 0xf9000fb1
.word 0xf9400bb1
.word 0xf9402e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb1
.word 0xf9404e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #416]
bl _p_18
.word 0xf9001ba0
.word 0xf9400bb1
.word 0xf9407231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #296]
.word 0xf9000001
.word 0xf9400bb1
.word 0xf9409631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb1
.word 0xf940a631
.word 0xb4000051
.word 0xd63f0220
.word 0x910003bf
.word 0xa8c47bfd
.word 0xd65f03c0

Lme_40:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBNotificationHub__ctor
WindowsAzure_Messaging_SBNotificationHub__ctor:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000bba
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #424]
.word 0xf9000fb0
.word 0xf9400a11
.word 0xf90013b1
.word 0xf9400fb1
.word 0xf9403631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9405631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #152]
.word 0xf9400001
.word 0xaa1a03e0
bl _p_1
.word 0xf9400fb1
.word 0xf9408231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0xf9400340
.word 0xf9400c00
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf940b631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a1
.word 0xaa0103e0
.word 0xf9400021
.word 0xf943c430
.word 0xd63f0200
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf940de31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x1, [x16, #136]
.word 0xf9400021
bl _p_2
.word 0x53001c00
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf9410e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa1
.word 0xaa1a03e0
bl _p_3
.word 0xf9400fb1
.word 0xf9412a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9413a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_4
.word 0x53001c00
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf9415e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0x340005a0
.word 0xf9400fb1
.word 0xf9417631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_5
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf9419a31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_0@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_0@PAGEOFF
ldr x0, [x0]
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf941ba31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
.word 0xf94023a1
bl _p_6
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf941da31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x2, [x16, #160]
.word 0xaa1a03e0
bl _p_7
.word 0xf9400fb1
.word 0xf9420231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9421231
.word 0xb4000051
.word 0xd63f0220
.word 0x14000028
.word 0xf9400fb1
.word 0xf9422631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_8
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf9424a31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_0@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_0@PAGEOFF
ldr x0, [x0]
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9426a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
.word 0xf94023a1
bl _p_9
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf9428a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x2, [x16, #160]
.word 0xaa1a03e0
bl _p_7
.word 0xf9400fb1
.word 0xf942b231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf942d231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf942e231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bba
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_41:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBNotificationHub__ctor_Foundation_NSObjectFlag
WindowsAzure_Messaging_SBNotificationHub__ctor_Foundation_NSObjectFlag:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bb9
.word 0xaa0003f9
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #432]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xf94013b1
.word 0xf9403a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9405a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xf9400fa1
.word 0xaa1903e0
bl _p_1
.word 0xf94013b1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9408a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0xf9400320
.word 0xf9400c00
.word 0xf9002ba0
.word 0xf94013b1
.word 0xf940ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba1
.word 0xaa0103e0
.word 0xf9400021
.word 0xf943c430
.word 0xd63f0200
.word 0xf90027a0
.word 0xf94013b1
.word 0xf940d631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x1, [x16, #136]
.word 0xf9400021
bl _p_2
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a1
.word 0xaa1903e0
bl _p_3
.word 0xf94013b1
.word 0xf9412231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9414231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb9
.word 0x910003bf
.word 0xa8c67bfd
.word 0xd65f03c0

Lme_42:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBNotificationHub__ctor_intptr
WindowsAzure_Messaging_SBNotificationHub__ctor_intptr:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bb9
.word 0xaa0003f9
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #440]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xf94013b1
.word 0xf9403a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9405a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xf9400fa1
.word 0xaa1903e0
bl _p_10
.word 0xf94013b1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9408a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0xf9400320
.word 0xf9400c00
.word 0xf9002ba0
.word 0xf94013b1
.word 0xf940ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba1
.word 0xaa0103e0
.word 0xf9400021
.word 0xf943c430
.word 0xd63f0200
.word 0xf90027a0
.word 0xf94013b1
.word 0xf940d631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x1, [x16, #136]
.word 0xf9400021
bl _p_2
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a1
.word 0xaa1903e0
bl _p_3
.word 0xf94013b1
.word 0xf9412231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9414231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb9
.word 0x910003bf
.word 0xa8c67bfd
.word 0xd65f03c0

Lme_43:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBNotificationHub__ctor_string_string
WindowsAzure_Messaging_SBNotificationHub__ctor_string_string:
.loc 1 1 0
.word 0xa9b87bfd
.word 0x910003fd
.word 0xa9015fb6
.word 0xa90267b8
.word 0xf9001bba
.word 0xaa0003f8
.word 0xaa0103f9
.word 0xaa0203fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #448]
.word 0xf9001fb0
.word 0xf9400a11
.word 0xf90023b1
.word 0xd2800017
.word 0xd2800016
.word 0xf9401fb1
.word 0xf9404e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9406e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #152]
.word 0xf9400001
.word 0xaa1803e0
bl _p_1
.word 0xf9401fb1
.word 0xf9409a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf940aa31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xb5000259
.word 0xf9401fb1
.word 0xf940c231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd280b9e1
.word 0xd280b9e1
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf9401fb1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xb500025a
.word 0xf9401fb1
.word 0xf9411e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd2804121
.word 0xd2804121
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf9401fb1
.word 0xf9416231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_13
.word 0xf9003fa0
.word 0xf9401fb1
.word 0xf9418231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403fa0
.word 0xaa0003f7
.word 0xf9401fb1
.word 0xf9419a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_13
.word 0xf9003ba0
.word 0xf9401fb1
.word 0xf941ba31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403ba0
.word 0xaa0003f6
.word 0xf9401fb1
.word 0xf941d231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
.word 0xf9400300
.word 0xf9400c00
.word 0xf90037a0
.word 0xf9401fb1
.word 0xf941f631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94037a1
.word 0xaa0103e0
.word 0xf9400021
.word 0xf943c430
.word 0xd63f0200
.word 0xf90033a0
.word 0xf9401fb1
.word 0xf9421e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x1, [x16, #136]
.word 0xf9400021
bl _p_2
.word 0x53001c00
.word 0xf9002fa0
.word 0xf9401fb1
.word 0xf9424e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fa1
.word 0xaa1803e0
bl _p_3
.word 0xf9401fb1
.word 0xf9426a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9427a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
bl _p_4
.word 0x53001c00
.word 0xf9002ba0
.word 0xf9401fb1
.word 0xf9429e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
.word 0x34000620
.word 0xf9401fb1
.word 0xf942b631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
.word 0xaa1803e0
bl _p_5
.word 0xf9002fa0
.word 0xf9401fb1
.word 0xf942da31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_18@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_18@PAGEOFF
ldr x0, [x0]
.word 0xf90033a0
.word 0xf9401fb1
.word 0xf942fa31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fa0
.word 0xf94033a1
.word 0xaa1703e2
.word 0xaa1603e2
.word 0xaa1703e2
.word 0xaa1603e3
bl _p_17
.word 0xf9002ba0
.word 0xf9401fb1
.word 0xf9432a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x2, [x16, #456]
.word 0xaa1803e0
bl _p_7
.word 0xf9401fb1
.word 0xf9435231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9436231
.word 0xb4000051
.word 0xd63f0220
.word 0x1400002c
.word 0xf9401fb1
.word 0xf9437631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
.word 0xaa1803e0
bl _p_8
.word 0xf9002fa0
.word 0xf9401fb1
.word 0xf9439a31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_18@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_18@PAGEOFF
ldr x0, [x0]
.word 0xf90033a0
.word 0xf9401fb1
.word 0xf943ba31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fa0
.word 0xf94033a1
.word 0xaa1703e2
.word 0xaa1603e2
.word 0xaa1703e2
.word 0xaa1603e3
bl _p_34
.word 0xf9002ba0
.word 0xf9401fb1
.word 0xf943ea31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x2, [x16, #456]
.word 0xaa1803e0
bl _p_7
.word 0xf9401fb1
.word 0xf9441231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9443231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xaa1703e0
bl _p_16
.word 0xf9401fb1
.word 0xf9444e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9445e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0xaa1603e0
bl _p_16
.word 0xf9401fb1
.word 0xf9447a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9448a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9449a31
.word 0xb4000051
.word 0xd63f0220
.word 0xa9415fb6
.word 0xa94267b8
.word 0xf9401bba
.word 0x910003bf
.word 0xa8c87bfd
.word 0xd65f03c0

Lme_44:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBNotificationHub_get_ClassHandle
WindowsAzure_Messaging_SBNotificationHub_get_ClassHandle:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #464]
.word 0xf9000fb0
.word 0xf9400a11
.word 0xf90013b1
.word 0xf9400fb1
.word 0xf9403231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9405231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #472]
.word 0xf9400000
.word 0xf9001ba0
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9408631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xf9400fb1
.word 0xf9409a31
.word 0xb4000051
.word 0xd63f0220
.word 0x910003bf
.word 0xa8c47bfd
.word 0xd65f03c0

Lme_45:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBNotificationHub_RegisterNative_Foundation_NSData_Foundation_NSSet_Foundation_NSError_
WindowsAzure_Messaging_SBNotificationHub_RegisterNative_Foundation_NSData_Foundation_NSSet_Foundation_NSError_:
.loc 1 1 0
.word 0xa9b67bfd
.word 0x910003fd
.word 0xa90153b3
.word 0xa9025bb5
.word 0xa90363b7
.word 0xa9046bb9
.word 0xaa0003f7
.word 0xaa0103f8
.word 0xaa0203f9
.word 0xf9002ba3

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #480]
.word 0xf9002fb0
.word 0xf9400a11
.word 0xf90033b1
.word 0xf9003bbf
.word 0xd2800016
.word 0xf9402fb1
.word 0xf9405631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fb1
.word 0xf9407631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xb5000258
.word 0xf9402fb1
.word 0xf9408e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd28088a1
.word 0xd28088a1
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf9402fb1
.word 0xf940d231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #488]
.word 0xf9400000
.word 0xf9003ba0
.word 0xf9402fb1
.word 0xf940f631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xaa1703e0
bl _p_4
.word 0x53001c00
.word 0xf90043a0
.word 0xf9402fb1
.word 0xf9411a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94043a0
.word 0x34000a80
.word 0xf9402fb1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xaa1703e0
bl _p_5
.word 0xf9004ba0
.word 0xf9402fb1
.word 0xf9415231
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_19@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_19@PAGEOFF
ldr x0, [x0]
.word 0xf90047a0
.word 0xf9402fb1
.word 0xf9417231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
.word 0xf940031e
bl _p_5
.word 0xf90043a0
.word 0xf9402fb1
.word 0xf9419631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94043a0
.word 0xf94047a1
.word 0xf9404ba2
.word 0xaa1903e3
.word 0xaa0203f5
.word 0xaa0103f4
.word 0xaa0003f3
.word 0xb5000159
.word 0xaa1503e0
.word 0xaa1403e0
.word 0xaa1303e0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #488]
.word 0xf9400000
.word 0xaa0003fa
.word 0x1400000f
.word 0xaa1503e0
.word 0xaa1403e0
.word 0xaa1303e0
.word 0xaa1903e0
.word 0xaa1903e0
.word 0xf940033e
bl _p_5
.word 0xf90043a0
.word 0xf9402fb1
.word 0xf9420a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94043a0
.word 0xaa0003fa
.word 0xaa1503e0
.word 0xaa1403e0
.word 0xaa1303e0
.word 0xaa1a03e0
.word 0x9101c3a4
.word 0xaa1503e0
.word 0xaa1403e1
.word 0xaa1303e2
.word 0xaa1a03e3
bl _p_35
.word 0x53001c00
.word 0xf90043a0
.word 0xf9402fb1
.word 0xf9425231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94043a0
.word 0xaa0003f6
.word 0xf9402fb1
.word 0xf9426a31
.word 0xb4000051
.word 0xd63f0220
.word 0x1400004f
.word 0xf9402fb1
.word 0xf9427e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xaa1703e0
bl _p_8
.word 0xf9004ba0
.word 0xf9402fb1
.word 0xf9429e31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_19@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_19@PAGEOFF
ldr x0, [x0]
.word 0xf90047a0
.word 0xf9402fb1
.word 0xf942be31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
.word 0xf940031e
bl _p_5
.word 0xf90043a0
.word 0xf9402fb1
.word 0xf942e231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94043a0
.word 0xf94047a1
.word 0xf9404ba2
.word 0xaa1903e3
.word 0xaa0203f5
.word 0xaa0103f4
.word 0xaa0003f3
.word 0xb5000159
.word 0xaa1503e0
.word 0xaa1403e0
.word 0xaa1303e0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #488]
.word 0xf9400000
.word 0xaa0003fa
.word 0x1400000f
.word 0xaa1503e0
.word 0xaa1403e0
.word 0xaa1303e0
.word 0xaa1903e0
.word 0xaa1903e0
.word 0xf940033e
bl _p_5
.word 0xf90043a0
.word 0xf9402fb1
.word 0xf9435631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94043a0
.word 0xaa0003fa
.word 0xaa1503e0
.word 0xaa1403e0
.word 0xaa1303e0
.word 0xaa1a03e0
.word 0x9101c3a4
.word 0xaa1503e0
.word 0xaa1403e1
.word 0xaa1303e2
.word 0xaa1a03e3
bl _p_36
.word 0x53001c00
.word 0xf90043a0
.word 0xf9402fb1
.word 0xf9439e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94043a0
.word 0xaa0003f6
.word 0xf94033b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fb1
.word 0xf943c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
.word 0xf90047a0
.word 0xf9403ba0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x1, [x16, #488]
.word 0xf9400021
bl _p_37
.word 0x53001c00
.word 0xf90043a0
.word 0xf9402fb1
.word 0xf943fe31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94043a0
.word 0xf94047a1
.word 0xaa0103f5
.word 0x340001e0
.word 0xaa1503e0
.word 0xf9403ba0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x15, [x16, #496]
bl _p_38
.word 0xf90043a0
.word 0xf9402fb1
.word 0xf9443a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94043a0
.word 0xf9003fa0
.word 0x14000004
.word 0xaa1503e0
.word 0xd2800000
.word 0xf9003fbf
.word 0xaa1503e0
.word 0xf9403fa0
.word 0xf90043a0
.word 0xf90002a0
.word 0xaa1503e0
bl _p_39
.word 0xf94043a0
.word 0xf9402fb1
.word 0xf9447e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0xf94033b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fb1
.word 0xf944a231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0xf9402fb1
.word 0xf944b631
.word 0xb4000051
.word 0xd63f0220
.word 0xa94153b3
.word 0xa9425bb5
.word 0xa94363b7
.word 0xa9446bb9
.word 0x910003bf
.word 0xa8ca7bfd
.word 0xd65f03c0

Lme_46:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBNotificationHub_RegisterNativeAsync_Foundation_NSData_Foundation_NSSet_WindowsAzure_Messaging_ErrorCallback
WindowsAzure_Messaging_SBNotificationHub_RegisterNativeAsync_Foundation_NSData_Foundation_NSSet_WindowsAzure_Messaging_ErrorCallback:
.loc 1 1 0
.word 0xa9b47bfd
.word 0x910003fd
.word 0xa90153b3
.word 0xa9025bb5
.word 0xa90363b7
.word 0xa9046bb9
.word 0xaa0003f7
.word 0xaa0103f8
.word 0xaa0203f9
.word 0xaa0303fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #504]
.word 0xf9002bb0
.word 0xf9400a11
.word 0xf9002fb1
.word 0xf9004fbf
.word 0x9101a3a0
.word 0xd2800000
.word 0xf90037a0
.word 0xf9003ba0
.word 0xf9003fa0
.word 0xf90043a0
.word 0xf90047a0
.word 0xf9004ba0
.word 0xf9402bb1
.word 0xf9407231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xb5000258
.word 0xf9402bb1
.word 0xf940aa31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd28088a1
.word 0xd28088a1
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf9402bb1
.word 0xf940ee31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xb500025a
.word 0xf9402bb1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd280d421
.word 0xd280d421
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf9402bb1
.word 0xf9414a31
.word 0xb4000051
.word 0xd63f0220
.word 0x9101a3a0
.word 0xd2800000
.word 0xf90037a0
.word 0xf9003ba0
.word 0xf9003fa0
.word 0xf90043a0
.word 0xf90047a0
.word 0xf9004ba0
.word 0xf9402bb1
.word 0xf9417a31
.word 0xb4000051
.word 0xd63f0220
.word 0x9101a3a0
.word 0xf9004fa0
.word 0xf9402bb1
.word 0xf9419231
.word 0xb4000051
.word 0xd63f0220
.word 0x9101a3a0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x1, [x16, #512]
.word 0xf9400021
.word 0xaa1a03e2
.word 0xaa1a03e2
bl _p_40
.word 0xf9402bb1
.word 0xf941c231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf941d231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xaa1703e0
bl _p_4
.word 0x53001c00
.word 0xf90053a0
.word 0xf9402bb1
.word 0xf941f631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94053a0
.word 0x34000ae0
.word 0xf9402bb1
.word 0xf9420e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xaa1703e0
bl _p_5
.word 0xf9005ba0
.word 0xf9402bb1
.word 0xf9422e31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_20@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_20@PAGEOFF
ldr x0, [x0]
.word 0xf90057a0
.word 0xf9402bb1
.word 0xf9424e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
.word 0xf940031e
bl _p_5
.word 0xf90053a0
.word 0xf9402bb1
.word 0xf9427231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94053a0
.word 0xf94057a1
.word 0xf9405ba2
.word 0xaa1903e3
.word 0xaa0203f5
.word 0xaa0103f4
.word 0xaa0003f3
.word 0xb5000159
.word 0xaa1503e0
.word 0xaa1403e0
.word 0xaa1303e0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #488]
.word 0xf9400000
.word 0xaa0003f6
.word 0x1400000f
.word 0xaa1503e0
.word 0xaa1403e0
.word 0xaa1303e0
.word 0xaa1903e0
.word 0xaa1903e0
.word 0xf940033e
bl _p_5
.word 0xf90053a0
.word 0xf9402bb1
.word 0xf942e631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94053a0
.word 0xaa0003f6
.word 0xaa1503e0
.word 0xaa1403e0
.word 0xaa1303e0
.word 0xaa1603e0
.word 0xf9404fa0
bl _p_41
.word 0xf90053a0
.word 0xf9402bb1
.word 0xf9431a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94053a4
.word 0xaa1503e0
.word 0xaa1403e1
.word 0xaa1303e2
.word 0xaa1603e3
bl _p_42
.word 0xf9402bb1
.word 0xf9434231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9435231
.word 0xb4000051
.word 0xd63f0220
.word 0x14000052
.word 0xf9402bb1
.word 0xf9436631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xaa1703e0
bl _p_8
.word 0xf9005ba0
.word 0xf9402bb1
.word 0xf9438631
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_20@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_20@PAGEOFF
ldr x0, [x0]
.word 0xf90057a0
.word 0xf9402bb1
.word 0xf943a631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
.word 0xf940031e
bl _p_5
.word 0xf90053a0
.word 0xf9402bb1
.word 0xf943ca31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94053a0
.word 0xf94057a1
.word 0xf9405ba2
.word 0xaa1903e3
.word 0xaa0203f5
.word 0xaa0103f4
.word 0xaa0003f3
.word 0xb5000159
.word 0xaa1503e0
.word 0xaa1403e0
.word 0xaa1303e0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #488]
.word 0xf9400000
.word 0xaa0003f6
.word 0x1400000f
.word 0xaa1503e0
.word 0xaa1403e0
.word 0xaa1303e0
.word 0xaa1903e0
.word 0xaa1903e0
.word 0xf940033e
bl _p_5
.word 0xf90053a0
.word 0xf9402bb1
.word 0xf9443e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94053a0
.word 0xaa0003f6
.word 0xaa1503e0
.word 0xaa1403e0
.word 0xaa1303e0
.word 0xaa1603e0
.word 0xf9404fa0
bl _p_41
.word 0xf90053a0
.word 0xf9402bb1
.word 0xf9447231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94053a4
.word 0xaa1503e0
.word 0xaa1403e1
.word 0xaa1303e2
.word 0xaa1603e3
bl _p_43
.word 0xf9402bb1
.word 0xf9449a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf944ba31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9404fa0
bl _p_44
.word 0xf9402bb1
.word 0xf944d231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf944e231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf944f231
.word 0xb4000051
.word 0xd63f0220
.word 0xa94153b3
.word 0xa9425bb5
.word 0xa94363b7
.word 0xa9446bb9
.word 0x910003bf
.word 0xa8cc7bfd
.word 0xd65f03c0

Lme_47:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBNotificationHub_RegisterTemplate_Foundation_NSData_string_string_string_Foundation_NSSet_Foundation_NSError_
WindowsAzure_Messaging_SBNotificationHub_RegisterTemplate_Foundation_NSData_string_string_string_Foundation_NSSet_Foundation_NSError_:
.loc 1 1 0
.word 0xa9b17bfd
.word 0x910003fd
.word 0xa90153b3
.word 0xa9025bb5
.word 0xa90363b7
.word 0xa9046bb9
.word 0xf9002ba0
.word 0xf9002fa1
.word 0xf90033a2
.word 0xf90037a3
.word 0xf9003ba4
.word 0xf9003fa5
.word 0xf90043a6

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #520]
.word 0xf90047b0
.word 0xf9400a11
.word 0xf9004bb1
.word 0xf90053bf
.word 0xf90057bf
.word 0xd280001a
.word 0xf9005bbf
.word 0x3902e3bf
.word 0xf94047b1
.word 0xf9406e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9404bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94047b1
.word 0xf9408e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fa0
.word 0xb5000240
.word 0xf94047b1
.word 0xf940a631
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd28088a1
.word 0xd28088a1
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf94047b1
.word 0xf940ea31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a0
.word 0xb5000240
.word 0xf94047b1
.word 0xf9410231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd280e361
.word 0xd280e361
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf94047b1
.word 0xf9414631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94037a0
.word 0xb5000240
.word 0xf94047b1
.word 0xf9415e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd280e6a1
.word 0xd280e6a1
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf94047b1
.word 0xf941a231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403ba0
.word 0xb5000240
.word 0xf94047b1
.word 0xf941ba31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd280eae1
.word 0xd280eae1
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf94047b1
.word 0xf941fe31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #488]
.word 0xf9400000
.word 0xf90053a0
.word 0xf94047b1
.word 0xf9422231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a0
bl _p_13
.word 0xf90077a0
.word 0xf94047b1
.word 0xf9423e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94077a0
.word 0xf90057a0
.word 0xf94047b1
.word 0xf9425631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94037a0
bl _p_13
.word 0xf90073a0
.word 0xf94047b1
.word 0xf9427231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94073a0
.word 0xaa0003fa
.word 0xf94047b1
.word 0xf9428a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403ba0
bl _p_13
.word 0xf9006fa0
.word 0xf94047b1
.word 0xf942a631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9406fa0
.word 0xf9005ba0
.word 0xf94047b1
.word 0xf942be31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
bl _p_4
.word 0x53001c00
.word 0xf9006ba0
.word 0xf94047b1
.word 0xf942de31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9406ba0
.word 0x34000ca0
.word 0xf94047b1
.word 0xf942f631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
bl _p_5
.word 0xf90073a0
.word 0xf94047b1
.word 0xf9431231
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_21@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_21@PAGEOFF
ldr x0, [x0]
.word 0xf9006fa0
.word 0xf94047b1
.word 0xf9433231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fa1
.word 0xaa0103e0
.word 0xf940003e
bl _p_5
.word 0xf9006ba0
.word 0xf94047b1
.word 0xf9435631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9406ba3
.word 0xf9406fa4
.word 0xf94073a5
.word 0xf94057a2
.word 0xaa1a03e0
.word 0xf9405ba1
.word 0xf9403fa0
.word 0xaa0503f3
.word 0xaa0403f9
.word 0xaa0303f5
.word 0xaa0203f4
.word 0xaa1a03f8
.word 0xaa0103f7
.word 0xb50001a0
.word 0xaa1303e0
.word 0xaa1903e0
.word 0xaa1503e0
.word 0xaa1403e0
.word 0xaa1803e0
.word 0xaa1703e0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #488]
.word 0xf9400000
.word 0xaa0003f6
.word 0x14000012
.word 0xaa1303e0
.word 0xaa1903e0
.word 0xaa1503e0
.word 0xaa1403e0
.word 0xaa1803e0
.word 0xaa1703e0
.word 0xf9403fa1
.word 0xaa0103e0
.word 0xf940003e
bl _p_5
.word 0xf9006ba0
.word 0xf94047b1
.word 0xf943fa31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9406ba0
.word 0xaa0003f6
.word 0xaa1303e0
.word 0xaa1903e0
.word 0xaa1503e0
.word 0xaa1403e0
.word 0xaa1803e0
.word 0xaa1703e0
.word 0xaa1603e0
.word 0x910283a7
.word 0xaa1303e0
.word 0xaa1903e1
.word 0xaa1503e2
.word 0xaa1403e3
.word 0xaa1803e4
.word 0xaa1703e5
.word 0xaa1603e6
bl _p_45
.word 0xf9006ba0
.word 0x53001c00
.word 0xf94047b1
.word 0xf9445a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9406ba0
.word 0x3902e3a0
.word 0xf94047b1
.word 0xf9447231
.word 0xb4000051
.word 0xd63f0220
.word 0x14000060
.word 0xf94047b1
.word 0xf9448631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
bl _p_8
.word 0xf90073a0
.word 0xf94047b1
.word 0xf944a231
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_21@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_21@PAGEOFF
ldr x0, [x0]
.word 0xf9006fa0
.word 0xf94047b1
.word 0xf944c231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fa1
.word 0xaa0103e0
.word 0xf940003e
bl _p_5
.word 0xf9006ba0
.word 0xf94047b1
.word 0xf944e631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9406ba3
.word 0xf9406fa4
.word 0xf94073a5
.word 0xf94057a2
.word 0xaa1a03e0
.word 0xf9405ba1
.word 0xf9403fa0
.word 0xaa0503f3
.word 0xaa0403f9
.word 0xaa0303f5
.word 0xaa0203f4
.word 0xaa1a03f8
.word 0xaa0103f7
.word 0xb50001a0
.word 0xaa1303e0
.word 0xaa1903e0
.word 0xaa1503e0
.word 0xaa1403e0
.word 0xaa1803e0
.word 0xaa1703e0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #488]
.word 0xf9400000
.word 0xaa0003f6
.word 0x14000012
.word 0xaa1303e0
.word 0xaa1903e0
.word 0xaa1503e0
.word 0xaa1403e0
.word 0xaa1803e0
.word 0xaa1703e0
.word 0xf9403fa1
.word 0xaa0103e0
.word 0xf940003e
bl _p_5
.word 0xf9006ba0
.word 0xf94047b1
.word 0xf9458a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9406ba0
.word 0xaa0003f6
.word 0xaa1303e0
.word 0xaa1903e0
.word 0xaa1503e0
.word 0xaa1403e0
.word 0xaa1803e0
.word 0xaa1703e0
.word 0xaa1603e0
.word 0x910283a7
.word 0xaa1303e0
.word 0xaa1903e1
.word 0xaa1503e2
.word 0xaa1403e3
.word 0xaa1803e4
.word 0xaa1703e5
.word 0xaa1603e6
bl _p_46
.word 0xf9006ba0
.word 0x53001c00
.word 0xf94047b1
.word 0xf945ea31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9406ba0
.word 0x3902e3a0
.word 0xf9404bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94047b1
.word 0xf9461231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94057a0
bl _p_16
.word 0xf94047b1
.word 0xf9462a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94047b1
.word 0xf9463a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_16
.word 0xf94047b1
.word 0xf9465631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94047b1
.word 0xf9466631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9405ba0
bl _p_16
.word 0xf94047b1
.word 0xf9467e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94047b1
.word 0xf9468e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94043a0
.word 0xf9006fa0
.word 0xf94053a0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x1, [x16, #488]
.word 0xf9400021
bl _p_37
.word 0x53001c00
.word 0xf9006ba0
.word 0xf94047b1
.word 0xf946c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9406ba0
.word 0xf9406fa1
.word 0xaa0103f3
.word 0x340001e0
.word 0xaa1303e0
.word 0xf94053a0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x15, [x16, #496]
bl _p_38
.word 0xf9006ba0
.word 0xf94047b1
.word 0xf9470231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9406ba0
.word 0xf90063a0
.word 0x14000004
.word 0xaa1303e0
.word 0xd2800000
.word 0xf90063bf
.word 0xaa1303e0
.word 0xf94063a0
.word 0xf9006fa0
.word 0xf9000260
.word 0xaa1303e0
bl _p_39
.word 0xf9406fa0
.word 0xf94047b1
.word 0xf9474631
.word 0xb4000051
.word 0xd63f0220
.word 0x3942e3a0
.word 0xf9006ba0
.word 0xf9404bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94047b1
.word 0xf9476e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9406ba0
.word 0xf94047b1
.word 0xf9478231
.word 0xb4000051
.word 0xd63f0220
.word 0xa94153b3
.word 0xa9425bb5
.word 0xa94363b7
.word 0xa9446bb9
.word 0x910003bf
.word 0xa8cf7bfd
.word 0xd65f03c0

Lme_48:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBNotificationHub_RegisterTemplateAsync_Foundation_NSData_string_string_string_Foundation_NSSet_WindowsAzure_Messaging_ErrorCallback
WindowsAzure_Messaging_SBNotificationHub_RegisterTemplateAsync_Foundation_NSData_string_string_string_Foundation_NSSet_WindowsAzure_Messaging_ErrorCallback:
.loc 1 1 0
.word 0xa9b17bfd
.word 0x910003fd
.word 0xa90153b3
.word 0xa9025bb5
.word 0xa90363b7
.word 0xa9046bb9
.word 0xaa0003f4
.word 0xaa0103f5
.word 0xaa0203f6
.word 0xaa0303f7
.word 0xaa0403f8
.word 0xaa0503f9
.word 0xaa0603fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #528]
.word 0xf9002bb0
.word 0xf9400a11
.word 0xf9002fb1
.word 0xd2800013
.word 0xf9004fbf
.word 0xf90053bf
.word 0xf90057bf
.word 0x9101a3a0
.word 0xd2800000
.word 0xf90037a0
.word 0xf9003ba0
.word 0xf9003fa0
.word 0xf90043a0
.word 0xf90047a0
.word 0xf9004ba0
.word 0xf9402bb1
.word 0xf9408a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf940aa31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1503e0
.word 0xb5000255
.word 0xf9402bb1
.word 0xf940c231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd28088a1
.word 0xd28088a1
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf9402bb1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0xb5000256
.word 0xf9402bb1
.word 0xf9411e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd2810301
.word 0xd2810301
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf9402bb1
.word 0xf9416231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xb5000257
.word 0xf9402bb1
.word 0xf9417a31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd280e6a1
.word 0xd280e6a1
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf9402bb1
.word 0xf941be31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xb5000258
.word 0xf9402bb1
.word 0xf941d631
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd280eae1
.word 0xd280eae1
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf9402bb1
.word 0xf9421a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xb5000259
.word 0xf9402bb1
.word 0xf9423231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd2810441
.word 0xd2810441
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf9402bb1
.word 0xf9427631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xb500025a
.word 0xf9402bb1
.word 0xf9428e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd280d421
.word 0xd280d421
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf9402bb1
.word 0xf942d231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0xaa1603e0
bl _p_13
.word 0xf90067a0
.word 0xf9402bb1
.word 0xf942f231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94067a0
.word 0xaa0003f3
.word 0xf9402bb1
.word 0xf9430a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xaa1703e0
bl _p_13
.word 0xf90063a0
.word 0xf9402bb1
.word 0xf9432a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94063a0
.word 0xf9004fa0
.word 0xf9402bb1
.word 0xf9434231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
bl _p_13
.word 0xf9005fa0
.word 0xf9402bb1
.word 0xf9436231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9405fa0
.word 0xf90053a0
.word 0xf9402bb1
.word 0xf9437a31
.word 0xb4000051
.word 0xd63f0220
.word 0x9101a3a0
.word 0xd2800000
.word 0xf90037a0
.word 0xf9003ba0
.word 0xf9003fa0
.word 0xf90043a0
.word 0xf90047a0
.word 0xf9004ba0
.word 0xf9402bb1
.word 0xf943aa31
.word 0xb4000051
.word 0xd63f0220
.word 0x9101a3a0
.word 0xf90057a0
.word 0xf9402bb1
.word 0xf943c231
.word 0xb4000051
.word 0xd63f0220
.word 0x9101a3a0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x1, [x16, #512]
.word 0xf9400021
.word 0xaa1a03e2
.word 0xaa1a03e2
bl _p_40
.word 0xf9402bb1
.word 0xf943f231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9440231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1403e0
.word 0xaa1403e0
bl _p_4
.word 0x53001c00
.word 0xf9005ba0
.word 0xf9402bb1
.word 0xf9442631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9405ba0
.word 0x340008a0
.word 0xf9402bb1
.word 0xf9443e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1403e0
.word 0xaa1403e0
bl _p_5
.word 0xf9005ba0
.word 0xf9402bb1
.word 0xf9445e31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_22@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_22@PAGEOFF
ldr x0, [x0]
.word 0xf9005fa0
.word 0xf9402bb1
.word 0xf9447e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1503e0
.word 0xaa1503e0
.word 0xf94002be
bl _p_5
.word 0xf90063a0
.word 0xf9402bb1
.word 0xf944a231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1303e0
.word 0xf9404fa0
.word 0xf90067a0
.word 0xf94053a0
.word 0xf9006ba0
.word 0xaa1903e0
.word 0xaa1903e0
.word 0xf940033e
bl _p_5
.word 0xf9006fa0
.word 0xf9402bb1
.word 0xf944da31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94057a0
bl _p_41
.word 0xf90073a0
.word 0xf9402bb1
.word 0xf944f631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9405ba0
.word 0xf9405fa1
.word 0xf94063a2
.word 0xf94067a4
.word 0xf9406ba5
.word 0xf9406fa6
.word 0xf94073a7
.word 0xaa1303e3
bl _p_47
.word 0xf9402bb1
.word 0xf9452a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9453a31
.word 0xb4000051
.word 0xd63f0220
.word 0x14000040
.word 0xf9402bb1
.word 0xf9454e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1403e0
.word 0xaa1403e0
bl _p_8
.word 0xf9005ba0
.word 0xf9402bb1
.word 0xf9456e31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_22@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_22@PAGEOFF
ldr x0, [x0]
.word 0xf9005fa0
.word 0xf9402bb1
.word 0xf9458e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1503e0
.word 0xaa1503e0
.word 0xf94002be
bl _p_5
.word 0xf90063a0
.word 0xf9402bb1
.word 0xf945b231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1303e0
.word 0xf9404fa0
.word 0xf90067a0
.word 0xf94053a0
.word 0xf9006ba0
.word 0xaa1903e0
.word 0xaa1903e0
.word 0xf940033e
bl _p_5
.word 0xf9006fa0
.word 0xf9402bb1
.word 0xf945ea31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94057a0
bl _p_41
.word 0xf90073a0
.word 0xf9402bb1
.word 0xf9460631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9405ba0
.word 0xf9405fa1
.word 0xf94063a2
.word 0xf94067a4
.word 0xf9406ba5
.word 0xf9406fa6
.word 0xf94073a7
.word 0xaa1303e3
bl _p_48
.word 0xf9402bb1
.word 0xf9463a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9465a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1303e0
.word 0xaa1303e0
bl _p_16
.word 0xf9402bb1
.word 0xf9467631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9468631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9404fa0
bl _p_16
.word 0xf9402bb1
.word 0xf9469e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf946ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94053a0
bl _p_16
.word 0xf9402bb1
.word 0xf946c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf946d631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94057a0
bl _p_44
.word 0xf9402bb1
.word 0xf946ee31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf946fe31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9470e31
.word 0xb4000051
.word 0xd63f0220
.word 0xa94153b3
.word 0xa9425bb5
.word 0xa94363b7
.word 0xa9446bb9
.word 0x910003bf
.word 0xa8cf7bfd
.word 0xd65f03c0

Lme_49:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBNotificationHub_UnregisterAll_Foundation_NSData_Foundation_NSError_
WindowsAzure_Messaging_SBNotificationHub_UnregisterAll_Foundation_NSData_Foundation_NSError_:
.loc 1 1 0
.word 0xa9b87bfd
.word 0x910003fd
.word 0xa9015bb5
.word 0xa90263b7
.word 0xf9001bb9
.word 0xaa0003f8
.word 0xaa0103f9
.word 0xf9001fa2

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #536]
.word 0xf90023b0
.word 0xf9400a11
.word 0xf90027b1
.word 0xf9002fbf
.word 0xd2800017
.word 0xf94023b1
.word 0xf9404e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9406e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xb5000259
.word 0xf94023b1
.word 0xf9408631
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd28088a1
.word 0xd28088a1
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf94023b1
.word 0xf940ca31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #488]
.word 0xf9400000
.word 0xf9002fa0
.word 0xf94023b1
.word 0xf940ee31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
bl _p_4
.word 0x53001c00
.word 0xf90033a0
.word 0xf94023b1
.word 0xf9411231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a0
.word 0x34000600
.word 0xf94023b1
.word 0xf9412a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
bl _p_5
.word 0xf90037a0
.word 0xf94023b1
.word 0xf9414a31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_23@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_23@PAGEOFF
ldr x0, [x0]
.word 0xf9003ba0
.word 0xf94023b1
.word 0xf9416a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0xf940033e
bl _p_5
.word 0xf9003fa0
.word 0xf94023b1
.word 0xf9418e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94037a0
.word 0xf9403ba1
.word 0xf9403fa2
.word 0x910163a3
bl _p_49
.word 0x53001c00
.word 0xf90033a0
.word 0xf94023b1
.word 0xf941ba31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a0
.word 0xaa0003f7
.word 0xf94023b1
.word 0xf941d231
.word 0xb4000051
.word 0xd63f0220
.word 0x1400002b
.word 0xf94023b1
.word 0xf941e631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
bl _p_8
.word 0xf90037a0
.word 0xf94023b1
.word 0xf9420631
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_23@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_23@PAGEOFF
ldr x0, [x0]
.word 0xf9003ba0
.word 0xf94023b1
.word 0xf9422631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0xf940033e
bl _p_5
.word 0xf9003fa0
.word 0xf94023b1
.word 0xf9424a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94037a0
.word 0xf9403ba1
.word 0xf9403fa2
.word 0x910163a3
bl _p_50
.word 0x53001c00
.word 0xf90033a0
.word 0xf94023b1
.word 0xf9427631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a0
.word 0xaa0003f7
.word 0xf94027b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9429e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
.word 0xf90037a0
.word 0xf9402fa0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x1, [x16, #488]
.word 0xf9400021
bl _p_37
.word 0x53001c00
.word 0xf90033a0
.word 0xf94023b1
.word 0xf942d631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a0
.word 0xf94037a1
.word 0xaa0103f6
.word 0x340001e0
.word 0xaa1603e0
.word 0xf9402fa0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x15, [x16, #496]
bl _p_38
.word 0xf90033a0
.word 0xf94023b1
.word 0xf9431231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a0
.word 0xaa0003f5
.word 0x14000004
.word 0xaa1603e0
.word 0xd2800000
.word 0xd2800015
.word 0xaa1603e0
.word 0xaa1503e0
.word 0xf90002d5
.word 0xaa1603e0
bl _p_39
.word 0xf94023b1
.word 0xf9434e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xf94027b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9437231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xf94023b1
.word 0xf9438631
.word 0xb4000051
.word 0xd63f0220
.word 0xa9415bb5
.word 0xa94263b7
.word 0xf9401bb9
.word 0x910003bf
.word 0xa8c87bfd
.word 0xd65f03c0

Lme_4a:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBNotificationHub_UnregisterAllAsync_Foundation_NSData_WindowsAzure_Messaging_ErrorCallback
WindowsAzure_Messaging_SBNotificationHub_UnregisterAllAsync_Foundation_NSData_WindowsAzure_Messaging_ErrorCallback:
.loc 1 1 0
.word 0xa9b67bfd
.word 0x910003fd
.word 0xa90163b7
.word 0xa9026bb9
.word 0xaa0003f8
.word 0xaa0103f9
.word 0xaa0203fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #544]
.word 0xf9001bb0
.word 0xf9400a11
.word 0xf9001fb1
.word 0xd2800017
.word 0x910123a0
.word 0xd2800000
.word 0xf90027a0
.word 0xf9002ba0
.word 0xf9002fa0
.word 0xf90033a0
.word 0xf90037a0
.word 0xf9003ba0
.word 0xf9401bb1
.word 0xf9406631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9408631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xb5000259
.word 0xf9401bb1
.word 0xf9409e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd28088a1
.word 0xd28088a1
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf9401bb1
.word 0xf940e231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xb500025a
.word 0xf9401bb1
.word 0xf940fa31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd280d421
.word 0xd280d421
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf9401bb1
.word 0xf9413e31
.word 0xb4000051
.word 0xd63f0220
.word 0x910123a0
.word 0xd2800000
.word 0xf90027a0
.word 0xf9002ba0
.word 0xf9002fa0
.word 0xf90033a0
.word 0xf90037a0
.word 0xf9003ba0
.word 0xf9401bb1
.word 0xf9416e31
.word 0xb4000051
.word 0xd63f0220
.word 0x910123a0
.word 0xaa0003f7
.word 0xf9401bb1
.word 0xf9418631
.word 0xb4000051
.word 0xd63f0220
.word 0x910123a0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x1, [x16, #512]
.word 0xf9400021
.word 0xaa1a03e2
.word 0xaa1a03e2
bl _p_40
.word 0xf9401bb1
.word 0xf941b631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf941c631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
bl _p_4
.word 0x53001c00
.word 0xf90043a0
.word 0xf9401bb1
.word 0xf941ea31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94043a0
.word 0x34000680
.word 0xf9401bb1
.word 0xf9420231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
bl _p_5
.word 0xf90043a0
.word 0xf9401bb1
.word 0xf9422231
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_24@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_24@PAGEOFF
ldr x0, [x0]
.word 0xf90047a0
.word 0xf9401bb1
.word 0xf9424231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0xf940033e
bl _p_5
.word 0xf9004ba0
.word 0xf9401bb1
.word 0xf9426631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xaa1703e0
bl _p_41
.word 0xf9004fa0
.word 0xf9401bb1
.word 0xf9428631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94043a0
.word 0xf94047a1
.word 0xf9404ba2
.word 0xf9404fa3
bl _p_26
.word 0xf9401bb1
.word 0xf942aa31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf942ba31
.word 0xb4000051
.word 0xd63f0220
.word 0x1400002f
.word 0xf9401bb1
.word 0xf942ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
bl _p_8
.word 0xf90043a0
.word 0xf9401bb1
.word 0xf942ee31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_24@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_24@PAGEOFF
ldr x0, [x0]
.word 0xf90047a0
.word 0xf9401bb1
.word 0xf9430e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0xf940033e
bl _p_5
.word 0xf9004ba0
.word 0xf9401bb1
.word 0xf9433231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xaa1703e0
bl _p_41
.word 0xf9004fa0
.word 0xf9401bb1
.word 0xf9435231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94043a0
.word 0xf94047a1
.word 0xf9404ba2
.word 0xf9404fa3
bl _p_27
.word 0xf9401bb1
.word 0xf9437631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9439631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xaa1703e0
bl _p_44
.word 0xf9401bb1
.word 0xf943b231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf943c231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf943d231
.word 0xb4000051
.word 0xd63f0220
.word 0xa94163b7
.word 0xa9426bb9
.word 0x910003bf
.word 0xa8ca7bfd
.word 0xd65f03c0

Lme_4b:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBNotificationHub_UnregisterNative_Foundation_NSError_
WindowsAzure_Messaging_SBNotificationHub_UnregisterNative_Foundation_NSError_:
.loc 1 1 0
.word 0xa9b87bfd
.word 0x910003fd
.word 0xa9015fb6
.word 0xa90267b8
.word 0xaa0003f9
.word 0xf9001ba1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #552]
.word 0xf9001fb0
.word 0xf9400a11
.word 0xf90023b1
.word 0xf9002bbf
.word 0xd2800018
.word 0xf9401fb1
.word 0xf9404631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9406631
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #488]
.word 0xf9400000
.word 0xf9002ba0
.word 0xf9401fb1
.word 0xf9408a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_4
.word 0x53001c00
.word 0xf90033a0
.word 0xf9401fb1
.word 0xf940ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a0
.word 0x340004c0
.word 0xf9401fb1
.word 0xf940c631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_5
.word 0xf90037a0
.word 0xf9401fb1
.word 0xf940e631
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_25@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_25@PAGEOFF
ldr x0, [x0]
.word 0xf9003ba0
.word 0xf9401fb1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94037a0
.word 0xf9403ba1
.word 0x910143a2
bl _p_51
.word 0x53001c00
.word 0xf90033a0
.word 0xf9401fb1
.word 0xf9412e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a0
.word 0xaa0003f8
.word 0xf9401fb1
.word 0xf9414631
.word 0xb4000051
.word 0xd63f0220
.word 0x14000021
.word 0xf9401fb1
.word 0xf9415a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_8
.word 0xf90037a0
.word 0xf9401fb1
.word 0xf9417a31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_25@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_25@PAGEOFF
ldr x0, [x0]
.word 0xf9003ba0
.word 0xf9401fb1
.word 0xf9419a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94037a0
.word 0xf9403ba1
.word 0x910143a2
bl _p_52
.word 0x53001c00
.word 0xf90033a0
.word 0xf9401fb1
.word 0xf941c231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a0
.word 0xaa0003f8
.word 0xf94023b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf941ea31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xf90037a0
.word 0xf9402ba0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x1, [x16, #488]
.word 0xf9400021
bl _p_37
.word 0x53001c00
.word 0xf90033a0
.word 0xf9401fb1
.word 0xf9422231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a0
.word 0xf94037a1
.word 0xaa0103f7
.word 0x340001e0
.word 0xaa1703e0
.word 0xf9402ba0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x15, [x16, #496]
bl _p_38
.word 0xf90033a0
.word 0xf9401fb1
.word 0xf9425e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a0
.word 0xaa0003f6
.word 0x14000004
.word 0xaa1703e0
.word 0xd2800000
.word 0xd2800016
.word 0xaa1703e0
.word 0xaa1603e0
.word 0xf90002f6
.word 0xaa1703e0
bl _p_39
.word 0xf9401fb1
.word 0xf9429a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xf94023b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf942be31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xf9401fb1
.word 0xf942d231
.word 0xb4000051
.word 0xd63f0220
.word 0xa9415fb6
.word 0xa94267b8
.word 0x910003bf
.word 0xa8c87bfd
.word 0xd65f03c0

Lme_4c:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBNotificationHub_UnregisterNativeAsync_WindowsAzure_Messaging_ErrorCallback
WindowsAzure_Messaging_SBNotificationHub_UnregisterNativeAsync_WindowsAzure_Messaging_ErrorCallback:
.loc 1 1 0
.word 0xa9b77bfd
.word 0x910003fd
.word 0xa90167b8
.word 0xf90013ba
.word 0xaa0003f9
.word 0xaa0103fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #560]
.word 0xf90017b0
.word 0xf9400a11
.word 0xf9001bb1
.word 0xd2800018
.word 0x910103a0
.word 0xd2800000
.word 0xf90023a0
.word 0xf90027a0
.word 0xf9002ba0
.word 0xf9002fa0
.word 0xf90033a0
.word 0xf90037a0
.word 0xf94017b1
.word 0xf9406231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9408231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xb500025a
.word 0xf94017b1
.word 0xf9409a31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd280d421
.word 0xd280d421
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf94017b1
.word 0xf940de31
.word 0xb4000051
.word 0xd63f0220
.word 0x910103a0
.word 0xd2800000
.word 0xf90023a0
.word 0xf90027a0
.word 0xf9002ba0
.word 0xf9002fa0
.word 0xf90033a0
.word 0xf90037a0
.word 0xf94017b1
.word 0xf9410e31
.word 0xb4000051
.word 0xd63f0220
.word 0x910103a0
.word 0xaa0003f8
.word 0xf94017b1
.word 0xf9412631
.word 0xb4000051
.word 0xd63f0220
.word 0x910103a0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x1, [x16, #512]
.word 0xf9400021
.word 0xaa1a03e2
.word 0xaa1a03e2
bl _p_40
.word 0xf94017b1
.word 0xf9415631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9416631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_4
.word 0x53001c00
.word 0xf9003ba0
.word 0xf94017b1
.word 0xf9418a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403ba0
.word 0x34000540
.word 0xf94017b1
.word 0xf941a231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_5
.word 0xf9003ba0
.word 0xf94017b1
.word 0xf941c231
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_26@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_26@PAGEOFF
ldr x0, [x0]
.word 0xf9003fa0
.word 0xf94017b1
.word 0xf941e231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
bl _p_41
.word 0xf90043a0
.word 0xf94017b1
.word 0xf9420231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403ba0
.word 0xf9403fa1
.word 0xf94043a2
bl _p_21
.word 0xf94017b1
.word 0xf9422231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9423231
.word 0xb4000051
.word 0xd63f0220
.word 0x14000025
.word 0xf94017b1
.word 0xf9424631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_8
.word 0xf9003ba0
.word 0xf94017b1
.word 0xf9426631
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_26@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_26@PAGEOFF
ldr x0, [x0]
.word 0xf9003fa0
.word 0xf94017b1
.word 0xf9428631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
bl _p_41
.word 0xf90043a0
.word 0xf94017b1
.word 0xf942a631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403ba0
.word 0xf9403fa1
.word 0xf94043a2
bl _p_22
.word 0xf94017b1
.word 0xf942c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf942e631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
bl _p_44
.word 0xf94017b1
.word 0xf9430231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9431231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9432231
.word 0xb4000051
.word 0xd63f0220
.word 0xa94167b8
.word 0xf94013ba
.word 0x910003bf
.word 0xa8c97bfd
.word 0xd65f03c0

Lme_4d:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBNotificationHub_UnregisterTemplate_string_Foundation_NSError_
WindowsAzure_Messaging_SBNotificationHub_UnregisterTemplate_string_Foundation_NSError_:
.loc 1 1 0
.word 0xa9b77bfd
.word 0x910003fd
.word 0xa90157b4
.word 0xa9025fb6
.word 0xa90367b8
.word 0xaa0003f8
.word 0xaa0103f9
.word 0xf90023a2

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #568]
.word 0xf90027b0
.word 0xf9400a11
.word 0xf9002bb1
.word 0xf90033bf
.word 0xd2800017
.word 0xd2800016
.word 0xf94027b1
.word 0xf9405231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027b1
.word 0xf9407231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xb5000259
.word 0xf94027b1
.word 0xf9408a31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd2810301
.word 0xd2810301
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf94027b1
.word 0xf940ce31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #488]
.word 0xf9400000
.word 0xf90033a0
.word 0xf94027b1
.word 0xf940f231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_13
.word 0xf9003fa0
.word 0xf94027b1
.word 0xf9411231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403fa0
.word 0xaa0003f7
.word 0xf94027b1
.word 0xf9412a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
bl _p_4
.word 0x53001c00
.word 0xf9003ba0
.word 0xf94027b1
.word 0xf9414e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403ba0
.word 0x34000500
.word 0xf94027b1
.word 0xf9416631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
bl _p_5
.word 0xf9003fa0
.word 0xf94027b1
.word 0xf9418631
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_27@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_27@PAGEOFF
ldr x0, [x0]
.word 0xf90043a0
.word 0xf94027b1
.word 0xf941a631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403fa0
.word 0xf94043a1
.word 0xaa1703e2
.word 0x910183a3
.word 0xaa1703e2
bl _p_49
.word 0x53001c00
.word 0xf9003ba0
.word 0xf94027b1
.word 0xf941d631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403ba0
.word 0xaa0003f6
.word 0xf94027b1
.word 0xf941ee31
.word 0xb4000051
.word 0xd63f0220
.word 0x14000023
.word 0xf94027b1
.word 0xf9420231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
bl _p_8
.word 0xf9003fa0
.word 0xf94027b1
.word 0xf9422231
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_27@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_27@PAGEOFF
ldr x0, [x0]
.word 0xf90043a0
.word 0xf94027b1
.word 0xf9424231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403fa0
.word 0xf94043a1
.word 0xaa1703e2
.word 0x910183a3
.word 0xaa1703e2
bl _p_50
.word 0x53001c00
.word 0xf9003ba0
.word 0xf94027b1
.word 0xf9427231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403ba0
.word 0xaa0003f6
.word 0xf9402bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027b1
.word 0xf9429a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xaa1703e0
bl _p_16
.word 0xf94027b1
.word 0xf942b631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027b1
.word 0xf942c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf9003fa0
.word 0xf94033a0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x1, [x16, #488]
.word 0xf9400021
bl _p_37
.word 0x53001c00
.word 0xf9003ba0
.word 0xf94027b1
.word 0xf942fe31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403ba0
.word 0xf9403fa1
.word 0xaa0103f5
.word 0x340001e0
.word 0xaa1503e0
.word 0xf94033a0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x15, [x16, #496]
bl _p_38
.word 0xf9003ba0
.word 0xf94027b1
.word 0xf9433a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403ba0
.word 0xaa0003f4
.word 0x14000004
.word 0xaa1503e0
.word 0xd2800000
.word 0xd2800014
.word 0xaa1503e0
.word 0xaa1403e0
.word 0xf90002b4
.word 0xaa1503e0
bl _p_39
.word 0xf94027b1
.word 0xf9437631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0xf9402bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027b1
.word 0xf9439a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0xf94027b1
.word 0xf943ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xa94157b4
.word 0xa9425fb6
.word 0xa94367b8
.word 0x910003bf
.word 0xa8c97bfd
.word 0xd65f03c0

Lme_4e:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBNotificationHub_UnregisterTemplateAsync_string_WindowsAzure_Messaging_ErrorCallback
WindowsAzure_Messaging_SBNotificationHub_UnregisterTemplateAsync_string_WindowsAzure_Messaging_ErrorCallback:
.loc 1 1 0
.word 0xa9b67bfd
.word 0x910003fd
.word 0xa9015fb6
.word 0xa90267b8
.word 0xf9001bba
.word 0xaa0003f8
.word 0xaa0103f9
.word 0xaa0203fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #576]
.word 0xf9001fb0
.word 0xf9400a11
.word 0xf90023b1
.word 0xd2800017
.word 0xd2800016
.word 0x910143a0
.word 0xd2800000
.word 0xf9002ba0
.word 0xf9002fa0
.word 0xf90033a0
.word 0xf90037a0
.word 0xf9003ba0
.word 0xf9003fa0
.word 0xf9401fb1
.word 0xf9406e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9408e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xb5000259
.word 0xf9401fb1
.word 0xf940a631
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd2810301
.word 0xd2810301
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf9401fb1
.word 0xf940ea31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xb500025a
.word 0xf9401fb1
.word 0xf9410231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd280d421
.word 0xd280d421
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf9401fb1
.word 0xf9414631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_13
.word 0xf90047a0
.word 0xf9401fb1
.word 0xf9416631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94047a0
.word 0xaa0003f7
.word 0xf9401fb1
.word 0xf9417e31
.word 0xb4000051
.word 0xd63f0220
.word 0x910143a0
.word 0xd2800000
.word 0xf9002ba0
.word 0xf9002fa0
.word 0xf90033a0
.word 0xf90037a0
.word 0xf9003ba0
.word 0xf9003fa0
.word 0xf9401fb1
.word 0xf941ae31
.word 0xb4000051
.word 0xd63f0220
.word 0x910143a0
.word 0xaa0003f6
.word 0xf9401fb1
.word 0xf941c631
.word 0xb4000051
.word 0xd63f0220
.word 0x910143a0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x1, [x16, #512]
.word 0xf9400021
.word 0xaa1a03e2
.word 0xaa1a03e2
bl _p_40
.word 0xf9401fb1
.word 0xf941f631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9420631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
bl _p_4
.word 0x53001c00
.word 0xf90043a0
.word 0xf9401fb1
.word 0xf9422a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94043a0
.word 0x34000580
.word 0xf9401fb1
.word 0xf9424231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
bl _p_5
.word 0xf90043a0
.word 0xf9401fb1
.word 0xf9426231
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_28@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_28@PAGEOFF
ldr x0, [x0]
.word 0xf90047a0
.word 0xf9401fb1
.word 0xf9428231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xaa1603e0
.word 0xaa1603e0
bl _p_41
.word 0xf9004ba0
.word 0xf9401fb1
.word 0xf942a631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94043a0
.word 0xf94047a1
.word 0xf9404ba3
.word 0xaa1703e2
bl _p_26
.word 0xf9401fb1
.word 0xf942ca31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf942da31
.word 0xb4000051
.word 0xd63f0220
.word 0x14000027
.word 0xf9401fb1
.word 0xf942ee31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
bl _p_8
.word 0xf90043a0
.word 0xf9401fb1
.word 0xf9430e31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_28@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_28@PAGEOFF
ldr x0, [x0]
.word 0xf90047a0
.word 0xf9401fb1
.word 0xf9432e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xaa1603e0
.word 0xaa1603e0
bl _p_41
.word 0xf9004ba0
.word 0xf9401fb1
.word 0xf9435231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94043a0
.word 0xf94047a1
.word 0xf9404ba3
.word 0xaa1703e2
bl _p_27
.word 0xf9401fb1
.word 0xf9437631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9439631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xaa1703e0
bl _p_16
.word 0xf9401fb1
.word 0xf943b231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf943c231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0xaa1603e0
bl _p_44
.word 0xf9401fb1
.word 0xf943de31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf943ee31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf943fe31
.word 0xb4000051
.word 0xd63f0220
.word 0xa9415fb6
.word 0xa94267b8
.word 0xf9401bba
.word 0x910003bf
.word 0xa8ca7bfd
.word 0xd65f03c0

Lme_4f:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBNotificationHub_get_Version
WindowsAzure_Messaging_SBNotificationHub_get_Version:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #584]
.word 0xf9000bb0
.word 0xf9400a11
.word 0xf9000fb1
.word 0xf9400bb1
.word 0xf9402e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb1
.word 0xf9404e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #472]
.word 0xf9400000
.word 0xf90023a0
adrp x0, L_OBJC_SELECTOR_REFERENCES_29@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_29@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf9400bb1
.word 0xf9408231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
bl _p_6
.word 0xf9001fa0
.word 0xf9400bb1
.word 0xf940a231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
bl _p_15
.word 0xf9001ba0
.word 0xf9400bb1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb1
.word 0xf940de31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xf9400bb1
.word 0xf940f231
.word 0xb4000051
.word 0xd63f0220
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_50:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBNotificationHub__cctor
WindowsAzure_Messaging_SBNotificationHub__cctor:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #592]
.word 0xf9000bb0
.word 0xf9400a11
.word 0xf9000fb1
.word 0xf9400bb1
.word 0xf9402e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb1
.word 0xf9404e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #600]
bl _p_18
.word 0xf9001ba0
.word 0xf9400bb1
.word 0xf9407231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #472]
.word 0xf9000001
.word 0xf9400bb1
.word 0xf9409631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb1
.word 0xf940a631
.word 0xb4000051
.word 0xd63f0220
.word 0x910003bf
.word 0xa8c47bfd
.word 0xd65f03c0

Lme_51:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBRegistration__ctor
WindowsAzure_Messaging_SBRegistration__ctor:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000bba
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #608]
.word 0xf9000fb0
.word 0xf9400a11
.word 0xf90013b1
.word 0xf9400fb1
.word 0xf9403631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9405631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #152]
.word 0xf9400001
.word 0xaa1a03e0
bl _p_1
.word 0xf9400fb1
.word 0xf9408231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0xf9400340
.word 0xf9400c00
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf940b631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a1
.word 0xaa0103e0
.word 0xf9400021
.word 0xf943c430
.word 0xd63f0200
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf940de31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x1, [x16, #136]
.word 0xf9400021
bl _p_2
.word 0x53001c00
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf9410e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa1
.word 0xaa1a03e0
bl _p_3
.word 0xf9400fb1
.word 0xf9412a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9413a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_4
.word 0x53001c00
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf9415e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0x340005a0
.word 0xf9400fb1
.word 0xf9417631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_5
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf9419a31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_0@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_0@PAGEOFF
ldr x0, [x0]
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf941ba31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
.word 0xf94023a1
bl _p_6
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf941da31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x2, [x16, #160]
.word 0xaa1a03e0
bl _p_7
.word 0xf9400fb1
.word 0xf9420231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9421231
.word 0xb4000051
.word 0xd63f0220
.word 0x14000028
.word 0xf9400fb1
.word 0xf9422631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_8
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf9424a31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_0@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_0@PAGEOFF
ldr x0, [x0]
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9426a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
.word 0xf94023a1
bl _p_9
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf9428a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x2, [x16, #160]
.word 0xaa1a03e0
bl _p_7
.word 0xf9400fb1
.word 0xf942b231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf942d231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf942e231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bba
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_52:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBRegistration__ctor_Foundation_NSObjectFlag
WindowsAzure_Messaging_SBRegistration__ctor_Foundation_NSObjectFlag:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bb9
.word 0xaa0003f9
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #616]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xf94013b1
.word 0xf9403a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9405a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xf9400fa1
.word 0xaa1903e0
bl _p_1
.word 0xf94013b1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9408a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0xf9400320
.word 0xf9400c00
.word 0xf9002ba0
.word 0xf94013b1
.word 0xf940ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba1
.word 0xaa0103e0
.word 0xf9400021
.word 0xf943c430
.word 0xd63f0200
.word 0xf90027a0
.word 0xf94013b1
.word 0xf940d631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x1, [x16, #136]
.word 0xf9400021
bl _p_2
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a1
.word 0xaa1903e0
bl _p_3
.word 0xf94013b1
.word 0xf9412231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9414231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb9
.word 0x910003bf
.word 0xa8c67bfd
.word 0xd65f03c0

Lme_53:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBRegistration__ctor_intptr
WindowsAzure_Messaging_SBRegistration__ctor_intptr:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bb9
.word 0xaa0003f9
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #624]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xf94013b1
.word 0xf9403a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9405a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xf9400fa1
.word 0xaa1903e0
bl _p_10
.word 0xf94013b1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9408a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0xf9400320
.word 0xf9400c00
.word 0xf9002ba0
.word 0xf94013b1
.word 0xf940ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba1
.word 0xaa0103e0
.word 0xf9400021
.word 0xf943c430
.word 0xd63f0200
.word 0xf90027a0
.word 0xf94013b1
.word 0xf940d631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x1, [x16, #136]
.word 0xf9400021
bl _p_2
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a1
.word 0xaa1903e0
bl _p_3
.word 0xf94013b1
.word 0xf9412231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9414231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb9
.word 0x910003bf
.word 0xa8c67bfd
.word 0xd65f03c0

Lme_54:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBRegistration_get_ClassHandle
WindowsAzure_Messaging_SBRegistration_get_ClassHandle:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #632]
.word 0xf9000fb0
.word 0xf9400a11
.word 0xf90013b1
.word 0xf9400fb1
.word 0xf9403231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9405231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #640]
.word 0xf9400000
.word 0xf9001ba0
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9408631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xf9400fb1
.word 0xf9409a31
.word 0xb4000051
.word 0xd63f0220
.word 0x910003bf
.word 0xa8c47bfd
.word 0xd65f03c0

Lme_55:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBRegistration_Name
WindowsAzure_Messaging_SBRegistration_Name:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #648]
.word 0xf9000bb0
.word 0xf9400a11
.word 0xf9000fb1
.word 0xf9400bb1
.word 0xf9402e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb1
.word 0xf9404e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #640]
.word 0xf9400000
.word 0xf90023a0
adrp x0, L_OBJC_SELECTOR_REFERENCES_30@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_30@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf9400bb1
.word 0xf9408231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
bl _p_6
.word 0xf9001fa0
.word 0xf9400bb1
.word 0xf940a231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
bl _p_15
.word 0xf9001ba0
.word 0xf9400bb1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb1
.word 0xf940de31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xf9400bb1
.word 0xf940f231
.word 0xb4000051
.word 0xd63f0220
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_56:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBRegistration_Payload_string_Foundation_NSSet
WindowsAzure_Messaging_SBRegistration_Payload_string_Foundation_NSSet:
.loc 1 1 0
.word 0xa9b67bfd
.word 0x910003fd
.word 0xa90163b7
.word 0xa9026bb9
.word 0xaa0003f9
.word 0xaa0103fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #656]
.word 0xf9001bb0
.word 0xf9400a11
.word 0xf9001fb1
.word 0xd2800018
.word 0xd2800017
.word 0xf9401bb1
.word 0xf9404631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9406631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xb5000259
.word 0xf9401bb1
.word 0xf9407e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd28088a1
.word 0xd28088a1
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf9401bb1
.word 0xf940c231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xb500025a
.word 0xf9401bb1
.word 0xf940da31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd2810441
.word 0xd2810441
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf9401bb1
.word 0xf9411e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_13
.word 0xf9004ba0
.word 0xf9401bb1
.word 0xf9413e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9404ba0
.word 0xf90047a0
.word 0xaa0003f8
.word 0xf9401bb1
.word 0xf9415a31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #640]
.word 0xf9400000
.word 0xf90037a0
adrp x0, L_OBJC_SELECTOR_REFERENCES_31@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_31@PAGEOFF
ldr x0, [x0]
.word 0xf9003ba0
.word 0xf9401bb1
.word 0xf9418e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94047a0
.word 0xf9003fa0
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0xf940035e
bl _p_5
.word 0xf90043a0
.word 0xf9401bb1
.word 0xf941ba31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94037a0
.word 0xf9403ba1
.word 0xf9403fa2
.word 0xf94043a3
bl _p_17
.word 0xf90033a0
.word 0xf9401bb1
.word 0xf941e231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a0
bl _p_15
.word 0xf9002fa0
.word 0xf9401bb1
.word 0xf941fe31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fa0
.word 0xaa0003f7
.word 0xf9401bb1
.word 0xf9421631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
bl _p_16
.word 0xf9401bb1
.word 0xf9422e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9423e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xf9002ba0
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9426631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
.word 0xf9401bb1
.word 0xf9427a31
.word 0xb4000051
.word 0xd63f0220
.word 0xa94163b7
.word 0xa9426bb9
.word 0x910003bf
.word 0xa8ca7bfd
.word 0xd65f03c0

Lme_57:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBRegistration_get_DeviceToken
WindowsAzure_Messaging_SBRegistration_get_DeviceToken:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000bba
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #664]
.word 0xf9000fb0
.word 0xf9400a11
.word 0xf90013b1
.word 0xf9400fb1
.word 0xf9403631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9405631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_4
.word 0x53001c00
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0x340005c0
.word 0xf9400fb1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_5
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_14@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_14@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf940d231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
bl _p_6
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf940f231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
bl _p_15
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf9410e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9412e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0x1400002d
.word 0xf9400fb1
.word 0xf9414631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_8
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9416631
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_14@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_14@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf9418631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
bl _p_9
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf941a631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
bl _p_15
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf941c231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf941e231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xf9400fb1
.word 0xf941f631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bba
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_58:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBRegistration_set_DeviceToken_string
WindowsAzure_Messaging_SBRegistration_set_DeviceToken_string:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xa90167b8
.word 0xf90013ba
.word 0xaa0003f9
.word 0xaa0103fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #672]
.word 0xf90017b0
.word 0xf9400a11
.word 0xf9001bb1
.word 0xd2800018
.word 0xf94017b1
.word 0xf9404231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9406231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xb500025a
.word 0xf94017b1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd280a7a1
.word 0xd280a7a1
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf94017b1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_13
.word 0xf90027a0
.word 0xf94017b1
.word 0xf940de31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0
.word 0xaa0003f8
.word 0xf94017b1
.word 0xf940f631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_4
.word 0x53001c00
.word 0xf90023a0
.word 0xf94017b1
.word 0xf9411a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0x34000460
.word 0xf94017b1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_5
.word 0xf90023a0
.word 0xf94017b1
.word 0xf9415231
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_15@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_15@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf94017b1
.word 0xf9417231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
.word 0xaa1803e2
.word 0xaa1803e2
bl _p_21
.word 0xf94017b1
.word 0xf9419631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf941a631
.word 0xb4000051
.word 0xd63f0220
.word 0x1400001e
.word 0xf94017b1
.word 0xf941ba31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_8
.word 0xf90023a0
.word 0xf94017b1
.word 0xf941da31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_15@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_15@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf94017b1
.word 0xf941fa31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
.word 0xaa1803e2
.word 0xaa1803e2
bl _p_22
.word 0xf94017b1
.word 0xf9421e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9423e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
bl _p_16
.word 0xf94017b1
.word 0xf9425a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9426a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9427a31
.word 0xb4000051
.word 0xd63f0220
.word 0xa94167b8
.word 0xf94013ba
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_59:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBRegistration_get_ETag
WindowsAzure_Messaging_SBRegistration_get_ETag:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000bba
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #680]
.word 0xf9000fb0
.word 0xf9400a11
.word 0xf90013b1
.word 0xf9400fb1
.word 0xf9403631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9405631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_4
.word 0x53001c00
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0x340005c0
.word 0xf9400fb1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_5
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_32@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_32@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf940d231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
bl _p_6
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf940f231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
bl _p_15
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf9410e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9412e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0x1400002d
.word 0xf9400fb1
.word 0xf9414631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_8
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9416631
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_32@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_32@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf9418631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
bl _p_9
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf941a631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
bl _p_15
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf941c231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf941e231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xf9400fb1
.word 0xf941f631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bba
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_5a:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBRegistration_set_ETag_string
WindowsAzure_Messaging_SBRegistration_set_ETag_string:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xa90167b8
.word 0xf90013ba
.word 0xaa0003f9
.word 0xaa0103fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #688]
.word 0xf90017b0
.word 0xf9400a11
.word 0xf9001bb1
.word 0xd2800018
.word 0xf94017b1
.word 0xf9404231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9406231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xb500025a
.word 0xf94017b1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd280a7a1
.word 0xd280a7a1
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf94017b1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_13
.word 0xf90027a0
.word 0xf94017b1
.word 0xf940de31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0
.word 0xaa0003f8
.word 0xf94017b1
.word 0xf940f631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_4
.word 0x53001c00
.word 0xf90023a0
.word 0xf94017b1
.word 0xf9411a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0x34000460
.word 0xf94017b1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_5
.word 0xf90023a0
.word 0xf94017b1
.word 0xf9415231
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_33@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_33@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf94017b1
.word 0xf9417231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
.word 0xaa1803e2
.word 0xaa1803e2
bl _p_21
.word 0xf94017b1
.word 0xf9419631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf941a631
.word 0xb4000051
.word 0xd63f0220
.word 0x1400001e
.word 0xf94017b1
.word 0xf941ba31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_8
.word 0xf90023a0
.word 0xf94017b1
.word 0xf941da31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_33@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_33@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf94017b1
.word 0xf941fa31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
.word 0xaa1803e2
.word 0xaa1803e2
bl _p_22
.word 0xf94017b1
.word 0xf9421e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9423e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
bl _p_16
.word 0xf94017b1
.word 0xf9425a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9426a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9427a31
.word 0xb4000051
.word 0xd63f0220
.word 0xa94167b8
.word 0xf94013ba
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_5b:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBRegistration_get_ExpiresAt
WindowsAzure_Messaging_SBRegistration_get_ExpiresAt:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xa9016bb9
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #696]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xd2800019
.word 0xf94013b1
.word 0xf9403a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9405a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_4
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9407e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0x340005c0
.word 0xf94013b1
.word 0xf9409631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_5
.word 0xf9002ba0
.word 0xf94013b1
.word 0xf940b631
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_34@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_34@PAGEOFF
ldr x0, [x0]
.word 0xf9002fa0
.word 0xf94013b1
.word 0xf940d631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
.word 0xf9402fa1
bl _p_6
.word 0xf90027a0
.word 0xf94013b1
.word 0xf940f631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x15, [x16, #704]
bl _p_53
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9411e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xaa0003f9
.word 0xf94013b1
.word 0xf9413631
.word 0xb4000051
.word 0xd63f0220
.word 0x14000029
.word 0xf94013b1
.word 0xf9414a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_8
.word 0xf9002ba0
.word 0xf94013b1
.word 0xf9416a31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_34@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_34@PAGEOFF
ldr x0, [x0]
.word 0xf9002fa0
.word 0xf94013b1
.word 0xf9418a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
.word 0xf9402fa1
bl _p_9
.word 0xf90027a0
.word 0xf94013b1
.word 0xf941aa31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x15, [x16, #704]
bl _p_53
.word 0xf90023a0
.word 0xf94013b1
.word 0xf941d231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xaa0003f9
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf941fa31
.word 0xb4000051
.word 0xd63f0220
bl _p_54
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9421631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0x35000140
.word 0xf94013b1
.word 0xf9422e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1903e0
.word 0xf9001759
.word 0x9100a340
bl _p_39
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9426231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9428631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xf94013b1
.word 0xf9429a31
.word 0xb4000051
.word 0xd63f0220
.word 0xa9416bb9
.word 0x910003bf
.word 0xa8c67bfd
.word 0xd65f03c0

Lme_5c:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBRegistration_set_ExpiresAt_Foundation_NSDate
WindowsAzure_Messaging_SBRegistration_set_ExpiresAt_Foundation_NSDate:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xa9016bb9
.word 0xaa0003f9
.word 0xaa0103fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #712]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xf94013b1
.word 0xf9403a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9405a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xb500025a
.word 0xf94013b1
.word 0xf9407231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd280a7a1
.word 0xd280a7a1
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf94013b1
.word 0xf940b631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_4
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf940da31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0x34000560
.word 0xf94013b1
.word 0xf940f231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_5
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9411231
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_35@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_35@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf94013b1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0xf940035e
bl _p_5
.word 0xf9002ba0
.word 0xf94013b1
.word 0xf9415631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
.word 0xf9402ba2
bl _p_21
.word 0xf94013b1
.word 0xf9417631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9418631
.word 0xb4000051
.word 0xd63f0220
.word 0x14000026
.word 0xf94013b1
.word 0xf9419a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_8
.word 0xf90023a0
.word 0xf94013b1
.word 0xf941ba31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_35@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_35@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf94013b1
.word 0xf941da31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0xf940035e
bl _p_5
.word 0xf9002ba0
.word 0xf94013b1
.word 0xf941fe31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
.word 0xf9402ba2
bl _p_22
.word 0xf94013b1
.word 0xf9421e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9423e31
.word 0xb4000051
.word 0xd63f0220
bl _p_54
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9425a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0x35000140
.word 0xf94013b1
.word 0xf9427231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1a03e0
.word 0xf900173a
.word 0x9100a320
bl _p_39
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf942a631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf942b631
.word 0xb4000051
.word 0xd63f0220
.word 0xa9416bb9
.word 0x910003bf
.word 0xa8c67bfd
.word 0xd65f03c0

Lme_5d:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBRegistration_get_RegistrationId
WindowsAzure_Messaging_SBRegistration_get_RegistrationId:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000bba
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #720]
.word 0xf9000fb0
.word 0xf9400a11
.word 0xf90013b1
.word 0xf9400fb1
.word 0xf9403631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9405631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_4
.word 0x53001c00
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0x340005c0
.word 0xf9400fb1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_5
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_36@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_36@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf940d231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
bl _p_6
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf940f231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
bl _p_15
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf9410e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9412e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0x1400002d
.word 0xf9400fb1
.word 0xf9414631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_8
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9416631
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_36@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_36@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf9418631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
bl _p_9
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf941a631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
bl _p_15
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf941c231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf941e231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xf9400fb1
.word 0xf941f631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bba
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_5e:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBRegistration_set_RegistrationId_string
WindowsAzure_Messaging_SBRegistration_set_RegistrationId_string:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xa90167b8
.word 0xf90013ba
.word 0xaa0003f9
.word 0xaa0103fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #728]
.word 0xf90017b0
.word 0xf9400a11
.word 0xf9001bb1
.word 0xd2800018
.word 0xf94017b1
.word 0xf9404231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9406231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xb500025a
.word 0xf94017b1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd280a7a1
.word 0xd280a7a1
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf94017b1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_13
.word 0xf90027a0
.word 0xf94017b1
.word 0xf940de31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0
.word 0xaa0003f8
.word 0xf94017b1
.word 0xf940f631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_4
.word 0x53001c00
.word 0xf90023a0
.word 0xf94017b1
.word 0xf9411a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0x34000460
.word 0xf94017b1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_5
.word 0xf90023a0
.word 0xf94017b1
.word 0xf9415231
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_37@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_37@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf94017b1
.word 0xf9417231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
.word 0xaa1803e2
.word 0xaa1803e2
bl _p_21
.word 0xf94017b1
.word 0xf9419631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf941a631
.word 0xb4000051
.word 0xd63f0220
.word 0x1400001e
.word 0xf94017b1
.word 0xf941ba31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_8
.word 0xf90023a0
.word 0xf94017b1
.word 0xf941da31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_37@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_37@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf94017b1
.word 0xf941fa31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
.word 0xaa1803e2
.word 0xaa1803e2
bl _p_22
.word 0xf94017b1
.word 0xf9421e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9423e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
bl _p_16
.word 0xf94017b1
.word 0xf9425a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9426a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9427a31
.word 0xb4000051
.word 0xd63f0220
.word 0xa94167b8
.word 0xf94013ba
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_5f:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBRegistration_get_Tags
WindowsAzure_Messaging_SBRegistration_get_Tags:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xa9016bb9
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #736]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xd2800019
.word 0xf94013b1
.word 0xf9403a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9405a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_4
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9407e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0x340005c0
.word 0xf94013b1
.word 0xf9409631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_5
.word 0xf9002ba0
.word 0xf94013b1
.word 0xf940b631
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_38@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_38@PAGEOFF
ldr x0, [x0]
.word 0xf9002fa0
.word 0xf94013b1
.word 0xf940d631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
.word 0xf9402fa1
bl _p_6
.word 0xf90027a0
.word 0xf94013b1
.word 0xf940f631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x15, [x16, #744]
bl _p_55
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9411e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xaa0003f9
.word 0xf94013b1
.word 0xf9413631
.word 0xb4000051
.word 0xd63f0220
.word 0x14000029
.word 0xf94013b1
.word 0xf9414a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_8
.word 0xf9002ba0
.word 0xf94013b1
.word 0xf9416a31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_38@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_38@PAGEOFF
ldr x0, [x0]
.word 0xf9002fa0
.word 0xf94013b1
.word 0xf9418a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
.word 0xf9402fa1
bl _p_9
.word 0xf90027a0
.word 0xf94013b1
.word 0xf941aa31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x15, [x16, #744]
bl _p_55
.word 0xf90023a0
.word 0xf94013b1
.word 0xf941d231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xaa0003f9
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf941fa31
.word 0xb4000051
.word 0xd63f0220
bl _p_54
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9421631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0x35000140
.word 0xf94013b1
.word 0xf9422e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1903e0
.word 0xf9001b59
.word 0x9100c340
bl _p_39
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9426231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9428631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xf94013b1
.word 0xf9429a31
.word 0xb4000051
.word 0xd63f0220
.word 0xa9416bb9
.word 0x910003bf
.word 0xa8c67bfd
.word 0xd65f03c0

Lme_60:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBRegistration_set_Tags_Foundation_NSSet
WindowsAzure_Messaging_SBRegistration_set_Tags_Foundation_NSSet:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xa9016bb9
.word 0xaa0003f9
.word 0xaa0103fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #752]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xf94013b1
.word 0xf9403a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9405a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xb500025a
.word 0xf94013b1
.word 0xf9407231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd280a7a1
.word 0xd280a7a1
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf94013b1
.word 0xf940b631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_4
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf940da31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0x34000560
.word 0xf94013b1
.word 0xf940f231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_5
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9411231
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_39@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_39@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf94013b1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0xf940035e
bl _p_5
.word 0xf9002ba0
.word 0xf94013b1
.word 0xf9415631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
.word 0xf9402ba2
bl _p_21
.word 0xf94013b1
.word 0xf9417631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9418631
.word 0xb4000051
.word 0xd63f0220
.word 0x14000026
.word 0xf94013b1
.word 0xf9419a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_8
.word 0xf90023a0
.word 0xf94013b1
.word 0xf941ba31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_39@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_39@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf94013b1
.word 0xf941da31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0xf940035e
bl _p_5
.word 0xf9002ba0
.word 0xf94013b1
.word 0xf941fe31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
.word 0xf9402ba2
bl _p_22
.word 0xf94013b1
.word 0xf9421e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9423e31
.word 0xb4000051
.word 0xd63f0220
bl _p_54
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9425a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0x35000140
.word 0xf94013b1
.word 0xf9427231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1a03e0
.word 0xf9001b3a
.word 0x9100c320
bl _p_39
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf942a631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf942b631
.word 0xb4000051
.word 0xd63f0220
.word 0xa9416bb9
.word 0x910003bf
.word 0xa8c67bfd
.word 0xd65f03c0

Lme_61:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBRegistration_Dispose_bool
WindowsAzure_Messaging_SBRegistration_Dispose_bool:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000bb9
.word 0xaa0003f9
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #760]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xf94013b1
.word 0xf9403a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9405a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0x394063a1
.word 0xaa1903e0
bl _p_56
.word 0xf94013b1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9408a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_5
.word 0xf90027a0
.word 0xf94013b1
.word 0xf940aa31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x1, [x16, #488]
.word 0xf9400021
bl _p_57
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf940da31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0x340001e0
.word 0xf94013b1
.word 0xf940f231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xd2800000
.word 0xf900173f
.word 0xf94013b1
.word 0xf9410e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xd2800000
.word 0xf9001b3f
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9413a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9414a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb9
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_62:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBRegistration__cctor
WindowsAzure_Messaging_SBRegistration__cctor:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #768]
.word 0xf9000bb0
.word 0xf9400a11
.word 0xf9000fb1
.word 0xf9400bb1
.word 0xf9402e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb1
.word 0xf9404e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #776]
bl _p_18
.word 0xf9001ba0
.word 0xf9400bb1
.word 0xf9407231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #640]
.word 0xf9000001
.word 0xf9400bb1
.word 0xf9409631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb1
.word 0xf940a631
.word 0xb4000051
.word 0xd63f0220
.word 0x910003bf
.word 0xa8c47bfd
.word 0xd65f03c0

Lme_63:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_StoredRegistrationEntry__ctor
WindowsAzure_Messaging_StoredRegistrationEntry__ctor:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000bba
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #784]
.word 0xf9000fb0
.word 0xf9400a11
.word 0xf90013b1
.word 0xf9400fb1
.word 0xf9403631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9405631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #152]
.word 0xf9400001
.word 0xaa1a03e0
bl _p_1
.word 0xf9400fb1
.word 0xf9408231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0xf9400340
.word 0xf9400c00
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf940b631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a1
.word 0xaa0103e0
.word 0xf9400021
.word 0xf943c430
.word 0xd63f0200
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf940de31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x1, [x16, #136]
.word 0xf9400021
bl _p_2
.word 0x53001c00
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf9410e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa1
.word 0xaa1a03e0
bl _p_3
.word 0xf9400fb1
.word 0xf9412a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9413a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_4
.word 0x53001c00
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf9415e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0x340005a0
.word 0xf9400fb1
.word 0xf9417631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_5
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf9419a31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_0@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_0@PAGEOFF
ldr x0, [x0]
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf941ba31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
.word 0xf94023a1
bl _p_6
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf941da31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x2, [x16, #160]
.word 0xaa1a03e0
bl _p_7
.word 0xf9400fb1
.word 0xf9420231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9421231
.word 0xb4000051
.word 0xd63f0220
.word 0x14000028
.word 0xf9400fb1
.word 0xf9422631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_8
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf9424a31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_0@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_0@PAGEOFF
ldr x0, [x0]
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9426a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
.word 0xf94023a1
bl _p_9
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf9428a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x2, [x16, #160]
.word 0xaa1a03e0
bl _p_7
.word 0xf9400fb1
.word 0xf942b231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf942d231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf942e231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bba
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_64:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_StoredRegistrationEntry__ctor_Foundation_NSObjectFlag
WindowsAzure_Messaging_StoredRegistrationEntry__ctor_Foundation_NSObjectFlag:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bb9
.word 0xaa0003f9
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #792]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xf94013b1
.word 0xf9403a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9405a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xf9400fa1
.word 0xaa1903e0
bl _p_1
.word 0xf94013b1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9408a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0xf9400320
.word 0xf9400c00
.word 0xf9002ba0
.word 0xf94013b1
.word 0xf940ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba1
.word 0xaa0103e0
.word 0xf9400021
.word 0xf943c430
.word 0xd63f0200
.word 0xf90027a0
.word 0xf94013b1
.word 0xf940d631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x1, [x16, #136]
.word 0xf9400021
bl _p_2
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a1
.word 0xaa1903e0
bl _p_3
.word 0xf94013b1
.word 0xf9412231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9414231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb9
.word 0x910003bf
.word 0xa8c67bfd
.word 0xd65f03c0

Lme_65:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_StoredRegistrationEntry__ctor_intptr
WindowsAzure_Messaging_StoredRegistrationEntry__ctor_intptr:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bb9
.word 0xaa0003f9
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #800]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xf94013b1
.word 0xf9403a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9405a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xf9400fa1
.word 0xaa1903e0
bl _p_10
.word 0xf94013b1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9408a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0xf9400320
.word 0xf9400c00
.word 0xf9002ba0
.word 0xf94013b1
.word 0xf940ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba1
.word 0xaa0103e0
.word 0xf9400021
.word 0xf943c430
.word 0xd63f0200
.word 0xf90027a0
.word 0xf94013b1
.word 0xf940d631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x1, [x16, #136]
.word 0xf9400021
bl _p_2
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a1
.word 0xaa1903e0
bl _p_3
.word 0xf94013b1
.word 0xf9412231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9414231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb9
.word 0x910003bf
.word 0xa8c67bfd
.word 0xd65f03c0

Lme_66:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_StoredRegistrationEntry__ctor_string
WindowsAzure_Messaging_StoredRegistrationEntry__ctor_string:
.loc 1 1 0
.word 0xa9b97bfd
.word 0x910003fd
.word 0xa90167b8
.word 0xf90013ba
.word 0xaa0003f9
.word 0xaa0103fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #808]
.word 0xf90017b0
.word 0xf9400a11
.word 0xf9001bb1
.word 0xd2800018
.word 0xf94017b1
.word 0xf9404231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9406231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #152]
.word 0xf9400001
.word 0xaa1903e0
bl _p_1
.word 0xf94017b1
.word 0xf9408e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9409e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xb500025a
.word 0xf94017b1
.word 0xf940b631
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd28172a1
.word 0xd28172a1
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf94017b1
.word 0xf940fa31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_13
.word 0xf90033a0
.word 0xf94017b1
.word 0xf9411a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a0
.word 0xaa0003f8
.word 0xf94017b1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0xf9400320
.word 0xf9400c00
.word 0xf9002fa0
.word 0xf94017b1
.word 0xf9415631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fa1
.word 0xaa0103e0
.word 0xf9400021
.word 0xf943c430
.word 0xd63f0200
.word 0xf9002ba0
.word 0xf94017b1
.word 0xf9417e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x1, [x16, #136]
.word 0xf9400021
bl _p_2
.word 0x53001c00
.word 0xf90027a0
.word 0xf94017b1
.word 0xf941ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a1
.word 0xaa1903e0
bl _p_3
.word 0xf94017b1
.word 0xf941ca31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf941da31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_4
.word 0x53001c00
.word 0xf90023a0
.word 0xf94017b1
.word 0xf941fe31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0x340005e0
.word 0xf94017b1
.word 0xf9421631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_5
.word 0xf90027a0
.word 0xf94017b1
.word 0xf9423a31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_40@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_40@PAGEOFF
ldr x0, [x0]
.word 0xf9002ba0
.word 0xf94017b1
.word 0xf9425a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0
.word 0xf9402ba1
.word 0xaa1803e2
.word 0xaa1803e2
bl _p_19
.word 0xf90023a0
.word 0xf94017b1
.word 0xf9428231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x2, [x16, #816]
.word 0xaa1903e0
bl _p_7
.word 0xf94017b1
.word 0xf942aa31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf942ba31
.word 0xb4000051
.word 0xd63f0220
.word 0x1400002a
.word 0xf94017b1
.word 0xf942ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_8
.word 0xf90027a0
.word 0xf94017b1
.word 0xf942f231
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_40@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_40@PAGEOFF
ldr x0, [x0]
.word 0xf9002ba0
.word 0xf94017b1
.word 0xf9431231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0
.word 0xf9402ba1
.word 0xaa1803e2
.word 0xaa1803e2
bl _p_20
.word 0xf90023a0
.word 0xf94017b1
.word 0xf9433a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x2, [x16, #816]
.word 0xaa1903e0
bl _p_7
.word 0xf94017b1
.word 0xf9436231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9438231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
bl _p_16
.word 0xf94017b1
.word 0xf9439e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf943ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf943be31
.word 0xb4000051
.word 0xd63f0220
.word 0xa94167b8
.word 0xf94013ba
.word 0x910003bf
.word 0xa8c77bfd
.word 0xd65f03c0

Lme_67:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_StoredRegistrationEntry_get_ClassHandle
WindowsAzure_Messaging_StoredRegistrationEntry_get_ClassHandle:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #824]
.word 0xf9000fb0
.word 0xf9400a11
.word 0xf90013b1
.word 0xf9400fb1
.word 0xf9403231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9405231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #832]
.word 0xf9400000
.word 0xf9001ba0
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9408631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xf9400fb1
.word 0xf9409a31
.word 0xb4000051
.word 0xd63f0220
.word 0x910003bf
.word 0xa8c47bfd
.word 0xd65f03c0

Lme_68:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_StoredRegistrationEntry_AsString
WindowsAzure_Messaging_StoredRegistrationEntry_AsString:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000bba
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #840]
.word 0xf9000fb0
.word 0xf9400a11
.word 0xf90013b1
.word 0xf9400fb1
.word 0xf9403631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9405631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_4
.word 0x53001c00
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0x340005c0
.word 0xf9400fb1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_5
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_41@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_41@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf940d231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
bl _p_6
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf940f231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
bl _p_15
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf9410e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9412e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0x1400002d
.word 0xf9400fb1
.word 0xf9414631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_8
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9416631
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_41@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_41@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf9418631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
bl _p_9
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf941a631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
bl _p_15
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf941c231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf941e231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xf9400fb1
.word 0xf941f631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bba
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_69:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_StoredRegistrationEntry_get_ETag
WindowsAzure_Messaging_StoredRegistrationEntry_get_ETag:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000bba
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #848]
.word 0xf9000fb0
.word 0xf9400a11
.word 0xf90013b1
.word 0xf9400fb1
.word 0xf9403631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9405631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_4
.word 0x53001c00
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0x340005c0
.word 0xf9400fb1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_5
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_32@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_32@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf940d231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
bl _p_6
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf940f231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
bl _p_15
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf9410e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9412e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0x1400002d
.word 0xf9400fb1
.word 0xf9414631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_8
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9416631
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_32@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_32@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf9418631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
bl _p_9
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf941a631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
bl _p_15
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf941c231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf941e231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xf9400fb1
.word 0xf941f631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bba
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_6a:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_StoredRegistrationEntry_set_ETag_string
WindowsAzure_Messaging_StoredRegistrationEntry_set_ETag_string:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xa90167b8
.word 0xf90013ba
.word 0xaa0003f9
.word 0xaa0103fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #856]
.word 0xf90017b0
.word 0xf9400a11
.word 0xf9001bb1
.word 0xd2800018
.word 0xf94017b1
.word 0xf9404231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9406231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xb500025a
.word 0xf94017b1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd280a7a1
.word 0xd280a7a1
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf94017b1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_13
.word 0xf90027a0
.word 0xf94017b1
.word 0xf940de31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0
.word 0xaa0003f8
.word 0xf94017b1
.word 0xf940f631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_4
.word 0x53001c00
.word 0xf90023a0
.word 0xf94017b1
.word 0xf9411a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0x34000460
.word 0xf94017b1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_5
.word 0xf90023a0
.word 0xf94017b1
.word 0xf9415231
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_33@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_33@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf94017b1
.word 0xf9417231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
.word 0xaa1803e2
.word 0xaa1803e2
bl _p_21
.word 0xf94017b1
.word 0xf9419631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf941a631
.word 0xb4000051
.word 0xd63f0220
.word 0x1400001e
.word 0xf94017b1
.word 0xf941ba31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_8
.word 0xf90023a0
.word 0xf94017b1
.word 0xf941da31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_33@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_33@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf94017b1
.word 0xf941fa31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
.word 0xaa1803e2
.word 0xaa1803e2
bl _p_22
.word 0xf94017b1
.word 0xf9421e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9423e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
bl _p_16
.word 0xf94017b1
.word 0xf9425a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9426a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9427a31
.word 0xb4000051
.word 0xd63f0220
.word 0xa94167b8
.word 0xf94013ba
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_6b:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_StoredRegistrationEntry_get_RegistrationId
WindowsAzure_Messaging_StoredRegistrationEntry_get_RegistrationId:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000bba
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #864]
.word 0xf9000fb0
.word 0xf9400a11
.word 0xf90013b1
.word 0xf9400fb1
.word 0xf9403631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9405631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_4
.word 0x53001c00
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0x340005c0
.word 0xf9400fb1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_5
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_42@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_42@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf940d231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
bl _p_6
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf940f231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
bl _p_15
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf9410e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9412e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0x1400002d
.word 0xf9400fb1
.word 0xf9414631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_8
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9416631
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_42@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_42@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf9418631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
bl _p_9
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf941a631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
bl _p_15
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf941c231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf941e231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xf9400fb1
.word 0xf941f631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bba
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_6c:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_StoredRegistrationEntry_set_RegistrationId_string
WindowsAzure_Messaging_StoredRegistrationEntry_set_RegistrationId_string:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xa90167b8
.word 0xf90013ba
.word 0xaa0003f9
.word 0xaa0103fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #872]
.word 0xf90017b0
.word 0xf9400a11
.word 0xf9001bb1
.word 0xd2800018
.word 0xf94017b1
.word 0xf9404231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9406231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xb500025a
.word 0xf94017b1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd280a7a1
.word 0xd280a7a1
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf94017b1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_13
.word 0xf90027a0
.word 0xf94017b1
.word 0xf940de31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0
.word 0xaa0003f8
.word 0xf94017b1
.word 0xf940f631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_4
.word 0x53001c00
.word 0xf90023a0
.word 0xf94017b1
.word 0xf9411a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0x34000460
.word 0xf94017b1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_5
.word 0xf90023a0
.word 0xf94017b1
.word 0xf9415231
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_37@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_37@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf94017b1
.word 0xf9417231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
.word 0xaa1803e2
.word 0xaa1803e2
bl _p_21
.word 0xf94017b1
.word 0xf9419631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf941a631
.word 0xb4000051
.word 0xd63f0220
.word 0x1400001e
.word 0xf94017b1
.word 0xf941ba31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_8
.word 0xf90023a0
.word 0xf94017b1
.word 0xf941da31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_37@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_37@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf94017b1
.word 0xf941fa31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
.word 0xaa1803e2
.word 0xaa1803e2
bl _p_22
.word 0xf94017b1
.word 0xf9421e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9423e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
bl _p_16
.word 0xf94017b1
.word 0xf9425a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9426a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9427a31
.word 0xb4000051
.word 0xd63f0220
.word 0xa94167b8
.word 0xf94013ba
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_6d:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_StoredRegistrationEntry_get_RegistrationName
WindowsAzure_Messaging_StoredRegistrationEntry_get_RegistrationName:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000bba
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #880]
.word 0xf9000fb0
.word 0xf9400a11
.word 0xf90013b1
.word 0xf9400fb1
.word 0xf9403631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9405631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_4
.word 0x53001c00
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0x340005c0
.word 0xf9400fb1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_5
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_43@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_43@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf940d231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
bl _p_6
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf940f231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
bl _p_15
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf9410e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9412e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0x1400002d
.word 0xf9400fb1
.word 0xf9414631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_8
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9416631
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_43@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_43@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf9418631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
bl _p_9
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf941a631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
bl _p_15
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf941c231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf941e231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xf9400fb1
.word 0xf941f631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bba
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_6e:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_StoredRegistrationEntry_set_RegistrationName_string
WindowsAzure_Messaging_StoredRegistrationEntry_set_RegistrationName_string:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xa90167b8
.word 0xf90013ba
.word 0xaa0003f9
.word 0xaa0103fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #888]
.word 0xf90017b0
.word 0xf9400a11
.word 0xf9001bb1
.word 0xd2800018
.word 0xf94017b1
.word 0xf9404231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9406231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xb500025a
.word 0xf94017b1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd280a7a1
.word 0xd280a7a1
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf94017b1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_13
.word 0xf90027a0
.word 0xf94017b1
.word 0xf940de31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0
.word 0xaa0003f8
.word 0xf94017b1
.word 0xf940f631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_4
.word 0x53001c00
.word 0xf90023a0
.word 0xf94017b1
.word 0xf9411a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0x34000460
.word 0xf94017b1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_5
.word 0xf90023a0
.word 0xf94017b1
.word 0xf9415231
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_44@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_44@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf94017b1
.word 0xf9417231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
.word 0xaa1803e2
.word 0xaa1803e2
bl _p_21
.word 0xf94017b1
.word 0xf9419631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf941a631
.word 0xb4000051
.word 0xd63f0220
.word 0x1400001e
.word 0xf94017b1
.word 0xf941ba31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_8
.word 0xf90023a0
.word 0xf94017b1
.word 0xf941da31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_44@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_44@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf94017b1
.word 0xf941fa31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
.word 0xaa1803e2
.word 0xaa1803e2
bl _p_22
.word 0xf94017b1
.word 0xf9421e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9423e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
bl _p_16
.word 0xf94017b1
.word 0xf9425a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9426a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9427a31
.word 0xb4000051
.word 0xd63f0220
.word 0xa94167b8
.word 0xf94013ba
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_6f:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_StoredRegistrationEntry__cctor
WindowsAzure_Messaging_StoredRegistrationEntry__cctor:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #896]
.word 0xf9000bb0
.word 0xf9400a11
.word 0xf9000fb1
.word 0xf9400bb1
.word 0xf9402e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb1
.word 0xf9404e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #904]
bl _p_18
.word 0xf9001ba0
.word 0xf9400bb1
.word 0xf9407231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #832]
.word 0xf9000001
.word 0xf9400bb1
.word 0xf9409631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb1
.word 0xf940a631
.word 0xb4000051
.word 0xd63f0220
.word 0x910003bf
.word 0xa8c47bfd
.word 0xd65f03c0

Lme_70:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBTokenProvider__ctor
WindowsAzure_Messaging_SBTokenProvider__ctor:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000bba
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #912]
.word 0xf9000fb0
.word 0xf9400a11
.word 0xf90013b1
.word 0xf9400fb1
.word 0xf9403631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9405631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #152]
.word 0xf9400001
.word 0xaa1a03e0
bl _p_1
.word 0xf9400fb1
.word 0xf9408231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0xf9400340
.word 0xf9400c00
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf940b631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a1
.word 0xaa0103e0
.word 0xf9400021
.word 0xf943c430
.word 0xd63f0200
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf940de31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x1, [x16, #136]
.word 0xf9400021
bl _p_2
.word 0x53001c00
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf9410e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa1
.word 0xaa1a03e0
bl _p_3
.word 0xf9400fb1
.word 0xf9412a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9413a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_4
.word 0x53001c00
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf9415e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0x340005a0
.word 0xf9400fb1
.word 0xf9417631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_5
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf9419a31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_0@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_0@PAGEOFF
ldr x0, [x0]
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf941ba31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
.word 0xf94023a1
bl _p_6
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf941da31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x2, [x16, #160]
.word 0xaa1a03e0
bl _p_7
.word 0xf9400fb1
.word 0xf9420231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9421231
.word 0xb4000051
.word 0xd63f0220
.word 0x14000028
.word 0xf9400fb1
.word 0xf9422631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_8
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf9424a31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_0@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_0@PAGEOFF
ldr x0, [x0]
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9426a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
.word 0xf94023a1
bl _p_9
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf9428a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x2, [x16, #160]
.word 0xaa1a03e0
bl _p_7
.word 0xf9400fb1
.word 0xf942b231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf942d231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf942e231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bba
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_71:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBTokenProvider__ctor_Foundation_NSObjectFlag
WindowsAzure_Messaging_SBTokenProvider__ctor_Foundation_NSObjectFlag:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bb9
.word 0xaa0003f9
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #920]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xf94013b1
.word 0xf9403a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9405a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xf9400fa1
.word 0xaa1903e0
bl _p_1
.word 0xf94013b1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9408a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0xf9400320
.word 0xf9400c00
.word 0xf9002ba0
.word 0xf94013b1
.word 0xf940ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba1
.word 0xaa0103e0
.word 0xf9400021
.word 0xf943c430
.word 0xd63f0200
.word 0xf90027a0
.word 0xf94013b1
.word 0xf940d631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x1, [x16, #136]
.word 0xf9400021
bl _p_2
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a1
.word 0xaa1903e0
bl _p_3
.word 0xf94013b1
.word 0xf9412231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9414231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb9
.word 0x910003bf
.word 0xa8c67bfd
.word 0xd65f03c0

Lme_72:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBTokenProvider__ctor_intptr
WindowsAzure_Messaging_SBTokenProvider__ctor_intptr:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bb9
.word 0xaa0003f9
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #928]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xf94013b1
.word 0xf9403a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9405a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xf9400fa1
.word 0xaa1903e0
bl _p_10
.word 0xf94013b1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9408a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0xf9400320
.word 0xf9400c00
.word 0xf9002ba0
.word 0xf94013b1
.word 0xf940ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba1
.word 0xaa0103e0
.word 0xf9400021
.word 0xf943c430
.word 0xd63f0200
.word 0xf90027a0
.word 0xf94013b1
.word 0xf940d631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x1, [x16, #136]
.word 0xf9400021
bl _p_2
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a1
.word 0xaa1903e0
bl _p_3
.word 0xf94013b1
.word 0xf9412231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9414231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb9
.word 0x910003bf
.word 0xa8c67bfd
.word 0xd65f03c0

Lme_73:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBTokenProvider_get_ClassHandle
WindowsAzure_Messaging_SBTokenProvider_get_ClassHandle:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #936]
.word 0xf9000fb0
.word 0xf9400a11
.word 0xf90013b1
.word 0xf9400fb1
.word 0xf9403231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9405231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #944]
.word 0xf9400000
.word 0xf9001ba0
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9408631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xf9400fb1
.word 0xf9409a31
.word 0xb4000051
.word 0xd63f0220
.word 0x910003bf
.word 0xa8c47bfd
.word 0xd65f03c0

Lme_74:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBTokenProvider_SetToken_Foundation_NSMutableUrlRequest_WindowsAzure_Messaging_ErrorCallback
WindowsAzure_Messaging_SBTokenProvider_SetToken_Foundation_NSMutableUrlRequest_WindowsAzure_Messaging_ErrorCallback:
.loc 1 1 0
.word 0xa9b67bfd
.word 0x910003fd
.word 0xa90163b7
.word 0xa9026bb9
.word 0xaa0003f8
.word 0xaa0103f9
.word 0xaa0203fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #952]
.word 0xf9001bb0
.word 0xf9400a11
.word 0xf9001fb1
.word 0xd2800017
.word 0x910123a0
.word 0xd2800000
.word 0xf90027a0
.word 0xf9002ba0
.word 0xf9002fa0
.word 0xf90033a0
.word 0xf90037a0
.word 0xf9003ba0
.word 0xf9401bb1
.word 0xf9406631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9408631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xb5000259
.word 0xf9401bb1
.word 0xf9409e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd2818d21
.word 0xd2818d21
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf9401bb1
.word 0xf940e231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xb500025a
.word 0xf9401bb1
.word 0xf940fa31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd280d421
.word 0xd280d421
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf9401bb1
.word 0xf9413e31
.word 0xb4000051
.word 0xd63f0220
.word 0x910123a0
.word 0xd2800000
.word 0xf90027a0
.word 0xf9002ba0
.word 0xf9002fa0
.word 0xf90033a0
.word 0xf90037a0
.word 0xf9003ba0
.word 0xf9401bb1
.word 0xf9416e31
.word 0xb4000051
.word 0xd63f0220
.word 0x910123a0
.word 0xaa0003f7
.word 0xf9401bb1
.word 0xf9418631
.word 0xb4000051
.word 0xd63f0220
.word 0x910123a0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x1, [x16, #512]
.word 0xf9400021
.word 0xaa1a03e2
.word 0xaa1a03e2
bl _p_40
.word 0xf9401bb1
.word 0xf941b631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf941c631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
bl _p_4
.word 0x53001c00
.word 0xf90043a0
.word 0xf9401bb1
.word 0xf941ea31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94043a0
.word 0x34000680
.word 0xf9401bb1
.word 0xf9420231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
bl _p_5
.word 0xf90043a0
.word 0xf9401bb1
.word 0xf9422231
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_45@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_45@PAGEOFF
ldr x0, [x0]
.word 0xf90047a0
.word 0xf9401bb1
.word 0xf9424231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0xf940033e
bl _p_5
.word 0xf9004ba0
.word 0xf9401bb1
.word 0xf9426631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xaa1703e0
bl _p_41
.word 0xf9004fa0
.word 0xf9401bb1
.word 0xf9428631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94043a0
.word 0xf94047a1
.word 0xf9404ba2
.word 0xf9404fa3
bl _p_26
.word 0xf9401bb1
.word 0xf942aa31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf942ba31
.word 0xb4000051
.word 0xd63f0220
.word 0x1400002f
.word 0xf9401bb1
.word 0xf942ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
bl _p_8
.word 0xf90043a0
.word 0xf9401bb1
.word 0xf942ee31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_45@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_45@PAGEOFF
ldr x0, [x0]
.word 0xf90047a0
.word 0xf9401bb1
.word 0xf9430e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0xf940033e
bl _p_5
.word 0xf9004ba0
.word 0xf9401bb1
.word 0xf9433231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xaa1703e0
bl _p_41
.word 0xf9004fa0
.word 0xf9401bb1
.word 0xf9435231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94043a0
.word 0xf94047a1
.word 0xf9404ba2
.word 0xf9404fa3
bl _p_27
.word 0xf9401bb1
.word 0xf9437631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9439631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xaa1703e0
bl _p_44
.word 0xf9401bb1
.word 0xf943b231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf943c231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf943d231
.word 0xb4000051
.word 0xd63f0220
.word 0xa94163b7
.word 0xa9426bb9
.word 0x910003bf
.word 0xa8ca7bfd
.word 0xd65f03c0

Lme_75:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBTokenProvider_SetToken_Foundation_NSMutableUrlRequest_Foundation_NSError_
WindowsAzure_Messaging_SBTokenProvider_SetToken_Foundation_NSMutableUrlRequest_Foundation_NSError_:
.loc 1 1 0
.word 0xa9b87bfd
.word 0x910003fd
.word 0xa9015bb5
.word 0xa90263b7
.word 0xf9001bb9
.word 0xaa0003f8
.word 0xaa0103f9
.word 0xf9001fa2

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #960]
.word 0xf90023b0
.word 0xf9400a11
.word 0xf90027b1
.word 0xf9002fbf
.word 0xd2800017
.word 0xf94023b1
.word 0xf9404e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9406e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xb5000259
.word 0xf94023b1
.word 0xf9408631
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd2818d21
.word 0xd2818d21
bl _p_11
.word 0xaa0003e1
.word 0xd28014c0
.word 0xf2a04000
.word 0xd28014c0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_12
.word 0xf94023b1
.word 0xf940ca31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #488]
.word 0xf9400000
.word 0xf9002fa0
.word 0xf94023b1
.word 0xf940ee31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
bl _p_4
.word 0x53001c00
.word 0xf90033a0
.word 0xf94023b1
.word 0xf9411231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a0
.word 0x34000600
.word 0xf94023b1
.word 0xf9412a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
bl _p_5
.word 0xf90037a0
.word 0xf94023b1
.word 0xf9414a31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_46@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_46@PAGEOFF
ldr x0, [x0]
.word 0xf9003ba0
.word 0xf94023b1
.word 0xf9416a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0xf940033e
bl _p_5
.word 0xf9003fa0
.word 0xf94023b1
.word 0xf9418e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94037a0
.word 0xf9403ba1
.word 0xf9403fa2
.word 0x910163a3
bl _p_49
.word 0x53001c00
.word 0xf90033a0
.word 0xf94023b1
.word 0xf941ba31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a0
.word 0xaa0003f7
.word 0xf94023b1
.word 0xf941d231
.word 0xb4000051
.word 0xd63f0220
.word 0x1400002b
.word 0xf94023b1
.word 0xf941e631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
bl _p_8
.word 0xf90037a0
.word 0xf94023b1
.word 0xf9420631
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_46@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_46@PAGEOFF
ldr x0, [x0]
.word 0xf9003ba0
.word 0xf94023b1
.word 0xf9422631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0xf940033e
bl _p_5
.word 0xf9003fa0
.word 0xf94023b1
.word 0xf9424a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94037a0
.word 0xf9403ba1
.word 0xf9403fa2
.word 0x910163a3
bl _p_50
.word 0x53001c00
.word 0xf90033a0
.word 0xf94023b1
.word 0xf9427631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a0
.word 0xaa0003f7
.word 0xf94027b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9429e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
.word 0xf90037a0
.word 0xf9402fa0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x1, [x16, #488]
.word 0xf9400021
bl _p_37
.word 0x53001c00
.word 0xf90033a0
.word 0xf94023b1
.word 0xf942d631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a0
.word 0xf94037a1
.word 0xaa0103f6
.word 0x340001e0
.word 0xaa1603e0
.word 0xf9402fa0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x15, [x16, #496]
bl _p_38
.word 0xf90033a0
.word 0xf94023b1
.word 0xf9431231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a0
.word 0xaa0003f5
.word 0x14000004
.word 0xaa1603e0
.word 0xd2800000
.word 0xd2800015
.word 0xaa1603e0
.word 0xaa1503e0
.word 0xf90002d5
.word 0xaa1603e0
bl _p_39
.word 0xf94023b1
.word 0xf9434e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xf94027b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9437231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xf94023b1
.word 0xf9438631
.word 0xb4000051
.word 0xd63f0220
.word 0xa9415bb5
.word 0xa94263b7
.word 0xf9401bb9
.word 0x910003bf
.word 0xa8c87bfd
.word 0xd65f03c0

Lme_76:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBTokenProvider_get_TimeToExpireInMin
WindowsAzure_Messaging_SBTokenProvider_get_TimeToExpireInMin:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000bba
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #968]
.word 0xf9000fb0
.word 0xf9400a11
.word 0xf90013b1
.word 0xf9400fb1
.word 0xf9403631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9405631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_4
.word 0x53001c00
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0x34000500
.word 0xf9400fb1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_5
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_47@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_47@PAGEOFF
ldr x0, [x0]
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf940d231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
.word 0xf94023a1
bl _p_58
.word 0x93407c00
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf940f631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9411631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0x14000027
.word 0xf9400fb1
.word 0xf9412e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_8
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf9414e31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_47@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_47@PAGEOFF
ldr x0, [x0]
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9416e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
.word 0xf94023a1
bl _p_59
.word 0x93407c00
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf9419231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf941b231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xf9400fb1
.word 0xf941c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bba
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_77:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBTokenProvider_set_TimeToExpireInMin_int
WindowsAzure_Messaging_SBTokenProvider_set_TimeToExpireInMin_int:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xa9016bb9
.word 0xaa0003f9
.word 0xaa0103fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #976]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xf94013b1
.word 0xf9403a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9405a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_4
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9407e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0x34000460
.word 0xf94013b1
.word 0xf9409631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_5
.word 0xf90023a0
.word 0xf94013b1
.word 0xf940b631
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_48@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_48@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf94013b1
.word 0xf940d631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
.word 0xaa1a03e2
.word 0xaa1a03e2
bl _p_60
.word 0xf94013b1
.word 0xf940fa31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9410a31
.word 0xb4000051
.word 0xd63f0220
.word 0x1400001e
.word 0xf94013b1
.word 0xf9411e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_8
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9413e31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_48@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_48@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf94013b1
.word 0xf9415e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
.word 0xaa1a03e2
.word 0xaa1a03e2
bl _p_61
.word 0xf94013b1
.word 0xf9418231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf941a231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf941b231
.word 0xb4000051
.word 0xd63f0220
.word 0xa9416bb9
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_78:
.text
	.align 4
	.no_dead_strip WindowsAzure_Messaging_SBTokenProvider__cctor
WindowsAzure_Messaging_SBTokenProvider__cctor:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #984]
.word 0xf9000bb0
.word 0xf9400a11
.word 0xf9000fb1
.word 0xf9400bb1
.word 0xf9402e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb1
.word 0xf9404e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #992]
bl _p_18
.word 0xf9001ba0
.word 0xf9400bb1
.word 0xf9407231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #944]
.word 0xf9000001
.word 0xf9400bb1
.word 0xf9409631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb1
.word 0xf940a631
.word 0xb4000051
.word 0xd63f0220
.word 0x910003bf
.word 0xa8c47bfd
.word 0xd65f03c0

Lme_79:
.text
	.align 4
	.no_dead_strip ObjCRuntime_Trampolines_SDErrorCallback_Invoke_intptr_intptr
ObjCRuntime_Trampolines_SDErrorCallback_Invoke_intptr_intptr:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xa9015fb6
.word 0xf90013b8
.word 0xf90017a0
.word 0xf9001ba1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1000]
.word 0xf9001fb0
.word 0xf9400a11
.word 0xf90023b1
.word 0xd2800018
.word 0xd2800017
.word 0xf9401fb1
.word 0xf9404631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9406631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017a0
bl _p_62
.word 0xf9002fa0
.word 0xf9401fb1
.word 0xf9408231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fa0
.word 0xf9002ba0
.word 0xaa0003f8
.word 0xf9401fb1
.word 0xf9409e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
.word 0xaa0003e1
bl _p_63
.word 0xaa0003f6
.word 0xf9401fb1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0xb4000176
.word 0xf94002c0
.word 0xf9400000
.word 0xf9400800
.word 0xf9400c00

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x1, [x16, #1008]
.word 0xeb01001f
.word 0x10000011
.word 0x54000601
.word 0xaa1603f7
.word 0xf9401fb1
.word 0xf940fe31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0xb4000316
.word 0xf9401fb1
.word 0xf9411631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xf9401ba0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x15, [x16, #496]
bl _p_38
.word 0xf9002ba0
.word 0xf9401fb1
.word 0xf9414231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba1
.word 0xaa1703e0
.word 0xf9400ef0
.word 0xd63f0200
.word 0xf9401fb1
.word 0xf9416231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9418231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9419231
.word 0xb4000051
.word 0xd63f0220
.word 0xa9415fb6
.word 0xf94013b8
.word 0x910003bf
.word 0xa8c67bfd
.word 0xd65f03c0
.word 0xd2804380
.word 0xaa1103e1
bl _p_64

Lme_84:
.text
	.align 4
	.no_dead_strip ObjCRuntime_Trampolines_SDErrorCallback__cctor
ObjCRuntime_Trampolines_SDErrorCallback__cctor:
.loc 1 1 0
.word 0xa9bd7bfd
.word 0x910003fd

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1016]
.word 0xf9000bb0
.word 0xf9400a11
.word 0xf9000fb1
.word 0xf9400bb1
.word 0xf9402e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb1
.word 0xf9404e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1024]
.word 0xf9400000
.word 0xb5000400
.word 0xf9400bb1
.word 0xf9407231
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800000

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1032]
bl _p_65
.word 0xaa0003e1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1040]
.word 0xf9001420

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1048]
.word 0xf9002020

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1056]
.word 0xf9401402
.word 0xf9000c22
.word 0xf9401000
.word 0xf9000820
.word 0xd2800000
.word 0x3901803f

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1024]
.word 0xf9000001
.word 0xf9400fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb1
.word 0xf940fe31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1024]
.word 0xf9400001

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #512]
.word 0xf9000001
.word 0xf9400bb1
.word 0xf9412e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb1
.word 0xf9413e31
.word 0xb4000051
.word 0xd63f0220
.word 0x910003bf
.word 0xa8c37bfd
.word 0xd65f03c0

Lme_85:
.text
	.align 4
	.no_dead_strip ObjCRuntime_Trampolines_NIDErrorCallback__ctor_ObjCRuntime_BlockLiteral_
ObjCRuntime_Trampolines_NIDErrorCallback__ctor_ObjCRuntime_BlockLiteral_:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xa9016bb9
.word 0xaa0003f9
.word 0xaa0103fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1064]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xf94013b1
.word 0xf9403a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9405a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xf94013b1
.word 0xf9406e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9407e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_41
.word 0xf9002fa0
.word 0xf94013b1
.word 0xf940a231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fa0
bl _p_66
.word 0xf9002ba0
.word 0xf94013b1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
.word 0xf9000f20
.word 0xf94013b1
.word 0xf940d631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1a03e0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x15, [x16, #1072]
.word 0xaa1a03e0
bl _p_67
.word 0xf90027a0
.word 0xf94013b1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0
.word 0xf90023a0
.word 0xf9000b20
.word 0x91004320
bl _p_39
.word 0xf94023a0
.word 0xf94013b1
.word 0xf9412e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9413e31
.word 0xb4000051
.word 0xd63f0220
.word 0xa9416bb9
.word 0x910003bf
.word 0xa8c67bfd
.word 0xd65f03c0

Lme_86:
.text
	.align 4
	.no_dead_strip ObjCRuntime_Trampolines_NIDErrorCallback_Finalize
ObjCRuntime_Trampolines_NIDErrorCallback_Finalize:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1080]
.word 0xf9000fb0
.word 0xf9400a11
.word 0xf90013b1
.word 0xf9400fb1
.word 0xf9403231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9405231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400c00
bl _p_68
.word 0xf9400fb1
.word 0xf9406e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9407e31
.word 0xb4000051
.word 0xd63f0220
.word 0x94000002
.word 0x14000012
.word 0xf9001fbe
.word 0xf9400fb1
.word 0xf9409a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
bl _p_69
.word 0xf9400fb1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf940c231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fbe
.word 0xd61f03c0
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf940ea31
.word 0xb4000051
.word 0xd63f0220
.word 0x14000001
.word 0xf9400fb1
.word 0xf940fe31
.word 0xb4000051
.word 0xd63f0220
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_87:
.text
	.align 4
	.no_dead_strip ObjCRuntime_Trampolines_NIDErrorCallback_Create_intptr
ObjCRuntime_Trampolines_NIDErrorCallback_Create_intptr:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1088]
.word 0xf9000fb0
.word 0xf9400a11
.word 0xf90013b1
.word 0xf9400fb1
.word 0xf9403231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9405231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
bl _p_62
.word 0xf9002fa0
.word 0xf9400fb1
.word 0xf9406e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1096]
bl _p_70
.word 0xf9402fa1
.word 0xf9002ba0
bl _p_71
.word 0xf9400fb1
.word 0xf9409a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
.word 0xf90027a0
.word 0xeb1f001f
.word 0x10000011
.word 0x540005e0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1104]
bl _p_65
.word 0xf94027a1
.word 0xf90023a1
.word 0xf9001001
.word 0xf9001fa0
.word 0x91008000
bl _p_39
.word 0xf9401fa0
.word 0xf94023a1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x1, [x16, #1112]
.word 0xf9001401

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x1, [x16, #1120]
.word 0xf9002001

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x1, [x16, #1128]
.word 0xf9401422
.word 0xf9000c02
.word 0xf9401021
.word 0xf9000801
.word 0xd2800001
.word 0x3901801f
.word 0xf9001ba0
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9414631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xf9400fb1
.word 0xf9415a31
.word 0xb4000051
.word 0xd63f0220
.word 0x910003bf
.word 0xa8c67bfd
.word 0xd65f03c0
.word 0xd28014a0
.word 0xaa1103e1
bl _p_64

Lme_88:
.text
	.align 4
	.no_dead_strip ObjCRuntime_Trampolines_NIDErrorCallback_Invoke_Foundation_NSError
ObjCRuntime_Trampolines_NIDErrorCallback_Invoke_Foundation_NSError:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xa9015fb6
.word 0xa90267b8
.word 0xf9001bba
.word 0xaa0003f9
.word 0xaa0103fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1136]
.word 0xf9001fb0
.word 0xf9400a11
.word 0xf90023b1
.word 0xf9401fb1
.word 0xf9404231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9406231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xf9400b21
.word 0xaa1903e0
.word 0xf9400f20
.word 0xaa1a03e2
.word 0xaa0103f8
.word 0xaa0003f7
.word 0xb500013a
.word 0xaa1803e0
.word 0xaa1703e0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #488]
.word 0xf9400000
.word 0xaa0003f6
.word 0x1400000e
.word 0xaa1803e0
.word 0xaa1703e0
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0xf940035e
bl _p_5
.word 0xf9002ba0
.word 0xf9401fb1
.word 0xf940ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
.word 0xaa0003f6
.word 0xaa1803e0
.word 0xaa1703e0
.word 0xaa1603e0
.word 0xaa1803e0
.word 0xaa1703e1
.word 0xaa1603e2
.word 0xf9400f10
.word 0xd63f0200
.word 0xf9401fb1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9411631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9412631
.word 0xb4000051
.word 0xd63f0220
.word 0xa9415fb6
.word 0xa94267b8
.word 0xf9401bba
.word 0x910003bf
.word 0xa8c67bfd
.word 0xd65f03c0

Lme_89:
.text
	.align 4
	.no_dead_strip wrapper_delegate_invoke__Module_invoke_void_NSError_Foundation_NSError
wrapper_delegate_invoke__Module_invoke_void_NSError_Foundation_NSError:
.loc 1 1 0
.word 0xa9b87bfd
.word 0x910003fd
.word 0xa90153b3
.word 0xa9025bb5
.word 0xa90363b7
.word 0xa9046bb9
.word 0xaa0003f9
.word 0xaa0103fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1144]
.word 0xf9002bb0
.word 0xf9400a11
.word 0xf9002fb1
.word 0xd2800018
.word 0xd2800017
.word 0xd2800016
.word 0xd2800015
.word 0xd2800014
.word 0xf9402bb1
.word 0xf9405a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xb9400000
.word 0x34000240
.word 0xf9402bb1
.word 0xf9409e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf940ae31
.word 0xb4000051
.word 0xd63f0220
bl _p_72
.word 0xaa0003f3
.word 0xaa1303e0
.word 0xaa1303e1
.word 0xf90037a0
.word 0xb4000073
.word 0xf94037a0
bl _p_12
.word 0xf94037a0
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf940f231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0x9101a320
.word 0xf9403720
.word 0xaa0003f6
.word 0xf9402bb1
.word 0xf9411631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0xb5000756
.word 0xf9402bb1
.word 0xf9412e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0x91008320
.word 0xf9401320
.word 0xaa0003f4
.word 0xf9402bb1
.word 0xf9415231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1403e0
.word 0xb40002f4
.word 0xf9402bb1
.word 0xf9416a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1403e0
.word 0xaa1a03e0
.word 0xaa1903e0
.word 0xaa1903e0
.word 0x9100e320
.word 0xf9401f20
.word 0xaa1903e0
.word 0xaa1903e0
.word 0x91004320
.word 0xf9400b22
.word 0xaa1403e0
.word 0xaa1a03e1
.word 0xd63f0040
.word 0xf9402bb1
.word 0xf941ae31
.word 0xb4000051
.word 0xd63f0220
.word 0x14000058
.word 0xf9402bb1
.word 0xf941c231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1903e0
.word 0xaa1903e0
.word 0x9100e320
.word 0xf9401f20
.word 0xaa1903e0
.word 0xaa1903e0
.word 0x91004320
.word 0xf9400b21
.word 0xaa1a03e0
.word 0xd63f0020
.word 0xf9402bb1
.word 0xf941fe31
.word 0xb4000051
.word 0xd63f0220
.word 0x14000044
.word 0xf9402bb1
.word 0xf9421231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0xb9801ac0
.word 0xaa0003f7
.word 0xf9402bb1
.word 0xf9422e31
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800018
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9425231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0xaa1803e0
.word 0x93407f00
.word 0xb9801ac1
.word 0xeb00003f
.word 0x10000011
.word 0x54000689
.word 0xd37df000
.word 0x8b0002c0
.word 0x91008000
.word 0xf9400000
.word 0xaa0003f5
.word 0xf9402bb1
.word 0xf9429231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1503e0
.word 0xf9003ba0
.word 0xaa1a03e0
.word 0xaa1503e0
.word 0xaa1a03e1
.word 0xf9400eb0
.word 0xd63f0200
.word 0xf9403ba0
.word 0xf9402bb1
.word 0xf942c231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf942d231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0x11000700
.word 0xaa0003f8
.word 0xf9402bb1
.word 0xf942ee31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1703e0
.word 0x6b17031f
.word 0x54fff9cb
.word 0xf9402bb1
.word 0xf9430e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9431e31
.word 0xb4000051
.word 0xd63f0220
.word 0xa94153b3
.word 0xa9425bb5
.word 0xa94363b7
.word 0xa9446bb9
.word 0x910003bf
.word 0xa8c87bfd
.word 0xd65f03c0
.word 0xd28042c0
.word 0xaa1103e1
bl _p_64

Lme_8b:
.text
	.align 4
	.no_dead_strip wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___NSError_AsyncCallback_object_Foundation_NSError_System_AsyncCallback_object
wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___NSError_AsyncCallback_object_Foundation_NSError_System_AsyncCallback_object:
.loc 1 1 0
.word 0xa9b97bfd
.word 0x910003fd
.word 0xa90167b8
.word 0xf90013a0
.word 0xf90017a1
.word 0xf9001ba2
.word 0xf9001fa3

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1160]
.word 0xf90023b0
.word 0xf9400a11
.word 0xf90027b1
.word 0xd2800019
.word 0xd2800018
.word 0xf94023b1
.word 0xf9404a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9406a31
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800400
.word 0xd10083ff
.word 0xa9007fff
.word 0xa9017fff
.word 0x910003e0
.word 0xaa0003f9
.word 0xf94023b1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903f8
.word 0xf94023b1
.word 0xf940aa31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0x9100a3a0
.word 0xf9000320
.word 0xf94023b1
.word 0xf940c631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xd2800100
.word 0x93407c00
.word 0x91002320
.word 0xaa0003f8
.word 0xf94023b1
.word 0xf940ea31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0x9100c3a0
.word 0xf9000300
.word 0xf94023b1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xd2800100
.word 0x93407c00
.word 0x91002300
.word 0xaa0003f8
.word 0xf94023b1
.word 0xf9412a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0x9100e3a0
.word 0xf9000300
.word 0xf94023b1
.word 0xf9414631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013a0
.word 0xaa1903e1
.word 0xaa1903e1
bl _p_73
.word 0xf90033a0
.word 0xf94027b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9417a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a0
.word 0xf94023b1
.word 0xf9418e31
.word 0xb4000051
.word 0xd63f0220
.word 0xa94167b8
.word 0x910003bf
.word 0xa8c77bfd
.word 0xd65f03c0

Lme_8c:
.text
	.align 4
	.no_dead_strip wrapper_delegate_end_invoke__Module_end_invoke_void__this___IAsyncResult_System_IAsyncResult
wrapper_delegate_end_invoke__Module_end_invoke_void__this___IAsyncResult_System_IAsyncResult:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xa90167b8
.word 0xf90013a0
.word 0xf90017a1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1168]
.word 0xf9001bb0
.word 0xf9400a11
.word 0xf9001fb1
.word 0xd2800019
.word 0xd2800018
.word 0xf9401bb1
.word 0xf9404231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9406231
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800200
.word 0xd10043ff
.word 0xa9007fff
.word 0x910003e0
.word 0xaa0003f9
.word 0xf9401bb1
.word 0xf9408631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903f8
.word 0xf9401bb1
.word 0xf9409e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0x9100a3a0
.word 0xf9000320
.word 0xf9401bb1
.word 0xf940ba31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013a0
.word 0xaa1903e1
.word 0xaa1903e1
bl _p_74
.word 0xf9401bb1
.word 0xf940da31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf940ea31
.word 0xb4000051
.word 0xd63f0220
.word 0xa94167b8
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_8d:
.text
	.align 4
	.no_dead_strip wrapper_delegate_invoke__Module_invoke_void_intptr_intptr_intptr_intptr
wrapper_delegate_invoke__Module_invoke_void_intptr_intptr_intptr_intptr:
.loc 1 1 0
.word 0xa9b77bfd
.word 0x910003fd
.word 0xa90153b3
.word 0xa9025bb5
.word 0xa90363b7
.word 0xa9046bb9
.word 0xaa0003f8
.word 0xaa0103f9
.word 0xaa0203fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1176]
.word 0xf9002bb0
.word 0xf9400a11
.word 0xf9002fb1
.word 0xd2800017
.word 0xd2800016
.word 0xd2800015
.word 0xd2800014
.word 0xd2800013
.word 0xf9402bb1
.word 0xf9405e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9407e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xb9400000
.word 0x34000240
.word 0xf9402bb1
.word 0xf940a231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220
bl _p_72
.word 0xf90037a0
.word 0xf94037a1
.word 0xf94037a0
.word 0xf9003ba1
.word 0xb4000060
.word 0xf9403ba0
bl _p_12
.word 0xf9403ba0
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf940f631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
.word 0x9101a300
.word 0xf9403700
.word 0xaa0003f5
.word 0xf9402bb1
.word 0xf9411a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1503e0
.word 0xb50007d5
.word 0xf9402bb1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
.word 0x91008300
.word 0xf9401300
.word 0xaa0003f3
.word 0xf9402bb1
.word 0xf9415631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1303e0
.word 0xb4000333
.word 0xf9402bb1
.word 0xf9416e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1303e0
.word 0xaa1903e0
.word 0xaa1a03e0
.word 0xaa1803e0
.word 0xaa1803e0
.word 0x9100e300
.word 0xf9401f00
.word 0xaa1803e0
.word 0xaa1803e0
.word 0x91004300
.word 0xf9400b03
.word 0xaa1303e0
.word 0xaa1903e1
.word 0xaa1a03e2
.word 0xd63f0060
.word 0xf9402bb1
.word 0xf941ba31
.word 0xb4000051
.word 0xd63f0220
.word 0x1400005c
.word 0xf9402bb1
.word 0xf941ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1a03e0
.word 0xaa1803e0
.word 0xaa1803e0
.word 0x9100e300
.word 0xf9401f00
.word 0xaa1803e0
.word 0xaa1803e0
.word 0x91004300
.word 0xf9400b02
.word 0xaa1903e0
.word 0xaa1a03e1
.word 0xd63f0040
.word 0xf9402bb1
.word 0xf9421231
.word 0xb4000051
.word 0xd63f0220
.word 0x14000046
.word 0xf9402bb1
.word 0xf9422631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1503e0
.word 0xb9801aa0
.word 0xaa0003f6
.word 0xf9402bb1
.word 0xf9424231
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800017
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9426631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1503e0
.word 0xaa1703e0
.word 0x93407ee0
.word 0xb9801aa1
.word 0xeb00003f
.word 0x10000011
.word 0x540006c9
.word 0xd37df000
.word 0x8b0002a0
.word 0x91008000
.word 0xf9400000
.word 0xaa0003f4
.word 0xf9402bb1
.word 0xf942a631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1403e0
.word 0xf90043a0
.word 0xaa1903e0
.word 0xaa1a03e0
.word 0xaa1403e0
.word 0xaa1903e1
.word 0xaa1a03e2
.word 0xf9400e90
.word 0xd63f0200
.word 0xf94043a0
.word 0xf9402bb1
.word 0xf942de31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf942ee31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0x110006e0
.word 0xaa0003f7
.word 0xf9402bb1
.word 0xf9430a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xaa1603e0
.word 0x6b1602ff
.word 0x54fff98b
.word 0xf9402bb1
.word 0xf9432a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9433a31
.word 0xb4000051
.word 0xd63f0220
.word 0xa94153b3
.word 0xa9425bb5
.word 0xa94363b7
.word 0xa9446bb9
.word 0x910003bf
.word 0xa8c97bfd
.word 0xd65f03c0
.word 0xd28042c0
.word 0xaa1103e1
bl _p_64

Lme_8e:
.text
	.align 4
	.no_dead_strip wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___intptr_intptr_AsyncCallback_object_intptr_intptr_System_AsyncCallback_object
wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___intptr_intptr_AsyncCallback_object_intptr_intptr_System_AsyncCallback_object:
.loc 1 1 0
.word 0xa9b97bfd
.word 0x910003fd
.word 0xa90167b8
.word 0xf90013a0
.word 0xf90017a1
.word 0xf9001ba2
.word 0xf9001fa3
.word 0xf90023a4

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1184]
.word 0xf90027b0
.word 0xf9400a11
.word 0xf9002bb1
.word 0xd2800019
.word 0xd2800018
.word 0xf94027b1
.word 0xf9404e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027b1
.word 0xf9406e31
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800500
.word 0xd2800500
.word 0x91003c10
.word 0x928001f1
.word 0xf2bffff1
.word 0x8a110210
.word 0x910003f1
.word 0xcb100231
.word 0x9100023f
.word 0x8b100230
.word 0xeb10023f
.word 0x54000080
.word 0xa9007e3f
.word 0x91004231
.word 0x17fffffc
.word 0x910003e0
.word 0xaa0003f9
.word 0xf94027b1
.word 0xf940c231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903f8
.word 0xf94027b1
.word 0xf940da31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0x9100a3a0
.word 0xf9000320
.word 0xf94027b1
.word 0xf940f631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xd2800100
.word 0x93407c00
.word 0x91002320
.word 0xaa0003f8
.word 0xf94027b1
.word 0xf9411a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0x9100c3a0
.word 0xf9000300
.word 0xf94027b1
.word 0xf9413631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xd2800100
.word 0x93407c00
.word 0x91002300
.word 0xaa0003f8
.word 0xf94027b1
.word 0xf9415a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0x9100e3a0
.word 0xf9000300
.word 0xf94027b1
.word 0xf9417631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xd2800100
.word 0x93407c00
.word 0x91002300
.word 0xaa0003f8
.word 0xf94027b1
.word 0xf9419a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0x910103a0
.word 0xf9000300
.word 0xf94027b1
.word 0xf941b631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013a0
.word 0xaa1903e1
.word 0xaa1903e1
bl _p_73
.word 0xf90033a0
.word 0xf9402bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027b1
.word 0xf941ea31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a0
.word 0xf94027b1
.word 0xf941fe31
.word 0xb4000051
.word 0xd63f0220
.word 0xa94167b8
.word 0x910003bf
.word 0xa8c77bfd
.word 0xd65f03c0

Lme_8f:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ObjCRuntime_Trampolines_DErrorCallback_wrapper_aot_native_object_intptr_intptr
wrapper_managed_to_native_ObjCRuntime_Trampolines_DErrorCallback_wrapper_aot_native_object_intptr_intptr:
.loc 1 1 0
.word 0xa9b37bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf9002bbe
.word 0xa905d3b3
.word 0xa906dbb5
.word 0xa907e3b7
.word 0xa908ebb9
.word 0xa909f3bb
.word 0xf90057bd
.word 0x910003f1
.word 0xf9005bb1
.word 0xf9000ba0
.word 0xf9000fa1
.word 0xf90013a2

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1192]
.word 0xf90017b0
.word 0xf9400a11
.word 0xf9001bb1
.word 0xf9005fbf
.word 0xf90063bf
.word 0x390323bf

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #32]
bl _pthread_getspecific
.word 0x91004016
.word 0x910103a0
.word 0xf94002c1
.word 0xf90023a1
.word 0xf90002c0
.word 0xf94017b1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220
.word 0x390323bf
.word 0xf94017b1
.word 0xf940c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fa0
.word 0xf94013a1
.word 0xf9400ba2
.word 0xf9400043
.word 0x3940a864
.word 0xeb1f009f
.word 0x10000011
.word 0x54000761
.word 0xf9400063
.word 0xf9400063

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x4, [x16, #1200]
.word 0xeb04007f
.word 0x10000011
.word 0x54000661
.word 0x91004043
.word 0xf9400842
.word 0xd63f0040
.word 0xf94017b1
.word 0xf9412231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xb9400000
.word 0x34000260
.word 0xf94017b1
.word 0xf9414631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9415631
.word 0xb4000051
.word 0xd63f0220
bl _p_72
.word 0xaa0003f5
.word 0xaa1503e0
.word 0xaa1503e1
.word 0xaa0003f4
.word 0xb4000095
.word 0xaa1403e0
.word 0xaa1403e0
bl _p_12
.word 0xaa1403e0
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9419e31
.word 0xb4000051
.word 0xd63f0220
.word 0x910103a0
.word 0xf94023a0
.word 0xf90002c0
.word 0xf94017b1
.word 0xf941ba31
.word 0xb4000051
.word 0xd63f0220
.word 0xa94657b4
.word 0xf9403bb6
.word 0x910003bf
.word 0xa8cd7bfd
.word 0xd65f03c0
.word 0xd2804380
.word 0xaa1103e1
bl _p_64

Lme_90:
.text
	.align 4
	.no_dead_strip wrapper_delegate_invoke__Module_invoke_bound_void_object_intptr_intptr_intptr_intptr
wrapper_delegate_invoke__Module_invoke_bound_void_object_intptr_intptr_intptr_intptr:
.loc 1 1 0
.word 0xa9b77bfd
.word 0x910003fd
.word 0xa90153b3
.word 0xa9025bb5
.word 0xa90363b7
.word 0xa9046bb9
.word 0xaa0003f8
.word 0xaa0103f9
.word 0xaa0203fa

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1208]
.word 0xf9002bb0
.word 0xf9400a11
.word 0xf9002fb1
.word 0xd2800017
.word 0xd2800016
.word 0xd2800015
.word 0xd2800014
.word 0xd2800013
.word 0xf9402bb1
.word 0xf9405e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9407e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xb9400000
.word 0x34000240
.word 0xf9402bb1
.word 0xf940a231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220
bl _p_72
.word 0xf90037a0
.word 0xf94037a1
.word 0xf94037a0
.word 0xf9003ba1
.word 0xb4000060
.word 0xf9403ba0
bl _p_12
.word 0xf9403ba0
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf940f631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
.word 0x9101a300
.word 0xf9403700
.word 0xaa0003f5
.word 0xf9402bb1
.word 0xf9411a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1503e0
.word 0xb5000455
.word 0xf9402bb1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1803e0
.word 0x91008300
.word 0xf9401300
.word 0xaa0003f3
.word 0xf9402bb1
.word 0xf9415631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1303e0
.word 0xaa1903e0
.word 0xaa1a03e0
.word 0xaa1803e0
.word 0xaa1803e0
.word 0x9100e300
.word 0xf9401f00
.word 0xaa1803e0
.word 0xaa1803e0
.word 0x91004300
.word 0xf9400b03
.word 0xaa1303e0
.word 0xaa1903e1
.word 0xaa1a03e2
.word 0xd63f0060
.word 0xf9402bb1
.word 0xf941a231
.word 0xb4000051
.word 0xd63f0220
.word 0x14000046
.word 0xf9402bb1
.word 0xf941b631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1503e0
.word 0xb9801aa0
.word 0xaa0003f6
.word 0xf9402bb1
.word 0xf941d231
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800017
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf941f631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1503e0
.word 0xaa1703e0
.word 0x93407ee0
.word 0xb9801aa1
.word 0xeb00003f
.word 0x10000011
.word 0x540006c9
.word 0xd37df000
.word 0x8b0002a0
.word 0x91008000
.word 0xf9400000
.word 0xaa0003f4
.word 0xf9402bb1
.word 0xf9423631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1403e0
.word 0xf90043a0
.word 0xaa1903e0
.word 0xaa1a03e0
.word 0xaa1403e0
.word 0xaa1903e1
.word 0xaa1a03e2
.word 0xf9400e90
.word 0xd63f0200
.word 0xf94043a0
.word 0xf9402bb1
.word 0xf9426e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9427e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0x110006e0
.word 0xaa0003f7
.word 0xf9402bb1
.word 0xf9429a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xaa1603e0
.word 0x6b1602ff
.word 0x54fff98b
.word 0xf9402bb1
.word 0xf942ba31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf942ca31
.word 0xb4000051
.word 0xd63f0220
.word 0xa94153b3
.word 0xa9425bb5
.word 0xa94363b7
.word 0xa9446bb9
.word 0x910003bf
.word 0xa8c97bfd
.word 0xd65f03c0
.word 0xd28042c0
.word 0xaa1103e1
bl _p_64

Lme_91:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_intptr_intptr
wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_intptr_intptr:
.loc 1 1 0
.word 0xa9b37bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf90027be
.word 0xa90553b3
.word 0xa9065bb5
.word 0xa90763b7
.word 0xa9086bb9
.word 0xa90973bb
.word 0xf90053bd
.word 0x910003f1
.word 0xf90057b1
.word 0xf9000ba0
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1216]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xf9005bbf
.word 0xf9005fbf
.word 0x390303bf
.word 0xd2800017

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #32]
bl _pthread_getspecific
.word 0x91004016
.word 0x9100e3a0
.word 0xf94002c1
.word 0xf9001fa1
.word 0xf90002c0
.word 0xf94013b1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220
.word 0x390303bf
.word 0xf94013b1
.word 0xf940c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
bl _p_75
.word 0xaa0003f7
.word 0xf94013b1
.word 0xf940e631
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xb9400000
.word 0x34000260
.word 0xf94013b1
.word 0xf9410a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9411a31
.word 0xb4000051
.word 0xd63f0220
bl _p_72
.word 0xaa0003f5
.word 0xaa1503e0
.word 0xaa1503e1
.word 0xaa0003f4
.word 0xb4000095
.word 0xaa1403e0
.word 0xaa1403e0
bl _p_12
.word 0xaa1403e0
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9416231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0x9100e3a0
.word 0xf9401fa0
.word 0xf90002c0
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9419231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xf94013b1
.word 0xf941a631
.word 0xb4000051
.word 0xd63f0220
.word 0xa945d7b4
.word 0xa946dfb6
.word 0x910003bf
.word 0xa8cd7bfd
.word 0xd65f03c0

Lme_92:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_intptr_intptr
wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_intptr_intptr:
.loc 1 1 0
.word 0xa9b37bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf90027be
.word 0xa90553b3
.word 0xa9065bb5
.word 0xa90763b7
.word 0xa9086bb9
.word 0xa90973bb
.word 0xf90053bd
.word 0x910003f1
.word 0xf90057b1
.word 0xf9000ba0
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1224]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xf9005bbf
.word 0xf9005fbf
.word 0x390303bf
.word 0xd2800017

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #32]
bl _pthread_getspecific
.word 0x91004016
.word 0x9100e3a0
.word 0xf94002c1
.word 0xf9001fa1
.word 0xf90002c0
.word 0xf94013b1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220
.word 0x390303bf
.word 0xf94013b1
.word 0xf940c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
bl _p_76
.word 0xaa0003f7
.word 0xf94013b1
.word 0xf940e631
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xb9400000
.word 0x34000260
.word 0xf94013b1
.word 0xf9410a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9411a31
.word 0xb4000051
.word 0xd63f0220
bl _p_72
.word 0xaa0003f5
.word 0xaa1503e0
.word 0xaa1503e1
.word 0xaa0003f4
.word 0xb4000095
.word 0xaa1403e0
.word 0xaa1403e0
bl _p_12
.word 0xaa1403e0
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9416231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0x9100e3a0
.word 0xf9401fa0
.word 0xf90002c0
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9419231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xf94013b1
.word 0xf941a631
.word 0xb4000051
.word 0xd63f0220
.word 0xa945d7b4
.word 0xa946dfb6
.word 0x910003bf
.word 0xa8cd7bfd
.word 0xd65f03c0

Lme_93:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_intptr_intptr_intptr
wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_intptr_intptr_intptr:
.loc 1 1 0
.word 0xa9b37bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf9002bbe
.word 0xa905d3b3
.word 0xa906dbb5
.word 0xa907e3b7
.word 0xa908ebb9
.word 0xa909f3bb
.word 0xf90057bd
.word 0x910003f1
.word 0xf9005bb1
.word 0xf9000ba0
.word 0xf9000fa1
.word 0xf90013a2

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1232]
.word 0xf90017b0
.word 0xf9400a11
.word 0xf9001bb1
.word 0xf9005fbf
.word 0xf90063bf
.word 0x390323bf
.word 0xd2800016

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #32]
bl _pthread_getspecific
.word 0x91004015
.word 0x910103a0
.word 0xf94002a1
.word 0xf90023a1
.word 0xf90002a0
.word 0xf94017b1
.word 0xf9409631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf940b631
.word 0xb4000051
.word 0xd63f0220
.word 0x390323bf
.word 0xf94017b1
.word 0xf940ca31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
.word 0xf94013a2
bl _p_77
.word 0xaa0003f6
.word 0xf94017b1
.word 0xf940ee31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xb9400000
.word 0x34000260
.word 0xf94017b1
.word 0xf9411231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9412231
.word 0xb4000051
.word 0xd63f0220
bl _p_72
.word 0xaa0003f4
.word 0xaa1403e0
.word 0xaa1403e1
.word 0xaa0003f3
.word 0xb4000094
.word 0xaa1303e0
.word 0xaa1303e0
bl _p_12
.word 0xaa1303e0
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9416a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0x910103a0
.word 0xf94023a0
.word 0xf90002a0
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9419a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0xf94017b1
.word 0xf941ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xa945d3b3
.word 0xa946dbb5
.word 0x910003bf
.word 0xa8cd7bfd
.word 0xd65f03c0

Lme_94:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_IntPtr_intptr_intptr_intptr
wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_IntPtr_intptr_intptr_intptr:
.loc 1 1 0
.word 0xa9b37bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf9002bbe
.word 0xa905d3b3
.word 0xa906dbb5
.word 0xa907e3b7
.word 0xa908ebb9
.word 0xa909f3bb
.word 0xf90057bd
.word 0x910003f1
.word 0xf9005bb1
.word 0xf9000ba0
.word 0xf9000fa1
.word 0xf90013a2

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1240]
.word 0xf90017b0
.word 0xf9400a11
.word 0xf9001bb1
.word 0xf9005fbf
.word 0xf90063bf
.word 0x390323bf
.word 0xd2800016

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #32]
bl _pthread_getspecific
.word 0x91004015
.word 0x910103a0
.word 0xf94002a1
.word 0xf90023a1
.word 0xf90002a0
.word 0xf94017b1
.word 0xf9409631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf940b631
.word 0xb4000051
.word 0xd63f0220
.word 0x390323bf
.word 0xf94017b1
.word 0xf940ca31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
.word 0xf94013a2
bl _p_78
.word 0xaa0003f6
.word 0xf94017b1
.word 0xf940ee31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xb9400000
.word 0x34000260
.word 0xf94017b1
.word 0xf9411231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9412231
.word 0xb4000051
.word 0xd63f0220
bl _p_72
.word 0xaa0003f4
.word 0xaa1403e0
.word 0xaa1403e1
.word 0xaa0003f3
.word 0xb4000094
.word 0xaa1303e0
.word 0xaa1303e0
bl _p_12
.word 0xaa1303e0
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9416a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0x910103a0
.word 0xf94023a0
.word 0xf90002a0
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9419a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0xf94017b1
.word 0xf941ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xa945d3b3
.word 0xa946dbb5
.word 0x910003bf
.word 0xa8cd7bfd
.word 0xd65f03c0

Lme_95:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr
wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr:
.loc 1 1 0
.word 0xa9b17bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf90033be
.word 0xa906d3b3
.word 0xa907dbb5
.word 0xa908e3b7
.word 0xa909ebb9
.word 0xa90af3bb
.word 0xf9005fbd
.word 0x910003f1
.word 0xf90063b1
.word 0xf9000ba0
.word 0xf9000fa1
.word 0xf90013a2
.word 0xf90017a3
.word 0xf9001ba4

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1248]
.word 0xf9001fb0
.word 0xf9400a11
.word 0xf90023b1
.word 0xf90067bf
.word 0xf9006bbf
.word 0x390363bf
.word 0xd2800014

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #32]
bl _pthread_getspecific
.word 0x91004013
.word 0x910143a0
.word 0xf9400261
.word 0xf9002ba1
.word 0xf9000260
.word 0xf9401fb1
.word 0xf9409e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0x390363bf
.word 0xf9401fb1
.word 0xf940d231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
.word 0xf94013a2
.word 0xf94017a3
.word 0xf9401ba4
bl _p_79
.word 0xaa0003f4
.word 0xf9401fb1
.word 0xf940fe31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xb9400000
.word 0x34000240
.word 0xf9401fb1
.word 0xf9412231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
bl _p_72
.word 0xf90073a0
.word 0xf94073a1
.word 0xf94073a0
.word 0xf90077a1
.word 0xb4000060
.word 0xf94077a0
bl _p_12
.word 0xf94077a0
.word 0xf94023b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9417631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1403e0
.word 0x910143a0
.word 0xf9402ba0
.word 0xf9000260
.word 0xf94023b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf941a631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1403e0
.word 0xf9401fb1
.word 0xf941ba31
.word 0xb4000051
.word 0xd63f0220
.word 0xa946d3b3
.word 0x910003bf
.word 0xa8cf7bfd
.word 0xd65f03c0

Lme_96:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr
wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr:
.loc 1 1 0
.word 0xa9b17bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf90033be
.word 0xa906d3b3
.word 0xa907dbb5
.word 0xa908e3b7
.word 0xa909ebb9
.word 0xa90af3bb
.word 0xf9005fbd
.word 0x910003f1
.word 0xf90063b1
.word 0xf9000ba0
.word 0xf9000fa1
.word 0xf90013a2
.word 0xf90017a3
.word 0xf9001ba4

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1256]
.word 0xf9001fb0
.word 0xf9400a11
.word 0xf90023b1
.word 0xf90067bf
.word 0xf9006bbf
.word 0x390363bf
.word 0xd2800014

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #32]
bl _pthread_getspecific
.word 0x91004013
.word 0x910143a0
.word 0xf9400261
.word 0xf9002ba1
.word 0xf9000260
.word 0xf9401fb1
.word 0xf9409e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0x390363bf
.word 0xf9401fb1
.word 0xf940d231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
.word 0xf94013a2
.word 0xf94017a3
.word 0xf9401ba4
bl _p_80
.word 0xaa0003f4
.word 0xf9401fb1
.word 0xf940fe31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xb9400000
.word 0x34000240
.word 0xf9401fb1
.word 0xf9412231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
bl _p_72
.word 0xf90073a0
.word 0xf94073a1
.word 0xf94073a0
.word 0xf90077a1
.word 0xb4000060
.word 0xf94077a0
bl _p_12
.word 0xf94077a0
.word 0xf94023b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9417631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1403e0
.word 0x910143a0
.word 0xf9402ba0
.word 0xf9000260
.word 0xf94023b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf941a631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1403e0
.word 0xf9401fb1
.word 0xf941ba31
.word 0xb4000051
.word 0xd63f0220
.word 0xa946d3b3
.word 0x910003bf
.word 0xa8cf7bfd
.word 0xd65f03c0

Lme_97:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_IntPtr_intptr_intptr_intptr_intptr
wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_IntPtr_intptr_intptr_intptr_intptr:
.loc 1 1 0
.word 0xa9b27bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf9002fbe
.word 0xa90653b3
.word 0xa9075bb5
.word 0xa90863b7
.word 0xa9096bb9
.word 0xa90a73bb
.word 0xf9005bbd
.word 0x910003f1
.word 0xf9005fb1
.word 0xf9000ba0
.word 0xf9000fa1
.word 0xf90013a2
.word 0xf90017a3

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1264]
.word 0xf9001bb0
.word 0xf9400a11
.word 0xf9001fb1
.word 0xf90063bf
.word 0xf90067bf
.word 0x390343bf
.word 0xd2800015

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #32]
bl _pthread_getspecific
.word 0x91004014
.word 0x910123a0
.word 0xf9400281
.word 0xf90027a1
.word 0xf9000280
.word 0xf9401bb1
.word 0xf9409a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf940ba31
.word 0xb4000051
.word 0xd63f0220
.word 0x390343bf
.word 0xf9401bb1
.word 0xf940ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
.word 0xf94013a2
.word 0xf94017a3
bl _p_81
.word 0xaa0003f5
.word 0xf9401bb1
.word 0xf940f631
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xb9400000
.word 0x34000240
.word 0xf9401bb1
.word 0xf9411a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9412a31
.word 0xb4000051
.word 0xd63f0220
bl _p_72
.word 0xaa0003f3
.word 0xaa1303e0
.word 0xaa1303e1
.word 0xf9006fa0
.word 0xb4000073
.word 0xf9406fa0
bl _p_12
.word 0xf9406fa0
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9416e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1503e0
.word 0x910123a0
.word 0xf94027a0
.word 0xf9000280
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9419e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1503e0
.word 0xf9401bb1
.word 0xf941b231
.word 0xb4000051
.word 0xd63f0220
.word 0xa94653b3
.word 0xf9403bb5
.word 0x910003bf
.word 0xa8ce7bfd
.word 0xd65f03c0

Lme_98:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_IntPtr_IntPtr_intptr_intptr_intptr_intptr
wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_IntPtr_IntPtr_intptr_intptr_intptr_intptr:
.loc 1 1 0
.word 0xa9b27bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf9002fbe
.word 0xa90653b3
.word 0xa9075bb5
.word 0xa90863b7
.word 0xa9096bb9
.word 0xa90a73bb
.word 0xf9005bbd
.word 0x910003f1
.word 0xf9005fb1
.word 0xf9000ba0
.word 0xf9000fa1
.word 0xf90013a2
.word 0xf90017a3

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1272]
.word 0xf9001bb0
.word 0xf9400a11
.word 0xf9001fb1
.word 0xf90063bf
.word 0xf90067bf
.word 0x390343bf
.word 0xd2800015

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #32]
bl _pthread_getspecific
.word 0x91004014
.word 0x910123a0
.word 0xf9400281
.word 0xf90027a1
.word 0xf9000280
.word 0xf9401bb1
.word 0xf9409a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf940ba31
.word 0xb4000051
.word 0xd63f0220
.word 0x390343bf
.word 0xf9401bb1
.word 0xf940ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
.word 0xf94013a2
.word 0xf94017a3
bl _p_82
.word 0xaa0003f5
.word 0xf9401bb1
.word 0xf940f631
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xb9400000
.word 0x34000240
.word 0xf9401bb1
.word 0xf9411a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9412a31
.word 0xb4000051
.word 0xd63f0220
bl _p_72
.word 0xaa0003f3
.word 0xaa1303e0
.word 0xaa1303e1
.word 0xf9006fa0
.word 0xb4000073
.word 0xf9406fa0
bl _p_12
.word 0xf9406fa0
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9416e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1503e0
.word 0x910123a0
.word 0xf94027a0
.word 0xf9000280
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9419e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1503e0
.word 0xf9401bb1
.word 0xf941b231
.word 0xb4000051
.word 0xd63f0220
.word 0xa94653b3
.word 0xf9403bb5
.word 0x910003bf
.word 0xa8ce7bfd
.word 0xd65f03c0

Lme_99:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_intptr_intptr_intptr
wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_intptr_intptr_intptr:
.loc 1 1 0
.word 0xa9b37bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf9002bbe
.word 0xa905d3b3
.word 0xa906dbb5
.word 0xa907e3b7
.word 0xa908ebb9
.word 0xa909f3bb
.word 0xf90057bd
.word 0x910003f1
.word 0xf9005bb1
.word 0xf9000ba0
.word 0xf9000fa1
.word 0xf90013a2

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1280]
.word 0xf90017b0
.word 0xf9400a11
.word 0xf9001bb1
.word 0xf9005fbf
.word 0xf90063bf
.word 0x390323bf

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #32]
bl _pthread_getspecific
.word 0x91004016
.word 0x910103a0
.word 0xf94002c1
.word 0xf90023a1
.word 0xf90002c0
.word 0xf94017b1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220
.word 0x390323bf
.word 0xf94017b1
.word 0xf940c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
.word 0xf94013a2
bl _p_83
.word 0xf94017b1
.word 0xf940e631
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xb9400000
.word 0x34000260
.word 0xf94017b1
.word 0xf9410a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9411a31
.word 0xb4000051
.word 0xd63f0220
bl _p_72
.word 0xaa0003f5
.word 0xaa1503e0
.word 0xaa1503e1
.word 0xaa0003f4
.word 0xb4000095
.word 0xaa1403e0
.word 0xaa1403e0
bl _p_12
.word 0xaa1403e0
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9416231
.word 0xb4000051
.word 0xd63f0220
.word 0x910103a0
.word 0xf94023a0
.word 0xf90002c0
.word 0xf94017b1
.word 0xf9417e31
.word 0xb4000051
.word 0xd63f0220
.word 0xa94657b4
.word 0xf9403bb6
.word 0x910003bf
.word 0xa8cd7bfd
.word 0xd65f03c0

Lme_9a:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_intptr_intptr_intptr
wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_intptr_intptr_intptr:
.loc 1 1 0
.word 0xa9b37bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf9002bbe
.word 0xa905d3b3
.word 0xa906dbb5
.word 0xa907e3b7
.word 0xa908ebb9
.word 0xa909f3bb
.word 0xf90057bd
.word 0x910003f1
.word 0xf9005bb1
.word 0xf9000ba0
.word 0xf9000fa1
.word 0xf90013a2

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1288]
.word 0xf90017b0
.word 0xf9400a11
.word 0xf9001bb1
.word 0xf9005fbf
.word 0xf90063bf
.word 0x390323bf

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #32]
bl _pthread_getspecific
.word 0x91004016
.word 0x910103a0
.word 0xf94002c1
.word 0xf90023a1
.word 0xf90002c0
.word 0xf94017b1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220
.word 0x390323bf
.word 0xf94017b1
.word 0xf940c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
.word 0xf94013a2
bl _p_84
.word 0xf94017b1
.word 0xf940e631
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xb9400000
.word 0x34000260
.word 0xf94017b1
.word 0xf9410a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9411a31
.word 0xb4000051
.word 0xd63f0220
bl _p_72
.word 0xaa0003f5
.word 0xaa1503e0
.word 0xaa1503e1
.word 0xaa0003f4
.word 0xb4000095
.word 0xaa1403e0
.word 0xaa1403e0
bl _p_12
.word 0xaa1403e0
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9416231
.word 0xb4000051
.word 0xd63f0220
.word 0x910103a0
.word 0xf94023a0
.word 0xf90002c0
.word 0xf94017b1
.word 0xf9417e31
.word 0xb4000051
.word 0xd63f0220
.word 0xa94657b4
.word 0xf9403bb6
.word 0x910003bf
.word 0xa8cd7bfd
.word 0xd65f03c0

Lme_9b:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_intptr_intptr
wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_intptr_intptr:
.loc 1 1 0
.word 0xa9b37bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf90027be
.word 0xa90553b3
.word 0xa9065bb5
.word 0xa90763b7
.word 0xa9086bb9
.word 0xa90973bb
.word 0xf90053bd
.word 0x910003f1
.word 0xf90057b1
.word 0xf9000ba0
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1296]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xf9005bbf
.word 0xf9005fbf
.word 0x390303bf
.word 0xd2800017

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #32]
bl _pthread_getspecific
.word 0x91004016
.word 0x9100e3a0
.word 0xf94002c1
.word 0xf9001fa1
.word 0xf90002c0
.word 0xf94013b1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220
.word 0x390303bf
.word 0xf94013b1
.word 0xf940c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
bl _p_85
.word 0x53001c00
.word 0xaa0003f7
.word 0xf94013b1
.word 0xf940ea31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xb9400000
.word 0x34000260
.word 0xf94013b1
.word 0xf9410e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9411e31
.word 0xb4000051
.word 0xd63f0220
bl _p_72
.word 0xaa0003f5
.word 0xaa1503e0
.word 0xaa1503e1
.word 0xaa0003f4
.word 0xb4000095
.word 0xaa1403e0
.word 0xaa1403e0
bl _p_12
.word 0xaa1403e0
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9416631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0x9100e3a0
.word 0xf9401fa0
.word 0xf90002c0
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9419631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xf94013b1
.word 0xf941aa31
.word 0xb4000051
.word 0xd63f0220
.word 0xa945d7b4
.word 0xa946dfb6
.word 0x910003bf
.word 0xa8cd7bfd
.word 0xd65f03c0

Lme_9c:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_intptr_intptr
wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_intptr_intptr:
.loc 1 1 0
.word 0xa9b37bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf90027be
.word 0xa90553b3
.word 0xa9065bb5
.word 0xa90763b7
.word 0xa9086bb9
.word 0xa90973bb
.word 0xf90053bd
.word 0x910003f1
.word 0xf90057b1
.word 0xf9000ba0
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1304]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xf9005bbf
.word 0xf9005fbf
.word 0x390303bf
.word 0xd2800017

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #32]
bl _pthread_getspecific
.word 0x91004016
.word 0x9100e3a0
.word 0xf94002c1
.word 0xf9001fa1
.word 0xf90002c0
.word 0xf94013b1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220
.word 0x390303bf
.word 0xf94013b1
.word 0xf940c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
bl _p_86
.word 0x53001c00
.word 0xaa0003f7
.word 0xf94013b1
.word 0xf940ea31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xb9400000
.word 0x34000260
.word 0xf94013b1
.word 0xf9410e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9411e31
.word 0xb4000051
.word 0xd63f0220
bl _p_72
.word 0xaa0003f5
.word 0xaa1503e0
.word 0xaa1503e1
.word 0xaa0003f4
.word 0xb4000095
.word 0xaa1403e0
.word 0xaa1403e0
bl _p_12
.word 0xaa1403e0
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9416631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0x9100e3a0
.word 0xf9401fa0
.word 0xf90002c0
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9419631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xf94013b1
.word 0xf941aa31
.word 0xb4000051
.word 0xd63f0220
.word 0xa945d7b4
.word 0xa946dfb6
.word 0x910003bf
.word 0xa8cd7bfd
.word 0xd65f03c0

Lme_9d:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_bool_intptr_intptr_bool
wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_bool_intptr_intptr_bool:
.loc 1 1 0
.word 0xa9b37bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf9002bbe
.word 0xa905d3b3
.word 0xa906dbb5
.word 0xa907e3b7
.word 0xa908ebb9
.word 0xa909f3bb
.word 0xf90057bd
.word 0x910003f1
.word 0xf9005bb1
.word 0xf9000ba0
.word 0xf9000fa1
.word 0xf90013a2

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1312]
.word 0xf90017b0
.word 0xf9400a11
.word 0xf9001bb1
.word 0xf9005fbf
.word 0xf90063bf
.word 0x390323bf
.word 0xd2800016

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #32]
bl _pthread_getspecific
.word 0x91004015
.word 0x910103a0
.word 0xf94002a1
.word 0xf90023a1
.word 0xf90002a0
.word 0xf94017b1
.word 0xf9409631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf940b631
.word 0xb4000051
.word 0xd63f0220
.word 0x390323bf
.word 0xf94017b1
.word 0xf940ca31
.word 0xb4000051
.word 0xd63f0220
.word 0x394083a0
.word 0x340000c0
.word 0xf94017b1
.word 0xf940e231
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800036
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
.word 0xaa1603e2
.word 0xaa1603e2
bl _p_87
.word 0xf94017b1
.word 0xf9412a31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xb9400000
.word 0x34000260
.word 0xf94017b1
.word 0xf9414e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9415e31
.word 0xb4000051
.word 0xd63f0220
bl _p_72
.word 0xaa0003f4
.word 0xaa1403e0
.word 0xaa1403e1
.word 0xaa0003f3
.word 0xb4000094
.word 0xaa1303e0
.word 0xaa1303e0
bl _p_12
.word 0xaa1303e0
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf941a631
.word 0xb4000051
.word 0xd63f0220
.word 0x910103a0
.word 0xf94023a0
.word 0xf90002a0
.word 0xf94017b1
.word 0xf941c231
.word 0xb4000051
.word 0xd63f0220
.word 0xa945d3b3
.word 0xa946dbb5
.word 0x910003bf
.word 0xa8cd7bfd
.word 0xd65f03c0

Lme_9e:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_bool_intptr_intptr_bool
wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_bool_intptr_intptr_bool:
.loc 1 1 0
.word 0xa9b37bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf9002bbe
.word 0xa905d3b3
.word 0xa906dbb5
.word 0xa907e3b7
.word 0xa908ebb9
.word 0xa909f3bb
.word 0xf90057bd
.word 0x910003f1
.word 0xf9005bb1
.word 0xf9000ba0
.word 0xf9000fa1
.word 0xf90013a2

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1320]
.word 0xf90017b0
.word 0xf9400a11
.word 0xf9001bb1
.word 0xf9005fbf
.word 0xf90063bf
.word 0x390323bf
.word 0xd2800016

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #32]
bl _pthread_getspecific
.word 0x91004015
.word 0x910103a0
.word 0xf94002a1
.word 0xf90023a1
.word 0xf90002a0
.word 0xf94017b1
.word 0xf9409631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf940b631
.word 0xb4000051
.word 0xd63f0220
.word 0x390323bf
.word 0xf94017b1
.word 0xf940ca31
.word 0xb4000051
.word 0xd63f0220
.word 0x394083a0
.word 0x340000c0
.word 0xf94017b1
.word 0xf940e231
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800036
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
.word 0xaa1603e2
.word 0xaa1603e2
bl _p_88
.word 0xf94017b1
.word 0xf9412a31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xb9400000
.word 0x34000260
.word 0xf94017b1
.word 0xf9414e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9415e31
.word 0xb4000051
.word 0xd63f0220
bl _p_72
.word 0xaa0003f4
.word 0xaa1403e0
.word 0xaa1403e1
.word 0xaa0003f3
.word 0xb4000094
.word 0xaa1303e0
.word 0xaa1303e0
bl _p_12
.word 0xaa1303e0
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf941a631
.word 0xb4000051
.word 0xd63f0220
.word 0x910103a0
.word 0xf94023a0
.word 0xf90002a0
.word 0xf94017b1
.word 0xf941c231
.word 0xb4000051
.word 0xd63f0220
.word 0xa945d3b3
.word 0xa946dbb5
.word 0x910003bf
.word 0xa8cd7bfd
.word 0xd65f03c0

Lme_9f:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_intptr_intptr_intptr_intptr
wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_intptr_intptr_intptr_intptr:
.loc 1 1 0
.word 0xa9b27bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf9002fbe
.word 0xa90653b3
.word 0xa9075bb5
.word 0xa90863b7
.word 0xa9096bb9
.word 0xa90a73bb
.word 0xf9005bbd
.word 0x910003f1
.word 0xf9005fb1
.word 0xf9000ba0
.word 0xf9000fa1
.word 0xf90013a2
.word 0xf90017a3

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1328]
.word 0xf9001bb0
.word 0xf9400a11
.word 0xf9001fb1
.word 0xf90063bf
.word 0xf90067bf
.word 0x390343bf

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #32]
bl _pthread_getspecific
.word 0x91004015
.word 0x910123a0
.word 0xf94002a1
.word 0xf90027a1
.word 0xf90002a0
.word 0xf9401bb1
.word 0xf9409631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf940b631
.word 0xb4000051
.word 0xd63f0220
.word 0x390343bf
.word 0xf9401bb1
.word 0xf940ca31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
.word 0xf94013a2
.word 0xf94017a3
bl _p_89
.word 0xf9401bb1
.word 0xf940ee31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xb9400000
.word 0x34000260
.word 0xf9401bb1
.word 0xf9411231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9412231
.word 0xb4000051
.word 0xd63f0220
bl _p_72
.word 0xaa0003f4
.word 0xaa1403e0
.word 0xaa1403e1
.word 0xaa0003f3
.word 0xb4000094
.word 0xaa1303e0
.word 0xaa1303e0
bl _p_12
.word 0xaa1303e0
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9416a31
.word 0xb4000051
.word 0xd63f0220
.word 0x910123a0
.word 0xf94027a0
.word 0xf90002a0
.word 0xf9401bb1
.word 0xf9418631
.word 0xb4000051
.word 0xd63f0220
.word 0xa94653b3
.word 0xf9403bb5
.word 0x910003bf
.word 0xa8ce7bfd
.word 0xd65f03c0

Lme_a0:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_intptr_intptr_intptr_intptr
wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_intptr_intptr_intptr_intptr:
.loc 1 1 0
.word 0xa9b27bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf9002fbe
.word 0xa90653b3
.word 0xa9075bb5
.word 0xa90863b7
.word 0xa9096bb9
.word 0xa90a73bb
.word 0xf9005bbd
.word 0x910003f1
.word 0xf9005fb1
.word 0xf9000ba0
.word 0xf9000fa1
.word 0xf90013a2
.word 0xf90017a3

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1336]
.word 0xf9001bb0
.word 0xf9400a11
.word 0xf9001fb1
.word 0xf90063bf
.word 0xf90067bf
.word 0x390343bf

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #32]
bl _pthread_getspecific
.word 0x91004015
.word 0x910123a0
.word 0xf94002a1
.word 0xf90027a1
.word 0xf90002a0
.word 0xf9401bb1
.word 0xf9409631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf940b631
.word 0xb4000051
.word 0xd63f0220
.word 0x390343bf
.word 0xf9401bb1
.word 0xf940ca31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
.word 0xf94013a2
.word 0xf94017a3
bl _p_90
.word 0xf9401bb1
.word 0xf940ee31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xb9400000
.word 0x34000260
.word 0xf9401bb1
.word 0xf9411231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9412231
.word 0xb4000051
.word 0xd63f0220
bl _p_72
.word 0xaa0003f4
.word 0xaa1403e0
.word 0xaa1403e1
.word 0xaa0003f3
.word 0xb4000094
.word 0xaa1303e0
.word 0xaa1303e0
bl _p_12
.word 0xaa1303e0
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9416a31
.word 0xb4000051
.word 0xd63f0220
.word 0x910123a0
.word 0xf94027a0
.word 0xf90002a0
.word 0xf9401bb1
.word 0xf9418631
.word 0xb4000051
.word 0xd63f0220
.word 0xa94653b3
.word 0xf9403bb5
.word 0x910003bf
.word 0xa8ce7bfd
.word 0xd65f03c0

Lme_a1:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr
wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr:
.loc 1 1 0
.word 0xa9b07bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf90037be
.word 0xa90753b3
.word 0xa9085bb5
.word 0xa90963b7
.word 0xa90a6bb9
.word 0xa90b73bb
.word 0xf90063bd
.word 0x910003f1
.word 0xf90067b1
.word 0xf9000ba0
.word 0xf9000fa1
.word 0xf90013a2
.word 0xf90017a3
.word 0xf9001ba4
.word 0xf9001fa5

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1344]
.word 0xf90023b0
.word 0xf9400a11
.word 0xf90027b1
.word 0xf9006bbf
.word 0xf9006fbf
.word 0x390383bf

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #32]
bl _pthread_getspecific
.word 0x91004013
.word 0x910163a0
.word 0xf9400261
.word 0xf9002fa1
.word 0xf9000260
.word 0xf94023b1
.word 0xf9409e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0x390383bf
.word 0xf94023b1
.word 0xf940d231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
.word 0xf94013a2
.word 0xf94017a3
.word 0xf9401ba4
.word 0xf9401fa5
bl _p_91
.word 0xf94023b1
.word 0xf940fe31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xb9400000
.word 0x34000240
.word 0xf94023b1
.word 0xf9412231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
bl _p_72
.word 0xf90077a0
.word 0xf94077a1
.word 0xf94077a0
.word 0xf9007ba1
.word 0xb4000060
.word 0xf9407ba0
bl _p_12
.word 0xf9407ba0
.word 0xf94027b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9417631
.word 0xb4000051
.word 0xd63f0220
.word 0x910163a0
.word 0xf9402fa0
.word 0xf9000260
.word 0xf94023b1
.word 0xf9419231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403bb3
.word 0x910003bf
.word 0xa8d07bfd
.word 0xd65f03c0

Lme_a2:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr
wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr:
.loc 1 1 0
.word 0xa9b07bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf90037be
.word 0xa90753b3
.word 0xa9085bb5
.word 0xa90963b7
.word 0xa90a6bb9
.word 0xa90b73bb
.word 0xf90063bd
.word 0x910003f1
.word 0xf90067b1
.word 0xf9000ba0
.word 0xf9000fa1
.word 0xf90013a2
.word 0xf90017a3
.word 0xf9001ba4
.word 0xf9001fa5

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1352]
.word 0xf90023b0
.word 0xf9400a11
.word 0xf90027b1
.word 0xf9006bbf
.word 0xf9006fbf
.word 0x390383bf

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #32]
bl _pthread_getspecific
.word 0x91004013
.word 0x910163a0
.word 0xf9400261
.word 0xf9002fa1
.word 0xf9000260
.word 0xf94023b1
.word 0xf9409e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0x390383bf
.word 0xf94023b1
.word 0xf940d231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
.word 0xf94013a2
.word 0xf94017a3
.word 0xf9401ba4
.word 0xf9401fa5
bl _p_92
.word 0xf94023b1
.word 0xf940fe31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xb9400000
.word 0x34000240
.word 0xf94023b1
.word 0xf9412231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
bl _p_72
.word 0xf90077a0
.word 0xf94077a1
.word 0xf94077a0
.word 0xf9007ba1
.word 0xb4000060
.word 0xf9407ba0
bl _p_12
.word 0xf9407ba0
.word 0xf94027b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9417631
.word 0xb4000051
.word 0xd63f0220
.word 0x910163a0
.word 0xf9402fa0
.word 0xf9000260
.word 0xf94023b1
.word 0xf9419231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403bb3
.word 0x910003bf
.word 0xa8d07bfd
.word 0xd65f03c0

Lme_a3:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_intptr_intptr
wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_intptr_intptr:
.loc 1 1 0
.word 0xa9b37bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf90027be
.word 0xa90553b3
.word 0xa9065bb5
.word 0xa90763b7
.word 0xa9086bb9
.word 0xa90973bb
.word 0xf90053bd
.word 0x910003f1
.word 0xf90057b1
.word 0xf9000ba0
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1360]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xf9005bbf
.word 0xf9005fbf
.word 0x390303bf

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #32]
bl _pthread_getspecific
.word 0x91004017
.word 0x9100e3a0
.word 0xf94002e1
.word 0xf9001fa1
.word 0xf90002e0
.word 0xf94013b1
.word 0xf9408e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf940ae31
.word 0xb4000051
.word 0xd63f0220
.word 0x390303bf
.word 0xf94013b1
.word 0xf940c231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
bl _p_93
.word 0xf94013b1
.word 0xf940de31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xb9400000
.word 0x34000260
.word 0xf94013b1
.word 0xf9410231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9411231
.word 0xb4000051
.word 0xd63f0220
bl _p_72
.word 0xaa0003f6
.word 0xaa1603e0
.word 0xaa1603e1
.word 0xaa0003f5
.word 0xb4000096
.word 0xaa1503e0
.word 0xaa1503e0
bl _p_12
.word 0xaa1503e0
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9415a31
.word 0xb4000051
.word 0xd63f0220
.word 0x9100e3a0
.word 0xf9401fa0
.word 0xf90002e0
.word 0xf94013b1
.word 0xf9417631
.word 0xb4000051
.word 0xd63f0220
.word 0xa9465bb5
.word 0xf9403bb7
.word 0x910003bf
.word 0xa8cd7bfd
.word 0xd65f03c0

Lme_a4:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_intptr_intptr
wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_intptr_intptr:
.loc 1 1 0
.word 0xa9b37bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf90027be
.word 0xa90553b3
.word 0xa9065bb5
.word 0xa90763b7
.word 0xa9086bb9
.word 0xa90973bb
.word 0xf90053bd
.word 0x910003f1
.word 0xf90057b1
.word 0xf9000ba0
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1368]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xf9005bbf
.word 0xf9005fbf
.word 0x390303bf

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #32]
bl _pthread_getspecific
.word 0x91004017
.word 0x9100e3a0
.word 0xf94002e1
.word 0xf9001fa1
.word 0xf90002e0
.word 0xf94013b1
.word 0xf9408e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf940ae31
.word 0xb4000051
.word 0xd63f0220
.word 0x390303bf
.word 0xf94013b1
.word 0xf940c231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
bl _p_94
.word 0xf94013b1
.word 0xf940de31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xb9400000
.word 0x34000260
.word 0xf94013b1
.word 0xf9410231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9411231
.word 0xb4000051
.word 0xd63f0220
bl _p_72
.word 0xaa0003f6
.word 0xaa1603e0
.word 0xaa1603e1
.word 0xaa0003f5
.word 0xb4000096
.word 0xaa1503e0
.word 0xaa1503e0
bl _p_12
.word 0xaa1503e0
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9415a31
.word 0xb4000051
.word 0xd63f0220
.word 0x9100e3a0
.word 0xf9401fa0
.word 0xf90002e0
.word 0xf94013b1
.word 0xf9417631
.word 0xb4000051
.word 0xd63f0220
.word 0xa9465bb5
.word 0xf9403bb7
.word 0x910003bf
.word 0xa8cd7bfd
.word 0xd65f03c0

Lme_a5:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr
wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr:
.loc 1 1 0
.word 0xa9b17bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf90033be
.word 0xa906d3b3
.word 0xa907dbb5
.word 0xa908e3b7
.word 0xa909ebb9
.word 0xa90af3bb
.word 0xf9005fbd
.word 0x910003f1
.word 0xf90063b1
.word 0xf9000ba0
.word 0xf9000fa1
.word 0xf90013a2
.word 0xf90017a3
.word 0xf9001ba4

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1376]
.word 0xf9001fb0
.word 0xf9400a11
.word 0xf90023b1
.word 0xf90067bf
.word 0xf9006bbf
.word 0x390363bf

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #32]
bl _pthread_getspecific
.word 0x91004014
.word 0x910143a0
.word 0xf9400281
.word 0xf9002ba1
.word 0xf9000280
.word 0xf9401fb1
.word 0xf9409a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf940ba31
.word 0xb4000051
.word 0xd63f0220
.word 0x390363bf
.word 0xf9401fb1
.word 0xf940ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
.word 0xf94013a2
.word 0xf94017a3
.word 0xf9401ba4
bl _p_95
.word 0xf9401fb1
.word 0xf940f631
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xb9400000
.word 0x34000240
.word 0xf9401fb1
.word 0xf9411a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9412a31
.word 0xb4000051
.word 0xd63f0220
bl _p_72
.word 0xaa0003f3
.word 0xaa1303e0
.word 0xaa1303e1
.word 0xf90073a0
.word 0xb4000073
.word 0xf94073a0
bl _p_12
.word 0xf94073a0
.word 0xf94023b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9416e31
.word 0xb4000051
.word 0xd63f0220
.word 0x910143a0
.word 0xf9402ba0
.word 0xf9000280
.word 0xf9401fb1
.word 0xf9418a31
.word 0xb4000051
.word 0xd63f0220
.word 0xa946d3b3
.word 0x910003bf
.word 0xa8cf7bfd
.word 0xd65f03c0

Lme_a6:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr
wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr:
.loc 1 1 0
.word 0xa9b17bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf90033be
.word 0xa906d3b3
.word 0xa907dbb5
.word 0xa908e3b7
.word 0xa909ebb9
.word 0xa90af3bb
.word 0xf9005fbd
.word 0x910003f1
.word 0xf90063b1
.word 0xf9000ba0
.word 0xf9000fa1
.word 0xf90013a2
.word 0xf90017a3
.word 0xf9001ba4

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1384]
.word 0xf9001fb0
.word 0xf9400a11
.word 0xf90023b1
.word 0xf90067bf
.word 0xf9006bbf
.word 0x390363bf

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #32]
bl _pthread_getspecific
.word 0x91004014
.word 0x910143a0
.word 0xf9400281
.word 0xf9002ba1
.word 0xf9000280
.word 0xf9401fb1
.word 0xf9409a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf940ba31
.word 0xb4000051
.word 0xd63f0220
.word 0x390363bf
.word 0xf9401fb1
.word 0xf940ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
.word 0xf94013a2
.word 0xf94017a3
.word 0xf9401ba4
bl _p_96
.word 0xf9401fb1
.word 0xf940f631
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xb9400000
.word 0x34000240
.word 0xf9401fb1
.word 0xf9411a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9412a31
.word 0xb4000051
.word 0xd63f0220
bl _p_72
.word 0xaa0003f3
.word 0xaa1303e0
.word 0xaa1303e1
.word 0xf90073a0
.word 0xb4000073
.word 0xf94073a0
bl _p_12
.word 0xf94073a0
.word 0xf94023b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9416e31
.word 0xb4000051
.word 0xd63f0220
.word 0x910143a0
.word 0xf9402ba0
.word 0xf9000280
.word 0xf9401fb1
.word 0xf9418a31
.word 0xb4000051
.word 0xd63f0220
.word 0xa946d3b3
.word 0x910003bf
.word 0xa8cf7bfd
.word 0xd65f03c0

Lme_a7:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr
wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr:
.loc 1 1 0
.word 0xa9b07bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf9003fbe
.word 0xa90853b3
.word 0xa9095bb5
.word 0xa90a63b7
.word 0xa90b6bb9
.word 0xa90c73bb
.word 0xf9006bbd
.word 0x910003f1
.word 0xf9006fb1
.word 0xf9000ba0
.word 0xf9000fa1
.word 0xf90013a2
.word 0xf90017a3
.word 0xf9001ba4
.word 0xf9001fa5
.word 0xf90023a6
.word 0xf90027a7

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1392]
.word 0xf9002bb0
.word 0xf9400a11
.word 0xf9002fb1
.word 0xf90073bf
.word 0xf90077bf
.word 0x3903c3bf

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #32]
bl _pthread_getspecific
.word 0x91004019
.word 0x9101a3a0
.word 0xf9400321
.word 0xf90037a1
.word 0xf9000320
.word 0xf9402bb1
.word 0xf940a631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf940c631
.word 0xb4000051
.word 0xd63f0220
.word 0x3903c3bf
.word 0xf9402bb1
.word 0xf940da31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
.word 0xf94013a2
.word 0xf94017a3
.word 0xf9401ba4
.word 0xf9401fa5
.word 0xf94023a6
.word 0xf94027a7
bl _p_97
.word 0xf9402bb1
.word 0xf9410e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xb9400000
.word 0x34000260
.word 0xf9402bb1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9414231
.word 0xb4000051
.word 0xd63f0220
bl _p_72
.word 0xaa0003f8
.word 0xaa1803e0
.word 0xaa1803e1
.word 0xaa0003f7
.word 0xb4000098
.word 0xaa1703e0
.word 0xaa1703e0
bl _p_12
.word 0xaa1703e0
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9418a31
.word 0xb4000051
.word 0xd63f0220
.word 0x9101a3a0
.word 0xf94037a0
.word 0xf9000320
.word 0xf9402bb1
.word 0xf941a631
.word 0xb4000051
.word 0xd63f0220
.word 0xa94a63b7
.word 0xf9405bb9
.word 0x910003bf
.word 0xa8d07bfd
.word 0xd65f03c0

Lme_a8:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr
wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr:
.loc 1 1 0
.word 0xa9b07bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf9003fbe
.word 0xa90853b3
.word 0xa9095bb5
.word 0xa90a63b7
.word 0xa90b6bb9
.word 0xa90c73bb
.word 0xf9006bbd
.word 0x910003f1
.word 0xf9006fb1
.word 0xf9000ba0
.word 0xf9000fa1
.word 0xf90013a2
.word 0xf90017a3
.word 0xf9001ba4
.word 0xf9001fa5
.word 0xf90023a6
.word 0xf90027a7

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1400]
.word 0xf9002bb0
.word 0xf9400a11
.word 0xf9002fb1
.word 0xf90073bf
.word 0xf90077bf
.word 0x3903c3bf

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #32]
bl _pthread_getspecific
.word 0x91004019
.word 0x9101a3a0
.word 0xf9400321
.word 0xf90037a1
.word 0xf9000320
.word 0xf9402bb1
.word 0xf940a631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf940c631
.word 0xb4000051
.word 0xd63f0220
.word 0x3903c3bf
.word 0xf9402bb1
.word 0xf940da31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
.word 0xf94013a2
.word 0xf94017a3
.word 0xf9401ba4
.word 0xf9401fa5
.word 0xf94023a6
.word 0xf94027a7
bl _p_98
.word 0xf9402bb1
.word 0xf9410e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xb9400000
.word 0x34000260
.word 0xf9402bb1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9414231
.word 0xb4000051
.word 0xd63f0220
bl _p_72
.word 0xaa0003f8
.word 0xaa1803e0
.word 0xaa1803e1
.word 0xaa0003f7
.word 0xb4000098
.word 0xaa1703e0
.word 0xaa1703e0
bl _p_12
.word 0xaa1703e0
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9418a31
.word 0xb4000051
.word 0xd63f0220
.word 0x9101a3a0
.word 0xf94037a0
.word 0xf9000320
.word 0xf9402bb1
.word 0xf941a631
.word 0xb4000051
.word 0xd63f0220
.word 0xa94a63b7
.word 0xf9405bb9
.word 0x910003bf
.word 0xa8d07bfd
.word 0xd65f03c0

Lme_a9:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_
wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_:
.loc 1 1 0
.word 0xa9b17bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf90033be
.word 0xa906d3b3
.word 0xa907dbb5
.word 0xa908e3b7
.word 0xa909ebb9
.word 0xa90af3bb
.word 0xf9005fbd
.word 0x910003f1
.word 0xf90063b1
.word 0xf9000ba0
.word 0xf9000fa1
.word 0xf90013a2
.word 0xf90017a3
.word 0xf9001ba4

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1408]
.word 0xf9001fb0
.word 0xf9400a11
.word 0xf90023b1
.word 0xf90067bf
.word 0xf9006bbf
.word 0x390363bf
.word 0xd2800014

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #32]
bl _pthread_getspecific
.word 0x91004013
.word 0x910143a0
.word 0xf9400261
.word 0xf9002ba1
.word 0xf9000260
.word 0xf9401fb1
.word 0xf9409e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0x390363bf
.word 0xf9401fb1
.word 0xf940d231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
.word 0xf94013a2
.word 0xf94017a3
.word 0xf9401ba4
bl _p_99
.word 0x53001c00
.word 0xaa0003f4
.word 0xf9401fb1
.word 0xf9410231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xb9400000
.word 0x34000240
.word 0xf9401fb1
.word 0xf9412631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9413631
.word 0xb4000051
.word 0xd63f0220
bl _p_72
.word 0xf90073a0
.word 0xf94073a1
.word 0xf94073a0
.word 0xf90077a1
.word 0xb4000060
.word 0xf94077a0
bl _p_12
.word 0xf94077a0
.word 0xf94023b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9417a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1403e0
.word 0x910143a0
.word 0xf9402ba0
.word 0xf9000260
.word 0xf94023b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf941aa31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1403e0
.word 0xf9401fb1
.word 0xf941be31
.word 0xb4000051
.word 0xd63f0220
.word 0xa946d3b3
.word 0x910003bf
.word 0xa8cf7bfd
.word 0xd65f03c0

Lme_aa:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_
wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_:
.loc 1 1 0
.word 0xa9b17bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf90033be
.word 0xa906d3b3
.word 0xa907dbb5
.word 0xa908e3b7
.word 0xa909ebb9
.word 0xa90af3bb
.word 0xf9005fbd
.word 0x910003f1
.word 0xf90063b1
.word 0xf9000ba0
.word 0xf9000fa1
.word 0xf90013a2
.word 0xf90017a3
.word 0xf9001ba4

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1416]
.word 0xf9001fb0
.word 0xf9400a11
.word 0xf90023b1
.word 0xf90067bf
.word 0xf9006bbf
.word 0x390363bf
.word 0xd2800014

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #32]
bl _pthread_getspecific
.word 0x91004013
.word 0x910143a0
.word 0xf9400261
.word 0xf9002ba1
.word 0xf9000260
.word 0xf9401fb1
.word 0xf9409e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0x390363bf
.word 0xf9401fb1
.word 0xf940d231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
.word 0xf94013a2
.word 0xf94017a3
.word 0xf9401ba4
bl _p_100
.word 0x53001c00
.word 0xaa0003f4
.word 0xf9401fb1
.word 0xf9410231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xb9400000
.word 0x34000240
.word 0xf9401fb1
.word 0xf9412631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9413631
.word 0xb4000051
.word 0xd63f0220
bl _p_72
.word 0xf90073a0
.word 0xf94073a1
.word 0xf94073a0
.word 0xf90077a1
.word 0xb4000060
.word 0xf94077a0
bl _p_12
.word 0xf94077a0
.word 0xf94023b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9417a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1403e0
.word 0x910143a0
.word 0xf9402ba0
.word 0xf9000260
.word 0xf94023b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf941aa31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1403e0
.word 0xf9401fb1
.word 0xf941be31
.word 0xb4000051
.word 0xd63f0220
.word 0xa946d3b3
.word 0x910003bf
.word 0xa8cf7bfd
.word 0xd65f03c0

Lme_ab:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_
wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_:
.loc 1 1 0
.word 0xa9b07bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf9003fbe
.word 0xa90853b3
.word 0xa9095bb5
.word 0xa90a63b7
.word 0xa90b6bb9
.word 0xa90c73bb
.word 0xf9006bbd
.word 0x910003f1
.word 0xf9006fb1
.word 0xf9000ba0
.word 0xf9000fa1
.word 0xf90013a2
.word 0xf90017a3
.word 0xf9001ba4
.word 0xf9001fa5
.word 0xf90023a6
.word 0xf90027a7

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1424]
.word 0xf9002bb0
.word 0xf9400a11
.word 0xf9002fb1
.word 0xf90073bf
.word 0xf90077bf
.word 0x3903c3bf
.word 0xd2800019

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #32]
bl _pthread_getspecific
.word 0x91004018
.word 0x9101a3a0
.word 0xf9400301
.word 0xf90037a1
.word 0xf9000300
.word 0xf9402bb1
.word 0xf940aa31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf940ca31
.word 0xb4000051
.word 0xd63f0220
.word 0x3903c3bf
.word 0xf9402bb1
.word 0xf940de31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
.word 0xf94013a2
.word 0xf94017a3
.word 0xf9401ba4
.word 0xf9401fa5
.word 0xf94023a6
.word 0xf94027a7
bl _p_101
.word 0x53001c00
.word 0xaa0003f9
.word 0xf9402bb1
.word 0xf9411a31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xb9400000
.word 0x34000260
.word 0xf9402bb1
.word 0xf9413e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9414e31
.word 0xb4000051
.word 0xd63f0220
bl _p_72
.word 0xaa0003f7
.word 0xaa1703e0
.word 0xaa1703e1
.word 0xaa0003f6
.word 0xb4000097
.word 0xaa1603e0
.word 0xaa1603e0
bl _p_12
.word 0xaa1603e0
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9419631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0x9101a3a0
.word 0xf94037a0
.word 0xf9000300
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf941c631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xf9402bb1
.word 0xf941da31
.word 0xb4000051
.word 0xd63f0220
.word 0xa949dfb6
.word 0xa94ae7b8
.word 0x910003bf
.word 0xa8d07bfd
.word 0xd65f03c0

Lme_ac:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_
wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_:
.loc 1 1 0
.word 0xa9b07bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf9003fbe
.word 0xa90853b3
.word 0xa9095bb5
.word 0xa90a63b7
.word 0xa90b6bb9
.word 0xa90c73bb
.word 0xf9006bbd
.word 0x910003f1
.word 0xf9006fb1
.word 0xf9000ba0
.word 0xf9000fa1
.word 0xf90013a2
.word 0xf90017a3
.word 0xf9001ba4
.word 0xf9001fa5
.word 0xf90023a6
.word 0xf90027a7

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1432]
.word 0xf9002bb0
.word 0xf9400a11
.word 0xf9002fb1
.word 0xf90073bf
.word 0xf90077bf
.word 0x3903c3bf
.word 0xd2800019

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #32]
bl _pthread_getspecific
.word 0x91004018
.word 0x9101a3a0
.word 0xf9400301
.word 0xf90037a1
.word 0xf9000300
.word 0xf9402bb1
.word 0xf940aa31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf940ca31
.word 0xb4000051
.word 0xd63f0220
.word 0x3903c3bf
.word 0xf9402bb1
.word 0xf940de31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
.word 0xf94013a2
.word 0xf94017a3
.word 0xf9401ba4
.word 0xf9401fa5
.word 0xf94023a6
.word 0xf94027a7
bl _p_102
.word 0x53001c00
.word 0xaa0003f9
.word 0xf9402bb1
.word 0xf9411a31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xb9400000
.word 0x34000260
.word 0xf9402bb1
.word 0xf9413e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9414e31
.word 0xb4000051
.word 0xd63f0220
bl _p_72
.word 0xaa0003f7
.word 0xaa1703e0
.word 0xaa1703e1
.word 0xaa0003f6
.word 0xb4000097
.word 0xaa1603e0
.word 0xaa1603e0
bl _p_12
.word 0xaa1603e0
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9419631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0x9101a3a0
.word 0xf94037a0
.word 0xf9000300
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf941c631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xf9402bb1
.word 0xf941da31
.word 0xb4000051
.word 0xd63f0220
.word 0xa949dfb6
.word 0xa94ae7b8
.word 0x910003bf
.word 0xa8d07bfd
.word 0xd65f03c0

Lme_ad:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_ref_IntPtr_intptr_intptr_intptr_
wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_ref_IntPtr_intptr_intptr_intptr_:
.loc 1 1 0
.word 0xa9b37bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf9002bbe
.word 0xa905d3b3
.word 0xa906dbb5
.word 0xa907e3b7
.word 0xa908ebb9
.word 0xa909f3bb
.word 0xf90057bd
.word 0x910003f1
.word 0xf9005bb1
.word 0xf9000ba0
.word 0xf9000fa1
.word 0xf90013a2

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1440]
.word 0xf90017b0
.word 0xf9400a11
.word 0xf9001bb1
.word 0xf9005fbf
.word 0xf90063bf
.word 0x390323bf
.word 0xd2800016

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #32]
bl _pthread_getspecific
.word 0x91004015
.word 0x910103a0
.word 0xf94002a1
.word 0xf90023a1
.word 0xf90002a0
.word 0xf94017b1
.word 0xf9409631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf940b631
.word 0xb4000051
.word 0xd63f0220
.word 0x390323bf
.word 0xf94017b1
.word 0xf940ca31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
.word 0xf94013a2
bl _p_103
.word 0x53001c00
.word 0xaa0003f6
.word 0xf94017b1
.word 0xf940f231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xb9400000
.word 0x34000260
.word 0xf94017b1
.word 0xf9411631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9412631
.word 0xb4000051
.word 0xd63f0220
bl _p_72
.word 0xaa0003f4
.word 0xaa1403e0
.word 0xaa1403e1
.word 0xaa0003f3
.word 0xb4000094
.word 0xaa1303e0
.word 0xaa1303e0
bl _p_12
.word 0xaa1303e0
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9416e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0x910103a0
.word 0xf94023a0
.word 0xf90002a0
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9419e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0xf94017b1
.word 0xf941b231
.word 0xb4000051
.word 0xd63f0220
.word 0xa945d3b3
.word 0xa946dbb5
.word 0x910003bf
.word 0xa8cd7bfd
.word 0xd65f03c0

Lme_ae:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_ref_IntPtr_intptr_intptr_intptr_
wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_ref_IntPtr_intptr_intptr_intptr_:
.loc 1 1 0
.word 0xa9b37bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf9002bbe
.word 0xa905d3b3
.word 0xa906dbb5
.word 0xa907e3b7
.word 0xa908ebb9
.word 0xa909f3bb
.word 0xf90057bd
.word 0x910003f1
.word 0xf9005bb1
.word 0xf9000ba0
.word 0xf9000fa1
.word 0xf90013a2

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1448]
.word 0xf90017b0
.word 0xf9400a11
.word 0xf9001bb1
.word 0xf9005fbf
.word 0xf90063bf
.word 0x390323bf
.word 0xd2800016

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #32]
bl _pthread_getspecific
.word 0x91004015
.word 0x910103a0
.word 0xf94002a1
.word 0xf90023a1
.word 0xf90002a0
.word 0xf94017b1
.word 0xf9409631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf940b631
.word 0xb4000051
.word 0xd63f0220
.word 0x390323bf
.word 0xf94017b1
.word 0xf940ca31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
.word 0xf94013a2
bl _p_104
.word 0x53001c00
.word 0xaa0003f6
.word 0xf94017b1
.word 0xf940f231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xb9400000
.word 0x34000260
.word 0xf94017b1
.word 0xf9411631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9412631
.word 0xb4000051
.word 0xd63f0220
bl _p_72
.word 0xaa0003f4
.word 0xaa1403e0
.word 0xaa1403e1
.word 0xaa0003f3
.word 0xb4000094
.word 0xaa1303e0
.word 0xaa1303e0
bl _p_12
.word 0xaa1303e0
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9416e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0x910103a0
.word 0xf94023a0
.word 0xf90002a0
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9419e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0xf94017b1
.word 0xf941b231
.word 0xb4000051
.word 0xd63f0220
.word 0xa945d3b3
.word 0xa946dbb5
.word 0x910003bf
.word 0xa8cd7bfd
.word 0xd65f03c0

Lme_af:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_
wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_:
.loc 1 1 0
.word 0xa9b27bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf9002fbe
.word 0xa90653b3
.word 0xa9075bb5
.word 0xa90863b7
.word 0xa9096bb9
.word 0xa90a73bb
.word 0xf9005bbd
.word 0x910003f1
.word 0xf9005fb1
.word 0xf9000ba0
.word 0xf9000fa1
.word 0xf90013a2
.word 0xf90017a3

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1456]
.word 0xf9001bb0
.word 0xf9400a11
.word 0xf9001fb1
.word 0xf90063bf
.word 0xf90067bf
.word 0x390343bf
.word 0xd2800015

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #32]
bl _pthread_getspecific
.word 0x91004014
.word 0x910123a0
.word 0xf9400281
.word 0xf90027a1
.word 0xf9000280
.word 0xf9401bb1
.word 0xf9409a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf940ba31
.word 0xb4000051
.word 0xd63f0220
.word 0x390343bf
.word 0xf9401bb1
.word 0xf940ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
.word 0xf94013a2
.word 0xf94017a3
bl _p_105
.word 0x53001c00
.word 0xaa0003f5
.word 0xf9401bb1
.word 0xf940fa31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xb9400000
.word 0x34000240
.word 0xf9401bb1
.word 0xf9411e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9412e31
.word 0xb4000051
.word 0xd63f0220
bl _p_72
.word 0xaa0003f3
.word 0xaa1303e0
.word 0xaa1303e1
.word 0xf9006fa0
.word 0xb4000073
.word 0xf9406fa0
bl _p_12
.word 0xf9406fa0
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9417231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1503e0
.word 0x910123a0
.word 0xf94027a0
.word 0xf9000280
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf941a231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1503e0
.word 0xf9401bb1
.word 0xf941b631
.word 0xb4000051
.word 0xd63f0220
.word 0xa94653b3
.word 0xf9403bb5
.word 0x910003bf
.word 0xa8ce7bfd
.word 0xd65f03c0

Lme_b0:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_
wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_:
.loc 1 1 0
.word 0xa9b27bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf9002fbe
.word 0xa90653b3
.word 0xa9075bb5
.word 0xa90863b7
.word 0xa9096bb9
.word 0xa90a73bb
.word 0xf9005bbd
.word 0x910003f1
.word 0xf9005fb1
.word 0xf9000ba0
.word 0xf9000fa1
.word 0xf90013a2
.word 0xf90017a3

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1464]
.word 0xf9001bb0
.word 0xf9400a11
.word 0xf9001fb1
.word 0xf90063bf
.word 0xf90067bf
.word 0x390343bf
.word 0xd2800015

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #32]
bl _pthread_getspecific
.word 0x91004014
.word 0x910123a0
.word 0xf9400281
.word 0xf90027a1
.word 0xf9000280
.word 0xf9401bb1
.word 0xf9409a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf940ba31
.word 0xb4000051
.word 0xd63f0220
.word 0x390343bf
.word 0xf9401bb1
.word 0xf940ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
.word 0xf94013a2
.word 0xf94017a3
bl _p_106
.word 0x53001c00
.word 0xaa0003f5
.word 0xf9401bb1
.word 0xf940fa31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xb9400000
.word 0x34000240
.word 0xf9401bb1
.word 0xf9411e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9412e31
.word 0xb4000051
.word 0xd63f0220
bl _p_72
.word 0xaa0003f3
.word 0xaa1303e0
.word 0xaa1303e1
.word 0xf9006fa0
.word 0xb4000073
.word 0xf9406fa0
bl _p_12
.word 0xf9406fa0
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9417231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1503e0
.word 0x910123a0
.word 0xf94027a0
.word 0xf9000280
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf941a231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1503e0
.word 0xf9401bb1
.word 0xf941b631
.word 0xb4000051
.word 0xd63f0220
.word 0xa94653b3
.word 0xf9403bb5
.word 0x910003bf
.word 0xa8ce7bfd
.word 0xd65f03c0

Lme_b1:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_int_objc_msgSend_intptr_intptr
wrapper_managed_to_native_ApiDefinition_Messaging_int_objc_msgSend_intptr_intptr:
.loc 1 1 0
.word 0xa9b37bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf90027be
.word 0xa90553b3
.word 0xa9065bb5
.word 0xa90763b7
.word 0xa9086bb9
.word 0xa90973bb
.word 0xf90053bd
.word 0x910003f1
.word 0xf90057b1
.word 0xf9000ba0
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1472]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xf9005bbf
.word 0xf9005fbf
.word 0x390303bf
.word 0xd2800017

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #32]
bl _pthread_getspecific
.word 0x91004016
.word 0x9100e3a0
.word 0xf94002c1
.word 0xf9001fa1
.word 0xf90002c0
.word 0xf94013b1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220
.word 0x390303bf
.word 0xf94013b1
.word 0xf940c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
bl _p_107
.word 0x93407c00
.word 0xaa0003f7
.word 0xf94013b1
.word 0xf940ea31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xb9400000
.word 0x34000260
.word 0xf94013b1
.word 0xf9410e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9411e31
.word 0xb4000051
.word 0xd63f0220
bl _p_72
.word 0xaa0003f5
.word 0xaa1503e0
.word 0xaa1503e1
.word 0xaa0003f4
.word 0xb4000095
.word 0xaa1403e0
.word 0xaa1403e0
bl _p_12
.word 0xaa1403e0
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9416631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0x9100e3a0
.word 0xf9401fa0
.word 0xf90002c0
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9419631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xf94013b1
.word 0xf941aa31
.word 0xb4000051
.word 0xd63f0220
.word 0xa945d7b4
.word 0xa946dfb6
.word 0x910003bf
.word 0xa8cd7bfd
.word 0xd65f03c0

Lme_b2:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_int_objc_msgSendSuper_intptr_intptr
wrapper_managed_to_native_ApiDefinition_Messaging_int_objc_msgSendSuper_intptr_intptr:
.loc 1 1 0
.word 0xa9b37bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf90027be
.word 0xa90553b3
.word 0xa9065bb5
.word 0xa90763b7
.word 0xa9086bb9
.word 0xa90973bb
.word 0xf90053bd
.word 0x910003f1
.word 0xf90057b1
.word 0xf9000ba0
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1480]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xf9005bbf
.word 0xf9005fbf
.word 0x390303bf
.word 0xd2800017

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #32]
bl _pthread_getspecific
.word 0x91004016
.word 0x9100e3a0
.word 0xf94002c1
.word 0xf9001fa1
.word 0xf90002c0
.word 0xf94013b1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220
.word 0x390303bf
.word 0xf94013b1
.word 0xf940c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
bl _p_108
.word 0x93407c00
.word 0xaa0003f7
.word 0xf94013b1
.word 0xf940ea31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xb9400000
.word 0x34000260
.word 0xf94013b1
.word 0xf9410e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9411e31
.word 0xb4000051
.word 0xd63f0220
bl _p_72
.word 0xaa0003f5
.word 0xaa1503e0
.word 0xaa1503e1
.word 0xaa0003f4
.word 0xb4000095
.word 0xaa1403e0
.word 0xaa1403e0
bl _p_12
.word 0xaa1403e0
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9416631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0x9100e3a0
.word 0xf9401fa0
.word 0xf90002c0
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9419631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xf94013b1
.word 0xf941aa31
.word 0xb4000051
.word 0xd63f0220
.word 0xa945d7b4
.word 0xa946dfb6
.word 0x910003bf
.word 0xa8cd7bfd
.word 0xd65f03c0

Lme_b3:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_int_intptr_intptr_int
wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_int_intptr_intptr_int:
.loc 1 1 0
.word 0xa9b37bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf9002bbe
.word 0xa905d3b3
.word 0xa906dbb5
.word 0xa907e3b7
.word 0xa908ebb9
.word 0xa909f3bb
.word 0xf90057bd
.word 0x910003f1
.word 0xf9005bb1
.word 0xf9000ba0
.word 0xf9000fa1
.word 0xf90013a2

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1488]
.word 0xf90017b0
.word 0xf9400a11
.word 0xf9001bb1
.word 0xf9005fbf
.word 0xf90063bf
.word 0x390323bf

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #32]
bl _pthread_getspecific
.word 0x91004016
.word 0x910103a0
.word 0xf94002c1
.word 0xf90023a1
.word 0xf90002c0
.word 0xf94017b1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220
.word 0x390323bf
.word 0xf94017b1
.word 0xf940c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
.word 0xb98023a2
bl _p_109
.word 0xf94017b1
.word 0xf940e631
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xb9400000
.word 0x34000260
.word 0xf94017b1
.word 0xf9410a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9411a31
.word 0xb4000051
.word 0xd63f0220
bl _p_72
.word 0xaa0003f5
.word 0xaa1503e0
.word 0xaa1503e1
.word 0xaa0003f4
.word 0xb4000095
.word 0xaa1403e0
.word 0xaa1403e0
bl _p_12
.word 0xaa1403e0
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9416231
.word 0xb4000051
.word 0xd63f0220
.word 0x910103a0
.word 0xf94023a0
.word 0xf90002c0
.word 0xf94017b1
.word 0xf9417e31
.word 0xb4000051
.word 0xd63f0220
.word 0xa94657b4
.word 0xf9403bb6
.word 0x910003bf
.word 0xa8cd7bfd
.word 0xd65f03c0

Lme_b4:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_int_intptr_intptr_int
wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_int_intptr_intptr_int:
.loc 1 1 0
.word 0xa9b37bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf9002bbe
.word 0xa905d3b3
.word 0xa906dbb5
.word 0xa907e3b7
.word 0xa908ebb9
.word 0xa909f3bb
.word 0xf90057bd
.word 0x910003f1
.word 0xf9005bb1
.word 0xf9000ba0
.word 0xf9000fa1
.word 0xf90013a2

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1496]
.word 0xf90017b0
.word 0xf9400a11
.word 0xf9001bb1
.word 0xf9005fbf
.word 0xf90063bf
.word 0x390323bf

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #32]
bl _pthread_getspecific
.word 0x91004016
.word 0x910103a0
.word 0xf94002c1
.word 0xf90023a1
.word 0xf90002c0
.word 0xf94017b1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220
.word 0x390323bf
.word 0xf94017b1
.word 0xf940c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
.word 0xb98023a2
bl _p_110
.word 0xf94017b1
.word 0xf940e631
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xb9400000
.word 0x34000260
.word 0xf94017b1
.word 0xf9410a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9411a31
.word 0xb4000051
.word 0xd63f0220
bl _p_72
.word 0xaa0003f5
.word 0xaa1503e0
.word 0xaa1503e1
.word 0xaa0003f4
.word 0xb4000095
.word 0xaa1403e0
.word 0xaa1403e0
bl _p_12
.word 0xaa1403e0
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9416231
.word 0xb4000051
.word 0xd63f0220
.word 0x910103a0
.word 0xf94023a0
.word 0xf90002c0
.word 0xf94017b1
.word 0xf9417e31
.word 0xb4000051
.word 0xd63f0220
.word 0xa94657b4
.word 0xf9403bb6
.word 0x910003bf
.word 0xa8cd7bfd
.word 0xd65f03c0

Lme_b5:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ObjCRuntime_Trampolines__Block_copy_intptr
wrapper_managed_to_native_ObjCRuntime_Trampolines__Block_copy_intptr:
.loc 1 1 0
.word 0xa9b47bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf90023be
.word 0xa904d3b3
.word 0xa905dbb5
.word 0xa906e3b7
.word 0xa907ebb9
.word 0xa908f3bb
.word 0xf9004fbd
.word 0x910003f1
.word 0xf90053b1
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1504]
.word 0xf9000fb0
.word 0xf9400a11
.word 0xf90013b1
.word 0xf90057bf
.word 0xf9005bbf
.word 0x3902e3bf
.word 0xd2800018

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #32]
bl _pthread_getspecific
.word 0x91004017
.word 0x9100c3a0
.word 0xf94002e1
.word 0xf9001ba1
.word 0xf90002e0
.word 0xf9400fb1
.word 0xf9408e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf940ae31
.word 0xb4000051
.word 0xd63f0220
.word 0x3902e3bf
.word 0xf9400fb1
.word 0xf940c231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
bl _p_111
.word 0xaa0003f8
.word 0xf9400fb1
.word 0xf940de31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xb9400000
.word 0x34000260
.word 0xf9400fb1
.word 0xf9410231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9411231
.word 0xb4000051
.word 0xd63f0220
bl _p_72
.word 0xaa0003f6
.word 0xaa1603e0
.word 0xaa1603e1
.word 0xaa0003f5
.word 0xb4000096
.word 0xaa1503e0
.word 0xaa1503e0
bl _p_12
.word 0xaa1503e0
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9415a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0x9100c3a0
.word 0xf9401ba0
.word 0xf90002e0
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9418a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xf9400fb1
.word 0xf9419e31
.word 0xb4000051
.word 0xd63f0220
.word 0xa945dbb5
.word 0xa946e3b7
.word 0x910003bf
.word 0xa8cc7bfd
.word 0xd65f03c0

Lme_b6:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ObjCRuntime_Trampolines__Block_release_intptr
wrapper_managed_to_native_ObjCRuntime_Trampolines__Block_release_intptr:
.loc 1 1 0
.word 0xa9b47bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf90023be
.word 0xa904d3b3
.word 0xa905dbb5
.word 0xa906e3b7
.word 0xa907ebb9
.word 0xa908f3bb
.word 0xf9004fbd
.word 0x910003f1
.word 0xf90053b1
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1512]
.word 0xf9000fb0
.word 0xf9400a11
.word 0xf90013b1
.word 0xf90057bf
.word 0xf9005bbf
.word 0x3902e3bf

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #32]
bl _pthread_getspecific
.word 0x91004018
.word 0x9100c3a0
.word 0xf9400301
.word 0xf9001ba1
.word 0xf9000300
.word 0xf9400fb1
.word 0xf9408a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf940aa31
.word 0xb4000051
.word 0xd63f0220
.word 0x3902e3bf
.word 0xf9400fb1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
bl _p_112
.word 0xf9400fb1
.word 0xf940d631
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xb9400000
.word 0x34000260
.word 0xf9400fb1
.word 0xf940fa31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9410a31
.word 0xb4000051
.word 0xd63f0220
bl _p_72
.word 0xaa0003f7
.word 0xaa1703e0
.word 0xaa1703e1
.word 0xaa0003f6
.word 0xb4000097
.word 0xaa1603e0
.word 0xaa1603e0
bl _p_12
.word 0xaa1603e0
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9415231
.word 0xb4000051
.word 0xd63f0220
.word 0x9100c3a0
.word 0xf9401ba0
.word 0xf9000300
.word 0xf9400fb1
.word 0xf9416e31
.word 0xb4000051
.word 0xd63f0220
.word 0xa9465fb6
.word 0xf9403bb8
.word 0x910003bf
.word 0xa8cc7bfd
.word 0xd65f03c0

Lme_b7:
.text
	.align 4
	.no_dead_strip wrapper_native_to_managed_ObjCRuntime_Trampolines_SDErrorCallback_Invoke_intptr_intptr
wrapper_native_to_managed_ObjCRuntime_Trampolines_SDErrorCallback_Invoke_intptr_intptr:
.loc 1 1 0
.word 0xa9b47bfd
.word 0x910003fd
.word 0xa9015fb6
.word 0xf90013a0
.word 0xf90017a1

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1520]
.word 0xf9001bb0
.word 0xf9400a11
.word 0xf9001fb1
.word 0xf90027bf
.word 0xf9002bbf
.word 0x390163bf
.word 0xb90063bf
.word 0xf90037bf
.word 0xf9003bbf
.word 0xf9003fbf
.word 0x390163bf
.word 0x92800000
.word 0xf2bfffe0
.word 0x92800000
.word 0xf2bfffe0
.word 0x9280001e
.word 0xf2bffffe
.word 0xb90063be
.word 0xd2800000
.word 0xf90043bf
.word 0xd2800000
.word 0xd2800000
bl _mono_jit_thread_attach
.word 0xf90043a0

adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xb9400000
.word 0x34000160
bl _p_72
.word 0xaa0003f7
.word 0xaa1703e0
.word 0xaa1703e1
.word 0xaa0003f6
.word 0xb4000097
.word 0xaa1603e0
.word 0xaa1603e0
bl _p_12
.word 0xaa1603e0
.word 0xf94013a0
.word 0xf94017a1
bl _p_113
.word 0xf9401bb1
.word 0xf940d631
.word 0xb4000051
.word 0xd63f0220
.word 0x94000012
.word 0x14000021
.word 0xf90047a0
.word 0xf94047a0
.word 0xf90037a0
.word 0xf94037a0
.word 0xd2800001
.word 0xd2800001
bl _p_114
.word 0xb90063a0
bl _p_115
.word 0xf9005ba0
.word 0xf9405ba0
.word 0xb4000060
.word 0xf9405ba0
bl _p_12
.word 0x94000002
.word 0x14000011
.word 0xf90057be
.word 0xf94043a0
bl _mono_jit_set_domain
.word 0xb94063a0
.word 0x92800001
.word 0xf2bfffe1
.word 0x92800001
.word 0xf2bfffe1
.word 0x9280001e
.word 0xf2bffffe
.word 0x6b1e001f
.word 0x54000060
.word 0xb94063a0
bl _p_116
.word 0xf94057be
.word 0xd61f03c0
.word 0xa9415fb6
.word 0x910003bf
.word 0xa8cc7bfd
.word 0xd65f03c0

Lme_b8:
.text
	.align 3
jit_code_end:

	.byte 0,0,0,0
.text
	.align 3
method_addresses:
	.no_dead_strip method_addresses
bl ApiDefinition_Messaging__ctor
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl ApiDefinition_Messaging__cctor
bl WindowsAzure_Messaging_SBConnectionString__ctor
bl WindowsAzure_Messaging_SBConnectionString__ctor_Foundation_NSObjectFlag
bl WindowsAzure_Messaging_SBConnectionString__ctor_intptr
bl WindowsAzure_Messaging_SBConnectionString_get_ClassHandle
bl WindowsAzure_Messaging_SBConnectionString_CreateByIssuer_Foundation_NSUrl_string_string
bl WindowsAzure_Messaging_SBConnectionString_CreateByKeyName_Foundation_NSUrl_string_string
bl WindowsAzure_Messaging_SBConnectionString_CreateFullAccess_Foundation_NSUrl_string
bl WindowsAzure_Messaging_SBConnectionString_CreateListenAccess_Foundation_NSUrl_string
bl WindowsAzure_Messaging_SBConnectionString__cctor
bl WindowsAzure_Messaging_SBLocalStorage__ctor
bl WindowsAzure_Messaging_SBLocalStorage__ctor_Foundation_NSObjectFlag
bl WindowsAzure_Messaging_SBLocalStorage__ctor_intptr
bl WindowsAzure_Messaging_SBLocalStorage__ctor_string
bl WindowsAzure_Messaging_SBLocalStorage_get_ClassHandle
bl WindowsAzure_Messaging_SBLocalStorage_Delete_string
bl WindowsAzure_Messaging_SBLocalStorage_DeleteAllRegistrations
bl WindowsAzure_Messaging_SBLocalStorage_GetStoredRegistrationEntry_string
bl WindowsAzure_Messaging_SBLocalStorage_RefreshFinished_string
bl WindowsAzure_Messaging_SBLocalStorage_Update_string_WindowsAzure_Messaging_SBRegistration
bl WindowsAzure_Messaging_SBLocalStorage_Update_string_string_string_string
bl WindowsAzure_Messaging_SBLocalStorage_Update_string
bl WindowsAzure_Messaging_SBLocalStorage_Update_WindowsAzure_Messaging_SBRegistration
bl WindowsAzure_Messaging_SBLocalStorage_get_DeviceToken
bl WindowsAzure_Messaging_SBLocalStorage_set_DeviceToken_string
bl WindowsAzure_Messaging_SBLocalStorage_get_IsRefreshNeeded
bl WindowsAzure_Messaging_SBLocalStorage_set_IsRefreshNeeded_bool
bl WindowsAzure_Messaging_SBLocalStorage__cctor
bl WindowsAzure_Messaging_SBNotificationHub__ctor
bl WindowsAzure_Messaging_SBNotificationHub__ctor_Foundation_NSObjectFlag
bl WindowsAzure_Messaging_SBNotificationHub__ctor_intptr
bl WindowsAzure_Messaging_SBNotificationHub__ctor_string_string
bl WindowsAzure_Messaging_SBNotificationHub_get_ClassHandle
bl WindowsAzure_Messaging_SBNotificationHub_RegisterNative_Foundation_NSData_Foundation_NSSet_Foundation_NSError_
bl WindowsAzure_Messaging_SBNotificationHub_RegisterNativeAsync_Foundation_NSData_Foundation_NSSet_WindowsAzure_Messaging_ErrorCallback
bl WindowsAzure_Messaging_SBNotificationHub_RegisterTemplate_Foundation_NSData_string_string_string_Foundation_NSSet_Foundation_NSError_
bl WindowsAzure_Messaging_SBNotificationHub_RegisterTemplateAsync_Foundation_NSData_string_string_string_Foundation_NSSet_WindowsAzure_Messaging_ErrorCallback
bl WindowsAzure_Messaging_SBNotificationHub_UnregisterAll_Foundation_NSData_Foundation_NSError_
bl WindowsAzure_Messaging_SBNotificationHub_UnregisterAllAsync_Foundation_NSData_WindowsAzure_Messaging_ErrorCallback
bl WindowsAzure_Messaging_SBNotificationHub_UnregisterNative_Foundation_NSError_
bl WindowsAzure_Messaging_SBNotificationHub_UnregisterNativeAsync_WindowsAzure_Messaging_ErrorCallback
bl WindowsAzure_Messaging_SBNotificationHub_UnregisterTemplate_string_Foundation_NSError_
bl WindowsAzure_Messaging_SBNotificationHub_UnregisterTemplateAsync_string_WindowsAzure_Messaging_ErrorCallback
bl WindowsAzure_Messaging_SBNotificationHub_get_Version
bl WindowsAzure_Messaging_SBNotificationHub__cctor
bl WindowsAzure_Messaging_SBRegistration__ctor
bl WindowsAzure_Messaging_SBRegistration__ctor_Foundation_NSObjectFlag
bl WindowsAzure_Messaging_SBRegistration__ctor_intptr
bl WindowsAzure_Messaging_SBRegistration_get_ClassHandle
bl WindowsAzure_Messaging_SBRegistration_Name
bl WindowsAzure_Messaging_SBRegistration_Payload_string_Foundation_NSSet
bl WindowsAzure_Messaging_SBRegistration_get_DeviceToken
bl WindowsAzure_Messaging_SBRegistration_set_DeviceToken_string
bl WindowsAzure_Messaging_SBRegistration_get_ETag
bl WindowsAzure_Messaging_SBRegistration_set_ETag_string
bl WindowsAzure_Messaging_SBRegistration_get_ExpiresAt
bl WindowsAzure_Messaging_SBRegistration_set_ExpiresAt_Foundation_NSDate
bl WindowsAzure_Messaging_SBRegistration_get_RegistrationId
bl WindowsAzure_Messaging_SBRegistration_set_RegistrationId_string
bl WindowsAzure_Messaging_SBRegistration_get_Tags
bl WindowsAzure_Messaging_SBRegistration_set_Tags_Foundation_NSSet
bl WindowsAzure_Messaging_SBRegistration_Dispose_bool
bl WindowsAzure_Messaging_SBRegistration__cctor
bl WindowsAzure_Messaging_StoredRegistrationEntry__ctor
bl WindowsAzure_Messaging_StoredRegistrationEntry__ctor_Foundation_NSObjectFlag
bl WindowsAzure_Messaging_StoredRegistrationEntry__ctor_intptr
bl WindowsAzure_Messaging_StoredRegistrationEntry__ctor_string
bl WindowsAzure_Messaging_StoredRegistrationEntry_get_ClassHandle
bl WindowsAzure_Messaging_StoredRegistrationEntry_AsString
bl WindowsAzure_Messaging_StoredRegistrationEntry_get_ETag
bl WindowsAzure_Messaging_StoredRegistrationEntry_set_ETag_string
bl WindowsAzure_Messaging_StoredRegistrationEntry_get_RegistrationId
bl WindowsAzure_Messaging_StoredRegistrationEntry_set_RegistrationId_string
bl WindowsAzure_Messaging_StoredRegistrationEntry_get_RegistrationName
bl WindowsAzure_Messaging_StoredRegistrationEntry_set_RegistrationName_string
bl WindowsAzure_Messaging_StoredRegistrationEntry__cctor
bl WindowsAzure_Messaging_SBTokenProvider__ctor
bl WindowsAzure_Messaging_SBTokenProvider__ctor_Foundation_NSObjectFlag
bl WindowsAzure_Messaging_SBTokenProvider__ctor_intptr
bl WindowsAzure_Messaging_SBTokenProvider_get_ClassHandle
bl WindowsAzure_Messaging_SBTokenProvider_SetToken_Foundation_NSMutableUrlRequest_WindowsAzure_Messaging_ErrorCallback
bl WindowsAzure_Messaging_SBTokenProvider_SetToken_Foundation_NSMutableUrlRequest_Foundation_NSError_
bl WindowsAzure_Messaging_SBTokenProvider_get_TimeToExpireInMin
bl WindowsAzure_Messaging_SBTokenProvider_set_TimeToExpireInMin_int
bl WindowsAzure_Messaging_SBTokenProvider__cctor
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl ObjCRuntime_Trampolines_SDErrorCallback_Invoke_intptr_intptr
bl ObjCRuntime_Trampolines_SDErrorCallback__cctor
bl ObjCRuntime_Trampolines_NIDErrorCallback__ctor_ObjCRuntime_BlockLiteral_
bl ObjCRuntime_Trampolines_NIDErrorCallback_Finalize
bl ObjCRuntime_Trampolines_NIDErrorCallback_Create_intptr
bl ObjCRuntime_Trampolines_NIDErrorCallback_Invoke_Foundation_NSError
bl method_addresses
bl wrapper_delegate_invoke__Module_invoke_void_NSError_Foundation_NSError
bl wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___NSError_AsyncCallback_object_Foundation_NSError_System_AsyncCallback_object
bl wrapper_delegate_end_invoke__Module_end_invoke_void__this___IAsyncResult_System_IAsyncResult
bl wrapper_delegate_invoke__Module_invoke_void_intptr_intptr_intptr_intptr
bl wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___intptr_intptr_AsyncCallback_object_intptr_intptr_System_AsyncCallback_object
bl wrapper_managed_to_native_ObjCRuntime_Trampolines_DErrorCallback_wrapper_aot_native_object_intptr_intptr
bl wrapper_delegate_invoke__Module_invoke_bound_void_object_intptr_intptr_intptr_intptr
bl wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_intptr_intptr
bl wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_intptr_intptr
bl wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_intptr_intptr_intptr
bl wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_IntPtr_intptr_intptr_intptr
bl wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr
bl wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr
bl wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_IntPtr_intptr_intptr_intptr_intptr
bl wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_IntPtr_IntPtr_intptr_intptr_intptr_intptr
bl wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_intptr_intptr_intptr
bl wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_intptr_intptr_intptr
bl wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_intptr_intptr
bl wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_intptr_intptr
bl wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_bool_intptr_intptr_bool
bl wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_bool_intptr_intptr_bool
bl wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_intptr_intptr_intptr_intptr
bl wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_intptr_intptr_intptr_intptr
bl wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr
bl wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr
bl wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_intptr_intptr
bl wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_intptr_intptr
bl wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr
bl wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr
bl wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr
bl wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr
bl wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_
bl wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_
bl wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_
bl wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_
bl wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_ref_IntPtr_intptr_intptr_intptr_
bl wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_ref_IntPtr_intptr_intptr_intptr_
bl wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_
bl wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_
bl wrapper_managed_to_native_ApiDefinition_Messaging_int_objc_msgSend_intptr_intptr
bl wrapper_managed_to_native_ApiDefinition_Messaging_int_objc_msgSendSuper_intptr_intptr
bl wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_int_intptr_intptr_int
bl wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_int_intptr_intptr_int
bl wrapper_managed_to_native_ObjCRuntime_Trampolines__Block_copy_intptr
bl wrapper_managed_to_native_ObjCRuntime_Trampolines__Block_release_intptr
bl wrapper_native_to_managed_ObjCRuntime_Trampolines_SDErrorCallback_Invoke_intptr_intptr
method_addresses_end:

.section __TEXT, __const
	.align 3
unbox_trampolines:
unbox_trampolines_end:

	.long 0
.text
	.align 3
unbox_trampoline_addresses:

	.long 0
.section __TEXT, __const
	.align 3
unwind_info:

	.byte 13,12,31,0,68,14,48,157,6,158,5,68,13,29,13,12,31,0,68,14,64,157,8,158,7,68,13,29,16,12,31,0
	.byte 68,14,80,157,10,158,9,68,13,29,68,154,8,16,12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10,29,12
	.byte 31,0,68,14,160,1,157,20,158,19,68,13,29,68,149,18,150,17,68,151,16,152,15,68,153,14,154,13,24,12,31,0
	.byte 68,14,144,1,157,18,158,17,68,13,29,68,151,16,152,15,68,153,14,154,13,21,12,31,0,68,14,112,157,14,158,13
	.byte 68,13,29,68,152,12,153,11,68,154,10,21,12,31,0,68,14,80,157,10,158,9,68,13,29,68,152,8,153,7,68,154
	.byte 6,16,12,31,0,68,14,64,157,8,158,7,68,13,29,68,154,6,23,12,31,0,68,14,112,157,14,158,13,68,13,29
	.byte 68,151,12,152,11,68,153,10,154,9,34,12,31,0,68,14,160,1,157,20,158,19,68,13,29,68,147,18,148,17,68,149
	.byte 16,150,15,68,151,14,152,13,68,153,12,154,11,18,12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10,154,9
	.byte 18,12,31,0,68,14,80,157,10,158,9,68,13,29,68,153,8,154,7,27,12,31,0,68,14,128,1,157,16,158,15,68
	.byte 13,29,68,150,14,151,13,68,152,12,153,11,68,154,10,34,12,31,0,68,14,192,1,157,24,158,23,68,13,29,68,147
	.byte 22,148,21,68,149,20,150,19,68,151,18,152,17,68,153,16,154,15,34,12,31,0,68,14,240,1,157,30,158,29,68,13
	.byte 29,68,147,28,148,27,68,149,26,150,25,68,151,24,152,23,68,153,22,154,21,27,12,31,0,68,14,128,1,157,16,158
	.byte 15,68,13,29,68,149,14,150,13,68,151,12,152,11,68,153,10,24,12,31,0,68,14,160,1,157,20,158,19,68,13,29
	.byte 68,151,18,152,17,68,153,16,154,15,24,12,31,0,68,14,128,1,157,16,158,15,68,13,29,68,150,14,151,13,68,152
	.byte 12,153,11,22,12,31,0,68,14,144,1,157,18,158,17,68,13,29,68,152,16,153,15,68,154,14,29,12,31,0,68,14
	.byte 144,1,157,18,158,17,68,13,29,68,148,16,149,15,68,150,14,151,13,68,152,12,153,11,27,12,31,0,68,14,160,1
	.byte 157,20,158,19,68,13,29,68,150,18,151,17,68,152,16,153,15,68,154,14,13,12,31,0,68,14,80,157,10,158,9,68
	.byte 13,29,16,12,31,0,68,14,80,157,10,158,9,68,13,29,68,153,8,21,12,31,0,68,14,96,157,12,158,11,68,13
	.byte 29,68,150,10,151,9,68,152,8,13,12,31,0,68,14,96,157,12,158,11,68,13,29,26,12,31,0,68,14,96,157,12
	.byte 158,11,68,13,29,68,150,10,151,9,68,152,8,153,7,68,154,6,34,12,31,0,68,14,128,1,157,16,158,15,68,13
	.byte 29,68,147,14,148,13,68,149,12,150,11,68,151,10,152,9,68,153,8,154,7,18,12,31,0,68,14,112,157,14,158,13
	.byte 68,13,29,68,152,12,153,11,18,12,31,0,68,14,80,157,10,158,9,68,13,29,68,152,8,153,7,34,12,31,0,68
	.byte 14,144,1,157,18,158,17,68,13,29,68,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10,154,9,39,12
	.byte 31,0,68,14,208,1,157,26,158,25,68,13,29,76,147,15,148,14,68,149,13,150,12,68,151,11,152,10,68,153,9,154
	.byte 8,68,155,7,156,6,39,12,31,0,68,14,208,1,157,26,158,25,68,13,29,76,147,16,148,15,68,149,14,150,13,68
	.byte 151,12,152,11,68,153,10,154,9,68,155,8,156,7,39,12,31,0,68,14,240,1,157,30,158,29,68,13,29,76,147,17
	.byte 148,16,68,149,15,150,14,68,151,13,152,12,68,153,11,154,10,68,155,9,156,8,39,12,31,0,68,14,224,1,157,28
	.byte 158,27,68,13,29,76,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10,154,9,68,155,8,156,7,39,12
	.byte 31,0,68,14,128,2,157,32,158,31,68,13,29,76,147,18,148,17,68,149,16,150,15,68,151,14,152,13,68,153,12,154
	.byte 11,68,155,10,156,9,39,12,31,0,68,14,128,2,157,32,158,31,68,13,29,76,147,16,148,15,68,149,14,150,13,68
	.byte 151,12,152,11,68,153,10,154,9,68,155,8,156,7,39,12,31,0,68,14,192,1,157,24,158,23,68,13,29,76,147,15
	.byte 148,14,68,149,13,150,12,68,151,11,152,10,68,153,9,154,8,68,155,7,156,6,19,12,31,0,68,14,192,1,157,24
	.byte 158,23,68,13,29,68,150,22,151,21

.text
	.align 4
plt:
mono_aot_Microsoft_WindowsAzure_Messaging_iOS_plt:
	.no_dead_strip plt_Foundation_NSObject__ctor_Foundation_NSObjectFlag
plt_Foundation_NSObject__ctor_Foundation_NSObjectFlag:
_p_1:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1536]
br x16
.word 1986
	.no_dead_strip plt_System_Reflection_Assembly_op_Equality_System_Reflection_Assembly_System_Reflection_Assembly
plt_System_Reflection_Assembly_op_Equality_System_Reflection_Assembly_System_Reflection_Assembly:
_p_2:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1544]
br x16
.word 1991
	.no_dead_strip plt_Foundation_NSObject_set_IsDirectBinding_bool
plt_Foundation_NSObject_set_IsDirectBinding_bool:
_p_3:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1552]
br x16
.word 1996
	.no_dead_strip plt_Foundation_NSObject_get_IsDirectBinding
plt_Foundation_NSObject_get_IsDirectBinding:
_p_4:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1560]
br x16
.word 2001
	.no_dead_strip plt_Foundation_NSObject_get_Handle
plt_Foundation_NSObject_get_Handle:
_p_5:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1568]
br x16
.word 2006
	.no_dead_strip plt_ApiDefinition_Messaging_IntPtr_objc_msgSend_intptr_intptr
plt_ApiDefinition_Messaging_IntPtr_objc_msgSend_intptr_intptr:
_p_6:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1576]
br x16
.word 2011
	.no_dead_strip plt_Foundation_NSObject_InitializeHandle_intptr_string
plt_Foundation_NSObject_InitializeHandle_intptr_string:
_p_7:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1584]
br x16
.word 2013
	.no_dead_strip plt_Foundation_NSObject_get_SuperHandle
plt_Foundation_NSObject_get_SuperHandle:
_p_8:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1592]
br x16
.word 2018
	.no_dead_strip plt_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_intptr_intptr
plt_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_intptr_intptr:
_p_9:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1600]
br x16
.word 2023
	.no_dead_strip plt_Foundation_NSObject__ctor_intptr
plt_Foundation_NSObject__ctor_intptr:
_p_10:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1608]
br x16
.word 2025
	.no_dead_strip plt__jit_icall_mono_helper_ldstr
plt__jit_icall_mono_helper_ldstr:
_p_11:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1616]
br x16
.word 2030
	.no_dead_strip plt__jit_icall_mono_arch_throw_exception
plt__jit_icall_mono_arch_throw_exception:
_p_12:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1624]
br x16
.word 2050
	.no_dead_strip plt_Foundation_NSString_CreateNative_string
plt_Foundation_NSString_CreateNative_string:
_p_13:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1632]
br x16
.word 2078
	.no_dead_strip plt_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr
plt_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr:
_p_14:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1640]
br x16
.word 2083
	.no_dead_strip plt_Foundation_NSString_FromHandle_intptr
plt_Foundation_NSString_FromHandle_intptr:
_p_15:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1648]
br x16
.word 2085
	.no_dead_strip plt_Foundation_NSString_ReleaseNative_intptr
plt_Foundation_NSString_ReleaseNative_intptr:
_p_16:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1656]
br x16
.word 2090
	.no_dead_strip plt_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_IntPtr_intptr_intptr_intptr_intptr
plt_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_IntPtr_intptr_intptr_intptr_intptr:
_p_17:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1664]
br x16
.word 2095
	.no_dead_strip plt_ObjCRuntime_Class_GetHandle_string
plt_ObjCRuntime_Class_GetHandle_string:
_p_18:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1672]
br x16
.word 2097
	.no_dead_strip plt_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_intptr_intptr_intptr
plt_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_intptr_intptr_intptr:
_p_19:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1680]
br x16
.word 2102
	.no_dead_strip plt_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_IntPtr_intptr_intptr_intptr
plt_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_IntPtr_intptr_intptr_intptr:
_p_20:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1688]
br x16
.word 2104
	.no_dead_strip plt_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_intptr_intptr_intptr
plt_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_intptr_intptr_intptr:
_p_21:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1696]
br x16
.word 2106
	.no_dead_strip plt_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_intptr_intptr_intptr
plt_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_intptr_intptr_intptr:
_p_22:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1704]
br x16
.word 2108
	.no_dead_strip plt_ApiDefinition_Messaging_void_objc_msgSend_intptr_intptr
plt_ApiDefinition_Messaging_void_objc_msgSend_intptr_intptr:
_p_23:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1712]
br x16
.word 2110
	.no_dead_strip plt_ApiDefinition_Messaging_void_objc_msgSendSuper_intptr_intptr
plt_ApiDefinition_Messaging_void_objc_msgSendSuper_intptr_intptr:
_p_24:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1720]
br x16
.word 2112
	.no_dead_strip plt_ObjCRuntime_Runtime_GetNSObject_WindowsAzure_Messaging_StoredRegistrationEntry_intptr
plt_ObjCRuntime_Runtime_GetNSObject_WindowsAzure_Messaging_StoredRegistrationEntry_intptr:
_p_25:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1728]
br x16
.word 2114
	.no_dead_strip plt_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_intptr_intptr_intptr_intptr
plt_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_intptr_intptr_intptr_intptr:
_p_26:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1736]
br x16
.word 2126
	.no_dead_strip plt_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_intptr_intptr_intptr_intptr
plt_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_intptr_intptr_intptr_intptr:
_p_27:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1744]
br x16
.word 2128
	.no_dead_strip plt_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr
plt_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr:
_p_28:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1752]
br x16
.word 2130
	.no_dead_strip plt_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr
plt_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr:
_p_29:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1760]
br x16
.word 2132
	.no_dead_strip plt_ApiDefinition_Messaging_bool_objc_msgSend_intptr_intptr
plt_ApiDefinition_Messaging_bool_objc_msgSend_intptr_intptr:
_p_30:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1768]
br x16
.word 2134
	.no_dead_strip plt_ApiDefinition_Messaging_bool_objc_msgSendSuper_intptr_intptr
plt_ApiDefinition_Messaging_bool_objc_msgSendSuper_intptr_intptr:
_p_31:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1776]
br x16
.word 2136
	.no_dead_strip plt_ApiDefinition_Messaging_void_objc_msgSend_bool_intptr_intptr_bool
plt_ApiDefinition_Messaging_void_objc_msgSend_bool_intptr_intptr_bool:
_p_32:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1784]
br x16
.word 2138
	.no_dead_strip plt_ApiDefinition_Messaging_void_objc_msgSendSuper_bool_intptr_intptr_bool
plt_ApiDefinition_Messaging_void_objc_msgSendSuper_bool_intptr_intptr_bool:
_p_33:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1792]
br x16
.word 2140
	.no_dead_strip plt_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_IntPtr_IntPtr_intptr_intptr_intptr_intptr
plt_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_IntPtr_IntPtr_intptr_intptr_intptr_intptr:
_p_34:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1800]
br x16
.word 2142
	.no_dead_strip plt_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_
plt_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_:
_p_35:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1808]
br x16
.word 2144
	.no_dead_strip plt_ApiDefinition_Messaging_bool_objc_msgSendSuper_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_
plt_ApiDefinition_Messaging_bool_objc_msgSendSuper_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_:
_p_36:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1816]
br x16
.word 2146
	.no_dead_strip plt_intptr_op_Inequality_intptr_intptr
plt_intptr_op_Inequality_intptr_intptr:
_p_37:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1824]
br x16
.word 2148
	.no_dead_strip plt_ObjCRuntime_Runtime_GetNSObject_Foundation_NSError_intptr
plt_ObjCRuntime_Runtime_GetNSObject_Foundation_NSError_intptr:
_p_38:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1832]
br x16
.word 2153
	.no_dead_strip plt_wrapper_write_barrier_object_wbarrier_noconc_intptr
plt_wrapper_write_barrier_object_wbarrier_noconc_intptr:
_p_39:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1840]
br x16
.word 2165
	.no_dead_strip plt_ObjCRuntime_BlockLiteral_SetupBlock_System_Delegate_System_Delegate
plt_ObjCRuntime_BlockLiteral_SetupBlock_System_Delegate_System_Delegate:
_p_40:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1848]
br x16
.word 2172
	.no_dead_strip plt_intptr_op_Explicit_void_
plt_intptr_op_Explicit_void_:
_p_41:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1856]
br x16
.word 2177
	.no_dead_strip plt_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr
plt_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr:
_p_42:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1864]
br x16
.word 2182
	.no_dead_strip plt_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr
plt_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr:
_p_43:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1872]
br x16
.word 2184
	.no_dead_strip plt_ObjCRuntime_BlockLiteral_CleanupBlock
plt_ObjCRuntime_BlockLiteral_CleanupBlock:
_p_44:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1880]
br x16
.word 2186
	.no_dead_strip plt_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_
plt_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_:
_p_45:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1888]
br x16
.word 2191
	.no_dead_strip plt_ApiDefinition_Messaging_bool_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_
plt_ApiDefinition_Messaging_bool_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_:
_p_46:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1896]
br x16
.word 2193
	.no_dead_strip plt_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr
plt_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr:
_p_47:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1904]
br x16
.word 2195
	.no_dead_strip plt_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr
plt_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr:
_p_48:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1912]
br x16
.word 2197
	.no_dead_strip plt_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_
plt_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_:
_p_49:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1920]
br x16
.word 2199
	.no_dead_strip plt_ApiDefinition_Messaging_bool_objc_msgSendSuper_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_
plt_ApiDefinition_Messaging_bool_objc_msgSendSuper_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_:
_p_50:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1928]
br x16
.word 2201
	.no_dead_strip plt_ApiDefinition_Messaging_bool_objc_msgSend_ref_IntPtr_intptr_intptr_intptr_
plt_ApiDefinition_Messaging_bool_objc_msgSend_ref_IntPtr_intptr_intptr_intptr_:
_p_51:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1936]
br x16
.word 2203
	.no_dead_strip plt_ApiDefinition_Messaging_bool_objc_msgSendSuper_ref_IntPtr_intptr_intptr_intptr_
plt_ApiDefinition_Messaging_bool_objc_msgSendSuper_ref_IntPtr_intptr_intptr_intptr_:
_p_52:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1944]
br x16
.word 2205
	.no_dead_strip plt_ObjCRuntime_Runtime_GetNSObject_Foundation_NSDate_intptr
plt_ObjCRuntime_Runtime_GetNSObject_Foundation_NSDate_intptr:
_p_53:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1952]
br x16
.word 2207
	.no_dead_strip plt_Foundation_NSObject_IsNewRefcountEnabled
plt_Foundation_NSObject_IsNewRefcountEnabled:
_p_54:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1960]
br x16
.word 2219
	.no_dead_strip plt_ObjCRuntime_Runtime_GetNSObject_Foundation_NSSet_intptr
plt_ObjCRuntime_Runtime_GetNSObject_Foundation_NSSet_intptr:
_p_55:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1968]
br x16
.word 2224
	.no_dead_strip plt_Foundation_NSObject_Dispose_bool
plt_Foundation_NSObject_Dispose_bool:
_p_56:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1976]
br x16
.word 2236
	.no_dead_strip plt_intptr_op_Equality_intptr_intptr
plt_intptr_op_Equality_intptr_intptr:
_p_57:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1984]
br x16
.word 2241
	.no_dead_strip plt_ApiDefinition_Messaging_int_objc_msgSend_intptr_intptr
plt_ApiDefinition_Messaging_int_objc_msgSend_intptr_intptr:
_p_58:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #1992]
br x16
.word 2246
	.no_dead_strip plt_ApiDefinition_Messaging_int_objc_msgSendSuper_intptr_intptr
plt_ApiDefinition_Messaging_int_objc_msgSendSuper_intptr_intptr:
_p_59:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2000]
br x16
.word 2248
	.no_dead_strip plt_ApiDefinition_Messaging_void_objc_msgSend_int_intptr_intptr_int
plt_ApiDefinition_Messaging_void_objc_msgSend_int_intptr_intptr_int:
_p_60:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2008]
br x16
.word 2250
	.no_dead_strip plt_ApiDefinition_Messaging_void_objc_msgSendSuper_int_intptr_intptr_int
plt_ApiDefinition_Messaging_void_objc_msgSendSuper_int_intptr_intptr_int:
_p_61:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2016]
br x16
.word 2252
	.no_dead_strip plt_intptr_op_Explicit_intptr
plt_intptr_op_Explicit_intptr:
_p_62:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2024]
br x16
.word 2254
	.no_dead_strip plt_ObjCRuntime_BlockLiteral_get_Target
plt_ObjCRuntime_BlockLiteral_get_Target:
_p_63:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2032]
br x16
.word 2259
	.no_dead_strip plt__jit_icall_mono_arch_throw_corlib_exception
plt__jit_icall_mono_arch_throw_corlib_exception:
_p_64:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2040]
br x16
.word 2264
	.no_dead_strip plt__jit_icall_ves_icall_object_new_fast
plt__jit_icall_ves_icall_object_new_fast:
_p_65:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2048]
br x16
.word 2299
	.no_dead_strip plt_ObjCRuntime_Trampolines__Block_copy_intptr
plt_ObjCRuntime_Trampolines__Block_copy_intptr:
_p_66:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2056]
br x16
.word 2327
	.no_dead_strip plt_ObjCRuntime_BlockLiteral_GetDelegateForBlock_ObjCRuntime_Trampolines_DErrorCallback
plt_ObjCRuntime_BlockLiteral_GetDelegateForBlock_ObjCRuntime_Trampolines_DErrorCallback:
_p_67:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2064]
br x16
.word 2329
	.no_dead_strip plt_ObjCRuntime_Trampolines__Block_release_intptr
plt_ObjCRuntime_Trampolines__Block_release_intptr:
_p_68:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2072]
br x16
.word 2341
	.no_dead_strip plt_object_Finalize
plt_object_Finalize:
_p_69:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2080]
br x16
.word 2344
	.no_dead_strip plt__jit_icall_ves_icall_object_new_specific
plt__jit_icall_ves_icall_object_new_specific:
_p_70:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2088]
br x16
.word 2349
	.no_dead_strip plt_ObjCRuntime_Trampolines_NIDErrorCallback__ctor_ObjCRuntime_BlockLiteral_
plt_ObjCRuntime_Trampolines_NIDErrorCallback__ctor_ObjCRuntime_BlockLiteral_:
_p_71:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2096]
br x16
.word 2381
	.no_dead_strip plt__jit_icall_mono_thread_interruption_checkpoint
plt__jit_icall_mono_thread_interruption_checkpoint:
_p_72:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2104]
br x16
.word 2384
	.no_dead_strip plt__jit_icall_mono_delegate_begin_invoke
plt__jit_icall_mono_delegate_begin_invoke:
_p_73:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2112]
br x16
.word 2422
	.no_dead_strip plt__jit_icall_mono_delegate_end_invoke
plt__jit_icall_mono_delegate_end_invoke:
_p_74:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2120]
br x16
.word 2451
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_intptr_intptr
plt__icall_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_intptr_intptr:
_p_75:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2128]
br x16
.word 2478
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_intptr_intptr
plt__icall_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_intptr_intptr:
_p_76:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2136]
br x16
.word 2480
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_intptr_intptr_intptr
plt__icall_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_intptr_intptr_intptr:
_p_77:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2144]
br x16
.word 2482
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_IntPtr_intptr_intptr_intptr
plt__icall_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_IntPtr_intptr_intptr_intptr:
_p_78:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2152]
br x16
.word 2484
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr
plt__icall_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr:
_p_79:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2160]
br x16
.word 2486
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr
plt__icall_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr:
_p_80:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2168]
br x16
.word 2488
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_IntPtr_intptr_intptr_intptr_intptr
plt__icall_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_IntPtr_intptr_intptr_intptr_intptr:
_p_81:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2176]
br x16
.word 2490
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_IntPtr_IntPtr_intptr_intptr_intptr_intptr
plt__icall_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_IntPtr_IntPtr_intptr_intptr_intptr_intptr:
_p_82:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2184]
br x16
.word 2492
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_intptr_intptr_intptr
plt__icall_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_intptr_intptr_intptr:
_p_83:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2192]
br x16
.word 2494
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_intptr_intptr_intptr
plt__icall_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_intptr_intptr_intptr:
_p_84:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2200]
br x16
.word 2496
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_bool_objc_msgSend_intptr_intptr
plt__icall_native_ApiDefinition_Messaging_bool_objc_msgSend_intptr_intptr:
_p_85:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2208]
br x16
.word 2498
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_intptr_intptr
plt__icall_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_intptr_intptr:
_p_86:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2216]
br x16
.word 2500
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_void_objc_msgSend_bool_intptr_intptr_bool
plt__icall_native_ApiDefinition_Messaging_void_objc_msgSend_bool_intptr_intptr_bool:
_p_87:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2224]
br x16
.word 2502
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_void_objc_msgSendSuper_bool_intptr_intptr_bool
plt__icall_native_ApiDefinition_Messaging_void_objc_msgSendSuper_bool_intptr_intptr_bool:
_p_88:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2232]
br x16
.word 2504
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_intptr_intptr_intptr_intptr
plt__icall_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_intptr_intptr_intptr_intptr:
_p_89:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2240]
br x16
.word 2506
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_intptr_intptr_intptr_intptr
plt__icall_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_intptr_intptr_intptr_intptr:
_p_90:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2248]
br x16
.word 2508
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr
plt__icall_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr:
_p_91:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2256]
br x16
.word 2510
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr
plt__icall_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr:
_p_92:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2264]
br x16
.word 2512
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_void_objc_msgSend_intptr_intptr
plt__icall_native_ApiDefinition_Messaging_void_objc_msgSend_intptr_intptr:
_p_93:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2272]
br x16
.word 2514
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_void_objc_msgSendSuper_intptr_intptr
plt__icall_native_ApiDefinition_Messaging_void_objc_msgSendSuper_intptr_intptr:
_p_94:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2280]
br x16
.word 2516
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr
plt__icall_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr:
_p_95:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2288]
br x16
.word 2518
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr
plt__icall_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr:
_p_96:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2296]
br x16
.word 2520
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr
plt__icall_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr:
_p_97:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2304]
br x16
.word 2522
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr
plt__icall_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr:
_p_98:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2312]
br x16
.word 2524
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_
plt__icall_native_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_:
_p_99:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2320]
br x16
.word 2526
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_
plt__icall_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_:
_p_100:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2328]
br x16
.word 2528
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_
plt__icall_native_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_:
_p_101:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2336]
br x16
.word 2530
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_
plt__icall_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_:
_p_102:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2344]
br x16
.word 2532
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_bool_objc_msgSend_ref_IntPtr_intptr_intptr_intptr_
plt__icall_native_ApiDefinition_Messaging_bool_objc_msgSend_ref_IntPtr_intptr_intptr_intptr_:
_p_103:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2352]
br x16
.word 2534
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_ref_IntPtr_intptr_intptr_intptr_
plt__icall_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_ref_IntPtr_intptr_intptr_intptr_:
_p_104:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2360]
br x16
.word 2536
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_
plt__icall_native_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_:
_p_105:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2368]
br x16
.word 2538
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_
plt__icall_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_:
_p_106:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2376]
br x16
.word 2540
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_int_objc_msgSend_intptr_intptr
plt__icall_native_ApiDefinition_Messaging_int_objc_msgSend_intptr_intptr:
_p_107:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2384]
br x16
.word 2542
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_int_objc_msgSendSuper_intptr_intptr
plt__icall_native_ApiDefinition_Messaging_int_objc_msgSendSuper_intptr_intptr:
_p_108:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2392]
br x16
.word 2544
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_void_objc_msgSend_int_intptr_intptr_int
plt__icall_native_ApiDefinition_Messaging_void_objc_msgSend_int_intptr_intptr_int:
_p_109:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2400]
br x16
.word 2546
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_void_objc_msgSendSuper_int_intptr_intptr_int
plt__icall_native_ApiDefinition_Messaging_void_objc_msgSendSuper_int_intptr_intptr_int:
_p_110:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2408]
br x16
.word 2548
	.no_dead_strip plt__icall_native_ObjCRuntime_Trampolines__Block_copy_intptr
plt__icall_native_ObjCRuntime_Trampolines__Block_copy_intptr:
_p_111:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2416]
br x16
.word 2550
	.no_dead_strip plt__icall_native_ObjCRuntime_Trampolines__Block_release_intptr
plt__icall_native_ObjCRuntime_Trampolines__Block_release_intptr:
_p_112:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2424]
br x16
.word 2552
	.no_dead_strip plt_ObjCRuntime_Trampolines_SDErrorCallback_Invoke_intptr_intptr
plt_ObjCRuntime_Trampolines_SDErrorCallback_Invoke_intptr_intptr:
_p_113:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2432]
br x16
.word 2555
	.no_dead_strip plt__jit_icall_mono_gchandle_new
plt__jit_icall_mono_gchandle_new:
_p_114:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2440]
br x16
.word 2558
	.no_dead_strip plt__jit_icall_mono_thread_get_undeniable_exception
plt__jit_icall_mono_thread_get_undeniable_exception:
_p_115:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2448]
br x16
.word 2578
	.no_dead_strip plt__jit_icall_mono_marshal_ftnptr_eh_callback
plt__jit_icall_mono_marshal_ftnptr_eh_callback:
_p_116:
adrp x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGE+0
add x16, x16, mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got@PAGEOFF
ldr x16, [x16, #2456]
br x16
.word 2617
plt_end:
.section __DATA, __bss
	.align 3
.lcomm mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got, 2464
got_end:
.section	__DATA,__objc_selrefs,literal_pointers,no_dead_strip
.align	3
L_OBJC_SELECTOR_REFERENCES_0:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_0
L_OBJC_SELECTOR_REFERENCES_1:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_1
L_OBJC_SELECTOR_REFERENCES_2:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_2
L_OBJC_SELECTOR_REFERENCES_3:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_3
L_OBJC_SELECTOR_REFERENCES_4:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_4
L_OBJC_SELECTOR_REFERENCES_5:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_5
L_OBJC_SELECTOR_REFERENCES_6:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_6
L_OBJC_SELECTOR_REFERENCES_7:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_7
L_OBJC_SELECTOR_REFERENCES_8:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_8
L_OBJC_SELECTOR_REFERENCES_9:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_9
L_OBJC_SELECTOR_REFERENCES_10:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_10
L_OBJC_SELECTOR_REFERENCES_11:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_11
L_OBJC_SELECTOR_REFERENCES_12:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_12
L_OBJC_SELECTOR_REFERENCES_13:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_13
L_OBJC_SELECTOR_REFERENCES_14:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_14
L_OBJC_SELECTOR_REFERENCES_15:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_15
L_OBJC_SELECTOR_REFERENCES_16:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_16
L_OBJC_SELECTOR_REFERENCES_17:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_17
L_OBJC_SELECTOR_REFERENCES_18:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_18
L_OBJC_SELECTOR_REFERENCES_19:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_19
L_OBJC_SELECTOR_REFERENCES_20:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_20
L_OBJC_SELECTOR_REFERENCES_21:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_21
L_OBJC_SELECTOR_REFERENCES_22:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_22
L_OBJC_SELECTOR_REFERENCES_23:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_23
L_OBJC_SELECTOR_REFERENCES_24:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_24
L_OBJC_SELECTOR_REFERENCES_25:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_25
L_OBJC_SELECTOR_REFERENCES_26:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_26
L_OBJC_SELECTOR_REFERENCES_27:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_27
L_OBJC_SELECTOR_REFERENCES_28:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_28
L_OBJC_SELECTOR_REFERENCES_29:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_29
L_OBJC_SELECTOR_REFERENCES_30:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_30
L_OBJC_SELECTOR_REFERENCES_31:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_31
L_OBJC_SELECTOR_REFERENCES_32:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_32
L_OBJC_SELECTOR_REFERENCES_33:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_33
L_OBJC_SELECTOR_REFERENCES_34:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_34
L_OBJC_SELECTOR_REFERENCES_35:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_35
L_OBJC_SELECTOR_REFERENCES_36:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_36
L_OBJC_SELECTOR_REFERENCES_37:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_37
L_OBJC_SELECTOR_REFERENCES_38:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_38
L_OBJC_SELECTOR_REFERENCES_39:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_39
L_OBJC_SELECTOR_REFERENCES_40:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_40
L_OBJC_SELECTOR_REFERENCES_41:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_41
L_OBJC_SELECTOR_REFERENCES_42:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_42
L_OBJC_SELECTOR_REFERENCES_43:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_43
L_OBJC_SELECTOR_REFERENCES_44:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_44
L_OBJC_SELECTOR_REFERENCES_45:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_45
L_OBJC_SELECTOR_REFERENCES_46:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_46
L_OBJC_SELECTOR_REFERENCES_47:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_47
L_OBJC_SELECTOR_REFERENCES_48:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_48
.section	__TEXT,__cstring,cstring_literals
L_OBJC_METH_VAR_NAME_0:
.asciz "init"
L_OBJC_METH_VAR_NAME_1:
.asciz "stringWithEndpoint:issuer:issuerSecret:"
L_OBJC_METH_VAR_NAME_2:
.asciz "stringWithEndpoint:sharedAccessKeyName:accessSecret:"
L_OBJC_METH_VAR_NAME_3:
.asciz "stringWithEndpoint:fullAccessSecret:"
L_OBJC_METH_VAR_NAME_4:
.asciz "stringWithEndpoint:listenAccessSecret:"
L_OBJC_METH_VAR_NAME_5:
.asciz "initWithNotificationHubPath:"
L_OBJC_METH_VAR_NAME_6:
.asciz "deleteWithRegistrationName:"
L_OBJC_METH_VAR_NAME_7:
.asciz "deleteAllRegistrations"
L_OBJC_METH_VAR_NAME_8:
.asciz "getStoredRegistrationEntryWithRegistrationName:"
L_OBJC_METH_VAR_NAME_9:
.asciz "refreshFinishedWithDeviceToken:"
L_OBJC_METH_VAR_NAME_10:
.asciz "updateWithRegistrationName:registration:"
L_OBJC_METH_VAR_NAME_11:
.asciz "updateWithRegistrationName:registrationId:eTag:deviceToken:"
L_OBJC_METH_VAR_NAME_12:
.asciz "updateWithRegistrationName:"
L_OBJC_METH_VAR_NAME_13:
.asciz "updateWithRegistration:"
L_OBJC_METH_VAR_NAME_14:
.asciz "deviceToken"
L_OBJC_METH_VAR_NAME_15:
.asciz "setDeviceToken:"
L_OBJC_METH_VAR_NAME_16:
.asciz "isRefreshNeeded"
L_OBJC_METH_VAR_NAME_17:
.asciz "setIsRefreshNeeded:"
L_OBJC_METH_VAR_NAME_18:
.asciz "initWithConnectionString:notificationHubPath:"
L_OBJC_METH_VAR_NAME_19:
.asciz "registerNativeWithDeviceToken:tags:error:"
L_OBJC_METH_VAR_NAME_20:
.asciz "registerNativeWithDeviceToken:tags:completion:"
L_OBJC_METH_VAR_NAME_21:
.asciz "registerTemplateWithDeviceToken:name:jsonBodyTemplate:expiryTemplate:tags:error:"
L_OBJC_METH_VAR_NAME_22:
.asciz "registerTemplateWithDeviceToken:name:jsonBodyTemplate:expiryTemplate:tags:completion:"
L_OBJC_METH_VAR_NAME_23:
.asciz "unregisterAllWithDeviceToken:error:"
L_OBJC_METH_VAR_NAME_24:
.asciz "unregisterAllWithDeviceToken:completion:"
L_OBJC_METH_VAR_NAME_25:
.asciz "unregisterNativeWithError:"
L_OBJC_METH_VAR_NAME_26:
.asciz "unregisterNativeWithCompletion:"
L_OBJC_METH_VAR_NAME_27:
.asciz "unregisterTemplateWithName:error:"
L_OBJC_METH_VAR_NAME_28:
.asciz "unregisterTemplateWithName:completion:"
L_OBJC_METH_VAR_NAME_29:
.asciz "Version"
L_OBJC_METH_VAR_NAME_30:
.asciz "Name"
L_OBJC_METH_VAR_NAME_31:
.asciz "payloadWithDeviceToken:tags:"
L_OBJC_METH_VAR_NAME_32:
.asciz "ETag"
L_OBJC_METH_VAR_NAME_33:
.asciz "setETag:"
L_OBJC_METH_VAR_NAME_34:
.asciz "expiresAt"
L_OBJC_METH_VAR_NAME_35:
.asciz "setExpiresAt:"
L_OBJC_METH_VAR_NAME_36:
.asciz "registrationId"
L_OBJC_METH_VAR_NAME_37:
.asciz "setRegistrationId:"
L_OBJC_METH_VAR_NAME_38:
.asciz "tags"
L_OBJC_METH_VAR_NAME_39:
.asciz "setTags:"
L_OBJC_METH_VAR_NAME_40:
.asciz "initWithString:"
L_OBJC_METH_VAR_NAME_41:
.asciz "toString"
L_OBJC_METH_VAR_NAME_42:
.asciz "RegistrationId"
L_OBJC_METH_VAR_NAME_43:
.asciz "RegistrationName"
L_OBJC_METH_VAR_NAME_44:
.asciz "setRegistrationName:"
L_OBJC_METH_VAR_NAME_45:
.asciz "setTokenWithRequest:completion:"
L_OBJC_METH_VAR_NAME_46:
.asciz "setTokenWithRequest:error:"
L_OBJC_METH_VAR_NAME_47:
.asciz "timeToExpireinMins"
L_OBJC_METH_VAR_NAME_48:
.asciz "setTimeToExpireinMins:"
.section	__DATA,__objc_imageinfo,regular,no_dead_strip
.align	3
L_OBJC_IMAGE_INFO:
.long	0
.long	16
.section __TEXT, __const
	.align 3
Lglobals_hash:

	.short 11, 0, 0, 0, 0, 0, 0, 0
	.short 0, 0, 0, 0, 0, 0, 0, 0
	.short 0, 0, 0, 0, 0, 0, 0
.data
	.align 3
globals:
	.align 3
	.quad Lglobals_hash

	.long 0,0
.section __TEXT, __const
	.align 2
runtime_version:
	.asciz ""
.section __TEXT, __const
	.align 2
assembly_guid:
	.asciz "FDD8609C-19B0-4DA8-816E-12E093A59503"
.section __TEXT, __const
	.align 2
assembly_name:
	.asciz "Microsoft.WindowsAzure.Messaging.iOS"
.data
	.align 3
_mono_aot_file_info:

	.long 137,0
	.align 3
	.quad mono_aot_Microsoft_WindowsAzure_Messaging_iOS_got
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad jit_code_start
	.align 3
	.quad jit_code_end
	.align 3
	.quad method_addresses
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad mem_end
	.align 3
	.quad assembly_guid
	.align 3
	.quad runtime_version
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad globals
	.align 3
	.quad assembly_name
	.align 3
	.quad plt
	.align 3
	.quad plt_end
	.align 3
	.quad unwind_info
	.align 3
	.quad unbox_trampolines
	.align 3
	.quad unbox_trampolines_end
	.align 3
	.quad unbox_trampoline_addresses

	.long 191,2464,117,185,70,387000831,0,33038
	.long 128,8,8,10,0,14,35760,2712
	.long 2432,1640,0,2000,2384,1728,0,1264
	.long 272,0,0,0,0,0,0,0
	.long 0,0,0,0,0,0,0,0
	.long 0
	.byte 154,31,236,143,209,35,25,106,3,119,185,135,237,50,164,184
	.globl _mono_aot_module_Microsoft_WindowsAzure_Messaging_iOS_info
	.align 3
_mono_aot_module_Microsoft_WindowsAzure_Messaging_iOS_info:
	.align 3
	.quad _mono_aot_file_info
.section __DWARF, __debug_info,regular,debug
LTDIE_1:

	.byte 17
	.asciz "System_Object"

	.byte 16,7
	.asciz "System_Object"

LDIFF_SYM3=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM3
LTDIE_1_POINTER:

	.byte 13
LDIFF_SYM4=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM4
LTDIE_1_REFERENCE:

	.byte 14
LDIFF_SYM5=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM5
LTDIE_0:

	.byte 5
	.asciz "ApiDefinition_Messaging"

	.byte 16,16
LDIFF_SYM6=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM6
	.byte 2,35,0,0,7
	.asciz "ApiDefinition_Messaging"

LDIFF_SYM7=LTDIE_0 - Ldebug_info_start
	.long LDIFF_SYM7
LTDIE_0_POINTER:

	.byte 13
LDIFF_SYM8=LTDIE_0 - Ldebug_info_start
	.long LDIFF_SYM8
LTDIE_0_REFERENCE:

	.byte 14
LDIFF_SYM9=LTDIE_0 - Ldebug_info_start
	.long LDIFF_SYM9
	.byte 2
	.asciz "ApiDefinition.Messaging:.ctor"
	.asciz "ApiDefinition_Messaging__ctor"

	.byte 0,0
	.quad ApiDefinition_Messaging__ctor
	.quad Lme_0

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM10=LTDIE_0_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM10
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM11=Lfde0_end - Lfde0_start
	.long LDIFF_SYM11
Lfde0_start:

	.long 0
	.align 3
	.quad ApiDefinition_Messaging__ctor

LDIFF_SYM12=Lme_0 - ApiDefinition_Messaging__ctor
	.long LDIFF_SYM12
	.long 0
	.byte 12,31,0,68,14,48,157,6,158,5,68,13,29
	.align 3
Lfde0_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "ApiDefinition.Messaging:.cctor"
	.asciz "ApiDefinition_Messaging__cctor"

	.byte 0,0
	.quad ApiDefinition_Messaging__cctor
	.quad Lme_25

	.byte 2,118,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM13=Lfde1_end - Lfde1_start
	.long LDIFF_SYM13
Lfde1_start:

	.long 0
	.align 3
	.quad ApiDefinition_Messaging__cctor

LDIFF_SYM14=Lme_25 - ApiDefinition_Messaging__cctor
	.long LDIFF_SYM14
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29
	.align 3
Lfde1_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_4:

	.byte 8
	.asciz "_Flags"

	.byte 1
LDIFF_SYM15=LDIE_U1 - Ldebug_info_start
	.long LDIFF_SYM15
	.byte 9
	.asciz "Disposed"

	.byte 1,9
	.asciz "NativeRef"

	.byte 2,9
	.asciz "IsDirectBinding"

	.byte 4,9
	.asciz "RegisteredToggleRef"

	.byte 8,9
	.asciz "InFinalizerQueue"

	.byte 16,9
	.asciz "HasManagedRef"

	.byte 32,0,7
	.asciz "_Flags"

LDIFF_SYM16=LTDIE_4 - Ldebug_info_start
	.long LDIFF_SYM16
LTDIE_4_POINTER:

	.byte 13
LDIFF_SYM17=LTDIE_4 - Ldebug_info_start
	.long LDIFF_SYM17
LTDIE_4_REFERENCE:

	.byte 14
LDIFF_SYM18=LTDIE_4 - Ldebug_info_start
	.long LDIFF_SYM18
LTDIE_3:

	.byte 5
	.asciz "Foundation_NSObject"

	.byte 40,16
LDIFF_SYM19=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM19
	.byte 2,35,0,6
	.asciz "handle"

LDIFF_SYM20=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM20
	.byte 2,35,16,6
	.asciz "class_handle"

LDIFF_SYM21=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM21
	.byte 2,35,24,6
	.asciz "flags"

LDIFF_SYM22=LTDIE_4 - Ldebug_info_start
	.long LDIFF_SYM22
	.byte 2,35,32,0,7
	.asciz "Foundation_NSObject"

LDIFF_SYM23=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM23
LTDIE_3_POINTER:

	.byte 13
LDIFF_SYM24=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM24
LTDIE_3_REFERENCE:

	.byte 14
LDIFF_SYM25=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM25
LTDIE_2:

	.byte 5
	.asciz "WindowsAzure_Messaging_SBConnectionString"

	.byte 40,16
LDIFF_SYM26=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM26
	.byte 2,35,0,0,7
	.asciz "WindowsAzure_Messaging_SBConnectionString"

LDIFF_SYM27=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM27
LTDIE_2_POINTER:

	.byte 13
LDIFF_SYM28=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM28
LTDIE_2_REFERENCE:

	.byte 14
LDIFF_SYM29=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM29
	.byte 2
	.asciz "WindowsAzure.Messaging.SBConnectionString:.ctor"
	.asciz "WindowsAzure_Messaging_SBConnectionString__ctor"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBConnectionString__ctor
	.quad Lme_26

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM30=LTDIE_2_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM30
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM31=Lfde2_end - Lfde2_start
	.long LDIFF_SYM31
Lfde2_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBConnectionString__ctor

LDIFF_SYM32=Lme_26 - WindowsAzure_Messaging_SBConnectionString__ctor
	.long LDIFF_SYM32
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29,68,154,8
	.align 3
Lfde2_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_5:

	.byte 5
	.asciz "Foundation_NSObjectFlag"

	.byte 16,16
LDIFF_SYM33=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM33
	.byte 2,35,0,0,7
	.asciz "Foundation_NSObjectFlag"

LDIFF_SYM34=LTDIE_5 - Ldebug_info_start
	.long LDIFF_SYM34
LTDIE_5_POINTER:

	.byte 13
LDIFF_SYM35=LTDIE_5 - Ldebug_info_start
	.long LDIFF_SYM35
LTDIE_5_REFERENCE:

	.byte 14
LDIFF_SYM36=LTDIE_5 - Ldebug_info_start
	.long LDIFF_SYM36
	.byte 2
	.asciz "WindowsAzure.Messaging.SBConnectionString:.ctor"
	.asciz "WindowsAzure_Messaging_SBConnectionString__ctor_Foundation_NSObjectFlag"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBConnectionString__ctor_Foundation_NSObjectFlag
	.quad Lme_27

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM37=LTDIE_2_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM37
	.byte 1,105,3
	.asciz "t"

LDIFF_SYM38=LTDIE_5_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM38
	.byte 2,141,24,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM39=Lfde3_end - Lfde3_start
	.long LDIFF_SYM39
Lfde3_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBConnectionString__ctor_Foundation_NSObjectFlag

LDIFF_SYM40=Lme_27 - WindowsAzure_Messaging_SBConnectionString__ctor_Foundation_NSObjectFlag
	.long LDIFF_SYM40
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10
	.align 3
Lfde3_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBConnectionString:.ctor"
	.asciz "WindowsAzure_Messaging_SBConnectionString__ctor_intptr"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBConnectionString__ctor_intptr
	.quad Lme_28

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM41=LTDIE_2_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM41
	.byte 1,105,3
	.asciz "handle"

LDIFF_SYM42=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM42
	.byte 2,141,24,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM43=Lfde4_end - Lfde4_start
	.long LDIFF_SYM43
Lfde4_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBConnectionString__ctor_intptr

LDIFF_SYM44=Lme_28 - WindowsAzure_Messaging_SBConnectionString__ctor_intptr
	.long LDIFF_SYM44
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10
	.align 3
Lfde4_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBConnectionString:get_ClassHandle"
	.asciz "WindowsAzure_Messaging_SBConnectionString_get_ClassHandle"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBConnectionString_get_ClassHandle
	.quad Lme_29

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM45=LTDIE_2_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM45
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM46=Lfde5_end - Lfde5_start
	.long LDIFF_SYM46
Lfde5_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBConnectionString_get_ClassHandle

LDIFF_SYM47=Lme_29 - WindowsAzure_Messaging_SBConnectionString_get_ClassHandle
	.long LDIFF_SYM47
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29
	.align 3
Lfde5_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_6:

	.byte 5
	.asciz "Foundation_NSUrl"

	.byte 40,16
LDIFF_SYM48=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM48
	.byte 2,35,0,0,7
	.asciz "Foundation_NSUrl"

LDIFF_SYM49=LTDIE_6 - Ldebug_info_start
	.long LDIFF_SYM49
LTDIE_6_POINTER:

	.byte 13
LDIFF_SYM50=LTDIE_6 - Ldebug_info_start
	.long LDIFF_SYM50
LTDIE_6_REFERENCE:

	.byte 14
LDIFF_SYM51=LTDIE_6 - Ldebug_info_start
	.long LDIFF_SYM51
	.byte 2
	.asciz "WindowsAzure.Messaging.SBConnectionString:CreateByIssuer"
	.asciz "WindowsAzure_Messaging_SBConnectionString_CreateByIssuer_Foundation_NSUrl_string_string"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBConnectionString_CreateByIssuer_Foundation_NSUrl_string_string
	.quad Lme_2a

	.byte 2,118,16,3
	.asciz "endpoint"

LDIFF_SYM52=LTDIE_6_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM52
	.byte 1,104,3
	.asciz "issuer"

LDIFF_SYM53=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM53
	.byte 1,105,3
	.asciz "secret"

LDIFF_SYM54=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM54
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM55=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM55
	.byte 1,103,11
	.asciz "V_1"

LDIFF_SYM56=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM56
	.byte 1,102,11
	.asciz "V_2"

LDIFF_SYM57=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM57
	.byte 1,101,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM58=Lfde6_end - Lfde6_start
	.long LDIFF_SYM58
Lfde6_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBConnectionString_CreateByIssuer_Foundation_NSUrl_string_string

LDIFF_SYM59=Lme_2a - WindowsAzure_Messaging_SBConnectionString_CreateByIssuer_Foundation_NSUrl_string_string
	.long LDIFF_SYM59
	.long 0
	.byte 12,31,0,68,14,160,1,157,20,158,19,68,13,29,68,149,18,150,17,68,151,16,152,15,68,153,14,154,13
	.align 3
Lfde6_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBConnectionString:CreateByKeyName"
	.asciz "WindowsAzure_Messaging_SBConnectionString_CreateByKeyName_Foundation_NSUrl_string_string"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBConnectionString_CreateByKeyName_Foundation_NSUrl_string_string
	.quad Lme_2b

	.byte 2,118,16,3
	.asciz "endpoint"

LDIFF_SYM60=LTDIE_6_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM60
	.byte 1,104,3
	.asciz "keyName"

LDIFF_SYM61=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM61
	.byte 1,105,3
	.asciz "secret"

LDIFF_SYM62=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM62
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM63=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM63
	.byte 1,103,11
	.asciz "V_1"

LDIFF_SYM64=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM64
	.byte 1,102,11
	.asciz "V_2"

LDIFF_SYM65=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM65
	.byte 1,101,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM66=Lfde7_end - Lfde7_start
	.long LDIFF_SYM66
Lfde7_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBConnectionString_CreateByKeyName_Foundation_NSUrl_string_string

LDIFF_SYM67=Lme_2b - WindowsAzure_Messaging_SBConnectionString_CreateByKeyName_Foundation_NSUrl_string_string
	.long LDIFF_SYM67
	.long 0
	.byte 12,31,0,68,14,160,1,157,20,158,19,68,13,29,68,149,18,150,17,68,151,16,152,15,68,153,14,154,13
	.align 3
Lfde7_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBConnectionString:CreateFullAccess"
	.asciz "WindowsAzure_Messaging_SBConnectionString_CreateFullAccess_Foundation_NSUrl_string"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBConnectionString_CreateFullAccess_Foundation_NSUrl_string
	.quad Lme_2c

	.byte 2,118,16,3
	.asciz "endpoint"

LDIFF_SYM68=LTDIE_6_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM68
	.byte 1,105,3
	.asciz "fullAccessSecret"

LDIFF_SYM69=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM69
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM70=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM70
	.byte 1,104,11
	.asciz "V_1"

LDIFF_SYM71=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM71
	.byte 1,103,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM72=Lfde8_end - Lfde8_start
	.long LDIFF_SYM72
Lfde8_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBConnectionString_CreateFullAccess_Foundation_NSUrl_string

LDIFF_SYM73=Lme_2c - WindowsAzure_Messaging_SBConnectionString_CreateFullAccess_Foundation_NSUrl_string
	.long LDIFF_SYM73
	.long 0
	.byte 12,31,0,68,14,144,1,157,18,158,17,68,13,29,68,151,16,152,15,68,153,14,154,13
	.align 3
Lfde8_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBConnectionString:CreateListenAccess"
	.asciz "WindowsAzure_Messaging_SBConnectionString_CreateListenAccess_Foundation_NSUrl_string"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBConnectionString_CreateListenAccess_Foundation_NSUrl_string
	.quad Lme_2d

	.byte 2,118,16,3
	.asciz "endpoint"

LDIFF_SYM74=LTDIE_6_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM74
	.byte 1,105,3
	.asciz "listenAccessSecret"

LDIFF_SYM75=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM75
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM76=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM76
	.byte 1,104,11
	.asciz "V_1"

LDIFF_SYM77=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM77
	.byte 1,103,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM78=Lfde9_end - Lfde9_start
	.long LDIFF_SYM78
Lfde9_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBConnectionString_CreateListenAccess_Foundation_NSUrl_string

LDIFF_SYM79=Lme_2d - WindowsAzure_Messaging_SBConnectionString_CreateListenAccess_Foundation_NSUrl_string
	.long LDIFF_SYM79
	.long 0
	.byte 12,31,0,68,14,144,1,157,18,158,17,68,13,29,68,151,16,152,15,68,153,14,154,13
	.align 3
Lfde9_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBConnectionString:.cctor"
	.asciz "WindowsAzure_Messaging_SBConnectionString__cctor"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBConnectionString__cctor
	.quad Lme_2e

	.byte 2,118,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM80=Lfde10_end - Lfde10_start
	.long LDIFF_SYM80
Lfde10_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBConnectionString__cctor

LDIFF_SYM81=Lme_2e - WindowsAzure_Messaging_SBConnectionString__cctor
	.long LDIFF_SYM81
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29
	.align 3
Lfde10_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_7:

	.byte 5
	.asciz "WindowsAzure_Messaging_SBLocalStorage"

	.byte 40,16
LDIFF_SYM82=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM82
	.byte 2,35,0,0,7
	.asciz "WindowsAzure_Messaging_SBLocalStorage"

LDIFF_SYM83=LTDIE_7 - Ldebug_info_start
	.long LDIFF_SYM83
LTDIE_7_POINTER:

	.byte 13
LDIFF_SYM84=LTDIE_7 - Ldebug_info_start
	.long LDIFF_SYM84
LTDIE_7_REFERENCE:

	.byte 14
LDIFF_SYM85=LTDIE_7 - Ldebug_info_start
	.long LDIFF_SYM85
	.byte 2
	.asciz "WindowsAzure.Messaging.SBLocalStorage:.ctor"
	.asciz "WindowsAzure_Messaging_SBLocalStorage__ctor"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBLocalStorage__ctor
	.quad Lme_2f

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM86=LTDIE_7_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM86
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM87=Lfde11_end - Lfde11_start
	.long LDIFF_SYM87
Lfde11_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBLocalStorage__ctor

LDIFF_SYM88=Lme_2f - WindowsAzure_Messaging_SBLocalStorage__ctor
	.long LDIFF_SYM88
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29,68,154,8
	.align 3
Lfde11_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBLocalStorage:.ctor"
	.asciz "WindowsAzure_Messaging_SBLocalStorage__ctor_Foundation_NSObjectFlag"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBLocalStorage__ctor_Foundation_NSObjectFlag
	.quad Lme_30

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM89=LTDIE_7_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM89
	.byte 1,105,3
	.asciz "t"

LDIFF_SYM90=LTDIE_5_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM90
	.byte 2,141,24,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM91=Lfde12_end - Lfde12_start
	.long LDIFF_SYM91
Lfde12_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBLocalStorage__ctor_Foundation_NSObjectFlag

LDIFF_SYM92=Lme_30 - WindowsAzure_Messaging_SBLocalStorage__ctor_Foundation_NSObjectFlag
	.long LDIFF_SYM92
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10
	.align 3
Lfde12_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBLocalStorage:.ctor"
	.asciz "WindowsAzure_Messaging_SBLocalStorage__ctor_intptr"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBLocalStorage__ctor_intptr
	.quad Lme_31

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM93=LTDIE_7_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM93
	.byte 1,105,3
	.asciz "handle"

LDIFF_SYM94=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM94
	.byte 2,141,24,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM95=Lfde13_end - Lfde13_start
	.long LDIFF_SYM95
Lfde13_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBLocalStorage__ctor_intptr

LDIFF_SYM96=Lme_31 - WindowsAzure_Messaging_SBLocalStorage__ctor_intptr
	.long LDIFF_SYM96
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10
	.align 3
Lfde13_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBLocalStorage:.ctor"
	.asciz "WindowsAzure_Messaging_SBLocalStorage__ctor_string"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBLocalStorage__ctor_string
	.quad Lme_32

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM97=LTDIE_7_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM97
	.byte 1,105,3
	.asciz "notificationHubPath"

LDIFF_SYM98=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM98
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM99=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM99
	.byte 1,104,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM100=Lfde14_end - Lfde14_start
	.long LDIFF_SYM100
Lfde14_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBLocalStorage__ctor_string

LDIFF_SYM101=Lme_32 - WindowsAzure_Messaging_SBLocalStorage__ctor_string
	.long LDIFF_SYM101
	.long 0
	.byte 12,31,0,68,14,112,157,14,158,13,68,13,29,68,152,12,153,11,68,154,10
	.align 3
Lfde14_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBLocalStorage:get_ClassHandle"
	.asciz "WindowsAzure_Messaging_SBLocalStorage_get_ClassHandle"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBLocalStorage_get_ClassHandle
	.quad Lme_33

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM102=LTDIE_7_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM102
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM103=Lfde15_end - Lfde15_start
	.long LDIFF_SYM103
Lfde15_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBLocalStorage_get_ClassHandle

LDIFF_SYM104=Lme_33 - WindowsAzure_Messaging_SBLocalStorage_get_ClassHandle
	.long LDIFF_SYM104
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29
	.align 3
Lfde15_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBLocalStorage:Delete"
	.asciz "WindowsAzure_Messaging_SBLocalStorage_Delete_string"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBLocalStorage_Delete_string
	.quad Lme_34

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM105=LTDIE_7_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM105
	.byte 1,105,3
	.asciz "registrationName"

LDIFF_SYM106=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM106
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM107=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM107
	.byte 1,104,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM108=Lfde16_end - Lfde16_start
	.long LDIFF_SYM108
Lfde16_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBLocalStorage_Delete_string

LDIFF_SYM109=Lme_34 - WindowsAzure_Messaging_SBLocalStorage_Delete_string
	.long LDIFF_SYM109
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29,68,152,8,153,7,68,154,6
	.align 3
Lfde16_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBLocalStorage:DeleteAllRegistrations"
	.asciz "WindowsAzure_Messaging_SBLocalStorage_DeleteAllRegistrations"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBLocalStorage_DeleteAllRegistrations
	.quad Lme_35

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM110=LTDIE_7_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM110
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM111=Lfde17_end - Lfde17_start
	.long LDIFF_SYM111
Lfde17_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBLocalStorage_DeleteAllRegistrations

LDIFF_SYM112=Lme_35 - WindowsAzure_Messaging_SBLocalStorage_DeleteAllRegistrations
	.long LDIFF_SYM112
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29,68,154,6
	.align 3
Lfde17_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_8:

	.byte 5
	.asciz "WindowsAzure_Messaging_StoredRegistrationEntry"

	.byte 40,16
LDIFF_SYM113=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM113
	.byte 2,35,0,0,7
	.asciz "WindowsAzure_Messaging_StoredRegistrationEntry"

LDIFF_SYM114=LTDIE_8 - Ldebug_info_start
	.long LDIFF_SYM114
LTDIE_8_POINTER:

	.byte 13
LDIFF_SYM115=LTDIE_8 - Ldebug_info_start
	.long LDIFF_SYM115
LTDIE_8_REFERENCE:

	.byte 14
LDIFF_SYM116=LTDIE_8 - Ldebug_info_start
	.long LDIFF_SYM116
	.byte 2
	.asciz "WindowsAzure.Messaging.SBLocalStorage:GetStoredRegistrationEntry"
	.asciz "WindowsAzure_Messaging_SBLocalStorage_GetStoredRegistrationEntry_string"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBLocalStorage_GetStoredRegistrationEntry_string
	.quad Lme_36

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM117=LTDIE_7_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM117
	.byte 1,105,3
	.asciz "registrationName"

LDIFF_SYM118=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM118
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM119=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM119
	.byte 1,104,11
	.asciz "V_1"

LDIFF_SYM120=LTDIE_8_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM120
	.byte 1,103,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM121=Lfde18_end - Lfde18_start
	.long LDIFF_SYM121
Lfde18_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBLocalStorage_GetStoredRegistrationEntry_string

LDIFF_SYM122=Lme_36 - WindowsAzure_Messaging_SBLocalStorage_GetStoredRegistrationEntry_string
	.long LDIFF_SYM122
	.long 0
	.byte 12,31,0,68,14,112,157,14,158,13,68,13,29,68,151,12,152,11,68,153,10,154,9
	.align 3
Lfde18_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBLocalStorage:RefreshFinished"
	.asciz "WindowsAzure_Messaging_SBLocalStorage_RefreshFinished_string"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBLocalStorage_RefreshFinished_string
	.quad Lme_37

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM123=LTDIE_7_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM123
	.byte 1,105,3
	.asciz "newDeviceToken"

LDIFF_SYM124=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM124
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM125=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM125
	.byte 1,104,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM126=Lfde19_end - Lfde19_start
	.long LDIFF_SYM126
Lfde19_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBLocalStorage_RefreshFinished_string

LDIFF_SYM127=Lme_37 - WindowsAzure_Messaging_SBLocalStorage_RefreshFinished_string
	.long LDIFF_SYM127
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29,68,152,8,153,7,68,154,6
	.align 3
Lfde19_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_9:

	.byte 5
	.asciz "WindowsAzure_Messaging_SBRegistration"

	.byte 56,16
LDIFF_SYM128=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM128
	.byte 2,35,0,6
	.asciz "__mt_ExpiresAt_var"

LDIFF_SYM129=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM129
	.byte 2,35,40,6
	.asciz "__mt_Tags_var"

LDIFF_SYM130=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM130
	.byte 2,35,48,0,7
	.asciz "WindowsAzure_Messaging_SBRegistration"

LDIFF_SYM131=LTDIE_9 - Ldebug_info_start
	.long LDIFF_SYM131
LTDIE_9_POINTER:

	.byte 13
LDIFF_SYM132=LTDIE_9 - Ldebug_info_start
	.long LDIFF_SYM132
LTDIE_9_REFERENCE:

	.byte 14
LDIFF_SYM133=LTDIE_9 - Ldebug_info_start
	.long LDIFF_SYM133
	.byte 2
	.asciz "WindowsAzure.Messaging.SBLocalStorage:Update"
	.asciz "WindowsAzure_Messaging_SBLocalStorage_Update_string_WindowsAzure_Messaging_SBRegistration"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBLocalStorage_Update_string_WindowsAzure_Messaging_SBRegistration
	.quad Lme_38

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM134=LTDIE_7_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM134
	.byte 1,104,3
	.asciz "registrationName"

LDIFF_SYM135=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM135
	.byte 1,105,3
	.asciz "registration"

LDIFF_SYM136=LTDIE_9_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM136
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM137=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM137
	.byte 1,103,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM138=Lfde20_end - Lfde20_start
	.long LDIFF_SYM138
Lfde20_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBLocalStorage_Update_string_WindowsAzure_Messaging_SBRegistration

LDIFF_SYM139=Lme_38 - WindowsAzure_Messaging_SBLocalStorage_Update_string_WindowsAzure_Messaging_SBRegistration
	.long LDIFF_SYM139
	.long 0
	.byte 12,31,0,68,14,112,157,14,158,13,68,13,29,68,151,12,152,11,68,153,10,154,9
	.align 3
Lfde20_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBLocalStorage:Update"
	.asciz "WindowsAzure_Messaging_SBLocalStorage_Update_string_string_string_string"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBLocalStorage_Update_string_string_string_string
	.quad Lme_39

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM140=LTDIE_7_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM140
	.byte 1,102,3
	.asciz "registrationName"

LDIFF_SYM141=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM141
	.byte 1,103,3
	.asciz "registrationId"

LDIFF_SYM142=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM142
	.byte 1,104,3
	.asciz "eTag"

LDIFF_SYM143=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM143
	.byte 1,105,3
	.asciz "deviceToken"

LDIFF_SYM144=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM144
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM145=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM145
	.byte 1,101,11
	.asciz "V_1"

LDIFF_SYM146=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM146
	.byte 1,100,11
	.asciz "V_2"

LDIFF_SYM147=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM147
	.byte 1,99,11
	.asciz "V_3"

LDIFF_SYM148=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM148
	.byte 3,141,232,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM149=Lfde21_end - Lfde21_start
	.long LDIFF_SYM149
Lfde21_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBLocalStorage_Update_string_string_string_string

LDIFF_SYM150=Lme_39 - WindowsAzure_Messaging_SBLocalStorage_Update_string_string_string_string
	.long LDIFF_SYM150
	.long 0
	.byte 12,31,0,68,14,160,1,157,20,158,19,68,13,29,68,147,18,148,17,68,149,16,150,15,68,151,14,152,13,68,153,12
	.byte 154,11
	.align 3
Lfde21_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBLocalStorage:Update"
	.asciz "WindowsAzure_Messaging_SBLocalStorage_Update_string"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBLocalStorage_Update_string
	.quad Lme_3a

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM151=LTDIE_7_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM151
	.byte 1,105,3
	.asciz "registrationName"

LDIFF_SYM152=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM152
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM153=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM153
	.byte 1,104,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM154=Lfde22_end - Lfde22_start
	.long LDIFF_SYM154
Lfde22_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBLocalStorage_Update_string

LDIFF_SYM155=Lme_3a - WindowsAzure_Messaging_SBLocalStorage_Update_string
	.long LDIFF_SYM155
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29,68,152,8,153,7,68,154,6
	.align 3
Lfde22_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBLocalStorage:Update"
	.asciz "WindowsAzure_Messaging_SBLocalStorage_Update_WindowsAzure_Messaging_SBRegistration"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBLocalStorage_Update_WindowsAzure_Messaging_SBRegistration
	.quad Lme_3b

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM156=LTDIE_7_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM156
	.byte 1,105,3
	.asciz "registration"

LDIFF_SYM157=LTDIE_9_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM157
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM158=Lfde23_end - Lfde23_start
	.long LDIFF_SYM158
Lfde23_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBLocalStorage_Update_WindowsAzure_Messaging_SBRegistration

LDIFF_SYM159=Lme_3b - WindowsAzure_Messaging_SBLocalStorage_Update_WindowsAzure_Messaging_SBRegistration
	.long LDIFF_SYM159
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10,154,9
	.align 3
Lfde23_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBLocalStorage:get_DeviceToken"
	.asciz "WindowsAzure_Messaging_SBLocalStorage_get_DeviceToken"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBLocalStorage_get_DeviceToken
	.quad Lme_3c

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM160=LTDIE_7_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM160
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM161=Lfde24_end - Lfde24_start
	.long LDIFF_SYM161
Lfde24_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBLocalStorage_get_DeviceToken

LDIFF_SYM162=Lme_3c - WindowsAzure_Messaging_SBLocalStorage_get_DeviceToken
	.long LDIFF_SYM162
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29,68,154,8
	.align 3
Lfde24_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBLocalStorage:set_DeviceToken"
	.asciz "WindowsAzure_Messaging_SBLocalStorage_set_DeviceToken_string"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBLocalStorage_set_DeviceToken_string
	.quad Lme_3d

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM163=LTDIE_7_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM163
	.byte 1,105,3
	.asciz "value"

LDIFF_SYM164=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM164
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM165=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM165
	.byte 1,104,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM166=Lfde25_end - Lfde25_start
	.long LDIFF_SYM166
Lfde25_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBLocalStorage_set_DeviceToken_string

LDIFF_SYM167=Lme_3d - WindowsAzure_Messaging_SBLocalStorage_set_DeviceToken_string
	.long LDIFF_SYM167
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29,68,152,8,153,7,68,154,6
	.align 3
Lfde25_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBLocalStorage:get_IsRefreshNeeded"
	.asciz "WindowsAzure_Messaging_SBLocalStorage_get_IsRefreshNeeded"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBLocalStorage_get_IsRefreshNeeded
	.quad Lme_3e

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM168=LTDIE_7_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM168
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM169=Lfde26_end - Lfde26_start
	.long LDIFF_SYM169
Lfde26_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBLocalStorage_get_IsRefreshNeeded

LDIFF_SYM170=Lme_3e - WindowsAzure_Messaging_SBLocalStorage_get_IsRefreshNeeded
	.long LDIFF_SYM170
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29,68,154,8
	.align 3
Lfde26_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_11:

	.byte 5
	.asciz "System_ValueType"

	.byte 16,16
LDIFF_SYM171=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM171
	.byte 2,35,0,0,7
	.asciz "System_ValueType"

LDIFF_SYM172=LTDIE_11 - Ldebug_info_start
	.long LDIFF_SYM172
LTDIE_11_POINTER:

	.byte 13
LDIFF_SYM173=LTDIE_11 - Ldebug_info_start
	.long LDIFF_SYM173
LTDIE_11_REFERENCE:

	.byte 14
LDIFF_SYM174=LTDIE_11 - Ldebug_info_start
	.long LDIFF_SYM174
LTDIE_10:

	.byte 5
	.asciz "System_Boolean"

	.byte 17,16
LDIFF_SYM175=LTDIE_11 - Ldebug_info_start
	.long LDIFF_SYM175
	.byte 2,35,0,6
	.asciz "m_value"

LDIFF_SYM176=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM176
	.byte 2,35,16,0,7
	.asciz "System_Boolean"

LDIFF_SYM177=LTDIE_10 - Ldebug_info_start
	.long LDIFF_SYM177
LTDIE_10_POINTER:

	.byte 13
LDIFF_SYM178=LTDIE_10 - Ldebug_info_start
	.long LDIFF_SYM178
LTDIE_10_REFERENCE:

	.byte 14
LDIFF_SYM179=LTDIE_10 - Ldebug_info_start
	.long LDIFF_SYM179
	.byte 2
	.asciz "WindowsAzure.Messaging.SBLocalStorage:set_IsRefreshNeeded"
	.asciz "WindowsAzure_Messaging_SBLocalStorage_set_IsRefreshNeeded_bool"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBLocalStorage_set_IsRefreshNeeded_bool
	.quad Lme_3f

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM180=LTDIE_7_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM180
	.byte 1,105,3
	.asciz "value"

LDIFF_SYM181=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM181
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM182=Lfde27_end - Lfde27_start
	.long LDIFF_SYM182
Lfde27_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBLocalStorage_set_IsRefreshNeeded_bool

LDIFF_SYM183=Lme_3f - WindowsAzure_Messaging_SBLocalStorage_set_IsRefreshNeeded_bool
	.long LDIFF_SYM183
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29,68,153,8,154,7
	.align 3
Lfde27_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBLocalStorage:.cctor"
	.asciz "WindowsAzure_Messaging_SBLocalStorage__cctor"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBLocalStorage__cctor
	.quad Lme_40

	.byte 2,118,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM184=Lfde28_end - Lfde28_start
	.long LDIFF_SYM184
Lfde28_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBLocalStorage__cctor

LDIFF_SYM185=Lme_40 - WindowsAzure_Messaging_SBLocalStorage__cctor
	.long LDIFF_SYM185
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29
	.align 3
Lfde28_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_12:

	.byte 5
	.asciz "WindowsAzure_Messaging_SBNotificationHub"

	.byte 40,16
LDIFF_SYM186=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM186
	.byte 2,35,0,0,7
	.asciz "WindowsAzure_Messaging_SBNotificationHub"

LDIFF_SYM187=LTDIE_12 - Ldebug_info_start
	.long LDIFF_SYM187
LTDIE_12_POINTER:

	.byte 13
LDIFF_SYM188=LTDIE_12 - Ldebug_info_start
	.long LDIFF_SYM188
LTDIE_12_REFERENCE:

	.byte 14
LDIFF_SYM189=LTDIE_12 - Ldebug_info_start
	.long LDIFF_SYM189
	.byte 2
	.asciz "WindowsAzure.Messaging.SBNotificationHub:.ctor"
	.asciz "WindowsAzure_Messaging_SBNotificationHub__ctor"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBNotificationHub__ctor
	.quad Lme_41

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM190=LTDIE_12_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM190
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM191=Lfde29_end - Lfde29_start
	.long LDIFF_SYM191
Lfde29_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBNotificationHub__ctor

LDIFF_SYM192=Lme_41 - WindowsAzure_Messaging_SBNotificationHub__ctor
	.long LDIFF_SYM192
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29,68,154,8
	.align 3
Lfde29_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBNotificationHub:.ctor"
	.asciz "WindowsAzure_Messaging_SBNotificationHub__ctor_Foundation_NSObjectFlag"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBNotificationHub__ctor_Foundation_NSObjectFlag
	.quad Lme_42

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM193=LTDIE_12_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM193
	.byte 1,105,3
	.asciz "t"

LDIFF_SYM194=LTDIE_5_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM194
	.byte 2,141,24,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM195=Lfde30_end - Lfde30_start
	.long LDIFF_SYM195
Lfde30_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBNotificationHub__ctor_Foundation_NSObjectFlag

LDIFF_SYM196=Lme_42 - WindowsAzure_Messaging_SBNotificationHub__ctor_Foundation_NSObjectFlag
	.long LDIFF_SYM196
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10
	.align 3
Lfde30_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBNotificationHub:.ctor"
	.asciz "WindowsAzure_Messaging_SBNotificationHub__ctor_intptr"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBNotificationHub__ctor_intptr
	.quad Lme_43

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM197=LTDIE_12_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM197
	.byte 1,105,3
	.asciz "handle"

LDIFF_SYM198=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM198
	.byte 2,141,24,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM199=Lfde31_end - Lfde31_start
	.long LDIFF_SYM199
Lfde31_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBNotificationHub__ctor_intptr

LDIFF_SYM200=Lme_43 - WindowsAzure_Messaging_SBNotificationHub__ctor_intptr
	.long LDIFF_SYM200
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10
	.align 3
Lfde31_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBNotificationHub:.ctor"
	.asciz "WindowsAzure_Messaging_SBNotificationHub__ctor_string_string"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBNotificationHub__ctor_string_string
	.quad Lme_44

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM201=LTDIE_12_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM201
	.byte 1,104,3
	.asciz "connectionString"

LDIFF_SYM202=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM202
	.byte 1,105,3
	.asciz "notificationHubPath"

LDIFF_SYM203=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM203
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM204=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM204
	.byte 1,103,11
	.asciz "V_1"

LDIFF_SYM205=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM205
	.byte 1,102,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM206=Lfde32_end - Lfde32_start
	.long LDIFF_SYM206
Lfde32_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBNotificationHub__ctor_string_string

LDIFF_SYM207=Lme_44 - WindowsAzure_Messaging_SBNotificationHub__ctor_string_string
	.long LDIFF_SYM207
	.long 0
	.byte 12,31,0,68,14,128,1,157,16,158,15,68,13,29,68,150,14,151,13,68,152,12,153,11,68,154,10
	.align 3
Lfde32_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBNotificationHub:get_ClassHandle"
	.asciz "WindowsAzure_Messaging_SBNotificationHub_get_ClassHandle"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBNotificationHub_get_ClassHandle
	.quad Lme_45

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM208=LTDIE_12_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM208
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM209=Lfde33_end - Lfde33_start
	.long LDIFF_SYM209
Lfde33_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBNotificationHub_get_ClassHandle

LDIFF_SYM210=Lme_45 - WindowsAzure_Messaging_SBNotificationHub_get_ClassHandle
	.long LDIFF_SYM210
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29
	.align 3
Lfde33_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_13:

	.byte 5
	.asciz "Foundation_NSData"

	.byte 40,16
LDIFF_SYM211=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM211
	.byte 2,35,0,0,7
	.asciz "Foundation_NSData"

LDIFF_SYM212=LTDIE_13 - Ldebug_info_start
	.long LDIFF_SYM212
LTDIE_13_POINTER:

	.byte 13
LDIFF_SYM213=LTDIE_13 - Ldebug_info_start
	.long LDIFF_SYM213
LTDIE_13_REFERENCE:

	.byte 14
LDIFF_SYM214=LTDIE_13 - Ldebug_info_start
	.long LDIFF_SYM214
LTDIE_14:

	.byte 5
	.asciz "Foundation_NSSet"

	.byte 40,16
LDIFF_SYM215=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM215
	.byte 2,35,0,0,7
	.asciz "Foundation_NSSet"

LDIFF_SYM216=LTDIE_14 - Ldebug_info_start
	.long LDIFF_SYM216
LTDIE_14_POINTER:

	.byte 13
LDIFF_SYM217=LTDIE_14 - Ldebug_info_start
	.long LDIFF_SYM217
LTDIE_14_REFERENCE:

	.byte 14
LDIFF_SYM218=LTDIE_14 - Ldebug_info_start
	.long LDIFF_SYM218
LTDIE_15:

	.byte 5
	.asciz "Foundation_NSError"

	.byte 40,16
LDIFF_SYM219=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM219
	.byte 2,35,0,0,7
	.asciz "Foundation_NSError"

LDIFF_SYM220=LTDIE_15 - Ldebug_info_start
	.long LDIFF_SYM220
LTDIE_15_POINTER:

	.byte 13
LDIFF_SYM221=LTDIE_15 - Ldebug_info_start
	.long LDIFF_SYM221
LTDIE_15_REFERENCE:

	.byte 14
LDIFF_SYM222=LTDIE_15 - Ldebug_info_start
	.long LDIFF_SYM222
	.byte 2
	.asciz "WindowsAzure.Messaging.SBNotificationHub:RegisterNative"
	.asciz "WindowsAzure_Messaging_SBNotificationHub_RegisterNative_Foundation_NSData_Foundation_NSSet_Foundation_NSError_"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBNotificationHub_RegisterNative_Foundation_NSData_Foundation_NSSet_Foundation_NSError_
	.quad Lme_46

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM223=LTDIE_12_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM223
	.byte 1,103,3
	.asciz "deviceToken"

LDIFF_SYM224=LTDIE_13_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM224
	.byte 1,104,3
	.asciz "tags"

LDIFF_SYM225=LTDIE_14_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM225
	.byte 1,105,3
	.asciz "error"

LDIFF_SYM226=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM226
	.byte 3,141,208,0,11
	.asciz "V_0"

LDIFF_SYM227=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM227
	.byte 3,141,240,0,11
	.asciz "V_1"

LDIFF_SYM228=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM228
	.byte 1,102,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM229=Lfde34_end - Lfde34_start
	.long LDIFF_SYM229
Lfde34_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBNotificationHub_RegisterNative_Foundation_NSData_Foundation_NSSet_Foundation_NSError_

LDIFF_SYM230=Lme_46 - WindowsAzure_Messaging_SBNotificationHub_RegisterNative_Foundation_NSData_Foundation_NSSet_Foundation_NSError_
	.long LDIFF_SYM230
	.long 0
	.byte 12,31,0,68,14,160,1,157,20,158,19,68,13,29,68,147,18,148,17,68,149,16,150,15,68,151,14,152,13,68,153,12
	.byte 154,11
	.align 3
Lfde34_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_21:

	.byte 5
	.asciz "System_Reflection_MemberInfo"

	.byte 16,16
LDIFF_SYM231=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM231
	.byte 2,35,0,0,7
	.asciz "System_Reflection_MemberInfo"

LDIFF_SYM232=LTDIE_21 - Ldebug_info_start
	.long LDIFF_SYM232
LTDIE_21_POINTER:

	.byte 13
LDIFF_SYM233=LTDIE_21 - Ldebug_info_start
	.long LDIFF_SYM233
LTDIE_21_REFERENCE:

	.byte 14
LDIFF_SYM234=LTDIE_21 - Ldebug_info_start
	.long LDIFF_SYM234
LTDIE_20:

	.byte 5
	.asciz "System_Reflection_MethodBase"

	.byte 16,16
LDIFF_SYM235=LTDIE_21 - Ldebug_info_start
	.long LDIFF_SYM235
	.byte 2,35,0,0,7
	.asciz "System_Reflection_MethodBase"

LDIFF_SYM236=LTDIE_20 - Ldebug_info_start
	.long LDIFF_SYM236
LTDIE_20_POINTER:

	.byte 13
LDIFF_SYM237=LTDIE_20 - Ldebug_info_start
	.long LDIFF_SYM237
LTDIE_20_REFERENCE:

	.byte 14
LDIFF_SYM238=LTDIE_20 - Ldebug_info_start
	.long LDIFF_SYM238
LTDIE_19:

	.byte 5
	.asciz "System_Reflection_MethodInfo"

	.byte 16,16
LDIFF_SYM239=LTDIE_20 - Ldebug_info_start
	.long LDIFF_SYM239
	.byte 2,35,0,0,7
	.asciz "System_Reflection_MethodInfo"

LDIFF_SYM240=LTDIE_19 - Ldebug_info_start
	.long LDIFF_SYM240
LTDIE_19_POINTER:

	.byte 13
LDIFF_SYM241=LTDIE_19 - Ldebug_info_start
	.long LDIFF_SYM241
LTDIE_19_REFERENCE:

	.byte 14
LDIFF_SYM242=LTDIE_19 - Ldebug_info_start
	.long LDIFF_SYM242
LTDIE_23:

	.byte 5
	.asciz "System_Type"

	.byte 24,16
LDIFF_SYM243=LTDIE_21 - Ldebug_info_start
	.long LDIFF_SYM243
	.byte 2,35,0,6
	.asciz "_impl"

LDIFF_SYM244=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM244
	.byte 2,35,16,0,7
	.asciz "System_Type"

LDIFF_SYM245=LTDIE_23 - Ldebug_info_start
	.long LDIFF_SYM245
LTDIE_23_POINTER:

	.byte 13
LDIFF_SYM246=LTDIE_23 - Ldebug_info_start
	.long LDIFF_SYM246
LTDIE_23_REFERENCE:

	.byte 14
LDIFF_SYM247=LTDIE_23 - Ldebug_info_start
	.long LDIFF_SYM247
LTDIE_22:

	.byte 5
	.asciz "System_DelegateData"

	.byte 40,16
LDIFF_SYM248=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM248
	.byte 2,35,0,6
	.asciz "target_type"

LDIFF_SYM249=LTDIE_23_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM249
	.byte 2,35,16,6
	.asciz "method_name"

LDIFF_SYM250=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM250
	.byte 2,35,24,6
	.asciz "curried_first_arg"

LDIFF_SYM251=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM251
	.byte 2,35,32,0,7
	.asciz "System_DelegateData"

LDIFF_SYM252=LTDIE_22 - Ldebug_info_start
	.long LDIFF_SYM252
LTDIE_22_POINTER:

	.byte 13
LDIFF_SYM253=LTDIE_22 - Ldebug_info_start
	.long LDIFF_SYM253
LTDIE_22_REFERENCE:

	.byte 14
LDIFF_SYM254=LTDIE_22 - Ldebug_info_start
	.long LDIFF_SYM254
LTDIE_18:

	.byte 5
	.asciz "System_Delegate"

	.byte 104,16
LDIFF_SYM255=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM255
	.byte 2,35,0,6
	.asciz "method_ptr"

LDIFF_SYM256=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM256
	.byte 2,35,16,6
	.asciz "invoke_impl"

LDIFF_SYM257=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM257
	.byte 2,35,24,6
	.asciz "m_target"

LDIFF_SYM258=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM258
	.byte 2,35,32,6
	.asciz "method"

LDIFF_SYM259=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM259
	.byte 2,35,40,6
	.asciz "delegate_trampoline"

LDIFF_SYM260=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM260
	.byte 2,35,48,6
	.asciz "extra_arg"

LDIFF_SYM261=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM261
	.byte 2,35,56,6
	.asciz "method_code"

LDIFF_SYM262=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM262
	.byte 2,35,64,6
	.asciz "method_info"

LDIFF_SYM263=LTDIE_19_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM263
	.byte 2,35,72,6
	.asciz "original_method_info"

LDIFF_SYM264=LTDIE_19_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM264
	.byte 2,35,80,6
	.asciz "data"

LDIFF_SYM265=LTDIE_22_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM265
	.byte 2,35,88,6
	.asciz "method_is_virtual"

LDIFF_SYM266=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM266
	.byte 2,35,96,0,7
	.asciz "System_Delegate"

LDIFF_SYM267=LTDIE_18 - Ldebug_info_start
	.long LDIFF_SYM267
LTDIE_18_POINTER:

	.byte 13
LDIFF_SYM268=LTDIE_18 - Ldebug_info_start
	.long LDIFF_SYM268
LTDIE_18_REFERENCE:

	.byte 14
LDIFF_SYM269=LTDIE_18 - Ldebug_info_start
	.long LDIFF_SYM269
LTDIE_17:

	.byte 5
	.asciz "System_MulticastDelegate"

	.byte 112,16
LDIFF_SYM270=LTDIE_18 - Ldebug_info_start
	.long LDIFF_SYM270
	.byte 2,35,0,6
	.asciz "delegates"

LDIFF_SYM271=LDIE_SZARRAY - Ldebug_info_start
	.long LDIFF_SYM271
	.byte 2,35,104,0,7
	.asciz "System_MulticastDelegate"

LDIFF_SYM272=LTDIE_17 - Ldebug_info_start
	.long LDIFF_SYM272
LTDIE_17_POINTER:

	.byte 13
LDIFF_SYM273=LTDIE_17 - Ldebug_info_start
	.long LDIFF_SYM273
LTDIE_17_REFERENCE:

	.byte 14
LDIFF_SYM274=LTDIE_17 - Ldebug_info_start
	.long LDIFF_SYM274
LTDIE_16:

	.byte 5
	.asciz "WindowsAzure_Messaging_ErrorCallback"

	.byte 112,16
LDIFF_SYM275=LTDIE_17 - Ldebug_info_start
	.long LDIFF_SYM275
	.byte 2,35,0,0,7
	.asciz "WindowsAzure_Messaging_ErrorCallback"

LDIFF_SYM276=LTDIE_16 - Ldebug_info_start
	.long LDIFF_SYM276
LTDIE_16_POINTER:

	.byte 13
LDIFF_SYM277=LTDIE_16 - Ldebug_info_start
	.long LDIFF_SYM277
LTDIE_16_REFERENCE:

	.byte 14
LDIFF_SYM278=LTDIE_16 - Ldebug_info_start
	.long LDIFF_SYM278
	.byte 2
	.asciz "WindowsAzure.Messaging.SBNotificationHub:RegisterNativeAsync"
	.asciz "WindowsAzure_Messaging_SBNotificationHub_RegisterNativeAsync_Foundation_NSData_Foundation_NSSet_WindowsAzure_Messaging_ErrorCallback"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBNotificationHub_RegisterNativeAsync_Foundation_NSData_Foundation_NSSet_WindowsAzure_Messaging_ErrorCallback
	.quad Lme_47

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM279=LTDIE_12_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM279
	.byte 1,103,3
	.asciz "deviceToken"

LDIFF_SYM280=LTDIE_13_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM280
	.byte 1,104,3
	.asciz "tags"

LDIFF_SYM281=LTDIE_14_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM281
	.byte 1,105,3
	.asciz "errorCallback"

LDIFF_SYM282=LTDIE_16_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM282
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM283=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM283
	.byte 3,141,152,1,11
	.asciz "V_1"

LDIFF_SYM284=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM284
	.byte 3,141,232,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM285=Lfde35_end - Lfde35_start
	.long LDIFF_SYM285
Lfde35_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBNotificationHub_RegisterNativeAsync_Foundation_NSData_Foundation_NSSet_WindowsAzure_Messaging_ErrorCallback

LDIFF_SYM286=Lme_47 - WindowsAzure_Messaging_SBNotificationHub_RegisterNativeAsync_Foundation_NSData_Foundation_NSSet_WindowsAzure_Messaging_ErrorCallback
	.long LDIFF_SYM286
	.long 0
	.byte 12,31,0,68,14,192,1,157,24,158,23,68,13,29,68,147,22,148,21,68,149,20,150,19,68,151,18,152,17,68,153,16
	.byte 154,15
	.align 3
Lfde35_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBNotificationHub:RegisterTemplate"
	.asciz "WindowsAzure_Messaging_SBNotificationHub_RegisterTemplate_Foundation_NSData_string_string_string_Foundation_NSSet_Foundation_NSError_"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBNotificationHub_RegisterTemplate_Foundation_NSData_string_string_string_Foundation_NSSet_Foundation_NSError_
	.quad Lme_48

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM287=LTDIE_12_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM287
	.byte 3,141,208,0,3
	.asciz "deviceToken"

LDIFF_SYM288=LTDIE_13_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM288
	.byte 3,141,216,0,3
	.asciz "templateName"

LDIFF_SYM289=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM289
	.byte 3,141,224,0,3
	.asciz "jsonBodyTemplate"

LDIFF_SYM290=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM290
	.byte 3,141,232,0,3
	.asciz "expiryTemplate"

LDIFF_SYM291=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM291
	.byte 3,141,240,0,3
	.asciz "tags"

LDIFF_SYM292=LTDIE_14_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM292
	.byte 3,141,248,0,3
	.asciz "error"

LDIFF_SYM293=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM293
	.byte 3,141,128,1,11
	.asciz "V_0"

LDIFF_SYM294=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM294
	.byte 3,141,160,1,11
	.asciz "V_1"

LDIFF_SYM295=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM295
	.byte 3,141,168,1,11
	.asciz "V_2"

LDIFF_SYM296=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM296
	.byte 1,106,11
	.asciz "V_3"

LDIFF_SYM297=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM297
	.byte 3,141,176,1,11
	.asciz "V_4"

LDIFF_SYM298=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM298
	.byte 3,141,184,1,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM299=Lfde36_end - Lfde36_start
	.long LDIFF_SYM299
Lfde36_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBNotificationHub_RegisterTemplate_Foundation_NSData_string_string_string_Foundation_NSSet_Foundation_NSError_

LDIFF_SYM300=Lme_48 - WindowsAzure_Messaging_SBNotificationHub_RegisterTemplate_Foundation_NSData_string_string_string_Foundation_NSSet_Foundation_NSError_
	.long LDIFF_SYM300
	.long 0
	.byte 12,31,0,68,14,240,1,157,30,158,29,68,13,29,68,147,28,148,27,68,149,26,150,25,68,151,24,152,23,68,153,22
	.byte 154,21
	.align 3
Lfde36_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBNotificationHub:RegisterTemplateAsync"
	.asciz "WindowsAzure_Messaging_SBNotificationHub_RegisterTemplateAsync_Foundation_NSData_string_string_string_Foundation_NSSet_WindowsAzure_Messaging_ErrorCallback"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBNotificationHub_RegisterTemplateAsync_Foundation_NSData_string_string_string_Foundation_NSSet_WindowsAzure_Messaging_ErrorCallback
	.quad Lme_49

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM301=LTDIE_12_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM301
	.byte 1,100,3
	.asciz "deviceToken"

LDIFF_SYM302=LTDIE_13_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM302
	.byte 1,101,3
	.asciz "name"

LDIFF_SYM303=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM303
	.byte 1,102,3
	.asciz "jsonBodyTemplate"

LDIFF_SYM304=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM304
	.byte 1,103,3
	.asciz "expiryTemplate"

LDIFF_SYM305=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM305
	.byte 1,104,3
	.asciz "tags"

LDIFF_SYM306=LTDIE_14_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM306
	.byte 1,105,3
	.asciz "errorCallback"

LDIFF_SYM307=LTDIE_16_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM307
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM308=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM308
	.byte 1,99,11
	.asciz "V_1"

LDIFF_SYM309=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM309
	.byte 3,141,152,1,11
	.asciz "V_2"

LDIFF_SYM310=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM310
	.byte 3,141,160,1,11
	.asciz "V_3"

LDIFF_SYM311=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM311
	.byte 3,141,168,1,11
	.asciz "V_4"

LDIFF_SYM312=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM312
	.byte 3,141,232,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM313=Lfde37_end - Lfde37_start
	.long LDIFF_SYM313
Lfde37_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBNotificationHub_RegisterTemplateAsync_Foundation_NSData_string_string_string_Foundation_NSSet_WindowsAzure_Messaging_ErrorCallback

LDIFF_SYM314=Lme_49 - WindowsAzure_Messaging_SBNotificationHub_RegisterTemplateAsync_Foundation_NSData_string_string_string_Foundation_NSSet_WindowsAzure_Messaging_ErrorCallback
	.long LDIFF_SYM314
	.long 0
	.byte 12,31,0,68,14,240,1,157,30,158,29,68,13,29,68,147,28,148,27,68,149,26,150,25,68,151,24,152,23,68,153,22
	.byte 154,21
	.align 3
Lfde37_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBNotificationHub:UnregisterAll"
	.asciz "WindowsAzure_Messaging_SBNotificationHub_UnregisterAll_Foundation_NSData_Foundation_NSError_"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBNotificationHub_UnregisterAll_Foundation_NSData_Foundation_NSError_
	.quad Lme_4a

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM315=LTDIE_12_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM315
	.byte 1,104,3
	.asciz "deviceToken"

LDIFF_SYM316=LTDIE_13_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM316
	.byte 1,105,3
	.asciz "error"

LDIFF_SYM317=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM317
	.byte 2,141,56,11
	.asciz "V_0"

LDIFF_SYM318=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM318
	.byte 3,141,216,0,11
	.asciz "V_1"

LDIFF_SYM319=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM319
	.byte 1,103,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM320=Lfde38_end - Lfde38_start
	.long LDIFF_SYM320
Lfde38_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBNotificationHub_UnregisterAll_Foundation_NSData_Foundation_NSError_

LDIFF_SYM321=Lme_4a - WindowsAzure_Messaging_SBNotificationHub_UnregisterAll_Foundation_NSData_Foundation_NSError_
	.long LDIFF_SYM321
	.long 0
	.byte 12,31,0,68,14,128,1,157,16,158,15,68,13,29,68,149,14,150,13,68,151,12,152,11,68,153,10
	.align 3
Lfde38_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBNotificationHub:UnregisterAllAsync"
	.asciz "WindowsAzure_Messaging_SBNotificationHub_UnregisterAllAsync_Foundation_NSData_WindowsAzure_Messaging_ErrorCallback"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBNotificationHub_UnregisterAllAsync_Foundation_NSData_WindowsAzure_Messaging_ErrorCallback
	.quad Lme_4b

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM322=LTDIE_12_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM322
	.byte 1,104,3
	.asciz "deviceToken"

LDIFF_SYM323=LTDIE_13_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM323
	.byte 1,105,3
	.asciz "errorCallback"

LDIFF_SYM324=LTDIE_16_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM324
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM325=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM325
	.byte 1,103,11
	.asciz "V_1"

LDIFF_SYM326=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM326
	.byte 3,141,200,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM327=Lfde39_end - Lfde39_start
	.long LDIFF_SYM327
Lfde39_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBNotificationHub_UnregisterAllAsync_Foundation_NSData_WindowsAzure_Messaging_ErrorCallback

LDIFF_SYM328=Lme_4b - WindowsAzure_Messaging_SBNotificationHub_UnregisterAllAsync_Foundation_NSData_WindowsAzure_Messaging_ErrorCallback
	.long LDIFF_SYM328
	.long 0
	.byte 12,31,0,68,14,160,1,157,20,158,19,68,13,29,68,151,18,152,17,68,153,16,154,15
	.align 3
Lfde39_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBNotificationHub:UnregisterNative"
	.asciz "WindowsAzure_Messaging_SBNotificationHub_UnregisterNative_Foundation_NSError_"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBNotificationHub_UnregisterNative_Foundation_NSError_
	.quad Lme_4c

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM329=LTDIE_12_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM329
	.byte 1,105,3
	.asciz "error"

LDIFF_SYM330=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM330
	.byte 2,141,48,11
	.asciz "V_0"

LDIFF_SYM331=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM331
	.byte 3,141,208,0,11
	.asciz "V_1"

LDIFF_SYM332=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM332
	.byte 1,104,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM333=Lfde40_end - Lfde40_start
	.long LDIFF_SYM333
Lfde40_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBNotificationHub_UnregisterNative_Foundation_NSError_

LDIFF_SYM334=Lme_4c - WindowsAzure_Messaging_SBNotificationHub_UnregisterNative_Foundation_NSError_
	.long LDIFF_SYM334
	.long 0
	.byte 12,31,0,68,14,128,1,157,16,158,15,68,13,29,68,150,14,151,13,68,152,12,153,11
	.align 3
Lfde40_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBNotificationHub:UnregisterNativeAsync"
	.asciz "WindowsAzure_Messaging_SBNotificationHub_UnregisterNativeAsync_WindowsAzure_Messaging_ErrorCallback"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBNotificationHub_UnregisterNativeAsync_WindowsAzure_Messaging_ErrorCallback
	.quad Lme_4d

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM335=LTDIE_12_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM335
	.byte 1,105,3
	.asciz "errorCallback"

LDIFF_SYM336=LTDIE_16_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM336
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM337=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM337
	.byte 1,104,11
	.asciz "V_1"

LDIFF_SYM338=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM338
	.byte 3,141,192,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM339=Lfde41_end - Lfde41_start
	.long LDIFF_SYM339
Lfde41_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBNotificationHub_UnregisterNativeAsync_WindowsAzure_Messaging_ErrorCallback

LDIFF_SYM340=Lme_4d - WindowsAzure_Messaging_SBNotificationHub_UnregisterNativeAsync_WindowsAzure_Messaging_ErrorCallback
	.long LDIFF_SYM340
	.long 0
	.byte 12,31,0,68,14,144,1,157,18,158,17,68,13,29,68,152,16,153,15,68,154,14
	.align 3
Lfde41_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBNotificationHub:UnregisterTemplate"
	.asciz "WindowsAzure_Messaging_SBNotificationHub_UnregisterTemplate_string_Foundation_NSError_"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBNotificationHub_UnregisterTemplate_string_Foundation_NSError_
	.quad Lme_4e

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM341=LTDIE_12_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM341
	.byte 1,104,3
	.asciz "name"

LDIFF_SYM342=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM342
	.byte 1,105,3
	.asciz "error"

LDIFF_SYM343=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM343
	.byte 3,141,192,0,11
	.asciz "V_0"

LDIFF_SYM344=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM344
	.byte 3,141,224,0,11
	.asciz "V_1"

LDIFF_SYM345=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM345
	.byte 1,103,11
	.asciz "V_2"

LDIFF_SYM346=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM346
	.byte 1,102,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM347=Lfde42_end - Lfde42_start
	.long LDIFF_SYM347
Lfde42_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBNotificationHub_UnregisterTemplate_string_Foundation_NSError_

LDIFF_SYM348=Lme_4e - WindowsAzure_Messaging_SBNotificationHub_UnregisterTemplate_string_Foundation_NSError_
	.long LDIFF_SYM348
	.long 0
	.byte 12,31,0,68,14,144,1,157,18,158,17,68,13,29,68,148,16,149,15,68,150,14,151,13,68,152,12,153,11
	.align 3
Lfde42_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBNotificationHub:UnregisterTemplateAsync"
	.asciz "WindowsAzure_Messaging_SBNotificationHub_UnregisterTemplateAsync_string_WindowsAzure_Messaging_ErrorCallback"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBNotificationHub_UnregisterTemplateAsync_string_WindowsAzure_Messaging_ErrorCallback
	.quad Lme_4f

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM349=LTDIE_12_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM349
	.byte 1,104,3
	.asciz "name"

LDIFF_SYM350=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM350
	.byte 1,105,3
	.asciz "errorCallback"

LDIFF_SYM351=LTDIE_16_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM351
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM352=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM352
	.byte 1,103,11
	.asciz "V_1"

LDIFF_SYM353=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM353
	.byte 1,102,11
	.asciz "V_2"

LDIFF_SYM354=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM354
	.byte 3,141,208,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM355=Lfde43_end - Lfde43_start
	.long LDIFF_SYM355
Lfde43_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBNotificationHub_UnregisterTemplateAsync_string_WindowsAzure_Messaging_ErrorCallback

LDIFF_SYM356=Lme_4f - WindowsAzure_Messaging_SBNotificationHub_UnregisterTemplateAsync_string_WindowsAzure_Messaging_ErrorCallback
	.long LDIFF_SYM356
	.long 0
	.byte 12,31,0,68,14,160,1,157,20,158,19,68,13,29,68,150,18,151,17,68,152,16,153,15,68,154,14
	.align 3
Lfde43_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBNotificationHub:get_Version"
	.asciz "WindowsAzure_Messaging_SBNotificationHub_get_Version"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBNotificationHub_get_Version
	.quad Lme_50

	.byte 2,118,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM357=Lfde44_end - Lfde44_start
	.long LDIFF_SYM357
Lfde44_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBNotificationHub_get_Version

LDIFF_SYM358=Lme_50 - WindowsAzure_Messaging_SBNotificationHub_get_Version
	.long LDIFF_SYM358
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29
	.align 3
Lfde44_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBNotificationHub:.cctor"
	.asciz "WindowsAzure_Messaging_SBNotificationHub__cctor"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBNotificationHub__cctor
	.quad Lme_51

	.byte 2,118,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM359=Lfde45_end - Lfde45_start
	.long LDIFF_SYM359
Lfde45_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBNotificationHub__cctor

LDIFF_SYM360=Lme_51 - WindowsAzure_Messaging_SBNotificationHub__cctor
	.long LDIFF_SYM360
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29
	.align 3
Lfde45_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBRegistration:.ctor"
	.asciz "WindowsAzure_Messaging_SBRegistration__ctor"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBRegistration__ctor
	.quad Lme_52

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM361=LTDIE_9_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM361
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM362=Lfde46_end - Lfde46_start
	.long LDIFF_SYM362
Lfde46_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBRegistration__ctor

LDIFF_SYM363=Lme_52 - WindowsAzure_Messaging_SBRegistration__ctor
	.long LDIFF_SYM363
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29,68,154,8
	.align 3
Lfde46_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBRegistration:.ctor"
	.asciz "WindowsAzure_Messaging_SBRegistration__ctor_Foundation_NSObjectFlag"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBRegistration__ctor_Foundation_NSObjectFlag
	.quad Lme_53

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM364=LTDIE_9_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM364
	.byte 1,105,3
	.asciz "t"

LDIFF_SYM365=LTDIE_5_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM365
	.byte 2,141,24,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM366=Lfde47_end - Lfde47_start
	.long LDIFF_SYM366
Lfde47_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBRegistration__ctor_Foundation_NSObjectFlag

LDIFF_SYM367=Lme_53 - WindowsAzure_Messaging_SBRegistration__ctor_Foundation_NSObjectFlag
	.long LDIFF_SYM367
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10
	.align 3
Lfde47_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBRegistration:.ctor"
	.asciz "WindowsAzure_Messaging_SBRegistration__ctor_intptr"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBRegistration__ctor_intptr
	.quad Lme_54

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM368=LTDIE_9_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM368
	.byte 1,105,3
	.asciz "handle"

LDIFF_SYM369=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM369
	.byte 2,141,24,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM370=Lfde48_end - Lfde48_start
	.long LDIFF_SYM370
Lfde48_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBRegistration__ctor_intptr

LDIFF_SYM371=Lme_54 - WindowsAzure_Messaging_SBRegistration__ctor_intptr
	.long LDIFF_SYM371
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10
	.align 3
Lfde48_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBRegistration:get_ClassHandle"
	.asciz "WindowsAzure_Messaging_SBRegistration_get_ClassHandle"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBRegistration_get_ClassHandle
	.quad Lme_55

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM372=LTDIE_9_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM372
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM373=Lfde49_end - Lfde49_start
	.long LDIFF_SYM373
Lfde49_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBRegistration_get_ClassHandle

LDIFF_SYM374=Lme_55 - WindowsAzure_Messaging_SBRegistration_get_ClassHandle
	.long LDIFF_SYM374
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29
	.align 3
Lfde49_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBRegistration:Name"
	.asciz "WindowsAzure_Messaging_SBRegistration_Name"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBRegistration_Name
	.quad Lme_56

	.byte 2,118,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM375=Lfde50_end - Lfde50_start
	.long LDIFF_SYM375
Lfde50_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBRegistration_Name

LDIFF_SYM376=Lme_56 - WindowsAzure_Messaging_SBRegistration_Name
	.long LDIFF_SYM376
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29
	.align 3
Lfde50_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBRegistration:Payload"
	.asciz "WindowsAzure_Messaging_SBRegistration_Payload_string_Foundation_NSSet"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBRegistration_Payload_string_Foundation_NSSet
	.quad Lme_57

	.byte 2,118,16,3
	.asciz "deviceToken"

LDIFF_SYM377=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM377
	.byte 1,105,3
	.asciz "tags"

LDIFF_SYM378=LTDIE_14_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM378
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM379=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM379
	.byte 1,104,11
	.asciz "V_1"

LDIFF_SYM380=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM380
	.byte 1,103,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM381=Lfde51_end - Lfde51_start
	.long LDIFF_SYM381
Lfde51_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBRegistration_Payload_string_Foundation_NSSet

LDIFF_SYM382=Lme_57 - WindowsAzure_Messaging_SBRegistration_Payload_string_Foundation_NSSet
	.long LDIFF_SYM382
	.long 0
	.byte 12,31,0,68,14,160,1,157,20,158,19,68,13,29,68,151,18,152,17,68,153,16,154,15
	.align 3
Lfde51_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBRegistration:get_DeviceToken"
	.asciz "WindowsAzure_Messaging_SBRegistration_get_DeviceToken"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBRegistration_get_DeviceToken
	.quad Lme_58

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM383=LTDIE_9_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM383
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM384=Lfde52_end - Lfde52_start
	.long LDIFF_SYM384
Lfde52_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBRegistration_get_DeviceToken

LDIFF_SYM385=Lme_58 - WindowsAzure_Messaging_SBRegistration_get_DeviceToken
	.long LDIFF_SYM385
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29,68,154,8
	.align 3
Lfde52_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBRegistration:set_DeviceToken"
	.asciz "WindowsAzure_Messaging_SBRegistration_set_DeviceToken_string"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBRegistration_set_DeviceToken_string
	.quad Lme_59

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM386=LTDIE_9_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM386
	.byte 1,105,3
	.asciz "value"

LDIFF_SYM387=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM387
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM388=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM388
	.byte 1,104,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM389=Lfde53_end - Lfde53_start
	.long LDIFF_SYM389
Lfde53_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBRegistration_set_DeviceToken_string

LDIFF_SYM390=Lme_59 - WindowsAzure_Messaging_SBRegistration_set_DeviceToken_string
	.long LDIFF_SYM390
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29,68,152,8,153,7,68,154,6
	.align 3
Lfde53_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBRegistration:get_ETag"
	.asciz "WindowsAzure_Messaging_SBRegistration_get_ETag"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBRegistration_get_ETag
	.quad Lme_5a

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM391=LTDIE_9_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM391
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM392=Lfde54_end - Lfde54_start
	.long LDIFF_SYM392
Lfde54_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBRegistration_get_ETag

LDIFF_SYM393=Lme_5a - WindowsAzure_Messaging_SBRegistration_get_ETag
	.long LDIFF_SYM393
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29,68,154,8
	.align 3
Lfde54_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBRegistration:set_ETag"
	.asciz "WindowsAzure_Messaging_SBRegistration_set_ETag_string"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBRegistration_set_ETag_string
	.quad Lme_5b

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM394=LTDIE_9_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM394
	.byte 1,105,3
	.asciz "value"

LDIFF_SYM395=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM395
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM396=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM396
	.byte 1,104,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM397=Lfde55_end - Lfde55_start
	.long LDIFF_SYM397
Lfde55_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBRegistration_set_ETag_string

LDIFF_SYM398=Lme_5b - WindowsAzure_Messaging_SBRegistration_set_ETag_string
	.long LDIFF_SYM398
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29,68,152,8,153,7,68,154,6
	.align 3
Lfde55_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_24:

	.byte 5
	.asciz "Foundation_NSDate"

	.byte 40,16
LDIFF_SYM399=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM399
	.byte 2,35,0,0,7
	.asciz "Foundation_NSDate"

LDIFF_SYM400=LTDIE_24 - Ldebug_info_start
	.long LDIFF_SYM400
LTDIE_24_POINTER:

	.byte 13
LDIFF_SYM401=LTDIE_24 - Ldebug_info_start
	.long LDIFF_SYM401
LTDIE_24_REFERENCE:

	.byte 14
LDIFF_SYM402=LTDIE_24 - Ldebug_info_start
	.long LDIFF_SYM402
	.byte 2
	.asciz "WindowsAzure.Messaging.SBRegistration:get_ExpiresAt"
	.asciz "WindowsAzure_Messaging_SBRegistration_get_ExpiresAt"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBRegistration_get_ExpiresAt
	.quad Lme_5c

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM403=LTDIE_9_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM403
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM404=LTDIE_24_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM404
	.byte 1,105,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM405=Lfde56_end - Lfde56_start
	.long LDIFF_SYM405
Lfde56_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBRegistration_get_ExpiresAt

LDIFF_SYM406=Lme_5c - WindowsAzure_Messaging_SBRegistration_get_ExpiresAt
	.long LDIFF_SYM406
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10,154,9
	.align 3
Lfde56_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBRegistration:set_ExpiresAt"
	.asciz "WindowsAzure_Messaging_SBRegistration_set_ExpiresAt_Foundation_NSDate"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBRegistration_set_ExpiresAt_Foundation_NSDate
	.quad Lme_5d

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM407=LTDIE_9_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM407
	.byte 1,105,3
	.asciz "value"

LDIFF_SYM408=LTDIE_24_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM408
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM409=Lfde57_end - Lfde57_start
	.long LDIFF_SYM409
Lfde57_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBRegistration_set_ExpiresAt_Foundation_NSDate

LDIFF_SYM410=Lme_5d - WindowsAzure_Messaging_SBRegistration_set_ExpiresAt_Foundation_NSDate
	.long LDIFF_SYM410
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10,154,9
	.align 3
Lfde57_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBRegistration:get_RegistrationId"
	.asciz "WindowsAzure_Messaging_SBRegistration_get_RegistrationId"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBRegistration_get_RegistrationId
	.quad Lme_5e

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM411=LTDIE_9_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM411
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM412=Lfde58_end - Lfde58_start
	.long LDIFF_SYM412
Lfde58_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBRegistration_get_RegistrationId

LDIFF_SYM413=Lme_5e - WindowsAzure_Messaging_SBRegistration_get_RegistrationId
	.long LDIFF_SYM413
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29,68,154,8
	.align 3
Lfde58_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBRegistration:set_RegistrationId"
	.asciz "WindowsAzure_Messaging_SBRegistration_set_RegistrationId_string"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBRegistration_set_RegistrationId_string
	.quad Lme_5f

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM414=LTDIE_9_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM414
	.byte 1,105,3
	.asciz "value"

LDIFF_SYM415=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM415
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM416=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM416
	.byte 1,104,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM417=Lfde59_end - Lfde59_start
	.long LDIFF_SYM417
Lfde59_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBRegistration_set_RegistrationId_string

LDIFF_SYM418=Lme_5f - WindowsAzure_Messaging_SBRegistration_set_RegistrationId_string
	.long LDIFF_SYM418
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29,68,152,8,153,7,68,154,6
	.align 3
Lfde59_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBRegistration:get_Tags"
	.asciz "WindowsAzure_Messaging_SBRegistration_get_Tags"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBRegistration_get_Tags
	.quad Lme_60

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM419=LTDIE_9_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM419
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM420=LTDIE_14_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM420
	.byte 1,105,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM421=Lfde60_end - Lfde60_start
	.long LDIFF_SYM421
Lfde60_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBRegistration_get_Tags

LDIFF_SYM422=Lme_60 - WindowsAzure_Messaging_SBRegistration_get_Tags
	.long LDIFF_SYM422
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10,154,9
	.align 3
Lfde60_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBRegistration:set_Tags"
	.asciz "WindowsAzure_Messaging_SBRegistration_set_Tags_Foundation_NSSet"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBRegistration_set_Tags_Foundation_NSSet
	.quad Lme_61

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM423=LTDIE_9_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM423
	.byte 1,105,3
	.asciz "value"

LDIFF_SYM424=LTDIE_14_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM424
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM425=Lfde61_end - Lfde61_start
	.long LDIFF_SYM425
Lfde61_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBRegistration_set_Tags_Foundation_NSSet

LDIFF_SYM426=Lme_61 - WindowsAzure_Messaging_SBRegistration_set_Tags_Foundation_NSSet
	.long LDIFF_SYM426
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10,154,9
	.align 3
Lfde61_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBRegistration:Dispose"
	.asciz "WindowsAzure_Messaging_SBRegistration_Dispose_bool"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBRegistration_Dispose_bool
	.quad Lme_62

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM427=LTDIE_9_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM427
	.byte 1,105,3
	.asciz "disposing"

LDIFF_SYM428=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM428
	.byte 2,141,24,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM429=Lfde62_end - Lfde62_start
	.long LDIFF_SYM429
Lfde62_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBRegistration_Dispose_bool

LDIFF_SYM430=Lme_62 - WindowsAzure_Messaging_SBRegistration_Dispose_bool
	.long LDIFF_SYM430
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29,68,153,8
	.align 3
Lfde62_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBRegistration:.cctor"
	.asciz "WindowsAzure_Messaging_SBRegistration__cctor"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBRegistration__cctor
	.quad Lme_63

	.byte 2,118,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM431=Lfde63_end - Lfde63_start
	.long LDIFF_SYM431
Lfde63_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBRegistration__cctor

LDIFF_SYM432=Lme_63 - WindowsAzure_Messaging_SBRegistration__cctor
	.long LDIFF_SYM432
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29
	.align 3
Lfde63_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.StoredRegistrationEntry:.ctor"
	.asciz "WindowsAzure_Messaging_StoredRegistrationEntry__ctor"

	.byte 0,0
	.quad WindowsAzure_Messaging_StoredRegistrationEntry__ctor
	.quad Lme_64

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM433=LTDIE_8_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM433
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM434=Lfde64_end - Lfde64_start
	.long LDIFF_SYM434
Lfde64_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_StoredRegistrationEntry__ctor

LDIFF_SYM435=Lme_64 - WindowsAzure_Messaging_StoredRegistrationEntry__ctor
	.long LDIFF_SYM435
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29,68,154,8
	.align 3
Lfde64_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.StoredRegistrationEntry:.ctor"
	.asciz "WindowsAzure_Messaging_StoredRegistrationEntry__ctor_Foundation_NSObjectFlag"

	.byte 0,0
	.quad WindowsAzure_Messaging_StoredRegistrationEntry__ctor_Foundation_NSObjectFlag
	.quad Lme_65

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM436=LTDIE_8_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM436
	.byte 1,105,3
	.asciz "t"

LDIFF_SYM437=LTDIE_5_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM437
	.byte 2,141,24,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM438=Lfde65_end - Lfde65_start
	.long LDIFF_SYM438
Lfde65_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_StoredRegistrationEntry__ctor_Foundation_NSObjectFlag

LDIFF_SYM439=Lme_65 - WindowsAzure_Messaging_StoredRegistrationEntry__ctor_Foundation_NSObjectFlag
	.long LDIFF_SYM439
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10
	.align 3
Lfde65_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.StoredRegistrationEntry:.ctor"
	.asciz "WindowsAzure_Messaging_StoredRegistrationEntry__ctor_intptr"

	.byte 0,0
	.quad WindowsAzure_Messaging_StoredRegistrationEntry__ctor_intptr
	.quad Lme_66

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM440=LTDIE_8_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM440
	.byte 1,105,3
	.asciz "handle"

LDIFF_SYM441=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM441
	.byte 2,141,24,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM442=Lfde66_end - Lfde66_start
	.long LDIFF_SYM442
Lfde66_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_StoredRegistrationEntry__ctor_intptr

LDIFF_SYM443=Lme_66 - WindowsAzure_Messaging_StoredRegistrationEntry__ctor_intptr
	.long LDIFF_SYM443
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10
	.align 3
Lfde66_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.StoredRegistrationEntry:.ctor"
	.asciz "WindowsAzure_Messaging_StoredRegistrationEntry__ctor_string"

	.byte 0,0
	.quad WindowsAzure_Messaging_StoredRegistrationEntry__ctor_string
	.quad Lme_67

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM444=LTDIE_8_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM444
	.byte 1,105,3
	.asciz "str"

LDIFF_SYM445=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM445
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM446=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM446
	.byte 1,104,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM447=Lfde67_end - Lfde67_start
	.long LDIFF_SYM447
Lfde67_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_StoredRegistrationEntry__ctor_string

LDIFF_SYM448=Lme_67 - WindowsAzure_Messaging_StoredRegistrationEntry__ctor_string
	.long LDIFF_SYM448
	.long 0
	.byte 12,31,0,68,14,112,157,14,158,13,68,13,29,68,152,12,153,11,68,154,10
	.align 3
Lfde67_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.StoredRegistrationEntry:get_ClassHandle"
	.asciz "WindowsAzure_Messaging_StoredRegistrationEntry_get_ClassHandle"

	.byte 0,0
	.quad WindowsAzure_Messaging_StoredRegistrationEntry_get_ClassHandle
	.quad Lme_68

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM449=LTDIE_8_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM449
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM450=Lfde68_end - Lfde68_start
	.long LDIFF_SYM450
Lfde68_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_StoredRegistrationEntry_get_ClassHandle

LDIFF_SYM451=Lme_68 - WindowsAzure_Messaging_StoredRegistrationEntry_get_ClassHandle
	.long LDIFF_SYM451
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29
	.align 3
Lfde68_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.StoredRegistrationEntry:AsString"
	.asciz "WindowsAzure_Messaging_StoredRegistrationEntry_AsString"

	.byte 0,0
	.quad WindowsAzure_Messaging_StoredRegistrationEntry_AsString
	.quad Lme_69

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM452=LTDIE_8_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM452
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM453=Lfde69_end - Lfde69_start
	.long LDIFF_SYM453
Lfde69_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_StoredRegistrationEntry_AsString

LDIFF_SYM454=Lme_69 - WindowsAzure_Messaging_StoredRegistrationEntry_AsString
	.long LDIFF_SYM454
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29,68,154,8
	.align 3
Lfde69_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.StoredRegistrationEntry:get_ETag"
	.asciz "WindowsAzure_Messaging_StoredRegistrationEntry_get_ETag"

	.byte 0,0
	.quad WindowsAzure_Messaging_StoredRegistrationEntry_get_ETag
	.quad Lme_6a

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM455=LTDIE_8_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM455
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM456=Lfde70_end - Lfde70_start
	.long LDIFF_SYM456
Lfde70_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_StoredRegistrationEntry_get_ETag

LDIFF_SYM457=Lme_6a - WindowsAzure_Messaging_StoredRegistrationEntry_get_ETag
	.long LDIFF_SYM457
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29,68,154,8
	.align 3
Lfde70_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.StoredRegistrationEntry:set_ETag"
	.asciz "WindowsAzure_Messaging_StoredRegistrationEntry_set_ETag_string"

	.byte 0,0
	.quad WindowsAzure_Messaging_StoredRegistrationEntry_set_ETag_string
	.quad Lme_6b

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM458=LTDIE_8_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM458
	.byte 1,105,3
	.asciz "value"

LDIFF_SYM459=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM459
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM460=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM460
	.byte 1,104,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM461=Lfde71_end - Lfde71_start
	.long LDIFF_SYM461
Lfde71_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_StoredRegistrationEntry_set_ETag_string

LDIFF_SYM462=Lme_6b - WindowsAzure_Messaging_StoredRegistrationEntry_set_ETag_string
	.long LDIFF_SYM462
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29,68,152,8,153,7,68,154,6
	.align 3
Lfde71_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.StoredRegistrationEntry:get_RegistrationId"
	.asciz "WindowsAzure_Messaging_StoredRegistrationEntry_get_RegistrationId"

	.byte 0,0
	.quad WindowsAzure_Messaging_StoredRegistrationEntry_get_RegistrationId
	.quad Lme_6c

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM463=LTDIE_8_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM463
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM464=Lfde72_end - Lfde72_start
	.long LDIFF_SYM464
Lfde72_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_StoredRegistrationEntry_get_RegistrationId

LDIFF_SYM465=Lme_6c - WindowsAzure_Messaging_StoredRegistrationEntry_get_RegistrationId
	.long LDIFF_SYM465
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29,68,154,8
	.align 3
Lfde72_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.StoredRegistrationEntry:set_RegistrationId"
	.asciz "WindowsAzure_Messaging_StoredRegistrationEntry_set_RegistrationId_string"

	.byte 0,0
	.quad WindowsAzure_Messaging_StoredRegistrationEntry_set_RegistrationId_string
	.quad Lme_6d

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM466=LTDIE_8_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM466
	.byte 1,105,3
	.asciz "value"

LDIFF_SYM467=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM467
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM468=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM468
	.byte 1,104,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM469=Lfde73_end - Lfde73_start
	.long LDIFF_SYM469
Lfde73_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_StoredRegistrationEntry_set_RegistrationId_string

LDIFF_SYM470=Lme_6d - WindowsAzure_Messaging_StoredRegistrationEntry_set_RegistrationId_string
	.long LDIFF_SYM470
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29,68,152,8,153,7,68,154,6
	.align 3
Lfde73_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.StoredRegistrationEntry:get_RegistrationName"
	.asciz "WindowsAzure_Messaging_StoredRegistrationEntry_get_RegistrationName"

	.byte 0,0
	.quad WindowsAzure_Messaging_StoredRegistrationEntry_get_RegistrationName
	.quad Lme_6e

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM471=LTDIE_8_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM471
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM472=Lfde74_end - Lfde74_start
	.long LDIFF_SYM472
Lfde74_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_StoredRegistrationEntry_get_RegistrationName

LDIFF_SYM473=Lme_6e - WindowsAzure_Messaging_StoredRegistrationEntry_get_RegistrationName
	.long LDIFF_SYM473
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29,68,154,8
	.align 3
Lfde74_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.StoredRegistrationEntry:set_RegistrationName"
	.asciz "WindowsAzure_Messaging_StoredRegistrationEntry_set_RegistrationName_string"

	.byte 0,0
	.quad WindowsAzure_Messaging_StoredRegistrationEntry_set_RegistrationName_string
	.quad Lme_6f

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM474=LTDIE_8_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM474
	.byte 1,105,3
	.asciz "value"

LDIFF_SYM475=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM475
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM476=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM476
	.byte 1,104,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM477=Lfde75_end - Lfde75_start
	.long LDIFF_SYM477
Lfde75_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_StoredRegistrationEntry_set_RegistrationName_string

LDIFF_SYM478=Lme_6f - WindowsAzure_Messaging_StoredRegistrationEntry_set_RegistrationName_string
	.long LDIFF_SYM478
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29,68,152,8,153,7,68,154,6
	.align 3
Lfde75_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.StoredRegistrationEntry:.cctor"
	.asciz "WindowsAzure_Messaging_StoredRegistrationEntry__cctor"

	.byte 0,0
	.quad WindowsAzure_Messaging_StoredRegistrationEntry__cctor
	.quad Lme_70

	.byte 2,118,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM479=Lfde76_end - Lfde76_start
	.long LDIFF_SYM479
Lfde76_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_StoredRegistrationEntry__cctor

LDIFF_SYM480=Lme_70 - WindowsAzure_Messaging_StoredRegistrationEntry__cctor
	.long LDIFF_SYM480
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29
	.align 3
Lfde76_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_25:

	.byte 5
	.asciz "WindowsAzure_Messaging_SBTokenProvider"

	.byte 40,16
LDIFF_SYM481=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM481
	.byte 2,35,0,0,7
	.asciz "WindowsAzure_Messaging_SBTokenProvider"

LDIFF_SYM482=LTDIE_25 - Ldebug_info_start
	.long LDIFF_SYM482
LTDIE_25_POINTER:

	.byte 13
LDIFF_SYM483=LTDIE_25 - Ldebug_info_start
	.long LDIFF_SYM483
LTDIE_25_REFERENCE:

	.byte 14
LDIFF_SYM484=LTDIE_25 - Ldebug_info_start
	.long LDIFF_SYM484
	.byte 2
	.asciz "WindowsAzure.Messaging.SBTokenProvider:.ctor"
	.asciz "WindowsAzure_Messaging_SBTokenProvider__ctor"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBTokenProvider__ctor
	.quad Lme_71

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM485=LTDIE_25_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM485
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM486=Lfde77_end - Lfde77_start
	.long LDIFF_SYM486
Lfde77_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBTokenProvider__ctor

LDIFF_SYM487=Lme_71 - WindowsAzure_Messaging_SBTokenProvider__ctor
	.long LDIFF_SYM487
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29,68,154,8
	.align 3
Lfde77_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBTokenProvider:.ctor"
	.asciz "WindowsAzure_Messaging_SBTokenProvider__ctor_Foundation_NSObjectFlag"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBTokenProvider__ctor_Foundation_NSObjectFlag
	.quad Lme_72

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM488=LTDIE_25_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM488
	.byte 1,105,3
	.asciz "t"

LDIFF_SYM489=LTDIE_5_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM489
	.byte 2,141,24,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM490=Lfde78_end - Lfde78_start
	.long LDIFF_SYM490
Lfde78_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBTokenProvider__ctor_Foundation_NSObjectFlag

LDIFF_SYM491=Lme_72 - WindowsAzure_Messaging_SBTokenProvider__ctor_Foundation_NSObjectFlag
	.long LDIFF_SYM491
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10
	.align 3
Lfde78_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBTokenProvider:.ctor"
	.asciz "WindowsAzure_Messaging_SBTokenProvider__ctor_intptr"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBTokenProvider__ctor_intptr
	.quad Lme_73

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM492=LTDIE_25_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM492
	.byte 1,105,3
	.asciz "handle"

LDIFF_SYM493=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM493
	.byte 2,141,24,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM494=Lfde79_end - Lfde79_start
	.long LDIFF_SYM494
Lfde79_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBTokenProvider__ctor_intptr

LDIFF_SYM495=Lme_73 - WindowsAzure_Messaging_SBTokenProvider__ctor_intptr
	.long LDIFF_SYM495
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10
	.align 3
Lfde79_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBTokenProvider:get_ClassHandle"
	.asciz "WindowsAzure_Messaging_SBTokenProvider_get_ClassHandle"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBTokenProvider_get_ClassHandle
	.quad Lme_74

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM496=LTDIE_25_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM496
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM497=Lfde80_end - Lfde80_start
	.long LDIFF_SYM497
Lfde80_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBTokenProvider_get_ClassHandle

LDIFF_SYM498=Lme_74 - WindowsAzure_Messaging_SBTokenProvider_get_ClassHandle
	.long LDIFF_SYM498
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29
	.align 3
Lfde80_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_27:

	.byte 5
	.asciz "Foundation_NSUrlRequest"

	.byte 40,16
LDIFF_SYM499=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM499
	.byte 2,35,0,0,7
	.asciz "Foundation_NSUrlRequest"

LDIFF_SYM500=LTDIE_27 - Ldebug_info_start
	.long LDIFF_SYM500
LTDIE_27_POINTER:

	.byte 13
LDIFF_SYM501=LTDIE_27 - Ldebug_info_start
	.long LDIFF_SYM501
LTDIE_27_REFERENCE:

	.byte 14
LDIFF_SYM502=LTDIE_27 - Ldebug_info_start
	.long LDIFF_SYM502
LTDIE_26:

	.byte 5
	.asciz "Foundation_NSMutableUrlRequest"

	.byte 40,16
LDIFF_SYM503=LTDIE_27 - Ldebug_info_start
	.long LDIFF_SYM503
	.byte 2,35,0,0,7
	.asciz "Foundation_NSMutableUrlRequest"

LDIFF_SYM504=LTDIE_26 - Ldebug_info_start
	.long LDIFF_SYM504
LTDIE_26_POINTER:

	.byte 13
LDIFF_SYM505=LTDIE_26 - Ldebug_info_start
	.long LDIFF_SYM505
LTDIE_26_REFERENCE:

	.byte 14
LDIFF_SYM506=LTDIE_26 - Ldebug_info_start
	.long LDIFF_SYM506
	.byte 2
	.asciz "WindowsAzure.Messaging.SBTokenProvider:SetToken"
	.asciz "WindowsAzure_Messaging_SBTokenProvider_SetToken_Foundation_NSMutableUrlRequest_WindowsAzure_Messaging_ErrorCallback"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBTokenProvider_SetToken_Foundation_NSMutableUrlRequest_WindowsAzure_Messaging_ErrorCallback
	.quad Lme_75

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM507=LTDIE_25_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM507
	.byte 1,104,3
	.asciz "request"

LDIFF_SYM508=LTDIE_26_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM508
	.byte 1,105,3
	.asciz "errorCallback"

LDIFF_SYM509=LTDIE_16_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM509
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM510=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM510
	.byte 1,103,11
	.asciz "V_1"

LDIFF_SYM511=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM511
	.byte 3,141,200,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM512=Lfde81_end - Lfde81_start
	.long LDIFF_SYM512
Lfde81_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBTokenProvider_SetToken_Foundation_NSMutableUrlRequest_WindowsAzure_Messaging_ErrorCallback

LDIFF_SYM513=Lme_75 - WindowsAzure_Messaging_SBTokenProvider_SetToken_Foundation_NSMutableUrlRequest_WindowsAzure_Messaging_ErrorCallback
	.long LDIFF_SYM513
	.long 0
	.byte 12,31,0,68,14,160,1,157,20,158,19,68,13,29,68,151,18,152,17,68,153,16,154,15
	.align 3
Lfde81_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBTokenProvider:SetToken"
	.asciz "WindowsAzure_Messaging_SBTokenProvider_SetToken_Foundation_NSMutableUrlRequest_Foundation_NSError_"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBTokenProvider_SetToken_Foundation_NSMutableUrlRequest_Foundation_NSError_
	.quad Lme_76

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM514=LTDIE_25_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM514
	.byte 1,104,3
	.asciz "request"

LDIFF_SYM515=LTDIE_26_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM515
	.byte 1,105,3
	.asciz "error"

LDIFF_SYM516=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM516
	.byte 2,141,56,11
	.asciz "V_0"

LDIFF_SYM517=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM517
	.byte 3,141,216,0,11
	.asciz "V_1"

LDIFF_SYM518=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM518
	.byte 1,103,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM519=Lfde82_end - Lfde82_start
	.long LDIFF_SYM519
Lfde82_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBTokenProvider_SetToken_Foundation_NSMutableUrlRequest_Foundation_NSError_

LDIFF_SYM520=Lme_76 - WindowsAzure_Messaging_SBTokenProvider_SetToken_Foundation_NSMutableUrlRequest_Foundation_NSError_
	.long LDIFF_SYM520
	.long 0
	.byte 12,31,0,68,14,128,1,157,16,158,15,68,13,29,68,149,14,150,13,68,151,12,152,11,68,153,10
	.align 3
Lfde82_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBTokenProvider:get_TimeToExpireInMin"
	.asciz "WindowsAzure_Messaging_SBTokenProvider_get_TimeToExpireInMin"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBTokenProvider_get_TimeToExpireInMin
	.quad Lme_77

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM521=LTDIE_25_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM521
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM522=Lfde83_end - Lfde83_start
	.long LDIFF_SYM522
Lfde83_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBTokenProvider_get_TimeToExpireInMin

LDIFF_SYM523=Lme_77 - WindowsAzure_Messaging_SBTokenProvider_get_TimeToExpireInMin
	.long LDIFF_SYM523
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29,68,154,8
	.align 3
Lfde83_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_28:

	.byte 5
	.asciz "System_Int32"

	.byte 20,16
LDIFF_SYM524=LTDIE_11 - Ldebug_info_start
	.long LDIFF_SYM524
	.byte 2,35,0,6
	.asciz "m_value"

LDIFF_SYM525=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM525
	.byte 2,35,16,0,7
	.asciz "System_Int32"

LDIFF_SYM526=LTDIE_28 - Ldebug_info_start
	.long LDIFF_SYM526
LTDIE_28_POINTER:

	.byte 13
LDIFF_SYM527=LTDIE_28 - Ldebug_info_start
	.long LDIFF_SYM527
LTDIE_28_REFERENCE:

	.byte 14
LDIFF_SYM528=LTDIE_28 - Ldebug_info_start
	.long LDIFF_SYM528
	.byte 2
	.asciz "WindowsAzure.Messaging.SBTokenProvider:set_TimeToExpireInMin"
	.asciz "WindowsAzure_Messaging_SBTokenProvider_set_TimeToExpireInMin_int"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBTokenProvider_set_TimeToExpireInMin_int
	.quad Lme_78

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM529=LTDIE_25_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM529
	.byte 1,105,3
	.asciz "value"

LDIFF_SYM530=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM530
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM531=Lfde84_end - Lfde84_start
	.long LDIFF_SYM531
Lfde84_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBTokenProvider_set_TimeToExpireInMin_int

LDIFF_SYM532=Lme_78 - WindowsAzure_Messaging_SBTokenProvider_set_TimeToExpireInMin_int
	.long LDIFF_SYM532
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29,68,153,8,154,7
	.align 3
Lfde84_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "WindowsAzure.Messaging.SBTokenProvider:.cctor"
	.asciz "WindowsAzure_Messaging_SBTokenProvider__cctor"

	.byte 0,0
	.quad WindowsAzure_Messaging_SBTokenProvider__cctor
	.quad Lme_79

	.byte 2,118,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM533=Lfde85_end - Lfde85_start
	.long LDIFF_SYM533
Lfde85_start:

	.long 0
	.align 3
	.quad WindowsAzure_Messaging_SBTokenProvider__cctor

LDIFF_SYM534=Lme_79 - WindowsAzure_Messaging_SBTokenProvider__cctor
	.long LDIFF_SYM534
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29
	.align 3
Lfde85_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "ObjCRuntime.Trampolines/SDErrorCallback:Invoke"
	.asciz "ObjCRuntime_Trampolines_SDErrorCallback_Invoke_intptr_intptr"

	.byte 0,0
	.quad ObjCRuntime_Trampolines_SDErrorCallback_Invoke_intptr_intptr
	.quad Lme_84

	.byte 2,118,16,3
	.asciz "block"

LDIFF_SYM535=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM535
	.byte 2,141,40,3
	.asciz "error"

LDIFF_SYM536=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM536
	.byte 2,141,48,11
	.asciz "V_0"

LDIFF_SYM537=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM537
	.byte 1,104,11
	.asciz "V_1"

LDIFF_SYM538=LTDIE_16_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM538
	.byte 1,103,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM539=Lfde86_end - Lfde86_start
	.long LDIFF_SYM539
Lfde86_start:

	.long 0
	.align 3
	.quad ObjCRuntime_Trampolines_SDErrorCallback_Invoke_intptr_intptr

LDIFF_SYM540=Lme_84 - ObjCRuntime_Trampolines_SDErrorCallback_Invoke_intptr_intptr
	.long LDIFF_SYM540
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,150,10,151,9,68,152,8
	.align 3
Lfde86_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "ObjCRuntime.Trampolines/SDErrorCallback:.cctor"
	.asciz "ObjCRuntime_Trampolines_SDErrorCallback__cctor"

	.byte 0,0
	.quad ObjCRuntime_Trampolines_SDErrorCallback__cctor
	.quad Lme_85

	.byte 2,118,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM541=Lfde87_end - Lfde87_start
	.long LDIFF_SYM541
Lfde87_start:

	.long 0
	.align 3
	.quad ObjCRuntime_Trampolines_SDErrorCallback__cctor

LDIFF_SYM542=Lme_85 - ObjCRuntime_Trampolines_SDErrorCallback__cctor
	.long LDIFF_SYM542
	.long 0
	.byte 12,31,0,68,14,48,157,6,158,5,68,13,29
	.align 3
Lfde87_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_30:

	.byte 5
	.asciz "_DErrorCallback"

	.byte 112,16
LDIFF_SYM543=LTDIE_17 - Ldebug_info_start
	.long LDIFF_SYM543
	.byte 2,35,0,0,7
	.asciz "_DErrorCallback"

LDIFF_SYM544=LTDIE_30 - Ldebug_info_start
	.long LDIFF_SYM544
LTDIE_30_POINTER:

	.byte 13
LDIFF_SYM545=LTDIE_30 - Ldebug_info_start
	.long LDIFF_SYM545
LTDIE_30_REFERENCE:

	.byte 14
LDIFF_SYM546=LTDIE_30 - Ldebug_info_start
	.long LDIFF_SYM546
LTDIE_29:

	.byte 5
	.asciz "_NIDErrorCallback"

	.byte 32,16
LDIFF_SYM547=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM547
	.byte 2,35,0,6
	.asciz "blockPtr"

LDIFF_SYM548=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM548
	.byte 2,35,24,6
	.asciz "invoker"

LDIFF_SYM549=LTDIE_30_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM549
	.byte 2,35,16,0,7
	.asciz "_NIDErrorCallback"

LDIFF_SYM550=LTDIE_29 - Ldebug_info_start
	.long LDIFF_SYM550
LTDIE_29_POINTER:

	.byte 13
LDIFF_SYM551=LTDIE_29 - Ldebug_info_start
	.long LDIFF_SYM551
LTDIE_29_REFERENCE:

	.byte 14
LDIFF_SYM552=LTDIE_29 - Ldebug_info_start
	.long LDIFF_SYM552
	.byte 2
	.asciz "ObjCRuntime.Trampolines/NIDErrorCallback:.ctor"
	.asciz "ObjCRuntime_Trampolines_NIDErrorCallback__ctor_ObjCRuntime_BlockLiteral_"

	.byte 0,0
	.quad ObjCRuntime_Trampolines_NIDErrorCallback__ctor_ObjCRuntime_BlockLiteral_
	.quad Lme_86

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM553=LTDIE_29_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM553
	.byte 1,105,3
	.asciz "block"

LDIFF_SYM554=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM554
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM555=Lfde88_end - Lfde88_start
	.long LDIFF_SYM555
Lfde88_start:

	.long 0
	.align 3
	.quad ObjCRuntime_Trampolines_NIDErrorCallback__ctor_ObjCRuntime_BlockLiteral_

LDIFF_SYM556=Lme_86 - ObjCRuntime_Trampolines_NIDErrorCallback__ctor_ObjCRuntime_BlockLiteral_
	.long LDIFF_SYM556
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10,154,9
	.align 3
Lfde88_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "ObjCRuntime.Trampolines/NIDErrorCallback:Finalize"
	.asciz "ObjCRuntime_Trampolines_NIDErrorCallback_Finalize"

	.byte 0,0
	.quad ObjCRuntime_Trampolines_NIDErrorCallback_Finalize
	.quad Lme_87

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM557=LTDIE_29_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM557
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM558=Lfde89_end - Lfde89_start
	.long LDIFF_SYM558
Lfde89_start:

	.long 0
	.align 3
	.quad ObjCRuntime_Trampolines_NIDErrorCallback_Finalize

LDIFF_SYM559=Lme_87 - ObjCRuntime_Trampolines_NIDErrorCallback_Finalize
	.long LDIFF_SYM559
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29
	.align 3
Lfde89_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "ObjCRuntime.Trampolines/NIDErrorCallback:Create"
	.asciz "ObjCRuntime_Trampolines_NIDErrorCallback_Create_intptr"

	.byte 0,0
	.quad ObjCRuntime_Trampolines_NIDErrorCallback_Create_intptr
	.quad Lme_88

	.byte 2,118,16,3
	.asciz "block"

LDIFF_SYM560=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM560
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM561=Lfde90_end - Lfde90_start
	.long LDIFF_SYM561
Lfde90_start:

	.long 0
	.align 3
	.quad ObjCRuntime_Trampolines_NIDErrorCallback_Create_intptr

LDIFF_SYM562=Lme_88 - ObjCRuntime_Trampolines_NIDErrorCallback_Create_intptr
	.long LDIFF_SYM562
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29
	.align 3
Lfde90_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "ObjCRuntime.Trampolines/NIDErrorCallback:Invoke"
	.asciz "ObjCRuntime_Trampolines_NIDErrorCallback_Invoke_Foundation_NSError"

	.byte 0,0
	.quad ObjCRuntime_Trampolines_NIDErrorCallback_Invoke_Foundation_NSError
	.quad Lme_89

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM563=LTDIE_29_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM563
	.byte 1,105,3
	.asciz "error"

LDIFF_SYM564=LTDIE_15_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM564
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM565=Lfde91_end - Lfde91_start
	.long LDIFF_SYM565
Lfde91_start:

	.long 0
	.align 3
	.quad ObjCRuntime_Trampolines_NIDErrorCallback_Invoke_Foundation_NSError

LDIFF_SYM566=Lme_89 - ObjCRuntime_Trampolines_NIDErrorCallback_Invoke_Foundation_NSError
	.long LDIFF_SYM566
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,150,10,151,9,68,152,8,153,7,68,154,6
	.align 3
Lfde91_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_31:

	.byte 17
	.asciz "_<Module>"

	.byte 16,7
	.asciz "_<Module>"

LDIFF_SYM567=LTDIE_31 - Ldebug_info_start
	.long LDIFF_SYM567
LTDIE_31_POINTER:

	.byte 13
LDIFF_SYM568=LTDIE_31 - Ldebug_info_start
	.long LDIFF_SYM568
LTDIE_31_REFERENCE:

	.byte 14
LDIFF_SYM569=LTDIE_31 - Ldebug_info_start
	.long LDIFF_SYM569
LTDIE_32:

	.byte 5
	.asciz "System_Array"

	.byte 16,16
LDIFF_SYM570=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM570
	.byte 2,35,0,0,7
	.asciz "System_Array"

LDIFF_SYM571=LTDIE_32 - Ldebug_info_start
	.long LDIFF_SYM571
LTDIE_32_POINTER:

	.byte 13
LDIFF_SYM572=LTDIE_32 - Ldebug_info_start
	.long LDIFF_SYM572
LTDIE_32_REFERENCE:

	.byte 14
LDIFF_SYM573=LTDIE_32 - Ldebug_info_start
	.long LDIFF_SYM573
	.byte 2
	.asciz "(wrapper_delegate-invoke)_<Module>:invoke_void_NSError"
	.asciz "wrapper_delegate_invoke__Module_invoke_void_NSError_Foundation_NSError"

	.byte 0,0
	.quad wrapper_delegate_invoke__Module_invoke_void_NSError_Foundation_NSError
	.quad Lme_8b

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM574=LTDIE_31_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM574
	.byte 1,105,3
	.asciz "param0"

LDIFF_SYM575=LTDIE_15_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM575
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM576=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM576
	.byte 1,104,11
	.asciz "V_1"

LDIFF_SYM577=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM577
	.byte 1,103,11
	.asciz "V_2"

LDIFF_SYM578=LTDIE_32_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM578
	.byte 1,102,11
	.asciz "V_3"

LDIFF_SYM579=LTDIE_17_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM579
	.byte 1,101,11
	.asciz "V_4"

LDIFF_SYM580=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM580
	.byte 1,100,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM581=Lfde92_end - Lfde92_start
	.long LDIFF_SYM581
Lfde92_start:

	.long 0
	.align 3
	.quad wrapper_delegate_invoke__Module_invoke_void_NSError_Foundation_NSError

LDIFF_SYM582=Lme_8b - wrapper_delegate_invoke__Module_invoke_void_NSError_Foundation_NSError
	.long LDIFF_SYM582
	.long 0
	.byte 12,31,0,68,14,128,1,157,16,158,15,68,13,29,68,147,14,148,13,68,149,12,150,11,68,151,10,152,9,68,153,8
	.byte 154,7
	.align 3
Lfde92_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_33:

	.byte 5
	.asciz "System_AsyncCallback"

	.byte 112,16
LDIFF_SYM583=LTDIE_17 - Ldebug_info_start
	.long LDIFF_SYM583
	.byte 2,35,0,0,7
	.asciz "System_AsyncCallback"

LDIFF_SYM584=LTDIE_33 - Ldebug_info_start
	.long LDIFF_SYM584
LTDIE_33_POINTER:

	.byte 13
LDIFF_SYM585=LTDIE_33 - Ldebug_info_start
	.long LDIFF_SYM585
LTDIE_33_REFERENCE:

	.byte 14
LDIFF_SYM586=LTDIE_33 - Ldebug_info_start
	.long LDIFF_SYM586
	.byte 2
	.asciz "(wrapper_delegate-begin-invoke)_<Module>:begin_invoke_IAsyncResult__this___NSError_AsyncCallback_object"
	.asciz "wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___NSError_AsyncCallback_object_Foundation_NSError_System_AsyncCallback_object"

	.byte 0,0
	.quad wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___NSError_AsyncCallback_object_Foundation_NSError_System_AsyncCallback_object
	.quad Lme_8c

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM587=LTDIE_31_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM587
	.byte 2,141,32,3
	.asciz "param0"

LDIFF_SYM588=LTDIE_15_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM588
	.byte 2,141,40,3
	.asciz "param1"

LDIFF_SYM589=LTDIE_33_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM589
	.byte 2,141,48,3
	.asciz "param2"

LDIFF_SYM590=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM590
	.byte 2,141,56,11
	.asciz "V_0"

LDIFF_SYM591=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM591
	.byte 1,105,11
	.asciz "V_1"

LDIFF_SYM592=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM592
	.byte 1,104,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM593=Lfde93_end - Lfde93_start
	.long LDIFF_SYM593
Lfde93_start:

	.long 0
	.align 3
	.quad wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___NSError_AsyncCallback_object_Foundation_NSError_System_AsyncCallback_object

LDIFF_SYM594=Lme_8c - wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___NSError_AsyncCallback_object_Foundation_NSError_System_AsyncCallback_object
	.long LDIFF_SYM594
	.long 0
	.byte 12,31,0,68,14,112,157,14,158,13,68,13,29,68,152,12,153,11
	.align 3
Lfde93_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_34:

	.byte 17
	.asciz "System_IAsyncResult"

	.byte 16,7
	.asciz "System_IAsyncResult"

LDIFF_SYM595=LTDIE_34 - Ldebug_info_start
	.long LDIFF_SYM595
LTDIE_34_POINTER:

	.byte 13
LDIFF_SYM596=LTDIE_34 - Ldebug_info_start
	.long LDIFF_SYM596
LTDIE_34_REFERENCE:

	.byte 14
LDIFF_SYM597=LTDIE_34 - Ldebug_info_start
	.long LDIFF_SYM597
	.byte 2
	.asciz "(wrapper_delegate-end-invoke)_<Module>:end_invoke_void__this___IAsyncResult"
	.asciz "wrapper_delegate_end_invoke__Module_end_invoke_void__this___IAsyncResult_System_IAsyncResult"

	.byte 0,0
	.quad wrapper_delegate_end_invoke__Module_end_invoke_void__this___IAsyncResult_System_IAsyncResult
	.quad Lme_8d

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM598=LTDIE_31_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM598
	.byte 2,141,32,3
	.asciz "param0"

LDIFF_SYM599=LTDIE_34_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM599
	.byte 2,141,40,11
	.asciz "V_0"

LDIFF_SYM600=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM600
	.byte 1,105,11
	.asciz "V_1"

LDIFF_SYM601=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM601
	.byte 1,104,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM602=Lfde94_end - Lfde94_start
	.long LDIFF_SYM602
Lfde94_start:

	.long 0
	.align 3
	.quad wrapper_delegate_end_invoke__Module_end_invoke_void__this___IAsyncResult_System_IAsyncResult

LDIFF_SYM603=Lme_8d - wrapper_delegate_end_invoke__Module_end_invoke_void__this___IAsyncResult_System_IAsyncResult
	.long LDIFF_SYM603
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29,68,152,8,153,7
	.align 3
Lfde94_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_delegate-invoke)_<Module>:invoke_void_intptr_intptr"
	.asciz "wrapper_delegate_invoke__Module_invoke_void_intptr_intptr_intptr_intptr"

	.byte 0,0
	.quad wrapper_delegate_invoke__Module_invoke_void_intptr_intptr_intptr_intptr
	.quad Lme_8e

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM604=LTDIE_31_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM604
	.byte 1,104,3
	.asciz "param0"

LDIFF_SYM605=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM605
	.byte 1,105,3
	.asciz "param1"

LDIFF_SYM606=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM606
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM607=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM607
	.byte 1,103,11
	.asciz "V_1"

LDIFF_SYM608=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM608
	.byte 1,102,11
	.asciz "V_2"

LDIFF_SYM609=LTDIE_32_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM609
	.byte 1,101,11
	.asciz "V_3"

LDIFF_SYM610=LTDIE_17_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM610
	.byte 1,100,11
	.asciz "V_4"

LDIFF_SYM611=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM611
	.byte 1,99,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM612=Lfde95_end - Lfde95_start
	.long LDIFF_SYM612
Lfde95_start:

	.long 0
	.align 3
	.quad wrapper_delegate_invoke__Module_invoke_void_intptr_intptr_intptr_intptr

LDIFF_SYM613=Lme_8e - wrapper_delegate_invoke__Module_invoke_void_intptr_intptr_intptr_intptr
	.long LDIFF_SYM613
	.long 0
	.byte 12,31,0,68,14,144,1,157,18,158,17,68,13,29,68,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10
	.byte 154,9
	.align 3
Lfde95_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_delegate-begin-invoke)_<Module>:begin_invoke_IAsyncResult__this___intptr_intptr_AsyncCallback_object"
	.asciz "wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___intptr_intptr_AsyncCallback_object_intptr_intptr_System_AsyncCallback_object"

	.byte 0,0
	.quad wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___intptr_intptr_AsyncCallback_object_intptr_intptr_System_AsyncCallback_object
	.quad Lme_8f

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM614=LTDIE_31_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM614
	.byte 2,141,32,3
	.asciz "param0"

LDIFF_SYM615=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM615
	.byte 2,141,40,3
	.asciz "param1"

LDIFF_SYM616=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM616
	.byte 2,141,48,3
	.asciz "param2"

LDIFF_SYM617=LTDIE_33_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM617
	.byte 2,141,56,3
	.asciz "param3"

LDIFF_SYM618=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM618
	.byte 3,141,192,0,11
	.asciz "V_0"

LDIFF_SYM619=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM619
	.byte 1,105,11
	.asciz "V_1"

LDIFF_SYM620=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM620
	.byte 1,104,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM621=Lfde96_end - Lfde96_start
	.long LDIFF_SYM621
Lfde96_start:

	.long 0
	.align 3
	.quad wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___intptr_intptr_AsyncCallback_object_intptr_intptr_System_AsyncCallback_object

LDIFF_SYM622=Lme_8f - wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___intptr_intptr_AsyncCallback_object_intptr_intptr_System_AsyncCallback_object
	.long LDIFF_SYM622
	.long 0
	.byte 12,31,0,68,14,112,157,14,158,13,68,13,29,68,152,12,153,11
	.align 3
Lfde96_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ObjCRuntime.Trampolines/DErrorCallback:wrapper_aot_native"
	.asciz "wrapper_managed_to_native_ObjCRuntime_Trampolines_DErrorCallback_wrapper_aot_native_object_intptr_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ObjCRuntime_Trampolines_DErrorCallback_wrapper_aot_native_object_intptr_intptr
	.quad Lme_90

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM623=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM623
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM624=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM624
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM625=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM625
	.byte 2,141,32,11
	.asciz "V_0"

LDIFF_SYM626=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM626
	.byte 3,141,184,1,11
	.asciz "V_1"

LDIFF_SYM627=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM627
	.byte 3,141,192,1,11
	.asciz "V_2"

LDIFF_SYM628=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM628
	.byte 3,141,200,1,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM629=Lfde97_end - Lfde97_start
	.long LDIFF_SYM629
Lfde97_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ObjCRuntime_Trampolines_DErrorCallback_wrapper_aot_native_object_intptr_intptr

LDIFF_SYM630=Lme_90 - wrapper_managed_to_native_ObjCRuntime_Trampolines_DErrorCallback_wrapper_aot_native_object_intptr_intptr
	.long LDIFF_SYM630
	.long 0
	.byte 12,31,0,68,14,208,1,157,26,158,25,68,13,29,76,147,15,148,14,68,149,13,150,12,68,151,11,152,10,68,153,9
	.byte 154,8,68,155,7,156,6
	.align 3
Lfde97_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_delegate-invoke)_<Module>:invoke_bound_void_object_intptr_intptr"
	.asciz "wrapper_delegate_invoke__Module_invoke_bound_void_object_intptr_intptr_intptr_intptr"

	.byte 0,0
	.quad wrapper_delegate_invoke__Module_invoke_bound_void_object_intptr_intptr_intptr_intptr
	.quad Lme_91

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM631=LTDIE_31_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM631
	.byte 1,104,3
	.asciz "param0"

LDIFF_SYM632=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM632
	.byte 1,105,3
	.asciz "param1"

LDIFF_SYM633=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM633
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM634=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM634
	.byte 1,103,11
	.asciz "V_1"

LDIFF_SYM635=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM635
	.byte 1,102,11
	.asciz "V_2"

LDIFF_SYM636=LTDIE_32_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM636
	.byte 1,101,11
	.asciz "V_3"

LDIFF_SYM637=LTDIE_17_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM637
	.byte 1,100,11
	.asciz "V_4"

LDIFF_SYM638=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM638
	.byte 1,99,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM639=Lfde98_end - Lfde98_start
	.long LDIFF_SYM639
Lfde98_start:

	.long 0
	.align 3
	.quad wrapper_delegate_invoke__Module_invoke_bound_void_object_intptr_intptr_intptr_intptr

LDIFF_SYM640=Lme_91 - wrapper_delegate_invoke__Module_invoke_bound_void_object_intptr_intptr_intptr_intptr
	.long LDIFF_SYM640
	.long 0
	.byte 12,31,0,68,14,144,1,157,18,158,17,68,13,29,68,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10
	.byte 154,9
	.align 3
Lfde98_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:IntPtr_objc_msgSend"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_intptr_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_intptr_intptr
	.quad Lme_92

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM641=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM641
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM642=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM642
	.byte 2,141,24,11
	.asciz "V_0"

LDIFF_SYM643=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM643
	.byte 3,141,176,1,11
	.asciz "V_1"

LDIFF_SYM644=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM644
	.byte 3,141,184,1,11
	.asciz "V_2"

LDIFF_SYM645=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM645
	.byte 3,141,192,1,11
	.asciz "V_3"

LDIFF_SYM646=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM646
	.byte 1,103,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM647=Lfde99_end - Lfde99_start
	.long LDIFF_SYM647
Lfde99_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_intptr_intptr

LDIFF_SYM648=Lme_92 - wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_intptr_intptr
	.long LDIFF_SYM648
	.long 0
	.byte 12,31,0,68,14,208,1,157,26,158,25,68,13,29,76,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10
	.byte 154,9,68,155,8,156,7
	.align 3
Lfde99_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:IntPtr_objc_msgSendSuper"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_intptr_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_intptr_intptr
	.quad Lme_93

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM649=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM649
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM650=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM650
	.byte 2,141,24,11
	.asciz "V_0"

LDIFF_SYM651=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM651
	.byte 3,141,176,1,11
	.asciz "V_1"

LDIFF_SYM652=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM652
	.byte 3,141,184,1,11
	.asciz "V_2"

LDIFF_SYM653=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM653
	.byte 3,141,192,1,11
	.asciz "V_3"

LDIFF_SYM654=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM654
	.byte 1,103,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM655=Lfde100_end - Lfde100_start
	.long LDIFF_SYM655
Lfde100_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_intptr_intptr

LDIFF_SYM656=Lme_93 - wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_intptr_intptr
	.long LDIFF_SYM656
	.long 0
	.byte 12,31,0,68,14,208,1,157,26,158,25,68,13,29,76,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10
	.byte 154,9,68,155,8,156,7
	.align 3
Lfde100_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:IntPtr_objc_msgSend_IntPtr"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_intptr_intptr_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_intptr_intptr_intptr
	.quad Lme_94

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM657=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM657
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM658=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM658
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM659=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM659
	.byte 2,141,32,11
	.asciz "V_0"

LDIFF_SYM660=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM660
	.byte 3,141,184,1,11
	.asciz "V_1"

LDIFF_SYM661=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM661
	.byte 3,141,192,1,11
	.asciz "V_2"

LDIFF_SYM662=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM662
	.byte 3,141,200,1,11
	.asciz "V_3"

LDIFF_SYM663=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM663
	.byte 1,102,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM664=Lfde101_end - Lfde101_start
	.long LDIFF_SYM664
Lfde101_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_intptr_intptr_intptr

LDIFF_SYM665=Lme_94 - wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_intptr_intptr_intptr
	.long LDIFF_SYM665
	.long 0
	.byte 12,31,0,68,14,208,1,157,26,158,25,68,13,29,76,147,15,148,14,68,149,13,150,12,68,151,11,152,10,68,153,9
	.byte 154,8,68,155,7,156,6
	.align 3
Lfde101_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:IntPtr_objc_msgSendSuper_IntPtr"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_IntPtr_intptr_intptr_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_IntPtr_intptr_intptr_intptr
	.quad Lme_95

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM666=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM666
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM667=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM667
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM668=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM668
	.byte 2,141,32,11
	.asciz "V_0"

LDIFF_SYM669=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM669
	.byte 3,141,184,1,11
	.asciz "V_1"

LDIFF_SYM670=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM670
	.byte 3,141,192,1,11
	.asciz "V_2"

LDIFF_SYM671=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM671
	.byte 3,141,200,1,11
	.asciz "V_3"

LDIFF_SYM672=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM672
	.byte 1,102,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM673=Lfde102_end - Lfde102_start
	.long LDIFF_SYM673
Lfde102_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_IntPtr_intptr_intptr_intptr

LDIFF_SYM674=Lme_95 - wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_IntPtr_intptr_intptr_intptr
	.long LDIFF_SYM674
	.long 0
	.byte 12,31,0,68,14,208,1,157,26,158,25,68,13,29,76,147,15,148,14,68,149,13,150,12,68,151,11,152,10,68,153,9
	.byte 154,8,68,155,7,156,6
	.align 3
Lfde102_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:IntPtr_objc_msgSend_IntPtr_IntPtr_IntPtr"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr
	.quad Lme_96

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM675=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM675
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM676=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM676
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM677=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM677
	.byte 2,141,32,3
	.asciz "param3"

LDIFF_SYM678=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM678
	.byte 2,141,40,3
	.asciz "param4"

LDIFF_SYM679=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM679
	.byte 2,141,48,11
	.asciz "V_0"

LDIFF_SYM680=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM680
	.byte 3,141,200,1,11
	.asciz "V_1"

LDIFF_SYM681=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM681
	.byte 3,141,208,1,11
	.asciz "V_2"

LDIFF_SYM682=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM682
	.byte 3,141,216,1,11
	.asciz "V_3"

LDIFF_SYM683=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM683
	.byte 1,100,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM684=Lfde103_end - Lfde103_start
	.long LDIFF_SYM684
Lfde103_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr

LDIFF_SYM685=Lme_96 - wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr
	.long LDIFF_SYM685
	.long 0
	.byte 12,31,0,68,14,240,1,157,30,158,29,68,13,29,76,147,17,148,16,68,149,15,150,14,68,151,13,152,12,68,153,11
	.byte 154,10,68,155,9,156,8
	.align 3
Lfde103_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:IntPtr_objc_msgSendSuper_IntPtr_IntPtr_IntPtr"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr
	.quad Lme_97

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM686=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM686
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM687=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM687
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM688=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM688
	.byte 2,141,32,3
	.asciz "param3"

LDIFF_SYM689=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM689
	.byte 2,141,40,3
	.asciz "param4"

LDIFF_SYM690=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM690
	.byte 2,141,48,11
	.asciz "V_0"

LDIFF_SYM691=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM691
	.byte 3,141,200,1,11
	.asciz "V_1"

LDIFF_SYM692=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM692
	.byte 3,141,208,1,11
	.asciz "V_2"

LDIFF_SYM693=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM693
	.byte 3,141,216,1,11
	.asciz "V_3"

LDIFF_SYM694=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM694
	.byte 1,100,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM695=Lfde104_end - Lfde104_start
	.long LDIFF_SYM695
Lfde104_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr

LDIFF_SYM696=Lme_97 - wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr
	.long LDIFF_SYM696
	.long 0
	.byte 12,31,0,68,14,240,1,157,30,158,29,68,13,29,76,147,17,148,16,68,149,15,150,14,68,151,13,152,12,68,153,11
	.byte 154,10,68,155,9,156,8
	.align 3
Lfde104_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:IntPtr_objc_msgSend_IntPtr_IntPtr"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_IntPtr_intptr_intptr_intptr_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_IntPtr_intptr_intptr_intptr_intptr
	.quad Lme_98

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM697=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM697
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM698=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM698
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM699=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM699
	.byte 2,141,32,3
	.asciz "param3"

LDIFF_SYM700=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM700
	.byte 2,141,40,11
	.asciz "V_0"

LDIFF_SYM701=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM701
	.byte 3,141,192,1,11
	.asciz "V_1"

LDIFF_SYM702=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM702
	.byte 3,141,200,1,11
	.asciz "V_2"

LDIFF_SYM703=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM703
	.byte 3,141,208,1,11
	.asciz "V_3"

LDIFF_SYM704=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM704
	.byte 1,101,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM705=Lfde105_end - Lfde105_start
	.long LDIFF_SYM705
Lfde105_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_IntPtr_intptr_intptr_intptr_intptr

LDIFF_SYM706=Lme_98 - wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_IntPtr_intptr_intptr_intptr_intptr
	.long LDIFF_SYM706
	.long 0
	.byte 12,31,0,68,14,224,1,157,28,158,27,68,13,29,76,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10
	.byte 154,9,68,155,8,156,7
	.align 3
Lfde105_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:IntPtr_objc_msgSendSuper_IntPtr_IntPtr"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_IntPtr_IntPtr_intptr_intptr_intptr_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_IntPtr_IntPtr_intptr_intptr_intptr_intptr
	.quad Lme_99

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM707=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM707
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM708=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM708
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM709=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM709
	.byte 2,141,32,3
	.asciz "param3"

LDIFF_SYM710=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM710
	.byte 2,141,40,11
	.asciz "V_0"

LDIFF_SYM711=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM711
	.byte 3,141,192,1,11
	.asciz "V_1"

LDIFF_SYM712=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM712
	.byte 3,141,200,1,11
	.asciz "V_2"

LDIFF_SYM713=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM713
	.byte 3,141,208,1,11
	.asciz "V_3"

LDIFF_SYM714=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM714
	.byte 1,101,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM715=Lfde106_end - Lfde106_start
	.long LDIFF_SYM715
Lfde106_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_IntPtr_IntPtr_intptr_intptr_intptr_intptr

LDIFF_SYM716=Lme_99 - wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_IntPtr_IntPtr_intptr_intptr_intptr_intptr
	.long LDIFF_SYM716
	.long 0
	.byte 12,31,0,68,14,224,1,157,28,158,27,68,13,29,76,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10
	.byte 154,9,68,155,8,156,7
	.align 3
Lfde106_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:void_objc_msgSend_IntPtr"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_intptr_intptr_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_intptr_intptr_intptr
	.quad Lme_9a

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM717=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM717
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM718=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM718
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM719=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM719
	.byte 2,141,32,11
	.asciz "V_0"

LDIFF_SYM720=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM720
	.byte 3,141,184,1,11
	.asciz "V_1"

LDIFF_SYM721=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM721
	.byte 3,141,192,1,11
	.asciz "V_2"

LDIFF_SYM722=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM722
	.byte 3,141,200,1,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM723=Lfde107_end - Lfde107_start
	.long LDIFF_SYM723
Lfde107_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_intptr_intptr_intptr

LDIFF_SYM724=Lme_9a - wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_intptr_intptr_intptr
	.long LDIFF_SYM724
	.long 0
	.byte 12,31,0,68,14,208,1,157,26,158,25,68,13,29,76,147,15,148,14,68,149,13,150,12,68,151,11,152,10,68,153,9
	.byte 154,8,68,155,7,156,6
	.align 3
Lfde107_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:void_objc_msgSendSuper_IntPtr"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_intptr_intptr_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_intptr_intptr_intptr
	.quad Lme_9b

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM725=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM725
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM726=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM726
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM727=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM727
	.byte 2,141,32,11
	.asciz "V_0"

LDIFF_SYM728=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM728
	.byte 3,141,184,1,11
	.asciz "V_1"

LDIFF_SYM729=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM729
	.byte 3,141,192,1,11
	.asciz "V_2"

LDIFF_SYM730=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM730
	.byte 3,141,200,1,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM731=Lfde108_end - Lfde108_start
	.long LDIFF_SYM731
Lfde108_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_intptr_intptr_intptr

LDIFF_SYM732=Lme_9b - wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_intptr_intptr_intptr
	.long LDIFF_SYM732
	.long 0
	.byte 12,31,0,68,14,208,1,157,26,158,25,68,13,29,76,147,15,148,14,68,149,13,150,12,68,151,11,152,10,68,153,9
	.byte 154,8,68,155,7,156,6
	.align 3
Lfde108_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:bool_objc_msgSend"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_intptr_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_intptr_intptr
	.quad Lme_9c

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM733=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM733
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM734=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM734
	.byte 2,141,24,11
	.asciz "V_0"

LDIFF_SYM735=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM735
	.byte 3,141,176,1,11
	.asciz "V_1"

LDIFF_SYM736=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM736
	.byte 3,141,184,1,11
	.asciz "V_2"

LDIFF_SYM737=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM737
	.byte 3,141,192,1,11
	.asciz "V_3"

LDIFF_SYM738=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM738
	.byte 1,103,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM739=Lfde109_end - Lfde109_start
	.long LDIFF_SYM739
Lfde109_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_intptr_intptr

LDIFF_SYM740=Lme_9c - wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_intptr_intptr
	.long LDIFF_SYM740
	.long 0
	.byte 12,31,0,68,14,208,1,157,26,158,25,68,13,29,76,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10
	.byte 154,9,68,155,8,156,7
	.align 3
Lfde109_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:bool_objc_msgSendSuper"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_intptr_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_intptr_intptr
	.quad Lme_9d

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM741=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM741
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM742=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM742
	.byte 2,141,24,11
	.asciz "V_0"

LDIFF_SYM743=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM743
	.byte 3,141,176,1,11
	.asciz "V_1"

LDIFF_SYM744=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM744
	.byte 3,141,184,1,11
	.asciz "V_2"

LDIFF_SYM745=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM745
	.byte 3,141,192,1,11
	.asciz "V_3"

LDIFF_SYM746=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM746
	.byte 1,103,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM747=Lfde110_end - Lfde110_start
	.long LDIFF_SYM747
Lfde110_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_intptr_intptr

LDIFF_SYM748=Lme_9d - wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_intptr_intptr
	.long LDIFF_SYM748
	.long 0
	.byte 12,31,0,68,14,208,1,157,26,158,25,68,13,29,76,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10
	.byte 154,9,68,155,8,156,7
	.align 3
Lfde110_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:void_objc_msgSend_bool"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_bool_intptr_intptr_bool"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_bool_intptr_intptr_bool
	.quad Lme_9e

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM749=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM749
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM750=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM750
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM751=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM751
	.byte 2,141,32,11
	.asciz "V_0"

LDIFF_SYM752=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM752
	.byte 3,141,184,1,11
	.asciz "V_1"

LDIFF_SYM753=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM753
	.byte 3,141,192,1,11
	.asciz "V_2"

LDIFF_SYM754=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM754
	.byte 3,141,200,1,11
	.asciz "V_3"

LDIFF_SYM755=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM755
	.byte 1,102,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM756=Lfde111_end - Lfde111_start
	.long LDIFF_SYM756
Lfde111_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_bool_intptr_intptr_bool

LDIFF_SYM757=Lme_9e - wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_bool_intptr_intptr_bool
	.long LDIFF_SYM757
	.long 0
	.byte 12,31,0,68,14,208,1,157,26,158,25,68,13,29,76,147,15,148,14,68,149,13,150,12,68,151,11,152,10,68,153,9
	.byte 154,8,68,155,7,156,6
	.align 3
Lfde111_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:void_objc_msgSendSuper_bool"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_bool_intptr_intptr_bool"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_bool_intptr_intptr_bool
	.quad Lme_9f

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM758=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM758
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM759=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM759
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM760=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM760
	.byte 2,141,32,11
	.asciz "V_0"

LDIFF_SYM761=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM761
	.byte 3,141,184,1,11
	.asciz "V_1"

LDIFF_SYM762=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM762
	.byte 3,141,192,1,11
	.asciz "V_2"

LDIFF_SYM763=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM763
	.byte 3,141,200,1,11
	.asciz "V_3"

LDIFF_SYM764=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM764
	.byte 1,102,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM765=Lfde112_end - Lfde112_start
	.long LDIFF_SYM765
Lfde112_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_bool_intptr_intptr_bool

LDIFF_SYM766=Lme_9f - wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_bool_intptr_intptr_bool
	.long LDIFF_SYM766
	.long 0
	.byte 12,31,0,68,14,208,1,157,26,158,25,68,13,29,76,147,15,148,14,68,149,13,150,12,68,151,11,152,10,68,153,9
	.byte 154,8,68,155,7,156,6
	.align 3
Lfde112_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:void_objc_msgSend_IntPtr_IntPtr"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_intptr_intptr_intptr_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_intptr_intptr_intptr_intptr
	.quad Lme_a0

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM767=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM767
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM768=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM768
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM769=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM769
	.byte 2,141,32,3
	.asciz "param3"

LDIFF_SYM770=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM770
	.byte 2,141,40,11
	.asciz "V_0"

LDIFF_SYM771=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM771
	.byte 3,141,192,1,11
	.asciz "V_1"

LDIFF_SYM772=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM772
	.byte 3,141,200,1,11
	.asciz "V_2"

LDIFF_SYM773=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM773
	.byte 3,141,208,1,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM774=Lfde113_end - Lfde113_start
	.long LDIFF_SYM774
Lfde113_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_intptr_intptr_intptr_intptr

LDIFF_SYM775=Lme_a0 - wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_intptr_intptr_intptr_intptr
	.long LDIFF_SYM775
	.long 0
	.byte 12,31,0,68,14,224,1,157,28,158,27,68,13,29,76,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10
	.byte 154,9,68,155,8,156,7
	.align 3
Lfde113_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:void_objc_msgSendSuper_IntPtr_IntPtr"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_intptr_intptr_intptr_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_intptr_intptr_intptr_intptr
	.quad Lme_a1

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM776=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM776
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM777=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM777
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM778=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM778
	.byte 2,141,32,3
	.asciz "param3"

LDIFF_SYM779=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM779
	.byte 2,141,40,11
	.asciz "V_0"

LDIFF_SYM780=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM780
	.byte 3,141,192,1,11
	.asciz "V_1"

LDIFF_SYM781=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM781
	.byte 3,141,200,1,11
	.asciz "V_2"

LDIFF_SYM782=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM782
	.byte 3,141,208,1,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM783=Lfde114_end - Lfde114_start
	.long LDIFF_SYM783
Lfde114_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_intptr_intptr_intptr_intptr

LDIFF_SYM784=Lme_a1 - wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_intptr_intptr_intptr_intptr
	.long LDIFF_SYM784
	.long 0
	.byte 12,31,0,68,14,224,1,157,28,158,27,68,13,29,76,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10
	.byte 154,9,68,155,8,156,7
	.align 3
Lfde114_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:void_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr
	.quad Lme_a2

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM785=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM785
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM786=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM786
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM787=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM787
	.byte 2,141,32,3
	.asciz "param3"

LDIFF_SYM788=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM788
	.byte 2,141,40,3
	.asciz "param4"

LDIFF_SYM789=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM789
	.byte 2,141,48,3
	.asciz "param5"

LDIFF_SYM790=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM790
	.byte 2,141,56,11
	.asciz "V_0"

LDIFF_SYM791=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM791
	.byte 3,141,208,1,11
	.asciz "V_1"

LDIFF_SYM792=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM792
	.byte 3,141,216,1,11
	.asciz "V_2"

LDIFF_SYM793=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM793
	.byte 3,141,224,1,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM794=Lfde115_end - Lfde115_start
	.long LDIFF_SYM794
Lfde115_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr

LDIFF_SYM795=Lme_a2 - wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr
	.long LDIFF_SYM795
	.long 0
	.byte 12,31,0,68,14,128,2,157,32,158,31,68,13,29,76,147,18,148,17,68,149,16,150,15,68,151,14,152,13,68,153,12
	.byte 154,11,68,155,10,156,9
	.align 3
Lfde115_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:void_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_IntPtr"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr
	.quad Lme_a3

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM796=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM796
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM797=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM797
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM798=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM798
	.byte 2,141,32,3
	.asciz "param3"

LDIFF_SYM799=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM799
	.byte 2,141,40,3
	.asciz "param4"

LDIFF_SYM800=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM800
	.byte 2,141,48,3
	.asciz "param5"

LDIFF_SYM801=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM801
	.byte 2,141,56,11
	.asciz "V_0"

LDIFF_SYM802=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM802
	.byte 3,141,208,1,11
	.asciz "V_1"

LDIFF_SYM803=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM803
	.byte 3,141,216,1,11
	.asciz "V_2"

LDIFF_SYM804=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM804
	.byte 3,141,224,1,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM805=Lfde116_end - Lfde116_start
	.long LDIFF_SYM805
Lfde116_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr

LDIFF_SYM806=Lme_a3 - wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr
	.long LDIFF_SYM806
	.long 0
	.byte 12,31,0,68,14,128,2,157,32,158,31,68,13,29,76,147,18,148,17,68,149,16,150,15,68,151,14,152,13,68,153,12
	.byte 154,11,68,155,10,156,9
	.align 3
Lfde116_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:void_objc_msgSend"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_intptr_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_intptr_intptr
	.quad Lme_a4

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM807=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM807
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM808=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM808
	.byte 2,141,24,11
	.asciz "V_0"

LDIFF_SYM809=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM809
	.byte 3,141,176,1,11
	.asciz "V_1"

LDIFF_SYM810=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM810
	.byte 3,141,184,1,11
	.asciz "V_2"

LDIFF_SYM811=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM811
	.byte 3,141,192,1,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM812=Lfde117_end - Lfde117_start
	.long LDIFF_SYM812
Lfde117_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_intptr_intptr

LDIFF_SYM813=Lme_a4 - wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_intptr_intptr
	.long LDIFF_SYM813
	.long 0
	.byte 12,31,0,68,14,208,1,157,26,158,25,68,13,29,76,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10
	.byte 154,9,68,155,8,156,7
	.align 3
Lfde117_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:void_objc_msgSendSuper"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_intptr_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_intptr_intptr
	.quad Lme_a5

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM814=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM814
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM815=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM815
	.byte 2,141,24,11
	.asciz "V_0"

LDIFF_SYM816=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM816
	.byte 3,141,176,1,11
	.asciz "V_1"

LDIFF_SYM817=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM817
	.byte 3,141,184,1,11
	.asciz "V_2"

LDIFF_SYM818=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM818
	.byte 3,141,192,1,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM819=Lfde118_end - Lfde118_start
	.long LDIFF_SYM819
Lfde118_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_intptr_intptr

LDIFF_SYM820=Lme_a5 - wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_intptr_intptr
	.long LDIFF_SYM820
	.long 0
	.byte 12,31,0,68,14,208,1,157,26,158,25,68,13,29,76,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10
	.byte 154,9,68,155,8,156,7
	.align 3
Lfde118_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:void_objc_msgSend_IntPtr_IntPtr_IntPtr"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr
	.quad Lme_a6

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM821=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM821
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM822=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM822
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM823=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM823
	.byte 2,141,32,3
	.asciz "param3"

LDIFF_SYM824=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM824
	.byte 2,141,40,3
	.asciz "param4"

LDIFF_SYM825=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM825
	.byte 2,141,48,11
	.asciz "V_0"

LDIFF_SYM826=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM826
	.byte 3,141,200,1,11
	.asciz "V_1"

LDIFF_SYM827=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM827
	.byte 3,141,208,1,11
	.asciz "V_2"

LDIFF_SYM828=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM828
	.byte 3,141,216,1,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM829=Lfde119_end - Lfde119_start
	.long LDIFF_SYM829
Lfde119_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr

LDIFF_SYM830=Lme_a6 - wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr
	.long LDIFF_SYM830
	.long 0
	.byte 12,31,0,68,14,240,1,157,30,158,29,68,13,29,76,147,17,148,16,68,149,15,150,14,68,151,13,152,12,68,153,11
	.byte 154,10,68,155,9,156,8
	.align 3
Lfde119_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:void_objc_msgSendSuper_IntPtr_IntPtr_IntPtr"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr
	.quad Lme_a7

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM831=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM831
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM832=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM832
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM833=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM833
	.byte 2,141,32,3
	.asciz "param3"

LDIFF_SYM834=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM834
	.byte 2,141,40,3
	.asciz "param4"

LDIFF_SYM835=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM835
	.byte 2,141,48,11
	.asciz "V_0"

LDIFF_SYM836=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM836
	.byte 3,141,200,1,11
	.asciz "V_1"

LDIFF_SYM837=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM837
	.byte 3,141,208,1,11
	.asciz "V_2"

LDIFF_SYM838=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM838
	.byte 3,141,216,1,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM839=Lfde120_end - Lfde120_start
	.long LDIFF_SYM839
Lfde120_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr

LDIFF_SYM840=Lme_a7 - wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr
	.long LDIFF_SYM840
	.long 0
	.byte 12,31,0,68,14,240,1,157,30,158,29,68,13,29,76,147,17,148,16,68,149,15,150,14,68,151,13,152,12,68,153,11
	.byte 154,10,68,155,9,156,8
	.align 3
Lfde120_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:void_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr
	.quad Lme_a8

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM841=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM841
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM842=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM842
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM843=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM843
	.byte 2,141,32,3
	.asciz "param3"

LDIFF_SYM844=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM844
	.byte 2,141,40,3
	.asciz "param4"

LDIFF_SYM845=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM845
	.byte 2,141,48,3
	.asciz "param5"

LDIFF_SYM846=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM846
	.byte 2,141,56,3
	.asciz "param6"

LDIFF_SYM847=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM847
	.byte 3,141,192,0,3
	.asciz "param7"

LDIFF_SYM848=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM848
	.byte 3,141,200,0,11
	.asciz "V_0"

LDIFF_SYM849=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM849
	.byte 3,141,224,1,11
	.asciz "V_1"

LDIFF_SYM850=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM850
	.byte 3,141,232,1,11
	.asciz "V_2"

LDIFF_SYM851=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM851
	.byte 3,141,240,1,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM852=Lfde121_end - Lfde121_start
	.long LDIFF_SYM852
Lfde121_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr

LDIFF_SYM853=Lme_a8 - wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr
	.long LDIFF_SYM853
	.long 0
	.byte 12,31,0,68,14,128,2,157,32,158,31,68,13,29,76,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10
	.byte 154,9,68,155,8,156,7
	.align 3
Lfde121_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:void_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr
	.quad Lme_a9

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM854=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM854
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM855=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM855
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM856=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM856
	.byte 2,141,32,3
	.asciz "param3"

LDIFF_SYM857=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM857
	.byte 2,141,40,3
	.asciz "param4"

LDIFF_SYM858=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM858
	.byte 2,141,48,3
	.asciz "param5"

LDIFF_SYM859=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM859
	.byte 2,141,56,3
	.asciz "param6"

LDIFF_SYM860=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM860
	.byte 3,141,192,0,3
	.asciz "param7"

LDIFF_SYM861=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM861
	.byte 3,141,200,0,11
	.asciz "V_0"

LDIFF_SYM862=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM862
	.byte 3,141,224,1,11
	.asciz "V_1"

LDIFF_SYM863=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM863
	.byte 3,141,232,1,11
	.asciz "V_2"

LDIFF_SYM864=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM864
	.byte 3,141,240,1,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM865=Lfde122_end - Lfde122_start
	.long LDIFF_SYM865
Lfde122_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr

LDIFF_SYM866=Lme_a9 - wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr
	.long LDIFF_SYM866
	.long 0
	.byte 12,31,0,68,14,128,2,157,32,158,31,68,13,29,76,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10
	.byte 154,9,68,155,8,156,7
	.align 3
Lfde122_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:bool_objc_msgSend_IntPtr_IntPtr_ref_IntPtr"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_
	.quad Lme_aa

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM867=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM867
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM868=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM868
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM869=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM869
	.byte 2,141,32,3
	.asciz "param3"

LDIFF_SYM870=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM870
	.byte 2,141,40,3
	.asciz "param4"

LDIFF_SYM871=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM871
	.byte 2,141,48,11
	.asciz "V_0"

LDIFF_SYM872=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM872
	.byte 3,141,200,1,11
	.asciz "V_1"

LDIFF_SYM873=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM873
	.byte 3,141,208,1,11
	.asciz "V_2"

LDIFF_SYM874=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM874
	.byte 3,141,216,1,11
	.asciz "V_3"

LDIFF_SYM875=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM875
	.byte 1,100,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM876=Lfde123_end - Lfde123_start
	.long LDIFF_SYM876
Lfde123_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_

LDIFF_SYM877=Lme_aa - wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_
	.long LDIFF_SYM877
	.long 0
	.byte 12,31,0,68,14,240,1,157,30,158,29,68,13,29,76,147,17,148,16,68,149,15,150,14,68,151,13,152,12,68,153,11
	.byte 154,10,68,155,9,156,8
	.align 3
Lfde123_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:bool_objc_msgSendSuper_IntPtr_IntPtr_ref_IntPtr"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_
	.quad Lme_ab

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM878=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM878
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM879=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM879
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM880=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM880
	.byte 2,141,32,3
	.asciz "param3"

LDIFF_SYM881=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM881
	.byte 2,141,40,3
	.asciz "param4"

LDIFF_SYM882=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM882
	.byte 2,141,48,11
	.asciz "V_0"

LDIFF_SYM883=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM883
	.byte 3,141,200,1,11
	.asciz "V_1"

LDIFF_SYM884=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM884
	.byte 3,141,208,1,11
	.asciz "V_2"

LDIFF_SYM885=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM885
	.byte 3,141,216,1,11
	.asciz "V_3"

LDIFF_SYM886=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM886
	.byte 1,100,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM887=Lfde124_end - Lfde124_start
	.long LDIFF_SYM887
Lfde124_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_

LDIFF_SYM888=Lme_ab - wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_
	.long LDIFF_SYM888
	.long 0
	.byte 12,31,0,68,14,240,1,157,30,158,29,68,13,29,76,147,17,148,16,68,149,15,150,14,68,151,13,152,12,68,153,11
	.byte 154,10,68,155,9,156,8
	.align 3
Lfde124_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:bool_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_ref_IntPtr"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_
	.quad Lme_ac

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM889=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM889
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM890=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM890
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM891=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM891
	.byte 2,141,32,3
	.asciz "param3"

LDIFF_SYM892=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM892
	.byte 2,141,40,3
	.asciz "param4"

LDIFF_SYM893=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM893
	.byte 2,141,48,3
	.asciz "param5"

LDIFF_SYM894=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM894
	.byte 2,141,56,3
	.asciz "param6"

LDIFF_SYM895=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM895
	.byte 3,141,192,0,3
	.asciz "param7"

LDIFF_SYM896=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM896
	.byte 3,141,200,0,11
	.asciz "V_0"

LDIFF_SYM897=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM897
	.byte 3,141,224,1,11
	.asciz "V_1"

LDIFF_SYM898=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM898
	.byte 3,141,232,1,11
	.asciz "V_2"

LDIFF_SYM899=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM899
	.byte 3,141,240,1,11
	.asciz "V_3"

LDIFF_SYM900=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM900
	.byte 1,105,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM901=Lfde125_end - Lfde125_start
	.long LDIFF_SYM901
Lfde125_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_

LDIFF_SYM902=Lme_ac - wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_
	.long LDIFF_SYM902
	.long 0
	.byte 12,31,0,68,14,128,2,157,32,158,31,68,13,29,76,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10
	.byte 154,9,68,155,8,156,7
	.align 3
Lfde125_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:bool_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_ref_IntPtr"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_
	.quad Lme_ad

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM903=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM903
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM904=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM904
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM905=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM905
	.byte 2,141,32,3
	.asciz "param3"

LDIFF_SYM906=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM906
	.byte 2,141,40,3
	.asciz "param4"

LDIFF_SYM907=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM907
	.byte 2,141,48,3
	.asciz "param5"

LDIFF_SYM908=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM908
	.byte 2,141,56,3
	.asciz "param6"

LDIFF_SYM909=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM909
	.byte 3,141,192,0,3
	.asciz "param7"

LDIFF_SYM910=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM910
	.byte 3,141,200,0,11
	.asciz "V_0"

LDIFF_SYM911=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM911
	.byte 3,141,224,1,11
	.asciz "V_1"

LDIFF_SYM912=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM912
	.byte 3,141,232,1,11
	.asciz "V_2"

LDIFF_SYM913=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM913
	.byte 3,141,240,1,11
	.asciz "V_3"

LDIFF_SYM914=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM914
	.byte 1,105,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM915=Lfde126_end - Lfde126_start
	.long LDIFF_SYM915
Lfde126_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_

LDIFF_SYM916=Lme_ad - wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_
	.long LDIFF_SYM916
	.long 0
	.byte 12,31,0,68,14,128,2,157,32,158,31,68,13,29,76,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10
	.byte 154,9,68,155,8,156,7
	.align 3
Lfde126_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:bool_objc_msgSend_ref_IntPtr"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_ref_IntPtr_intptr_intptr_intptr_"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_ref_IntPtr_intptr_intptr_intptr_
	.quad Lme_ae

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM917=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM917
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM918=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM918
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM919=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM919
	.byte 2,141,32,11
	.asciz "V_0"

LDIFF_SYM920=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM920
	.byte 3,141,184,1,11
	.asciz "V_1"

LDIFF_SYM921=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM921
	.byte 3,141,192,1,11
	.asciz "V_2"

LDIFF_SYM922=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM922
	.byte 3,141,200,1,11
	.asciz "V_3"

LDIFF_SYM923=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM923
	.byte 1,102,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM924=Lfde127_end - Lfde127_start
	.long LDIFF_SYM924
Lfde127_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_ref_IntPtr_intptr_intptr_intptr_

LDIFF_SYM925=Lme_ae - wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_ref_IntPtr_intptr_intptr_intptr_
	.long LDIFF_SYM925
	.long 0
	.byte 12,31,0,68,14,208,1,157,26,158,25,68,13,29,76,147,15,148,14,68,149,13,150,12,68,151,11,152,10,68,153,9
	.byte 154,8,68,155,7,156,6
	.align 3
Lfde127_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:bool_objc_msgSendSuper_ref_IntPtr"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_ref_IntPtr_intptr_intptr_intptr_"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_ref_IntPtr_intptr_intptr_intptr_
	.quad Lme_af

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM926=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM926
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM927=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM927
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM928=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM928
	.byte 2,141,32,11
	.asciz "V_0"

LDIFF_SYM929=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM929
	.byte 3,141,184,1,11
	.asciz "V_1"

LDIFF_SYM930=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM930
	.byte 3,141,192,1,11
	.asciz "V_2"

LDIFF_SYM931=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM931
	.byte 3,141,200,1,11
	.asciz "V_3"

LDIFF_SYM932=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM932
	.byte 1,102,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM933=Lfde128_end - Lfde128_start
	.long LDIFF_SYM933
Lfde128_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_ref_IntPtr_intptr_intptr_intptr_

LDIFF_SYM934=Lme_af - wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_ref_IntPtr_intptr_intptr_intptr_
	.long LDIFF_SYM934
	.long 0
	.byte 12,31,0,68,14,208,1,157,26,158,25,68,13,29,76,147,15,148,14,68,149,13,150,12,68,151,11,152,10,68,153,9
	.byte 154,8,68,155,7,156,6
	.align 3
Lfde128_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:bool_objc_msgSend_IntPtr_ref_IntPtr"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_
	.quad Lme_b0

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM935=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM935
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM936=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM936
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM937=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM937
	.byte 2,141,32,3
	.asciz "param3"

LDIFF_SYM938=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM938
	.byte 2,141,40,11
	.asciz "V_0"

LDIFF_SYM939=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM939
	.byte 3,141,192,1,11
	.asciz "V_1"

LDIFF_SYM940=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM940
	.byte 3,141,200,1,11
	.asciz "V_2"

LDIFF_SYM941=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM941
	.byte 3,141,208,1,11
	.asciz "V_3"

LDIFF_SYM942=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM942
	.byte 1,101,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM943=Lfde129_end - Lfde129_start
	.long LDIFF_SYM943
Lfde129_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_

LDIFF_SYM944=Lme_b0 - wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_
	.long LDIFF_SYM944
	.long 0
	.byte 12,31,0,68,14,224,1,157,28,158,27,68,13,29,76,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10
	.byte 154,9,68,155,8,156,7
	.align 3
Lfde129_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:bool_objc_msgSendSuper_IntPtr_ref_IntPtr"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_
	.quad Lme_b1

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM945=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM945
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM946=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM946
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM947=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM947
	.byte 2,141,32,3
	.asciz "param3"

LDIFF_SYM948=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM948
	.byte 2,141,40,11
	.asciz "V_0"

LDIFF_SYM949=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM949
	.byte 3,141,192,1,11
	.asciz "V_1"

LDIFF_SYM950=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM950
	.byte 3,141,200,1,11
	.asciz "V_2"

LDIFF_SYM951=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM951
	.byte 3,141,208,1,11
	.asciz "V_3"

LDIFF_SYM952=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM952
	.byte 1,101,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM953=Lfde130_end - Lfde130_start
	.long LDIFF_SYM953
Lfde130_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_

LDIFF_SYM954=Lme_b1 - wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSendSuper_IntPtr_ref_IntPtr_intptr_intptr_intptr_intptr_
	.long LDIFF_SYM954
	.long 0
	.byte 12,31,0,68,14,224,1,157,28,158,27,68,13,29,76,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10
	.byte 154,9,68,155,8,156,7
	.align 3
Lfde130_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:int_objc_msgSend"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_int_objc_msgSend_intptr_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_int_objc_msgSend_intptr_intptr
	.quad Lme_b2

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM955=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM955
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM956=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM956
	.byte 2,141,24,11
	.asciz "V_0"

LDIFF_SYM957=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM957
	.byte 3,141,176,1,11
	.asciz "V_1"

LDIFF_SYM958=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM958
	.byte 3,141,184,1,11
	.asciz "V_2"

LDIFF_SYM959=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM959
	.byte 3,141,192,1,11
	.asciz "V_3"

LDIFF_SYM960=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM960
	.byte 1,103,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM961=Lfde131_end - Lfde131_start
	.long LDIFF_SYM961
Lfde131_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_int_objc_msgSend_intptr_intptr

LDIFF_SYM962=Lme_b2 - wrapper_managed_to_native_ApiDefinition_Messaging_int_objc_msgSend_intptr_intptr
	.long LDIFF_SYM962
	.long 0
	.byte 12,31,0,68,14,208,1,157,26,158,25,68,13,29,76,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10
	.byte 154,9,68,155,8,156,7
	.align 3
Lfde131_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:int_objc_msgSendSuper"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_int_objc_msgSendSuper_intptr_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_int_objc_msgSendSuper_intptr_intptr
	.quad Lme_b3

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM963=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM963
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM964=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM964
	.byte 2,141,24,11
	.asciz "V_0"

LDIFF_SYM965=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM965
	.byte 3,141,176,1,11
	.asciz "V_1"

LDIFF_SYM966=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM966
	.byte 3,141,184,1,11
	.asciz "V_2"

LDIFF_SYM967=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM967
	.byte 3,141,192,1,11
	.asciz "V_3"

LDIFF_SYM968=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM968
	.byte 1,103,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM969=Lfde132_end - Lfde132_start
	.long LDIFF_SYM969
Lfde132_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_int_objc_msgSendSuper_intptr_intptr

LDIFF_SYM970=Lme_b3 - wrapper_managed_to_native_ApiDefinition_Messaging_int_objc_msgSendSuper_intptr_intptr
	.long LDIFF_SYM970
	.long 0
	.byte 12,31,0,68,14,208,1,157,26,158,25,68,13,29,76,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10
	.byte 154,9,68,155,8,156,7
	.align 3
Lfde132_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:void_objc_msgSend_int"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_int_intptr_intptr_int"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_int_intptr_intptr_int
	.quad Lme_b4

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM971=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM971
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM972=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM972
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM973=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM973
	.byte 2,141,32,11
	.asciz "V_0"

LDIFF_SYM974=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM974
	.byte 3,141,184,1,11
	.asciz "V_1"

LDIFF_SYM975=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM975
	.byte 3,141,192,1,11
	.asciz "V_2"

LDIFF_SYM976=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM976
	.byte 3,141,200,1,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM977=Lfde133_end - Lfde133_start
	.long LDIFF_SYM977
Lfde133_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_int_intptr_intptr_int

LDIFF_SYM978=Lme_b4 - wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_int_intptr_intptr_int
	.long LDIFF_SYM978
	.long 0
	.byte 12,31,0,68,14,208,1,157,26,158,25,68,13,29,76,147,15,148,14,68,149,13,150,12,68,151,11,152,10,68,153,9
	.byte 154,8,68,155,7,156,6
	.align 3
Lfde133_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:void_objc_msgSendSuper_int"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_int_intptr_intptr_int"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_int_intptr_intptr_int
	.quad Lme_b5

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM979=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM979
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM980=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM980
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM981=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM981
	.byte 2,141,32,11
	.asciz "V_0"

LDIFF_SYM982=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM982
	.byte 3,141,184,1,11
	.asciz "V_1"

LDIFF_SYM983=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM983
	.byte 3,141,192,1,11
	.asciz "V_2"

LDIFF_SYM984=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM984
	.byte 3,141,200,1,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM985=Lfde134_end - Lfde134_start
	.long LDIFF_SYM985
Lfde134_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_int_intptr_intptr_int

LDIFF_SYM986=Lme_b5 - wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSendSuper_int_intptr_intptr_int
	.long LDIFF_SYM986
	.long 0
	.byte 12,31,0,68,14,208,1,157,26,158,25,68,13,29,76,147,15,148,14,68,149,13,150,12,68,151,11,152,10,68,153,9
	.byte 154,8,68,155,7,156,6
	.align 3
Lfde134_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ObjCRuntime.Trampolines:_Block_copy"
	.asciz "wrapper_managed_to_native_ObjCRuntime_Trampolines__Block_copy_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ObjCRuntime_Trampolines__Block_copy_intptr
	.quad Lme_b6

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM987=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM987
	.byte 2,141,16,11
	.asciz "V_0"

LDIFF_SYM988=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM988
	.byte 3,141,168,1,11
	.asciz "V_1"

LDIFF_SYM989=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM989
	.byte 3,141,176,1,11
	.asciz "V_2"

LDIFF_SYM990=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM990
	.byte 3,141,184,1,11
	.asciz "V_3"

LDIFF_SYM991=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM991
	.byte 1,104,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM992=Lfde135_end - Lfde135_start
	.long LDIFF_SYM992
Lfde135_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ObjCRuntime_Trampolines__Block_copy_intptr

LDIFF_SYM993=Lme_b6 - wrapper_managed_to_native_ObjCRuntime_Trampolines__Block_copy_intptr
	.long LDIFF_SYM993
	.long 0
	.byte 12,31,0,68,14,192,1,157,24,158,23,68,13,29,76,147,15,148,14,68,149,13,150,12,68,151,11,152,10,68,153,9
	.byte 154,8,68,155,7,156,6
	.align 3
Lfde135_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ObjCRuntime.Trampolines:_Block_release"
	.asciz "wrapper_managed_to_native_ObjCRuntime_Trampolines__Block_release_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ObjCRuntime_Trampolines__Block_release_intptr
	.quad Lme_b7

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM994=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM994
	.byte 2,141,16,11
	.asciz "V_0"

LDIFF_SYM995=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM995
	.byte 3,141,168,1,11
	.asciz "V_1"

LDIFF_SYM996=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM996
	.byte 3,141,176,1,11
	.asciz "V_2"

LDIFF_SYM997=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM997
	.byte 3,141,184,1,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM998=Lfde136_end - Lfde136_start
	.long LDIFF_SYM998
Lfde136_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ObjCRuntime_Trampolines__Block_release_intptr

LDIFF_SYM999=Lme_b7 - wrapper_managed_to_native_ObjCRuntime_Trampolines__Block_release_intptr
	.long LDIFF_SYM999
	.long 0
	.byte 12,31,0,68,14,192,1,157,24,158,23,68,13,29,76,147,15,148,14,68,149,13,150,12,68,151,11,152,10,68,153,9
	.byte 154,8,68,155,7,156,6
	.align 3
Lfde136_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_35:

	.byte 5
	.asciz "System_UInt32"

	.byte 20,16
LDIFF_SYM1000=LTDIE_11 - Ldebug_info_start
	.long LDIFF_SYM1000
	.byte 2,35,0,6
	.asciz "m_value"

LDIFF_SYM1001=LDIE_U4 - Ldebug_info_start
	.long LDIFF_SYM1001
	.byte 2,35,16,0,7
	.asciz "System_UInt32"

LDIFF_SYM1002=LTDIE_35 - Ldebug_info_start
	.long LDIFF_SYM1002
LTDIE_35_POINTER:

	.byte 13
LDIFF_SYM1003=LTDIE_35 - Ldebug_info_start
	.long LDIFF_SYM1003
LTDIE_35_REFERENCE:

	.byte 14
LDIFF_SYM1004=LTDIE_35 - Ldebug_info_start
	.long LDIFF_SYM1004
LTDIE_37:

	.byte 17
	.asciz "System_Collections_IDictionary"

	.byte 16,7
	.asciz "System_Collections_IDictionary"

LDIFF_SYM1005=LTDIE_37 - Ldebug_info_start
	.long LDIFF_SYM1005
LTDIE_37_POINTER:

	.byte 13
LDIFF_SYM1006=LTDIE_37 - Ldebug_info_start
	.long LDIFF_SYM1006
LTDIE_37_REFERENCE:

	.byte 14
LDIFF_SYM1007=LTDIE_37 - Ldebug_info_start
	.long LDIFF_SYM1007
LTDIE_39:

	.byte 17
	.asciz "System_Collections_Generic_IList`1"

	.byte 16,7
	.asciz "System_Collections_Generic_IList`1"

LDIFF_SYM1008=LTDIE_39 - Ldebug_info_start
	.long LDIFF_SYM1008
LTDIE_39_POINTER:

	.byte 13
LDIFF_SYM1009=LTDIE_39 - Ldebug_info_start
	.long LDIFF_SYM1009
LTDIE_39_REFERENCE:

	.byte 14
LDIFF_SYM1010=LTDIE_39 - Ldebug_info_start
	.long LDIFF_SYM1010
LTDIE_42:

	.byte 17
	.asciz "System_Collections_Generic_IEqualityComparer`1"

	.byte 16,7
	.asciz "System_Collections_Generic_IEqualityComparer`1"

LDIFF_SYM1011=LTDIE_42 - Ldebug_info_start
	.long LDIFF_SYM1011
LTDIE_42_POINTER:

	.byte 13
LDIFF_SYM1012=LTDIE_42 - Ldebug_info_start
	.long LDIFF_SYM1012
LTDIE_42_REFERENCE:

	.byte 14
LDIFF_SYM1013=LTDIE_42 - Ldebug_info_start
	.long LDIFF_SYM1013
LTDIE_43:

	.byte 5
	.asciz "_KeyCollection"

	.byte 24,16
LDIFF_SYM1014=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM1014
	.byte 2,35,0,6
	.asciz "dictionary"

LDIFF_SYM1015=LTDIE_41_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM1015
	.byte 2,35,16,0,7
	.asciz "_KeyCollection"

LDIFF_SYM1016=LTDIE_43 - Ldebug_info_start
	.long LDIFF_SYM1016
LTDIE_43_POINTER:

	.byte 13
LDIFF_SYM1017=LTDIE_43 - Ldebug_info_start
	.long LDIFF_SYM1017
LTDIE_43_REFERENCE:

	.byte 14
LDIFF_SYM1018=LTDIE_43 - Ldebug_info_start
	.long LDIFF_SYM1018
LTDIE_44:

	.byte 5
	.asciz "_ValueCollection"

	.byte 24,16
LDIFF_SYM1019=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM1019
	.byte 2,35,0,6
	.asciz "dictionary"

LDIFF_SYM1020=LTDIE_41_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM1020
	.byte 2,35,16,0,7
	.asciz "_ValueCollection"

LDIFF_SYM1021=LTDIE_44 - Ldebug_info_start
	.long LDIFF_SYM1021
LTDIE_44_POINTER:

	.byte 13
LDIFF_SYM1022=LTDIE_44 - Ldebug_info_start
	.long LDIFF_SYM1022
LTDIE_44_REFERENCE:

	.byte 14
LDIFF_SYM1023=LTDIE_44 - Ldebug_info_start
	.long LDIFF_SYM1023
LTDIE_41:

	.byte 5
	.asciz "System_Collections_Generic_Dictionary`2"

	.byte 80,16
LDIFF_SYM1024=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM1024
	.byte 2,35,0,6
	.asciz "buckets"

LDIFF_SYM1025=LDIE_SZARRAY - Ldebug_info_start
	.long LDIFF_SYM1025
	.byte 2,35,16,6
	.asciz "entries"

LDIFF_SYM1026=LDIE_SZARRAY - Ldebug_info_start
	.long LDIFF_SYM1026
	.byte 2,35,24,6
	.asciz "count"

LDIFF_SYM1027=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM1027
	.byte 2,35,64,6
	.asciz "version"

LDIFF_SYM1028=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM1028
	.byte 2,35,68,6
	.asciz "freeList"

LDIFF_SYM1029=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM1029
	.byte 2,35,72,6
	.asciz "freeCount"

LDIFF_SYM1030=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM1030
	.byte 2,35,76,6
	.asciz "comparer"

LDIFF_SYM1031=LTDIE_42_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM1031
	.byte 2,35,32,6
	.asciz "keys"

LDIFF_SYM1032=LTDIE_43_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM1032
	.byte 2,35,40,6
	.asciz "values"

LDIFF_SYM1033=LTDIE_44_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM1033
	.byte 2,35,48,6
	.asciz "_syncRoot"

LDIFF_SYM1034=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM1034
	.byte 2,35,56,0,7
	.asciz "System_Collections_Generic_Dictionary`2"

LDIFF_SYM1035=LTDIE_41 - Ldebug_info_start
	.long LDIFF_SYM1035
LTDIE_41_POINTER:

	.byte 13
LDIFF_SYM1036=LTDIE_41 - Ldebug_info_start
	.long LDIFF_SYM1036
LTDIE_41_REFERENCE:

	.byte 14
LDIFF_SYM1037=LTDIE_41 - Ldebug_info_start
	.long LDIFF_SYM1037
LTDIE_45:

	.byte 17
	.asciz "System_Runtime_Serialization_IFormatterConverter"

	.byte 16,7
	.asciz "System_Runtime_Serialization_IFormatterConverter"

LDIFF_SYM1038=LTDIE_45 - Ldebug_info_start
	.long LDIFF_SYM1038
LTDIE_45_POINTER:

	.byte 13
LDIFF_SYM1039=LTDIE_45 - Ldebug_info_start
	.long LDIFF_SYM1039
LTDIE_45_REFERENCE:

	.byte 14
LDIFF_SYM1040=LTDIE_45 - Ldebug_info_start
	.long LDIFF_SYM1040
LTDIE_40:

	.byte 5
	.asciz "System_Runtime_Serialization_SerializationInfo"

	.byte 88,16
LDIFF_SYM1041=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM1041
	.byte 2,35,0,6
	.asciz "m_members"

LDIFF_SYM1042=LDIE_SZARRAY - Ldebug_info_start
	.long LDIFF_SYM1042
	.byte 2,35,16,6
	.asciz "m_data"

LDIFF_SYM1043=LDIE_SZARRAY - Ldebug_info_start
	.long LDIFF_SYM1043
	.byte 2,35,24,6
	.asciz "m_types"

LDIFF_SYM1044=LDIE_SZARRAY - Ldebug_info_start
	.long LDIFF_SYM1044
	.byte 2,35,32,6
	.asciz "m_nameToIndex"

LDIFF_SYM1045=LTDIE_41_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM1045
	.byte 2,35,40,6
	.asciz "m_currMember"

LDIFF_SYM1046=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM1046
	.byte 2,35,80,6
	.asciz "m_converter"

LDIFF_SYM1047=LTDIE_45_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM1047
	.byte 2,35,48,6
	.asciz "m_fullTypeName"

LDIFF_SYM1048=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM1048
	.byte 2,35,56,6
	.asciz "m_assemName"

LDIFF_SYM1049=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM1049
	.byte 2,35,64,6
	.asciz "objectType"

LDIFF_SYM1050=LTDIE_23_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM1050
	.byte 2,35,72,6
	.asciz "isFullTypeNameSetExplicit"

LDIFF_SYM1051=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM1051
	.byte 2,35,84,6
	.asciz "isAssemblyNameSetExplicit"

LDIFF_SYM1052=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM1052
	.byte 2,35,85,6
	.asciz "requireSameTokenInPartialTrust"

LDIFF_SYM1053=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM1053
	.byte 2,35,86,0,7
	.asciz "System_Runtime_Serialization_SerializationInfo"

LDIFF_SYM1054=LTDIE_40 - Ldebug_info_start
	.long LDIFF_SYM1054
LTDIE_40_POINTER:

	.byte 13
LDIFF_SYM1055=LTDIE_40 - Ldebug_info_start
	.long LDIFF_SYM1055
LTDIE_40_REFERENCE:

	.byte 14
LDIFF_SYM1056=LTDIE_40 - Ldebug_info_start
	.long LDIFF_SYM1056
LTDIE_47:

	.byte 5
	.asciz "System_Reflection_TypeInfo"

	.byte 24,16
LDIFF_SYM1057=LTDIE_23 - Ldebug_info_start
	.long LDIFF_SYM1057
	.byte 2,35,0,0,7
	.asciz "System_Reflection_TypeInfo"

LDIFF_SYM1058=LTDIE_47 - Ldebug_info_start
	.long LDIFF_SYM1058
LTDIE_47_POINTER:

	.byte 13
LDIFF_SYM1059=LTDIE_47 - Ldebug_info_start
	.long LDIFF_SYM1059
LTDIE_47_REFERENCE:

	.byte 14
LDIFF_SYM1060=LTDIE_47 - Ldebug_info_start
	.long LDIFF_SYM1060
LTDIE_51:

	.byte 5
	.asciz "System_Reflection_ConstructorInfo"

	.byte 16,16
LDIFF_SYM1061=LTDIE_20 - Ldebug_info_start
	.long LDIFF_SYM1061
	.byte 2,35,0,0,7
	.asciz "System_Reflection_ConstructorInfo"

LDIFF_SYM1062=LTDIE_51 - Ldebug_info_start
	.long LDIFF_SYM1062
LTDIE_51_POINTER:

	.byte 13
LDIFF_SYM1063=LTDIE_51 - Ldebug_info_start
	.long LDIFF_SYM1063
LTDIE_51_REFERENCE:

	.byte 14
LDIFF_SYM1064=LTDIE_51 - Ldebug_info_start
	.long LDIFF_SYM1064
LTDIE_50:

	.byte 5
	.asciz "System_Reflection_RuntimeConstructorInfo"

	.byte 16,16
LDIFF_SYM1065=LTDIE_51 - Ldebug_info_start
	.long LDIFF_SYM1065
	.byte 2,35,0,0,7
	.asciz "System_Reflection_RuntimeConstructorInfo"

LDIFF_SYM1066=LTDIE_50 - Ldebug_info_start
	.long LDIFF_SYM1066
LTDIE_50_POINTER:

	.byte 13
LDIFF_SYM1067=LTDIE_50 - Ldebug_info_start
	.long LDIFF_SYM1067
LTDIE_50_REFERENCE:

	.byte 14
LDIFF_SYM1068=LTDIE_50 - Ldebug_info_start
	.long LDIFF_SYM1068
LTDIE_49:

	.byte 5
	.asciz "System_Reflection_MonoCMethod"

	.byte 40,16
LDIFF_SYM1069=LTDIE_50 - Ldebug_info_start
	.long LDIFF_SYM1069
	.byte 2,35,0,6
	.asciz "mhandle"

LDIFF_SYM1070=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM1070
	.byte 2,35,16,6
	.asciz "name"

LDIFF_SYM1071=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM1071
	.byte 2,35,24,6
	.asciz "reftype"

LDIFF_SYM1072=LTDIE_23_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM1072
	.byte 2,35,32,0,7
	.asciz "System_Reflection_MonoCMethod"

LDIFF_SYM1073=LTDIE_49 - Ldebug_info_start
	.long LDIFF_SYM1073
LTDIE_49_POINTER:

	.byte 13
LDIFF_SYM1074=LTDIE_49 - Ldebug_info_start
	.long LDIFF_SYM1074
LTDIE_49_REFERENCE:

	.byte 14
LDIFF_SYM1075=LTDIE_49 - Ldebug_info_start
	.long LDIFF_SYM1075
LTDIE_48:

	.byte 5
	.asciz "System_MonoTypeInfo"

	.byte 32,16
LDIFF_SYM1076=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM1076
	.byte 2,35,0,6
	.asciz "full_name"

LDIFF_SYM1077=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM1077
	.byte 2,35,16,6
	.asciz "default_ctor"

LDIFF_SYM1078=LTDIE_49_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM1078
	.byte 2,35,24,0,7
	.asciz "System_MonoTypeInfo"

LDIFF_SYM1079=LTDIE_48 - Ldebug_info_start
	.long LDIFF_SYM1079
LTDIE_48_POINTER:

	.byte 13
LDIFF_SYM1080=LTDIE_48 - Ldebug_info_start
	.long LDIFF_SYM1080
LTDIE_48_REFERENCE:

	.byte 14
LDIFF_SYM1081=LTDIE_48 - Ldebug_info_start
	.long LDIFF_SYM1081
LTDIE_46:

	.byte 5
	.asciz "System_RuntimeType"

	.byte 48,16
LDIFF_SYM1082=LTDIE_47 - Ldebug_info_start
	.long LDIFF_SYM1082
	.byte 2,35,0,6
	.asciz "type_info"

LDIFF_SYM1083=LTDIE_48_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM1083
	.byte 2,35,24,6
	.asciz "GenericCache"

LDIFF_SYM1084=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM1084
	.byte 2,35,32,6
	.asciz "m_serializationCtor"

LDIFF_SYM1085=LTDIE_50_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM1085
	.byte 2,35,40,0,7
	.asciz "System_RuntimeType"

LDIFF_SYM1086=LTDIE_46 - Ldebug_info_start
	.long LDIFF_SYM1086
LTDIE_46_POINTER:

	.byte 13
LDIFF_SYM1087=LTDIE_46 - Ldebug_info_start
	.long LDIFF_SYM1087
LTDIE_46_REFERENCE:

	.byte 14
LDIFF_SYM1088=LTDIE_46 - Ldebug_info_start
	.long LDIFF_SYM1088
LTDIE_52:

	.byte 5
	.asciz "System_EventHandler`1"

	.byte 112,16
LDIFF_SYM1089=LTDIE_17 - Ldebug_info_start
	.long LDIFF_SYM1089
	.byte 2,35,0,0,7
	.asciz "System_EventHandler`1"

LDIFF_SYM1090=LTDIE_52 - Ldebug_info_start
	.long LDIFF_SYM1090
LTDIE_52_POINTER:

	.byte 13
LDIFF_SYM1091=LTDIE_52 - Ldebug_info_start
	.long LDIFF_SYM1091
LTDIE_52_REFERENCE:

	.byte 14
LDIFF_SYM1092=LTDIE_52 - Ldebug_info_start
	.long LDIFF_SYM1092
LTDIE_38:

	.byte 5
	.asciz "System_Runtime_Serialization_SafeSerializationManager"

	.byte 56,16
LDIFF_SYM1093=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM1093
	.byte 2,35,0,6
	.asciz "m_serializedStates"

LDIFF_SYM1094=LTDIE_39_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM1094
	.byte 2,35,16,6
	.asciz "m_savedSerializationInfo"

LDIFF_SYM1095=LTDIE_40_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM1095
	.byte 2,35,24,6
	.asciz "m_realObject"

LDIFF_SYM1096=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM1096
	.byte 2,35,32,6
	.asciz "m_realType"

LDIFF_SYM1097=LTDIE_46_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM1097
	.byte 2,35,40,6
	.asciz "SerializeObjectState"

LDIFF_SYM1098=LTDIE_52_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM1098
	.byte 2,35,48,0,7
	.asciz "System_Runtime_Serialization_SafeSerializationManager"

LDIFF_SYM1099=LTDIE_38 - Ldebug_info_start
	.long LDIFF_SYM1099
LTDIE_38_POINTER:

	.byte 13
LDIFF_SYM1100=LTDIE_38 - Ldebug_info_start
	.long LDIFF_SYM1100
LTDIE_38_REFERENCE:

	.byte 14
LDIFF_SYM1101=LTDIE_38 - Ldebug_info_start
	.long LDIFF_SYM1101
LTDIE_36:

	.byte 5
	.asciz "System_Exception"

	.byte 136,1,16
LDIFF_SYM1102=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM1102
	.byte 2,35,0,6
	.asciz "_className"

LDIFF_SYM1103=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM1103
	.byte 2,35,16,6
	.asciz "_message"

LDIFF_SYM1104=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM1104
	.byte 2,35,24,6
	.asciz "_data"

LDIFF_SYM1105=LTDIE_37_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM1105
	.byte 2,35,32,6
	.asciz "_innerException"

LDIFF_SYM1106=LTDIE_36_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM1106
	.byte 2,35,40,6
	.asciz "_helpURL"

LDIFF_SYM1107=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM1107
	.byte 2,35,48,6
	.asciz "_stackTrace"

LDIFF_SYM1108=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM1108
	.byte 2,35,56,6
	.asciz "_stackTraceString"

LDIFF_SYM1109=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM1109
	.byte 2,35,64,6
	.asciz "_remoteStackTraceString"

LDIFF_SYM1110=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM1110
	.byte 2,35,72,6
	.asciz "_remoteStackIndex"

LDIFF_SYM1111=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM1111
	.byte 2,35,80,6
	.asciz "_dynamicMethods"

LDIFF_SYM1112=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM1112
	.byte 2,35,88,6
	.asciz "_HResult"

LDIFF_SYM1113=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM1113
	.byte 2,35,96,6
	.asciz "_source"

LDIFF_SYM1114=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM1114
	.byte 2,35,104,6
	.asciz "_safeSerializationManager"

LDIFF_SYM1115=LTDIE_38_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM1115
	.byte 2,35,112,6
	.asciz "captured_traces"

LDIFF_SYM1116=LDIE_SZARRAY - Ldebug_info_start
	.long LDIFF_SYM1116
	.byte 2,35,120,6
	.asciz "native_trace_ips"

LDIFF_SYM1117=LDIE_SZARRAY - Ldebug_info_start
	.long LDIFF_SYM1117
	.byte 3,35,128,1,0,7
	.asciz "System_Exception"

LDIFF_SYM1118=LTDIE_36 - Ldebug_info_start
	.long LDIFF_SYM1118
LTDIE_36_POINTER:

	.byte 13
LDIFF_SYM1119=LTDIE_36 - Ldebug_info_start
	.long LDIFF_SYM1119
LTDIE_36_REFERENCE:

	.byte 14
LDIFF_SYM1120=LTDIE_36 - Ldebug_info_start
	.long LDIFF_SYM1120
	.byte 2
	.asciz "(wrapper_native-to-managed)_ObjCRuntime.Trampolines/SDErrorCallback:Invoke"
	.asciz "wrapper_native_to_managed_ObjCRuntime_Trampolines_SDErrorCallback_Invoke_intptr_intptr"

	.byte 0,0
	.quad wrapper_native_to_managed_ObjCRuntime_Trampolines_SDErrorCallback_Invoke_intptr_intptr
	.quad Lme_b8

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM1121=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM1121
	.byte 2,141,32,3
	.asciz "param1"

LDIFF_SYM1122=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM1122
	.byte 2,141,40,11
	.asciz "V_0"

LDIFF_SYM1123=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM1123
	.byte 3,141,200,0,11
	.asciz "V_1"

LDIFF_SYM1124=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM1124
	.byte 3,141,208,0,11
	.asciz "V_2"

LDIFF_SYM1125=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM1125
	.byte 3,141,216,0,11
	.asciz "V_3"

LDIFF_SYM1126=LDIE_U4 - Ldebug_info_start
	.long LDIFF_SYM1126
	.byte 3,141,224,0,11
	.asciz "V_4"

LDIFF_SYM1127=LTDIE_36_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM1127
	.byte 3,141,232,0,11
	.asciz "V_5"

LDIFF_SYM1128=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM1128
	.byte 3,141,240,0,11
	.asciz "V_6"

LDIFF_SYM1129=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM1129
	.byte 3,141,248,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM1130=Lfde137_end - Lfde137_start
	.long LDIFF_SYM1130
Lfde137_start:

	.long 0
	.align 3
	.quad wrapper_native_to_managed_ObjCRuntime_Trampolines_SDErrorCallback_Invoke_intptr_intptr

LDIFF_SYM1131=Lme_b8 - wrapper_native_to_managed_ObjCRuntime_Trampolines_SDErrorCallback_Invoke_intptr_intptr
	.long LDIFF_SYM1131
	.long 0
	.byte 12,31,0,68,14,192,1,157,24,158,23,68,13,29,68,150,22,151,21
	.align 3
Lfde137_end:

.section __DWARF, __debug_info,regular,debug

	.byte 0
Ldebug_info_end:
.text
	.align 3
mem_end:

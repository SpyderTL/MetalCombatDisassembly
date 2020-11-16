public class SnesRom
{
	public void L008C3B_Reset()
	{
		I = 1;
		C = 0;
		temp = C; C = E; E = temp;
		return this.L808C42_Start();
	}







	// Bank 0x80
	public void R808202_WaitFor014BFlag1()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P |= 0x30;
		A = 0x01;
		[0x014B] = A;
	}

	public void L80820D_Loop()
	{
		A = [0x014B];

		if (Z == 0)
			return this.L80820D_Loop();

		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}








	public void R808215_EnableVBlankIRQ()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P |= 0x20;
		A = [0x013C];
		A |= 0x80;
		[0x4200] = A;
		[0x013C] = A;
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}








	public void R808229_DisableVBlankIRQ()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P |= 0x20;
		A = [0x013C];
		A &= 0x7F;
		[0x4200] = A;
		[0x013C] = A;
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}








	public void R80823D_Set0100Flag80()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P |= 0x20;
		A = [0x0100];
		A |= 0x80;
		[0x0100] = A;
		this.R808202_WaitFor014BFlag1();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}








	public void R808252_Clear0100Flag80()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P |= 0x20;
		A = [0x0100];
		A &= 0x7F;
		[0x0100] = A;
		this.R808202_WaitFor014BFlag1();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}








	public void R80827B_Clear013CAnd4200Flag10()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P |= 0x20;
		A = [0x013C];
		A &= 0xEF;
		[0x4200] = A;
		[0x013C] = A;
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}








	public void R8082A3_Clear013CAnd4200Flag20()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P |= 0x20;
		A = [0x013C];
		A &= 0xDF;
		[0x4200] = A;
		[0x013C] = A;
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}








	public void R808306_HandleEvents()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P |= 0x20;
		A = [0x0154];

		if (Z == 1)
			return this.L808345_EventType0_Done();

		[0x0154] = 0;
		[0x420B] = 0;
		[0x420C] = 0;
		P &= ~0x30;

		// Word0152_NextEvent = 0;
		[0x0152] = 0;
		Y = 0x0000;
	}

	public void L808322_Loop()
	{
		// if (Y > 0x0100) Stop;
		temp = Y - 0x0100;

		if (C == 0)
			return this.L808329();
	}

	public void L808327_Stop()
	{
		return this.L808327_Stop();
	}

	public void L808329()
	{
		// if (EventType > 5) Stop;
		A = [0x0155 + Y];
		A &= 0x00FF;
		temp = A - 0x0005;

		if (C == 0)
			return this.L808336();
	}

	public void L808334_Stop()
	{
		return this.L808334_Stop();
	}

	public void L808336()
	{
		// FunctionTable[A * 2]();
		A <<= 1;
		X = A;
		return [(0x833B + X)]();
	}

	public byte[] FunctionTable80833B = new byte[]
	{
		0x45, 0x83,
		0x4D, 0x83,
		0x8B, 0x83,
		0xD7, 0x83,
		0x29, 0x84
	}

	public void L808345_EventType0_Done()
	{
		P |= 0x20;
		[0x0155] = 0;
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L80834D_EventType1()
	{
		P |= 0x20;

		A = [0x0156 + Y];
		[0x4312] = A;
		A = [0x0157 + Y];
		[0x4313] = A;
		A = [0x0158 + Y];
		[0x4314] = A;
		A = [0x0159 + Y];
		[0x4315] = A;
		A = [0x015A + Y];
		[0x4316] = A;
		A = [0x015B + Y];
		[0x2121] = A;
		[0x4310] = 0;
		A = 0x22;
		[0x4311] = A;
		A = 0x02;
		[0x420B] = A;

		// Y += 7
		P &= ~0x20;
		A = Y;
		C = 0;
		A += 0x0007 + C;
		Y = A;
		return this.L808322_Loop();
	}

	public void L80838B_EventType2()
	{
		P |= 0x20;

		A = [0x0156 + Y];
		[0x4312] = A;
		A = [0x0157 + Y];
		[0x4313] = A;
		A = [0x0158 + Y];
		[0x4314] = A;
		A = [0x0159 + Y];
		[0x4315] = A;
		A = [0x015A + Y];
		[0x4316] = A;
		A = [0x015B + Y];
		[0x2115] = A;
		A = [0x015C + Y];
		[0x2116] = A;
		A = [0x015D + Y];
		[0x2117] = A;
		A = 0x01;
		[0x4310] = A;
		A = 0x18;
		[0x4311] = A;
		A = 0x02;
		[0x420B] = A;

		// Y += 9;
		P &= ~0x20;
		A = Y;
		C = 0;
		A += 0x0009 + C;
		Y = A;
		return this.L808322_Loop();
	}

	public void L8083D7_EventType3()
	{
		P |= 0x20;

		A = [0x0156 + Y];
		[0x4312] = A;
		A = [0x0157 + Y];
		[0x4313] = A;
		A = [0x0158 + Y];
		[0x4314] = A;
		A = [0x0159 + Y];
		[0x4315] = A;
		A = [0x015A + Y];
		[0x4316] = A;
		A = [0x015B + Y];
		[0x2115] = A;
		A = [0x015C + Y];
		[0x2116] = A;
		A = [0x015D + Y];
		[0x2117] = A;
		A = 0x81;
		[0x4310] = A;
		A = 0x39;
		[0x4311] = A;
		A = [0x2139];
		A = [0x213A];
		A = 0x02;
		[0x420B] = A;

		// Y += 9
		P &= ~0x20;
		A = Y;
		C = 0;
		A += 0x0009 + C;
		Y = A;

		return this.L808322_Loop();
	}

	public void L808429_EventType4()
	{
		P |= 0x20;

		A = [0x0156 + Y];
		[0x4312] = A;
		A = [0x0157 + Y];
		[0x4313] = A;
		A = [0x0158 + Y];
		[0x4314] = A;
		A = [0x0159 + Y];
		[0x4315] = A;
		A = [0x015A + Y];
		[0x4316] = A;
		A = [0x015B + Y];
		[0x4310] = A;
		A = [0x015C + Y];
		[0x4311] = A;
		A = [0x015D + Y];
		[0x2115] = A;
		A = [0x015E + Y];
		[0x2116] = A;
		A = [0x015F + Y];
		[0x2117] = A;
		A = 0x02;
		[0x420B] = A;

		// Y += 11;
		P &= ~0x20;
		A = Y;
		C = 0;
		A += 0x000B + C;
		Y = A;

		return this.L808322_Loop();
	}








	public void R80850F_SetRam()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
	}

	public void L808515_Loop()
	{
		[0x7E0000 + X] = A;
		X++;
		X++;
		Y--;
		Y--;

		if (Z == 0)
			return this.L808515_Loop();

		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}








	public void R808744()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		A = 0x8000;
		[0x01] = A;
		A = 0x875B;
		[0x00] = A;
		this.R8087A4_LoadDmaTransferRecord();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public byte[] DmaTransferRecord80875B = new byte[]
	{
		// Type 0x02, RAM Address 0x7E2000, Length 0x0800, VRAM Control 0x80, VRAM Address 0x0000
		0x02, 0x00, 0x20, 0x7E, 0x00, 0x08, 0x80, 0x00, 0x00
	}







	public void R808764()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		A = 0x8000;
		[0x01] = A;
		A = 0x877B;
		[0x00] = A;
		this.R8087A4_LoadDmaTransferRecord();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public byte[] DmaTransferRecord80877B = new byte[]
	{
		// Type 0x02, RAM Address 0x7E2800, Length 0x0800, VRAM Control 0x80, VRAM Address 0x0800
		0x02, 0x00, 0x28, 0x7E, 0x00, 0x08, 0x80, 0x00, 0x08
	}





	public void R808784()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		A = 0x8000;
		[0x01] = A;
		A = 0x879B;
		[0x00] = A;
		this.R8087A4_LoadDmaTransferRecord();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public byte[] DmaTransferRecord80879B = new byte[]
	{
		// Type 0x02, RAM Address 0x7E3000, Length 0x0800, VRAM Control 0x80, VRAM Address 0x1C00
		0x02, 0x00, 0x30, 0x7E, 0x00, 0x08, 0x80, 0x00, 0x1C
	}








	public void R8087A4_LoadDmaTransferRecord()
	{
		Stack.Push(P);
		P &= ~0x30;

		// X = Word0152_NextEvent
		X = [0x0152];

		Y = 0x0000;
		P |= 0x20;

		// A = EventType
		A = [[0x00] + Y];
		Y++;

		// Write EventType To Event List
		[0x0155 + X] = A;

		// Event Type 0x01
		A--;

		if (Z == 0)
			return this.L8087BB();

		return this.L808822_EventType1();
	}

	public void L8087BB()
	{
		// Event Type 0x02
		A--;

		if (Z == 0)
			return this.L8087C1();

		return this.L8087CD_EventTypeOther();
	}

	public void L8087C1()
	{
		// Event Type 0x03
		A--;

		if (Z == 0)
			return this.L8087C7();

		return this.L8087CD_EventTypeOther();
	}

	public void L8087C7()
	{
		// Event Type 0x04
		A--;

		if (Z == 0)
			return this.L8087CD_EventTypeOther();

		return this.L8087F3_EventType4();
	}

	public void L8087CD_EventTypeOther()
	{
		[0x015E + X] = 0;
		P &= ~0x20;
		A = [[0x00] + Y];
		[0x0156 + X] = A;
		Y++;
		Y++;
		A = [[0x00] + Y];
		[0x0158 + X] = A;
		Y++;
		Y++;
		A = [[0x00] + Y];
		[0x015A + X] = A;
		Y++;
		Y++;
		A = [[0x00] + Y];
		[0x015C + X] = A;
		A = X;
		C = 0;
		A += 0x0009 + C;
		return this.L80883F_SetNextEvent();
	}

	public void L8087F3_EventType4()
	{
		[0x0160 + X] = 0;
		P &= ~0x20;
		A = [[0x00] + Y];
		[0x0156 + X] = A;
		Y++;
		Y++;
		A = [[0x00] + Y];
		[0x0158 + X] = A;
		Y++;
		Y++;
		A = [[0x00] + Y];
		[0x015A + X] = A;
		Y++;
		Y++;
		A = [[0x00] + Y];
		[0x015C + X] = A;
		Y++;
		Y++;
		A = [[0x00] + Y];
		[0x015E + X] = A;
		Y++;
		Y++;
		A = X;
		C = 0;
		A += 0x000B + C;
		return this.L80883F_SetNextEvent();
	}

	public void L808822_EventType1()
	{
		[0x015C + X] = 0;
		P &= ~0x20;
		A = [[0x00] + Y];
		[0x0156 + X] = A;
		Y++;
		Y++;
		A = [[0x00] + Y];
		[0x0158 + X] = A;
		Y++;
		Y++;
		A = [[0x00] + Y];
		[0x015A + X] = A;
		A = X;
		C = 0;
		A += 0x0007 + C;
	}

	public void L80883F_SetNextEvent()
	{
		// Word0152_NextEvent = A;
		[0x0152] = A;

		// Flag0154 = 1;
		P |= 0x30;
		A = 0x01;
		[0x0154] = A;

		A = [0x02D6];

		if (N == 0)
			return this.L808852_Done();

		this.R808306_HandleEvents();
	}

	public void L808852_Done()
	{
		P = Stack.Pop();
		return;
	}








	public void L808C42_Start()
	{
		P |= 0x20;

		// Screen Display (Blank)
		A = 0x80;
		[0x0100] = A;
		[0x2100] = A;

		A = 0x00;
		[0x7FF7] = A;

		P |= 0x30;

		// DMA
		[0x420B] = 0;
		[0x420C] = 0;

		// APU
		[0x2140] = 0;
		[0x2141] = 0;
		[0x2142] = 0;
		[0x2143] = 0;

		// Stack
		P &= ~0x30;
		X = 0x1FFF;
		S = X;

		// Direct Bank (0x0000)
		Y = 0x0000;
		Stack.Push(Y);
		D = Stack.Pop();

		// Data Bank (Program Bank)
		Stack.Push(K);
		B = Stack.Pop();

		return this.L808EE3_Start2();
	}








	public void R808C76_ResetRegisters()
	{
		Stack.Push(P);
		P |= 0x30;

		// Set Flag013C
		A = 0x01;
		[0x4200] = A;
		[0x013C] = A;

		// Enable PPU H/V Scanline Latch
		A = 0x80;
		[0x4201] = A;

		[0x4202] = 0;
		[0x4203] = 0;
		[0x4204] = 0;
		[0x4205] = 0;
		[0x4206] = 0;
		[0x4207] = 0;
		[0x013F] = 0;
		[0x4208] = 0;
		[0x0140] = 0;
		[0x4209] = 0;
		[0x013D] = 0;
		[0x420A] = 0;
		[0x013E] = 0;
		[0x420B] = 0;
		[0x420C] = 0;
		[0x0141] = 0;

		// ROM Speed (Fast)
		A = 0x01;
		[0x420D] = A;
		[0x0142] = A;

		P = Stack.Pop();

		return;
	}








	public void R808CC0_ResetPPU()
	{
		Stack.Push(P);
		P |= 0x30;

		// Screen Brightness (Blank)
		A = 0x8F;
		[0x2100] = A;
		[0x0100] = A;

		// Sprite Size (8x8 / 16x16 / Name: 0 / Address : 1 << 14)
		A = 0x01;
		[0x2101] = A;
		[0x0101] = A;

		// Sprite Address (0x0000 / Priority : 1)
		[0x2102] = 0;
		[0x0102] = 0;

		A = 0x80;
		[0x2103] = A;
		[0x0103] = A;

		// Sprite Data
		[0x2104] = 0;
		[0x2104] = 0;

		// Background Mode (Mode 9)
		A = 0x09;
		[0x2105] = A;
		[0x0104] = A;

		// Mosaic Enable (Off)
		[0x2106] = 0;
		[0x0105] = 0;

		// Background 1 Tilemap Address (0x00 << 10)
		A = 0x00;
		[0x2107] = A;
		[0x0106] = A;

		// Background 2 Tilemap Address (0x08 << 10)
		A = 0x08;
		[0x2108] = A;
		[0x0107] = A;

		// Background 3 Tilemap Address (0x1C << 10)
		A = 0x1C;
		[0x2109] = A;
		[0x0108] = A;

		// Background 4 Tilemap Address (0x00 << 10)
		A = 0x00;
		[0x210A] = 0;
		[0x0109] = 0;

		// Background 1/2 Character Address (0x06 << 12 / 0x00 << 12)
		A = 0x06;
		[0x210B] = A;
		[0x010A] = A;

		// Background 3/4 Character Address (0x01 << 12 / 0x00 << 12)
		A = 0x01;
		[0x210C] = A;
		[0x010B] = A;

		// Background 1-4 H/V Scroll (0x00)
		[0x210D] = 0;
		[0x210D] = 0;
		[0x210E] = 0;
		[0x210E] = 0;
		[0x210F] = 0;
		[0x210F] = 0;
		[0x2110] = 0;
		[0x2110] = 0;
		[0x2111] = 0;
		[0x2111] = 0;
		[0x2112] = 0;
		[0x2112] = 0;
		[0x2113] = 0;
		[0x2113] = 0;
		[0x2114] = 0;
		[0x2114] = 0;

		// Video Port Control
		[0x2115] = 0;

		// Mode 7 Settings
		[0x211A] = 0;
		[0x010C] = 0;

		// Mode 7 Matrix
		[0x211B] = 0;
		[0x211C] = 0;
		[0x211D] = 0;
		[0x211E] = 0;

		// Mode 7 Center X/Y
		[0x211F] = 0;
		[0x2120] = 0;

		// Background 1/2 Window
		A = 0x00;
		[0x2123] = A;
		[0x010D] = A;

		// Background 3/4 Window
		A = 0x00;
		[0x2124] = A;
		[0x010E] = A;

		// Sprite/Color Window
		[0x2125] = 0;
		[0x011F] = 0;

		// Window 1 Left
		A = 0x00;
		[0x2126] = A;
		[0x0120] = A;

		// Window 1 Right
		A = 0xF8;
		[0x2127] = A;
		[0x0121] = A;

		// Window 2 Left
		[0x2128] = 0;
		[0x0122] = 0;

		// Window 2 Right
		[0x2129] = 0;
		[0x0123] = 0;

		// Background Window Mask
		[0x212A] = 0;
		[0x0124] = 0;

		// Sprite / Color Window Mask
		[0x212B] = 0;
		[0x0125] = 0;

		// Main Screen Background Enable
		A = 0x11;
		[0x212C] = A;
		[0x0126] = A;

		// Main Screen Background Mask Enable
		[0x212E] = A;
		[0x0128] = A;

		// Sub Screen Background Enable
		A = 0x02;
		[0x212D] = A;
		[0x0127] = A;

		// Sub Screen Background Mask Enable
		[0x212F] = A;
		[0x0129] = A;

		// Color Addition Select
		A = 0x02;
		[0x2130] = A;
		[0x012A] = A;

		// Color Math Designation
		A = 0xA1;
		[0x2131] = A;
		[0x012B] = A;

		// Fixed Color Data (R: 0)
		A = 0x20;
		[0x2132] = A;
		[0x012E] = A;

		// Fixed Color Data (G: 0)
		A = 0x40;
		[0x2132] = A;
		[0x012D] = A;

		// Fixed Color Data (B: 0)
		A = 0x80;
		[0x2132] = A;
		[0x012C] = A;

		// Screen Mode (None)
		A = 0x00;
		[0x2133] = A;
		[0x012F] = A;

		P = Stack.Pop();

		return;
	}








	public void R808E19_Insanity()
	{
		P &= ~0x30;
		A = 0x1C2F;
		this.R808E3F_SetRam2000();
		A = 0x1C2F;
		this.R808E52_SetRam2800();
		A = 0x1C2F;
		this.R808E65_SetRam3000();
		P |= 0x30;
		this.R808744();
		this.R808764();
		this.R808784();
		return;
	}








	public void R808E3F_SetRam2000()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		X = 0x2000;
		Y = 0x0800;
		this.R80850F_SetRam();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}








	public void R808E52_SetRam2800()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		X = 0x2800;
		Y = 0x0800;
		this.R80850F_SetRam();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}








	public void R808E65_SetRam3000()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		X = 0x3000;
		Y = 0x0800;
		this.R80850F_SetRam();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}








	public void R808E78_MainLoop_2()
	{
		Stack.Push(P);
		P &= ~0x30;
		this.R808EA7();

		// Value0257 = (Value0255 >= 5);
		A = [0x0255];
		temp = A - 0x0005;

		if (C == 0)
			return this.L808E8E();

		A = 0x0001;
		[0x0257] = A;
		return this.L808E91();
	}

	public void L808E8E()
	{
		[0x0257] = 0;
	}

	public void L808E91()
	{
		// Value0261 = Value0259 + Value025D
		A = [0x0259];
		C = 0;
		A += [0x025D] + C;
		[0x0261] = A;

		// Value0263 = Value025B + Value025F
		A = [0x025B];
		C = 0;
		A += [0x025F] + C;
		[0x0263] = A;
		P = Stack.Pop();
		return;
	}








	public void R808EA7()
	{
		Stack.Push(P);
		P |= 0x20;

		// if (Ppu.LatchFlag == false) Skip;
		A = [0x213F];
		temp = A & 0x40;

		if (Z == 1)
			return this.L808ED9();

		A = [0x00213C];
		[0x0259] = A;
		A = [0x00213C];
		A &= 0x01;
		[0x025A] = A;
		A = [0x00213D];
		[0x025B] = A;
		A = [0x00213D];
		A &= 0x01;
		[0x025C] = A;
		[0x0255] = 0;
	}

	public void L808ED4()
	{
		[0x0256] = 0;
		P = Stack.Pop();
		return;
	}

	public void L808ED9()
	{
		// Value0255_PPULatchTimer = Min(255, Value0255_PPULatchTimer + 1);
		[0x0255]++;

		if (Z == 0)
			return this.L808ED4();

		[0x0255]--;
		return this.L808ED4();
	}

	public void L808EE3_Start2()
	{
		P |= 0x30;
		A = 0xA1;
		[0x7FF5] = A;
		A = 0x0A;
		[0x7FF7] = A;
		P &= ~0x30;
		X = 0x01FE;
	}

	public void L808EF4_Loop()
	{
		[0x00 + X] = 0;
		[0x0200 + X] = 0;
		[0x0400 + X] = 0;
		[0x0600 + X] = 0;
		[0x0800 + X] = 0;
		[0x0A00 + X] = 0;
		[0x0C00 + X] = 0;
		[0x0E00 + X] = 0;
		[0x1000 + X] = 0;
		[0x1200 + X] = 0;
		[0x1400 + X] = 0;
		[0x1600 + X] = 0;
		[0x1800 + X] = 0;
		[0x1A00 + X] = 0;
		[0x1C00 + X] = 0;
		[0x1E00 + X] = 0;
		X--;
		X--;

		if (N == 0)
			return this.L808EF4_Loop();

		return this.L808F49_Start3();
	}

	public void L808F49_Start3()
	{
		P |= 0x30;
		[0x4200] = 0;
		[0x013C] = 0;
		A = 0x8F;
		[0x2100] = A;
		[0x0100] = A;
		this.R808C76_ResetRegisters();
		this.R808CC0_ResetPPU();
		this.R808E19_Insanity();
		this.R809D46_InitializeObd1Ram();
		this.R809BAB_FillTable7800();
		this.R808215_EnableVBlankIRQ();
		P |= 0x20;
		A = 0x54;
		[0x36] = A;
		[0x37] = 0;
		[0x38] = 0;
		A = 0x6B;
		[0x39] = A;
		A = 0x44;
		[0x3A] = A;
		[0x3B] = 0;
		[0x3C] = 0;
		A = 0x6B;
		[0x3D] = A;
		A = 0x01;
		[0x4B] = A;
		P &= ~0x30;
		this.R8CC0E8_ResetRegistersAndRam();
		this.R808252_Clear0100Flag80();
		P &= ~0x30;
		this.R80942D();
		P &= ~0x30;
		Y = 0x003C;
	}

	public void L808FA1_Loop()
	{
		this.R808202_WaitFor014BFlag1();
		Y--;

		if (Z == 0)
			return this.L808FA1_Loop();

		// Clear RAM
		P |= 0x30;
		A = 0x7E;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x30;
		X = 0x0FFE;
		A = 0x0000;
	}

	public void L808FB6_Loop()
	{
		[0x2000 + X] = A;
		[0x3000 + X] = A;
		[0x4000 + X] = A;
		[0x5000 + X] = A;
		[0x6000 + X] = A;
		[0x7000 + X] = A;
		[0x8000 + X] = A;
		[0x9000 + X] = A;
		[0xA000 + X] = A;
		[0xB000 + X] = A;
		[0xC000 + X] = A;
		[0xD000 + X] = A;
		[0xE000 + X] = A;
		[0xF000 + X] = A;
		X--;
		X--;

		if (N == 0)
			return this.L808FB6_Loop();

		P |= 0x30;
		A = 0x7F;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x30;
		X = 0x0FFE;
		A = 0x0000;
	}

	public void L808FF2_Loop()
	{
		[0x0000 + X] = A;
		[0x1000 + X] = A;
		[0x2000 + X] = A;
		[0x3000 + X] = A;
		[0x4000 + X] = A;
		[0x5000 + X] = A;
		[0x6000 + X] = A;
		[0x7000 + X] = A;
		[0x8000 + X] = A;
		[0x9000 + X] = A;
		[0xA000 + X] = A;
		[0xB000 + X] = A;
		[0xC000 + X] = A;
		[0xD000 + X] = A;
		[0xE000 + X] = A;
		[0xF000 + X] = A;
		X--;
		X--;

		if (N == 0)
			return this.L808FF2_Loop();

		Stack.Push(K);
		B = Stack.Pop();
		P |= 0x20;
		A = 0x0F;
		[0x0100] = A;
	}

	public void L80902F_Loop()
	{
		this.R808202_WaitFor014BFlag1();
		[0x0100]--;

		if (Z == 0)
			return this.L80902F_Loop();

		P &= ~0x20;
		this.R80823D_Set0100Flag80();
		A = 0x8000;
		[0x01] = A;
		A = 0x904E;
		[0x00] = A;
		this.R8087A4_LoadDmaTransferRecord();
		return this.L809059_LoadEvents9069();
	}

	public byte[] DmaTransferRecord80904E = new byte[]
	{
		// Type 0x04, RAM Address 0x809077, Length 0x8000, DMA Control 0x08, DMA Address 0x2119, VRAM Control 0x80, VRAM Address 0x0000
		0x04, 0x77, 0x90, 0x80, 0x00, 0x80, 0x08, 0x19, 0x80, 0x00, 0x00
	}

	public void L809059_LoadEvents9069()
	{
		A = 0x8000;
		[0x01] = A;
		A = 0x9069;
		[0x00] = A;
		this.R8087A4_LoadDmaTransferRecord();
		return this.L809074();
	}

	public byte[] DmaTransferRecord809069 = new byte[]
	{
		// Type 0x04, RAM Address 0x809076, Length 0x8000, DMA Control 0x08, DMA Address 0x2118, VRAM Control 0x00, VRAM Address 0x0000
		0x04, 0x76, 0x90, 0x80, 0x00, 0x80, 0x08, 0x18, 0x00, 0x00, 0x00
	}

	public void L809074()
	{
		return this.L809078();
	}

	public void L809078()
	{
		P &= ~0x30;
		[0x026D] = 0;
		[0x0265] = 0;
		[0x0267] = 0;
		this.R809559_InitializeRam();
		this.R808202_WaitFor014BFlag1();
	}

	public void L80908B_MainLoop()
	{
		P &= ~0x30;
		this.R8090A1_MainLoop_1();
		this.R808E78_MainLoop_2();
		this.R8090CD_MainLoop_3();
		this.R8090B8_MainLoop_4();
		this.R808202_WaitFor014BFlag1();
		return this.L80908B_MainLoop();
	}








	public void R8090A1_MainLoop_1()
	{
		this.R809570_Execute();
		this.R809A94();
		this.R809B30();
		this.R809FDF();
		P &= ~0x30;
		this.R809D46_InitializeObd1Ram();
		return;
	}








	public void R8090B8_MainLoop_4()
	{
		this.R809BAB_FillTable7800();
		this.R80A005();
		P &= ~0x30;
		A = [0x5A];
		[0x0265] = A;
		A = [0x52];
		[0x0267] = A;
		return;
	}








	public void R8090CD_MainLoop_3()
	{
		P &= ~0x30;
		Stack.Push(B);

		// X = Value026D * 3
		A = [0x026D];
		A <<= 1;
		A += [0x026D] + C;
		X = A;

		// if (Table809105[X + 2] == 0x7D) Done;
		P |= 0x20;
		A = [0x809107 + X];
		temp = A - 0x7D;

		if (Z == 1)
			return this.L8090F6_Done();

		[0x02] = A;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		A = [0x809105 + X];
		[0x00] = A;
		this.R809102_ExecutePointer24();
	}

	public void L8090F2_Done()
	{
		P &= ~0x30;
		B = Stack.Pop();
		return;
	}

	public void L8090F6_Done()
	{
		P &= ~0x20;
		A = [0x809105 + X];
		[0x026D] = A;
		return this.L8090F2_Done();
	}








	public void R809102_ExecutePointer24()
	{
		return [[0x0000]]();    //24-Bit Address
	}








	public byte[] FunctionPointerTable809105 = new byte[]
	{
		0x0C, 0x9F, 0x80,
		0xDE, 0x9C, 0x90,
		0x97, 0x9D, 0x90,
		0x1C, 0x9F, 0x80,
		0xF9, 0x9C, 0x90,
		0x4F, 0xAE, 0x8E,
		0x6E, 0xCB, 0x8E,
		0xBE, 0x98, 0x8E,
		0x67, 0xA2, 0x90,
		0x5F, 0xD1, 0x90,
		0xD4, 0xAC, 0x90,
		0x2D, 0x9F, 0x80,
		0x44, 0x81, 0x96,
		0xA1, 0x9D, 0x90,
		0x82, 0x9D, 0x90,
		0x10, 0x80, 0x8B,
		0x00, 0xC7, 0x94,
		0xE5, 0x9E, 0x90,
		0xE6, 0xA0, 0x80,
		0xED, 0xA0, 0x80,
		0x64, 0x8C, 0x91,
		0x82, 0xA7, 0x90,
		0x2F, 0xC2, 0x8C,
		0x3E, 0xC2, 0x8C,
		0x64, 0xC2, 0x8C,
		0x46, 0x9E, 0x90,
		0x40, 0x9F, 0x80,
		0xD6, 0xC9, 0x8C,
		0x56, 0xCA, 0x8C,
		0x08, 0x9F, 0x90,
		0x53, 0xD2, 0x8C,
		0x7E, 0xD2, 0x8C,
		0xC2, 0x8E, 0x91,
		0xDD, 0xA0, 0x90,
		0xAE, 0xD2, 0x8C,
		0x4F, 0xA1, 0x90,
		0x1F, 0xC9, 0x8C,
		0x45, 0xC9, 0x8C,
		0x24, 0xA3, 0x90,
		0x53, 0xD2, 0x8C,
		0x7E, 0xD2, 0x8C,
		0xAE, 0xD2, 0x8C,
		0xBC, 0x00, 0x7D,
		0x53, 0xD2, 0x8C,
		0x7E, 0xD2, 0x8C,
		0xAE, 0xD2, 0x8C
	}








	public void R80942D()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;

		// Flag0322 = 1;
		A = 0x0001;
		[0x0322] = A;

		Stack.Push(X);
		Stack.Push(Y);
		A = [0x00];
		Stack.Push(A);
		A = [0x01];
		Stack.Push(A);
		A = 0xB900;
		[0x01] = A;
		Y = 0x8000;
		[0x00] = 0;
		this.R8098E6();
		P |= 0x30;
		A = 0xFE;
	}

	public void L809452_Loop()
	{
		// Wait For APU Idle
		[0x2142] = A;
		temp = A - [0x2142];

		if (Z == 0)
			return this.L809452_Loop();

		P &= ~0x30;
		X = 0x005E;
	}

	public void L80945F_Loop()
	{
		[0x02D7 + X] = 0;
		X--;
		X--;

		if (N == 1)
			return this.L809468();

		return this.L80945F_Loop();
	}

	public void L809468()
	{
		P &= ~0x30;
		A = Stack.Pop();
		[0x01] = A;
		A = Stack.Pop();
		[0x00] = A;
		Y = Stack.Pop();
		X = Stack.Pop();

		// Flag0322 = 0;
		A = 0x0000;
		[0x0322] = A;

		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}








	public void R809492()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		Stack.Push(X);
		X = A;
		A = [0x02F7];
		A &= 0x0001;

		if (Z == 0)
			return this.L8094B6_Done();

		Stack.Push(X);
		X = 0x0000;
	}

	public void L8094A6()
	{
		A = [0x02D7 + X];

		if (Z == 1)
			return this.L8094B2();

		X++;
		X++;
		temp = X - 0x0006;

		if (Z == 0)
			return this.L8094A6();
	}

	public void L8094B2()
	{
		A = Stack.Pop();
		[0x02D7 + X] = A;
	}

	public void L8094B6_Done()
	{
		X = Stack.Pop();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}








	public void R8094BA()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		Stack.Push(X);
		X = A;
		A = [0x02F7];
		A &= 0x0001;

		if (Z == 0)
			return this.L8094DE_Done();

		Stack.Push(X);
		X = 0x0000;
	}

	public void L8094CE()
	{
		A = [0x02DF + X];

		if (Z == 1)
			return this.L8094DA();

		X++;
		X++;
		temp = X - 0x0006;

		if (Z == 0)
			return this.L8094CE();
	}

	public void L8094DA()
	{
		A = Stack.Pop();
		[0x02DF + X] = A;
	}

	public void L8094DE_Done()
	{
		X = Stack.Pop();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}








	public void R8094E2()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		Stack.Push(X);
		X = A;
		temp = A - 0x00F0;

		if (C == 1)
			return this.L809541();

		temp = A - 0x0000;

		if (Z == 1)
			return this.L809555_Done();

		Stack.Push(Y);
		X = [0x00];
		Stack.Push(X);
		X = [0x01];
		Stack.Push(X);
		X = A;
		A = [0x030B];

		if (Z == 0)
			return this.L80950E();

		this.R808229_DisableVBlankIRQ();
		this.R8097B2_APU();
		this.R808215_EnableVBlankIRQ();
		P &= ~0x30;
	}

	public void L80950E()
	{
		X = Stack.Pop();
		[0x01] = X;
		X = Stack.Pop();
		[0x00] = X;
		Y = Stack.Pop();
		return this.L809555_Done();
	}








	public void R809517()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		Stack.Push(X);
		X = A;
		A &= 0x00FF;
		temp = A - 0x00F0;

		if (C == 1)
			return this.L809555_Done();

		temp = A - 0x00E0;

		if (C == 0)
			return this.L809555_Done();

		temp = A - 0x00E5;

		if (C == 0)
			return this.L809534();

		[0x02F9] = X;
	}

	public void L809534()
	{
		A = [0x030B];

		if (Z == 0)
			return this.L809555_Done();

		A = [0x02F7];
		A &= 0x0002;

		if (Z == 0)
			return this.L809555_Done();
	}

	public void L809541()
	{
		Stack.Push(X);
		X = 0x0000;
	}

	public void L809545()
	{
		A = [0x02D7 + X];

		if (Z == 1)
			return this.L809551();

		X++;
		X++;
		temp = X - 0x0006;

		if (Z == 0)
			return this.L809545();
	}

	public void L809551()
	{
		A = Stack.Pop();
		[0x02D7 + X] = A;
	}

	public void L809555_Done()
	{
		X = Stack.Pop();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}








	public void R809559_InitializeRam()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x20;
		Stack.Push(A);

		// Table02EB[0-2] = 0xFFFF
		A = 0xFFFF;
		[0x02EB] = A;
		[0x02EF] = A;
		[0x02F3] = A;

		A = Stack.Pop();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}








	public void R809570_Execute()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		Stack.Push(A);
		Stack.Push(X);
		Stack.Push(Y);
		A = 0xBA00;
		[0x01] = A;
		A = 0x80C0;
		[0x00] = A;
		X = 0x0000;
	}

	public void L809586_Loop()
	{
		// A = Table02EB[X];
		A = [0x02EB + X];

		// if (A >= 0) HandleEvent();
		if (N == 0)
			return this.L8095A2_HandleEvent();

		// else if (A == 0xFFFF) Skip();
		temp = A - 0xFFFF;

		if (Z == 1)
			return this.L8095AA_Skip();

		// else
		//	 A = (Abs(A) & 0xff) * 2;
		Stack.Push(A);
		A = Stack.Pop();
		A &= 0x00FF;
		A <<= 1;
		Y = X;
		X = A;

		//	Table02EB[X] = TableBA80C0[A];
		A = [0xBA80C0 + X];
		[0x02EB + Y] = A;
		X = Y;

		return this.L8095A7_Execute();
	}

	public void L8095A2_HandleEvent()
	{
		// Table02EB[X + 2] -= 1;
		[0x02ED + X]--;

		if (Z == 0)
			return this.L8095AA_Skip();
	}

	public void L8095A7_Execute()
	{
		this.R8095BB_Execute();
	}

	public void L8095AA_Skip()
	{
		// if (X == 8) Return;
		temp = X - 0x0005;

		if (C == 1)
			return this.L8095B5_Done();

		// X += 4;
		X++;
		X++;
		X++;
		X++;

		// Continue
		return this.L809586_Loop();
	}

	public void L8095B5_Done()
	{
		Y = Stack.Pop();
		X = Stack.Pop();
		A = Stack.Pop();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}








	public void R8095BB_Execute()
	{
		Stack.Push(X);

		// Y = Table02EB[X];
		A = [0x02EB + X];
		Y = A;
	}

	public void L8095C0_Loop()
	{
		// A = ReadShort();
		this.R80968B_ReadShort();

		X = A;

		if (Z == 0)
			return this.L8095CB();

		A--;
		Y = A;
		return this.L809682_Done();
	}

	public void L8095CB()
	{
		// A = ReadShort();
		this.R80968B_ReadShort();

		temp = X - 0x2000;

		if (C == 0)
			return this.L80962F();

		temp = X - 0x3000;

		if (C == 0)
			return this.L809635();

		temp = X - 0x4000;

		if (C == 0)
			return this.L80963B();

		temp = X - 0x5000;

		if (C == 0)
			return this.L809641();

		temp = X - 0x6000;

		if (C == 0)
			return this.L809647();

		temp = X - 0x7000;

		if (C == 0)
			return this.L809625();

		temp = X - 0x8000;

		if (C == 0)
			return this.L809666();

		temp = X - 0x9000;

		if (C == 0)
			return this.L80961A();

		temp = X - 0xA000;

		if (C == 0)
			return this.L80960F();

		temp = X - 0xB000;

		if (C == 0)
			return this.L80964A();

		temp = X - 0xC000;

		if (C == 0)
			return this.L80964F();

		temp = X - 0xD000;

		if (C == 0)
			return this.L80965A();

		temp = X - 0xE000;

		if (C == 0)
			return this.L809660();
	}

	public void L80960F()
	{
		temp = A - 0xFFFF;

		if (Z == 1)
			return this.L809620();

		A = 0x8000;
		temp = A & [0x031A];[0x031A] |= A;
	}

	public void L80961A()
	{
		A = [0x0318];
		this.R8096FB_Set031C();
	}

	public void L809620()
	{
		A |= [0x031A];
		return this.L809635();
	}

	public void L809625()
	{
		A = [0x02F9];
		this.R809517();
		return this.L809679();
	}

	public void L80962F()
	{
		this.R809492();
		return this.L809679();
	}

	public void L809635()
	{
		this.R8094BA();
		return this.L809679();
	}

	public void L80963B()
	{
		this.R809517();
		return this.L809679();
	}

	public void L809641()
	{
		this.R8094E2();
		return this.L809679();
	}

	public void L809647()
	{
		Y = A;
		return this.L809679();
	}

	public void L80964A()
	{
		this.R809690_APU();
		return this.L809679();
	}

	public void L80964F()
	{
		this.R809690_APU();
		A = [0x030B];

		if (Z == 0)
			return this.L809672();

		return this.L8095C0_Loop();
	}

	public void L80965A()
	{
		this.R809711_Set0402();
		return this.L8095C0_Loop();
	}

	public void L809660()
	{
		this.R809715();
		return this.L8095C0_Loop();
	}

	public void L809666()
	{
		A = X;
		A &= 0x00FF;
		A &= [0x02FB];

		if (Z == 0)
			return this.L809672();

		return this.L8095C0_Loop();
	}

	public void L809672()
	{
		Y--;
		Y--;
		Y--;
		Y--;
		X = 0x0001;
	}

	public void L809679()
	{
		A = X;
		A &= 0x0FFF;

		if (Z == 0)
			return this.L809682_Done();

		return this.L8095C0_Loop();
	}

	public void L809682_Done()
	{
		// Table02EB[X + 2] = A;
		X = Stack.Pop();
		[0x02ED + X] = A;

		// Table02EB[X] = Y;
		A = Y;
		[0x02EB + X] = A;
		return;
	}








	public void R80968B_ReadShort()
	{
		A = [[0x00] + Y];
		Y++;
		Y++;
		return;
	}








	public void R809690_APU()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		Stack.Push(X);
		X = A;
		Stack.Push(Y);
		X = [0x00];
		Stack.Push(X);
		X = [0x01];
		Stack.Push(X);
		X = A;
		A = [0x030B];

		if (Z == 0)
			return this.L8096AB();

		A = 0x0001;
		[0x030B] = A;
	}

	public void L8096AB()
	{
		this.R8097B2_APU();
		A = [0x02E7];
		[0x2140] = A;
		A = [0x02D7];
		[0x02E7] = A;
		A = [0x02D9];
		[0x02D7] = A;
		A = [0x02DB];
		[0x02D9] = A;
		A = [0x02DD];
		[0x02DB] = A;
		[0x02DD] = 0;
		A = [0x02E9];
		[0x2142] = A;
		A = [0x02DF];
		[0x02E9] = A;
		A = [0x02E1];
		[0x02DF] = A;
		A = [0x02E3];
		[0x02E1] = A;
		A = [0x02E5];
		[0x02E3] = A;
		[0x02E5] = 0;
		X = Stack.Pop();
		[0x01] = X;
		X = Stack.Pop();
		[0x00] = X;
		Y = Stack.Pop();
		X = Stack.Pop();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}








	public void R8096FB_Set031C()
	{
		A &= 0x00FF;
		[0x031C] = A;
		A = (A >> 4) | (A << 4);
		A >>= 1;
		A >>= 1;
		A >>= 1;
		C = 1;
		A -= [0x031C] - !C;
		C = 0;
		A += 0x0100 + C;
		A &= 0x1F00;
		return;
	}








	public void R809711_Set0402()
	{
		[0x0402] = A;
		return;
	}








	public void R809715()
	{
		temp = A - 0xFFF1;

		if (Z == 0)
			return this.L80971F();

		this.R80973C();
		return this.L80973B_Done();
	}

	public void L80971F()
	{
		Stack.Push(A);
		A &= 0xFF00;

		if (Z == 0)
			return this.L809731();

		A = Stack.Pop();
		A &= 0x00FF;
		A ^= 0xFFFF;
		A &= [0x02F7];
		return this.L809738();
	}

	public void L809731()
	{
		A = Stack.Pop();
		A &= 0x00FF;
		A |= [0x02F7];
	}

	public void L809738()
	{
		[0x02F7] = A;
	}

	public void L80973B_Done()
	{
		return;
	}








	public void R80973C()
	{
		Stack.Push(X);
		A = [0x036D];
		A &= 0x0003;
		[0x031C] = A;
		A = [0x0381];
		A &= 0x0001;

		if (Z == 1)
			return this.L80975A();

		A = 0x0010;
	}

	public void L809751()
	{
		C = 0;
		A += [0x031C] + C;
		[0x031C] = A;
		return this.L80976D();
	}

	public void L80975A()
	{
		A = 0x000E;
		[0x0367] = A;
		this.R94EB88_ReadCartridgeRam();
		A = [0x2C];

		if (Z == 1)
			return this.L80976D();

		A = 0x0008;
		return this.L809751();
	}

	public void L80976D()
	{
		A = [0x150C];
		A &= 0x0010;

		if (Z == 1)
			return this.L80977F();

		A = 0x0004;
		C = 0;
		A += [0x031C] + C;
		[0x031C] = A;
	}

	public void L80977F()
	{
		A = [0x031C];
		temp = A - 0x0018;

		if (C == 0)
			return this.L80978A();

		A = 0x0000;
	}

	public void L80978A()
	{
		X = A;
		A = [0x80979A + X];
		A &= 0x00FF;
		A |= 0x8000;
		[0x02F3] = A;
		X = Stack.Pop();
		return;
	}

	public byte[] Table80979A = new byte[]
	{
		0x71, 0x77, 0x7D, 0x7E,
		0x72, 0x78, 0x82, 0x86,
		0x73, 0x79, 0x80, 0x87,
		0x74, 0x7A, 0x81, 0x88,
		0x75, 0x7B, 0x84, 0x7F,
		0x76, 0x7C, 0x83, 0x85
	}





	public void R8097B2_APU()
	{
		P &= ~0x30;
		[0x0303] = 0;
		A = [0x030B];

		if (Z == 1)
			return this.L809801();

		[0x0322] = A;
		Y = 0x0040;
		[0x0303] = Y;
		temp = A - 0x0001;

		if (Z == 0)
			return this.L8097D2();

		[0x030B]++;
		A = 0x00FC;
		return this.L809804();
	}

	public void L8097D2()
	{
		A = [0x030D];
		Y = 0x1234;
	}

	public void L8097D8_Loop()
	{
		temp = Y - [0x2140];

		if (Z == 0)
			return this.L8097D8_Loop();

		[0x2140] = A;
		Y = 0x007F;
		[0x2142] = Y;
	}

	public void L8097E6()
	{
		temp = A - [0x2140];

		if (Z == 0)
			return this.L8097E6();

		A = [0x030F];
		[0x00] = A;
		A = [0x0310];
		[0x01] = A;
		A = 0x007F;
		X = [0x0307];
		Y = [0x0309];
		return this.L80988B();
	}

	public void L809801()
	{
		A = 0x00FE;
	}

	public void L809804()
	{
		[0x2140] = A;
		[0x2142] = 0;
		A = X;
		A--;
		A <<= 1;
		X = A;
		A = [0xBA8010 + X];
		[0x02FD] = A;
		X = 0x0000;
		return this.L809898();
	}

	public void L80981B()
	{
		[0x2142] = X;
		X = A;
		A = [0xBA8201 + X];
		C = 0;
		A += 0xB900 + C;
		[0x01] = A;
		[0x00] = 0;
		A = [0xBA8203 + X];
		A++;
		A >>= 1;
		[0x02FF] = A;
		A = [0xBA8205 + x];
		Y = 0x1234;
	}

	public void L80983B()
	{
		temp = Y - [0x2140];

		if (Z == 0)
			return this.L80983B();

		[0x2140] = A;
		[0x030D] = A;
		Y = 0x007F;
		[0x2142] = Y;
	}

	public void L80984C()
	{
		temp = A - [0x2140];

		if (Z == 0)
			return this.L80984C();

		A = [0xBA8200 + X];
		Y = A;
		[0x0301] = 0;
		A = [[0x00] + Y];
		X = A;
		A = 0x007F;
	}

	public void L80985F()
	{
		temp = A - [0x2142];

		if (Z == 0)
			return this.L80985F();

		[0x2140] = X;
		A = [0x0301];
		[0x2142] = A;
		Y++;
		Y++;
		Stack.Push(A);
		A = [[0x00] + Y];
		X = A;
		[0x0301]++;
		A = 0xFF80;
		temp = A & [0x0301];[0x0301] &= ~A;
		A = Stack.Pop();
		[0x030D]++;
		[0x030D]++;
		[0x0303]--;

		if (Z == 0)
			return this.L80988B();

		return this.L8098D1();
	}

	public void L80988B()
	{
		[0x02FF]--;

		if (Z == 0)
			return this.L80985F();

		X = 0x7FFF;
	}

	public void L809893()
	{
		temp = A - [0x2142];

		if (Z == 0)
			return this.L809893();
	}

	public void L809898()
	{
		Y = [0x02FD];
		A = 0xBA00;
		[0x01] = A;
		[0x00] = 0;
		A = [[0x00] + Y];

		if (Z == 1)
			return this.L8098AE();

		Y++;
		Y++;
		[0x02FD] = Y;
		return this.L80981B();
	}

	public void L8098AE()
	{
		[0x030B] = 0;
		[0x0305] = 0;
		A = 0x00FF;
	}

	public void L8098B7_Loop()
	{
		[0x2142] = A;
	}

	public void L8098BA()
	{
		A = [0x2140];

		if (Z == 0)
			return this.L8098BA();

		A = [0x2142];

		if (Z == 0)
			return this.L8098BA();

		[0x2142] = A;
		[0x2140] = A;
		A = 0x0000;
		[0x0322] = A;
		return;
	}

	public void L8098D1()
	{
		[0x0307] = X;
		[0x0309] = Y;
		A = [0x00];
		[0x030F] = A;
		A = [0x01];
		[0x0310] = A;
		A = 0xFFFF;
		return this.L8098B7_Loop();
	}








	public void R8098E6()
	{
		Stack.Push(P);
		P &= ~0x30;
		A = 0xBBAA;
		return this.L8098F4();
	}

	public void L8098EE()
	{
		X = 0x00FD;
		[0x2140] = X;
	}

	public void L8098F4()
	{
		temp = A - [0x2140];

		if (Z == 0)
			return this.L8098EE();

		P |= 0x20;
		A = 0xCC;
		return this.L809925();
	}

	public void L8098FF()
	{
		A = [[0x00] + Y];
		Y++;
		A = (A >> 4) | (A << 4);
		A = 0x00;
		return this.L809912();
	}

	public void L809907()
	{
		A = (A >> 4) | (A << 4);
		A = [[0x00] + Y];
		Y++;
		A = (A >> 4) | (A << 4);
	}

	public void L80990C()
	{
		temp = A - [0x2140];

		if (Z == 0)
			return this.L80990C();

		A++;
	}

	public void L809912()
	{
		P &= ~0x20;
		[0x2140] = A;
		P |= 0x20;
		X--;

		if (Z == 0)
			return this.L809907();
	}

	public void L80991C()
	{
		temp = A - [0x2140];

		if (Z == 0)
			return this.L80991C();
	}

	public void L809921()
	{
		A += 0x03 + C;

		if (Z == 1)
			return this.L809921();
	}

	public void L809925()
	{
		Stack.Push(A);
		P &= ~0x20;
		A = [[0x00] + Y];
		Y++;
		Y++;
		X = A;
		A = [[0x00] + Y];
		Y++;
		Y++;
		[0x2142] = A;
		P |= 0x20;
		temp = X - 0x0001;
		A = 0x00;
		Cpu.ROL();
		[0x2141] = A;
		A += 0x7F + C;
		A = Stack.Pop();
		[0x2140] = A;
	}

	public void L809945()
	{
		temp = A - [0x2140];

		if (Z == 0)
			return this.L809945();


		if (F.BVS)
			return this.L8098FF();

		P = Stack.Pop();
		return;
	}








	public void R809A94()
	{
		Stack.Push(P);
		P |= 0x20;
		A = [0x030B];

		if (Z == 0)
			return this.L809ADF_Done();

		A = [0x0100];
		temp = A & 0x80;

		if (Z == 0)
			return this.L809ADF_Done();

		A ^= 0xFF;
		temp = A & 0x0F;

		if (Z == 0)
			return this.L809ADF_Done();

		A = [0x026B];

		if (Z == 1)
			return this.L809ADF_Done();

		A = [0x0269];
		A++;

		if (Z == 1)
			return this.L809ADF_Done();

		A--;

		if (Z == 0)
			return this.L809AE1();

		A = [0x53];
		temp = A & 0x40;

		if (Z == 1)
			return this.L809ADF_Done();

		A = [0x0266];
		temp = A & 0x80;

		if (Z == 1)
			return this.L809ADF_Done();

		A = 0x3C;
		[0x0269] = A;
		A = [0x0268];
		A &= 0x7F;
		[0x0268] = A;
		A = [0x0266];
		A &= 0x7F;
		[0x0266] = A;
		A = [0x63];
		A &= 0x7F;
		[0x63] = A;
	}

	public void L809ADF_Done()
	{
		P = Stack.Pop();
		return;
	}

	public void L809AE1()
	{
		[0x0269]--;
		A = [0x53];
		temp = A & 0x40;

		if (Z == 1)
			return this.L809AF5();

		A = [0x0266];
		temp = A & 0x80;

		if (Z == 1)
			return this.L809ADF_Done();

		this.R809B58();
	}

	public void L809AF5()
	{
		A = [0x0266];
		temp = A & 0x90;

		if (Z == 1)
			return this.L809ADF_Done();

		[0x0269] = 0;
		return this.L809ADF_Done();
	}








	public void R809B30()
	{
		Stack.Push(P);
		P &= ~0x30;
		A = [0x030B];

		if (Z == 0)
			return this.L809B56_Done();

		A = [0x50];
		temp = A - 0x4080;

		if (Z == 0)
			return this.L809B56_Done();

		A = [0x58];
		temp = A & 0x4000;

		if (Z == 1)
			return this.L809B56_Done();

		[0x0255] = 0;
		[0x0257] = 0;
		A = 0x00FF;
		temp = A & [0x52];[0x52] |= A;
		A = 0x8000;
		temp = A & [0x5A];[0x5A] |= A;
	}

	public void L809B56_Done()
	{
		P = Stack.Pop();
		return;
	}








	public void R809B58()
	{
		Stack.Push(P);
		P &= ~0x30;
		this.R80823D_Set0100Flag80();
		P |= 0x20;
		A = 0x81;
		[0x4200] = A;
		[0x013C] = A;
		P &= ~0x20;
		this.R80827B_Clear013CAnd4200Flag10();
		this.R8082A3_Clear013CAnd4200Flag20();
		P |= 0x20;
		[0x49] = 0;
		[0x4A] = 0;
		[0x0141] = 0;
		[0x0154] = 0;
		P &= ~0x20;
		[0x0152] = 0;
		this.R808202_WaitFor014BFlag1();
		[0x026B] = 0;
		[0x14CE] = 0;
		[0x14CC] = 0;
		A = 0x0002;
		[0x026D] = A;
		P = Stack.Pop();
		return;
	}








	public void R809BAB_FillTable7800()
	{
		Stack.Push(P);
		P &= ~0x20;

		// Pointer = ((WordA6 / 4) * 3) + FunctionTable809BC4;
		A = [0xA6];
		A >>= 1;
		[0x00] = A;
		A >>= 1;
		C = 0;
		A += [0x00] + C;
		C = 0;
		A += 0x9BC4 + C;
		[0x00] = A;

		// return Pointer(0xEF);
		P |= 0x20;
		A = 0xEF;
		return [(0x0000)]();
	}

	public byte[] FunctionTable809BC4 = new byte[]
	{
		0x8D, 0x01, 0x78,
		0x8D, 0x05, 0x78,
		0x8D, 0x09, 0x78,
		0x8D, 0x0D, 0x78,
		0x8D, 0x11, 0x78,
		0x8D, 0x15, 0x78,
		0x8D, 0x19, 0x78,
		0x8D, 0x1D, 0x78,
		0x8D, 0x21, 0x78,
		0x8D, 0x25, 0x78,
		0x8D, 0x29, 0x78,
		0x8D, 0x2D, 0x78,
		0x8D, 0x31, 0x78,
		0x8D, 0x35, 0x78,
		0x8D, 0x39, 0x78,
		0x8D, 0x3D, 0x78,
		0x8D, 0x41, 0x78,
		0x8D, 0x45, 0x78,
		0x8D, 0x49, 0x78,
		0x8D, 0x4D, 0x78,
		0x8D, 0x51, 0x78,
		0x8D, 0x55, 0x78,
		0x8D, 0x59, 0x78,
		0x8D, 0x5D, 0x78,
		0x8D, 0x61, 0x78,
		0x8D, 0x65, 0x78,
		0x8D, 0x69, 0x78,
		0x8D, 0x6D, 0x78,
		0x8D, 0x71, 0x78,
		0x8D, 0x75, 0x78,
		0x8D, 0x79, 0x78,
		0x8D, 0x7D, 0x78,
		0x8D, 0x81, 0x78,
		0x8D, 0x85, 0x78,
		0x8D, 0x89, 0x78,
		0x8D, 0x8D, 0x78,
		0x8D, 0x91, 0x78,
		0x8D, 0x95, 0x78,
		0x8D, 0x99, 0x78,
		0x8D, 0x9D, 0x78,
		0x8D, 0xA1, 0x78,
		0x8D, 0xA5, 0x78,
		0x8D, 0xA9, 0x78,
		0x8D, 0xAD, 0x78,
		0x8D, 0xB1, 0x78,
		0x8D, 0xB5, 0x78,
		0x8D, 0xB9, 0x78,
		0x8D, 0xBD, 0x78,
		0x8D, 0xC1, 0x78,
		0x8D, 0xC5, 0x78,
		0x8D, 0xC9, 0x78,
		0x8D, 0xCD, 0x78,
		0x8D, 0xD1, 0x78,
		0x8D, 0xD5, 0x78,
		0x8D, 0xD9, 0x78,
		0x8D, 0xDD, 0x78,
		0x8D, 0xE1, 0x78,
		0x8D, 0xE5, 0x78,
		0x8D, 0xE9, 0x78,
		0x8D, 0xED, 0x78,
		0x8D, 0xF1, 0x78,
		0x8D, 0xF5, 0x78,
		0x8D, 0xF9, 0x78,
		0x8D, 0xFD, 0x78,
		0x8D, 0x01, 0x78,
		0x8D, 0x05, 0x79,
		0x8D, 0x09, 0x79,
		0x8D, 0x0D, 0x79,
		0x8D, 0x11, 0x79,
		0x8D, 0x15, 0x79,
		0x8D, 0x19, 0x79,
		0x8D, 0x1D, 0x79,
		0x8D, 0x21, 0x79,
		0x8D, 0x25, 0x79,
		0x8D, 0x29, 0x79,
		0x8D, 0x2D, 0x79,
		0x8D, 0x31, 0x79,
		0x8D, 0x35, 0x79,
		0x8D, 0x39, 0x79,
		0x8D, 0x3D, 0x79,
		0x8D, 0x41, 0x79,
		0x8D, 0x45, 0x79,
		0x8D, 0x49, 0x79,
		0x8D, 0x4D, 0x79,
		0x8D, 0x51, 0x79,
		0x8D, 0x55, 0x79,
		0x8D, 0x59, 0x79,
		0x8D, 0x5D, 0x79,
		0x8D, 0x61, 0x79,
		0x8D, 0x65, 0x79,
		0x8D, 0x69, 0x79,
		0x8D, 0x6D, 0x79,
		0x8D, 0x71, 0x79,
		0x8D, 0x75, 0x79,
		0x8D, 0x79, 0x79,
		0x8D, 0x7D, 0x79,
		0x8D, 0x81, 0x79,
		0x8D, 0x85, 0x79,
		0x8D, 0x89, 0x79,
		0x8D, 0x8D, 0x79,
		0x8D, 0x91, 0x79,
		0x8D, 0x95, 0x79,
		0x8D, 0x99, 0x79,
		0x8D, 0x9D, 0x79,
		0x8D, 0xA1, 0x79,
		0x8D, 0xA5, 0x79,
		0x8D, 0xA9, 0x79,
		0x8D, 0xAD, 0x79,
		0x8D, 0xB1, 0x79,
		0x8D, 0xB5, 0x79,
		0x8D, 0xB9, 0x79,
		0x8D, 0xBD, 0x79,
		0x8D, 0xC1, 0x79,
		0x8D, 0xC5, 0x79,
		0x8D, 0xC9, 0x79,
		0x8D, 0xCD, 0x79,
		0x8D, 0xD1, 0x79,
		0x8D, 0xD5, 0x79,
		0x8D, 0xD9, 0x79,
		0x8D, 0xDD, 0x79,
		0x8D, 0xE1, 0x79,
		0x8D, 0xE5, 0x79,
		0x8D, 0xE9, 0x79,
		0x8D, 0xED, 0x79,
		0x8D, 0xF1, 0x79,
		0x8D, 0xF5, 0x79,
		0x8D, 0xF9, 0x79,
		0x8D, 0xFD, 0x79,
		0x28, 0x6B
	};






	public void R809D46_InitializeObd1Ram()
	{
		Stack.Push(P);
		P &= ~0x30;
		[0x7A00] = 0;
		[0x7A02] = 0;
		[0x7A04] = 0;
		[0x7A06] = 0;
		[0x7A08] = 0;
		[0x7A0A] = 0;
		[0x7A0C] = 0;
		[0x7A0E] = 0;
		[0x7A10] = 0;
		[0x7A12] = 0;
		[0x7A14] = 0;
		[0x7A16] = 0;
		[0x7A18] = 0;
		[0x7A1A] = 0;
		[0x7A1C] = 0;
		[0x7A1E] = 0;
		[0xA6] = 0;
		P = Stack.Pop();
		return;
	}








	public void R809D7D()
	{
		A = [0x28];
		A ^= [0x2C];
		Stack.Push(P);
		A = [0x28];
		
		if (N == 0)
			return this.L809D9B();

		C = 0;
		A = [0x26];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x26] = A;
		A = [0x28];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x28] = A;
	}

	public void L809D9B()
	{
		A = [0x2C];
		
		if (N == 0)
			return this.L809DB4();

		C = 0;
		A = [0x2A];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x2A] = A;
		A = [0x2C];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x2C] = A;
	}

	public void L809DB4()
	{
		this.L80860D();
		P = Stack.Pop();
		
		if (N == 0)
			return this.L809DE4();

		C = 0;
		A = [0x2E];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x2E] = A;
		A = [0x30];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x30] = A;
		A = [0x32];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x32] = A;
		A = [0x34];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x34] = A;
	}

	public void L809DE4()
	{
		return;
	}









	public void R809F0C()
	{
		P &= ~0x30;
		this.R80823D_Set0100Flag80();
		this.R80A1E2();
		P &= ~0x30;
		[0x026D]++;
		return;
	}


	public void R809F1C()
	{
		this.R839443();
		A = 0x0000;
		[0x1B0F] = A;
		[0x035D] = 0;
		[0x026D]++;
		return;
	}







	public void L809F2D()
	{
		P &= ~0x30;
		this.R80823D_Set0100Flag80();
		[0x026F] = 0;
		this.R80A237();
		P &= ~0x30;
		[0x026D]++;
		return;
	}

	public void R80A237()
	{
		P &= ~0x30;
		this.R80A2B5();
		this.R80A256();
		this.R839416();
		this.R8391CD();
		this.R819E82();
		this.R81EAB4();
		this.R80A27F();
		return;
	}

	public void R80A256()
	{
		X = 0x005C;
		A = 0xFFFF;
	}

	public void L80A25C()
	{
		[0x117C + X] = A;
		X--;
		X--;
		
		if (N == 0)
			return this.L80A25C();

		X = 0x001E;
	}

	public void L80A266()
	{
		A = 0x0000;
		[0x1A81 + X] = A;
		X--;
		X--;
		
		if (N == 0)
			return this.L80A266();

		X = 0x001E;
	}

	public void L80A273()
	{
		A = 0x0000;
		[0x7E3963 + X] = A;
		X--;
		X--;
		
		if (N == 0)
			return this.L80A273();

		return;
	}








	public void R80A27F()
	{
		P |= 0x20;
		P &= ~0x10;
		X = 0x8000;
		[0x3E] = X;
		A = 0x9D;
		[0x40] = A;
		X = 0x6B38;
		[0x43] = X;
		A = 0x7E;
		[0x45] = A;
		this.L808888();
		P &= ~0x30;
		A = 0x8000;
		[0x01] = A;
		A = 0xA2AB;
		[0x00] = A;
		this.R8087A4_LoadDmaTransferRecord();
		return this.L80A2B4_Done();
	}

	public void L80A2B4_Done()
	{
		return;
	}








	public void R80A2B5()
	{
		Stack.Push(P);
		P |= 0x20;
		A = 0x8F;
		[0x0100] = A;
		A = 0x01;
		[0x0101] = A;
		A = 0x09;
		[0x0104] = A;
		A = 0x00;
		[0x0105] = A;
		A = 0x01;
		[0x0106] = A;
		A = 0x09;
		[0x0107] = A;
		A = 0x10;
		[0x0108] = A;
		A = 0x00;
		[0x0109] = A;
		A = 0x44;
		[0x010A] = A;
		A = 0x01;
		[0x010B] = A;
		P = Stack.Pop();
		return;
	}








	public void R80E680()
	{
		A = 0x000F;
		[0x7E5BCF] = A;
		A = 0x0000;
		[0x7E5BD1] = A;
		A = 0x000F;
		[0x7E5BD3] = A;
		A = 0x0000;
		[0x7E5BD5] = A;
		A = 0x0008;
		[0x7E5BD7] = A;
		A = 0x0000;
		[0x7E5BD9] = A;
		A = 0x0000;
		[0x7E5BC7] = A;
		A = 0x0000;
		[0x7E5BC9] = A;
		A = [0x14D6];
		A <<= 1;
		A <<= 1;
		A <<= 1;
		X = A;
		A = [0x80F233 + X];
		[0x7E5BE3] = A;
		A = [0x80F235 + X];
		[0x7E5BE5] = A;
		A = [0x80F237 + X];
		[0x7E5BE7] = A;
		A = [0x80F239 + X];
		[0x7E5BE9] = A;
		A = 0x0000;
		[0x7E5BCB] = A;
		[0x7E5BCD] = A;
		return;
	}









	public void R80F159()
	{
		Stack.Push(P);
		Stack.Push(X);
		P &= ~0x30;
		[0x12] = 0;
		[0x14] = 0;
		[0x22] = 0;
		A = 0x0080;
		[0x24] = A;
	}

	public void L80F168()
	{
		A = [0x12];
		[0x16] = A;
		A = [0x14];
		[0x18] = A;
		A = [0x16];
		[0x26] = A;
		A = [0x18];
		[0x28] = A;
		A = [0x12];
		[0x2A] = A;
		A = [0x14];
		[0x2C] = A;
		this.R809D7D();
		A = [0x30];
		[0x16] = A;
		A = [0x32];
		[0x18] = A;
		A = [0x16];
		[0x2A] = A;
		A = [0x18];
		[0x2C] = A;
		A = [0x7E39A3];
		[0x2E] = A;
		A = [0x7E39A5];
		[0x30] = A;
		Stack.Push(X);
		Stack.Push(Y);
		this.L8086DC();
		Y = Stack.Pop();
		X = Stack.Pop();
		A = [0x2A];
		[0x16] = A;
		A = [0x2C];
		[0x18] = A;
		A = [0x16];
		A >>= 1;
		A ^= 0xFFFF;
		A++;
		X = [0x22];
		[0x7F0412 + X] = A;
		A = [0x12];
		[0x16] = A;
		A = [0x14];
		[0x18] = A;
		A = [0x16];
		[0x26] = A;
		A = [0x18];
		[0x28] = A;
		A = [0x12];
		[0x2A] = A;
		A = [0x14];
		[0x2C] = A;
		this.R809D7D();
		A = [0x30];
		[0x16] = A;
		A = [0x32];
		[0x18] = A;
		A = [0x16];
		[0x2A] = A;
		A = [0x18];
		[0x2C] = A;
		A = [0x7E39CB];
		[0x2E] = A;
		A = [0x7E39CD];
		[0x30] = A;
		Stack.Push(X);
		Stack.Push(Y);
		this.L8086DC();
		Y = Stack.Pop();
		X = Stack.Pop();
		A = [0x2A];
		[0x16] = A;
		A = [0x2C];
		[0x18] = A;
		A = [0x16];
		A >>= 1;
		A ^= 0xFFFF;
		A++;
		X = [0x22];
		[0x7F0412 + X] = A;
		C = 0;
		A = [0x12];
		A += 0x4000 + C;
		[0x12] = A;
		A = [0x14];
		A += 0x0000 + C;
		[0x14] = A;
		A = [0x22];
		C = 0;
		A += 0x0002 + C;
		[0x22] = A;
		[0x24]--;
		
		if (Z == 1)
			return this.L80F230();

		return this.L80F168();
	}

	public void L80F230()
	{
		X = Stack.Pop();
		P = Stack.Pop();
		return;
	}








	// Bank 0x81
	public void R819E82()
	{
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		this.L819EA5();
		this.L819EA6();
		this.L819F28();
		this.L819F97();
		this.L81A0A5();
		this.L81A14A();
		this.L81A306();
		this.L81A544();
		this.L81A7D6();
		this.L81A886();
		B = Stack.Pop();
		return;
	}

	public void L819EA5()
	{
		return;
	}

	public void L819EA6()
	{
		X = 0x003E;
	}

	public void L819EA9()
	{
		A = 0xFFFF;
		[0x001826 + X] = A;
		A = 0xFFFF;
		[0x001866 + X] = A;
		A = 0xFFFF;
		[0x7E39F3 + X] = A;
		A = 0xFFFF;
		[0x7E3A33 + X] = A;
		A = 0x0000;
		[0x001926 + X] = A;
		A = 0x0000;
		[0x7E3A73 + X] = A;
		A = 0x0000;
		[0x7E3AB3 + X] = A;
		A = 0x0000;
		[0x7E3AF3 + X] = A;
		A = 0x8000;
		[0x7E3B33 + X] = A;
		A = 0x0000;
		[0x7E3B73 + X] = A;
		A = 0x8000;
		[0x7E3BB3 + X] = A;
		A = 0x0000;
		[0x7E3BF3 + X] = A;
		A = 0x8000;
		[0x7E3C33 + X] = A;
		A = 0x0000;
		[0x7E3C73 + X] = A;
		A = 0x0000;
		[0x7E3CB3 + X] = A;
		A = 0x0000;
		[0x7E3CF3 + X] = A;
		A = 0xFFFF;
		[0x7E3D33 + X] = A;
		X--;
		X--;
		
		if (N == 1)
			return this.L819F27();

		return this.L819EA9();
	}

	public void L819F27()
	{
		return;
	}

	public void L819F28()
	{
		this.L81AB0D();
		A = [0x0B3A];
		A <<= 1;
		C = 0;
		A += [0x00] + C;
		[0x00] = A;
		A = 0x0000;
		[0x1966] = A;
		A = [[0x00]];
		[0x1968] = A;
		A = [0x00];
		C = 0;
		A += 0x0010 + C;
		[0x00] = A;
		A = [0x0B3A];
		A <<= 1;
		[0x1AA3] = A;
		A = [0x00];
		C = 1;
		A -= [0x1AA3] - !C;
		[0x00] = A;
		A = 0x0000;
		[0x196A] = A;
		A = 0x0000;
		[0x196C] = A;
		A = [[0x00]];
		[0x196E] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x1970] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x1972] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x1974] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		return;
	}

	public void L819F97()
	{
		this.L81AB40();
		A = [[0x00]];
		[0x1AA1] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		Y = [0x1AA1];
		X = 0x0000;
		A = [0x0B38];
		A <<= 1;
		C = 0;
		A += [0x00] + C;
		[0x00] = A;
	}

	public void L819FB6()
	{
		A = [[0x00]];
		[0x7E3A33 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0010 + C;
		[0x00] = A;
		A = 0x0000;
		[0x7E39F3 + X] = A;
		X++;
		X++;
		Y--;
		
		if (Z == 1)
			return this.L819FD3();

		return this.L819FB6();
	}

	public void L819FD3()
	{
		A = [0x0B38];
		A <<= 1;
		[0x1AA3] = A;
		A = [0x00];
		C = 1;
		A -= [0x1AA3] - !C;
		[0x00] = A;
		Y = [0x1AA1];
		X = 0x0000;
	}

	public void L819FE8()
	{
		A = [[0x00]];
		[0x7E3AB3 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3B33 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3BB3 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3C33 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3CB3 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = 0x0000;
		[0x7E3A73 + X] = A;
		[0x7E3AF3 + X] = A;
		[0x7E3B73 + X] = A;
		[0x7E3BF3 + X] = A;
		[0x7E3C73 + X] = A;
		X++;
		X++;
		Y--;
		
		if (Z == 1)
			return this.L81A04D();

		return this.L819FE8();
	}

	public void L81A04D()
	{
		Y = [0x1AA1];
		X = 0x0000;
	}

	public void L81A053()
	{
		A = [[0x00]];
		A <<= 1;
		[0x001766 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		A <<= 1;
		[0x0017A6 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3CF3 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		A <<= 1;
		[0x7E3D33 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x001726 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		X++;
		X++;
		Y--;
		
		if (Z == 1)
			return this.L81A0A4();

		return this.L81A053();
	}

	public void L81A0A4()
	{
		return;
	}

	public void L81A0A5()
	{
		this.L81AB23();
		Y = 0x0040;
		X = 0x0000;
	}

	public void L81A0AE()
	{
		A = 0x0000;
		[0x7E49C3 + X] = A;
		A = [[0x00]];
		[0x7E4CC3 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = 0x0000;
		[0x7E4FC3 + X] = A;
		A = [[0x00]];
		[0x7E52C3 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = 0x0000;
		[0x7E55C3 + X] = A;
		A = [[0x00]];
		[0x7E58C3 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E46C3 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [0x7E46C3 + X];
		C = 0;
		A += 0x0001 + C;
		[0x7E46C3 + X] = A;
		A = [[0x00]];
		[0x7E43C3 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		X++;
		X++;
		Y--;
		
		if (Z == 1)
			return this.L81A11D();

		return this.L81A0AE();
	}

	public void L81A11D()
	{
		A = [0x14D6];
		A <<= 1;
		C = 0;
		A += [0x00] + C;
		[0x00] = A;
		Y = 0x0040;
		X = 0x0000;
	}

	public void L81A12C()
	{
		A = 0x0000;
		[0x7E3DC3 + X] = A;
		A = [[0x00]];
		[0x7E40C3 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0022 + C;
		[0x00] = A;
		X++;
		X++;
		Y--;
		
		if (Z == 1)
			return this.L81A149();

		return this.L81A12C();
	}

	public void L81A149()
	{
		return;
	}

	public void L81A14A()
	{
		Y = 0x00F8;
		X = 0x0000;
		this.L81A1B4();
		X = 0x0002;
		this.L81A1B4();
		X = 0x0004;
		this.L81A1B4();
		X = 0x0006;
		this.L81A1B4();
		X = 0x0008;
		this.L81A1B4();
		X = 0x000A;
		this.L81A1B4();
		X = 0x000C;
		this.L81A1B4();
		X = 0x000E;
		this.L81A1B4();
		X = 0x0010;
		this.L81A1B4();
		X = 0x0012;
		this.L81A1B4();
		X = 0x0014;
		this.L81A1B4();
		X = 0x0016;
		this.L81A1B4();
		X = 0x0018;
		this.L81A1B4();
		X = 0x001A;
		this.L81A1B4();
		X = 0x001C;
		this.L81A1B4();
		X = 0x001E;
		this.L81A1B4();
		X = 0x0020;
		this.L81A1B4();
		return;
	}

	public void L81A1B4()
	{
		Stack.Push(Y);
		A = [0x81A2E4 + X];
		[0x01] = A;
		A = [0x81A2C2 + X];
		[0x00] = A;
		A = [[0x00]];
		[0x1AA1] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [0x1AA1];
		[0x1AA3] = A;
	}

	public void L81A1D4()
	{
		A = [0x0381];
		
		if (Z == 1)
			return this.L81A1DF();

		A--;
		
		if (Z == 1)
			return this.L81A202();

		A--;
		
		if (Z == 1)
			return this.L81A225();

	}

	public void L81A1DF()
	{
		A = [0x00];
		C = 0;
		A += 0x0000 + C;
		[0x00] = A;
		Stack.Push(X);
		X = Y;
		A = 0x0000;
		[0x7E3DC3 + X] = A;
		A = [[0x00]];
		[0x7E40C3 + X] = A;
		X = Stack.Pop();
		A = [0x00];
		C = 0;
		A += 0x0006 + C;
		[0x00] = A;
		return this.L81A248();
	}

	public void L81A202()
	{
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		Stack.Push(X);
		X = Y;
		A = 0x0000;
		[0x7E3DC3 + X] = A;
		A = [[0x00]];
		[0x7E40C3 + X] = A;
		X = Stack.Pop();
		A = [0x00];
		C = 0;
		A += 0x0004 + C;
		[0x00] = A;
		return this.L81A248();
	}

	public void L81A225()
	{
		A = [0x00];
		C = 0;
		A += 0x0004 + C;
		[0x00] = A;
		Stack.Push(X);
		X = Y;
		A = 0x0000;
		[0x7E3DC3 + X] = A;
		A = [[0x00]];
		[0x7E40C3 + X] = A;
		X = Stack.Pop();
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		return this.L81A248();
	}

	public void L81A248()
	{
		Y++;
		Y++;
		[0x1AA1]--;
		
		if (Z == 1)
			return this.L81A252();

		return this.L81A1D4();
	}

	public void L81A252()
	{
		Y = Stack.Pop();
		A = [0x1AA3];
		[0x1AA1] = A;
	}

	public void L81A259()
	{
		Stack.Push(X);
		X = Y;
		A = 0x0000;
		[0x7E49C3 + X] = A;
		A = [[0x00]];
		[0x7E4CC3 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = 0x0000;
		[0x7E4FC3 + X] = A;
		A = [[0x00]];
		[0x7E52C3 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = 0x0000;
		[0x7E55C3 + X] = A;
		A = [[0x00]];
		[0x7E58C3 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E46C3 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E43C3 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		X = Stack.Pop();
		Y++;
		Y++;
		[0x1AA1]--;
		
		if (Z == 1)
			return this.L81A2C1();

		return this.L81A259();
	}

	public void L81A2C1()
	{
		return;
	}

	public void L81A306()
	{
		this.L81AAF7();
		A = [[0x00]];
		[0x7E3997] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3999] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E399B] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E399D] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E399F] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E39A1] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E39A3] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E39A5] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E39A7] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E39A9] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		C = 0;
		A = [0x7E3997];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x7E39AB] = A;
		A = [0x7E3999];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x7E39AD] = A;
		C = 0;
		A = [0x7E399B];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x7E39AF] = A;
		A = [0x7E399D];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x7E39B1] = A;
		C = 0;
		A = [0x7E399F];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x7E39B3] = A;
		A = [0x7E39A1];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x7E39B5] = A;
		C = 0;
		A = [0x7E39A3];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x7E39B7] = A;
		A = [0x7E39A5];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x7E39B9] = A;
		C = 0;
		A = [0x7E39A7];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x7E39BB] = A;
		A = [0x7E39A9];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x7E39BD] = A;
		A = [[0x00]];
		[0x7E39BF] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E39C1] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E39C3] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E39C5] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E39C7] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E39C9] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E39CB] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E39CD] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E39CF] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E39D1] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		C = 0;
		A = [0x7E39BF];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x7E39D3] = A;
		A = [0x7E39C1];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x7E39D5] = A;
		C = 0;
		A = [0x7E39C3];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x7E39D7] = A;
		A = [0x7E39C5];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x7E39D9] = A;
		C = 0;
		A = [0x7E39C7];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x7E39DB] = A;
		A = [0x7E39C9];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x7E39DD] = A;
		C = 0;
		A = [0x7E39CB];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x7E39DF] = A;
		A = [0x7E39CD];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x7E39E1] = A;
		C = 0;
		A = [0x7E39CF];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x7E39E3] = A;
		A = [0x7E39D1];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x7E39E5] = A;
		return;
	}

	public void L81A544()
	{
		this.L81AB70();
		A = [[0x00]];
		[0x7E3D73] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3D75] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3D77] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3D79] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3D7B] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3D7D] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3D7F] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3D81] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3D83] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3D85] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3D9B] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3D9D] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3D9F] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3DA1] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3DA3] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3DA5] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3DA7] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3DA9] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3DAB] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3DAD] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x001500] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x001506] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E39EB] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E39ED] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E39EF] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E39F1] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		C = 0;
		A = [0x7E3D73];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x7E3D87] = A;
		A = [0x7E3D75];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x7E3D89] = A;
		C = 0;
		A = [0x7E3D77];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x7E3D8B] = A;
		A = [0x7E3D79];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x7E3D8D] = A;
		C = 0;
		A = [0x7E3D7B];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x7E3D8F] = A;
		A = [0x7E3D7D];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x7E3D91] = A;
		C = 0;
		A = [0x7E3D7F];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x7E3D93] = A;
		A = [0x7E3D81];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x7E3D95] = A;
		C = 0;
		A = [0x7E3D83];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x7E3D97] = A;
		A = [0x7E3D85];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x7E3D99] = A;
		C = 0;
		A = [0x7E3D9B];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x7E3DAF] = A;
		A = [0x7E3D9D];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x7E3DB1] = A;
		C = 0;
		A = [0x7E3D9F];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x7E3DB3] = A;
		A = [0x7E3DA1];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x7E3DB5] = A;
		C = 0;
		A = [0x7E3DA3];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x7E3DB7] = A;
		A = [0x7E3DA5];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x7E3DB9] = A;
		C = 0;
		A = [0x7E3DA7];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x7E3DBB] = A;
		A = [0x7E3DA9];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x7E3DBD] = A;
		C = 0;
		A = [0x7E3DAB];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x7E3DBF] = A;
		A = [0x7E3DAD];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x7E3DC1] = A;
		return;
	}

	public void L81A7D6()
	{
		A = 0x0000;
		[0x1AA1] = A;
		A = 0x0080;
		[0x1AA3] = A;
		A = [0x1AA1];
		[0x2A] = A;
		A = [0x1AA3];
		[0x2C] = A;
		A = [0x1968];
		[0x2E] = A;
		A = 0x0000;
		[0x30] = A;
		Stack.Push(X);
		Stack.Push(Y);
		this.L8086DC();
		Y = Stack.Pop();
		X = Stack.Pop();
		A = [0x2A];
		[0x1AA1] = A;
		A = [0x2C];
		[0x1AA3] = A;
		A = [0x1966];
		Stack.Push(A);
		A = [0x1968];
		[0x1966] = A;
		A = Stack.Pop();
		[0x1968] = A;
		A = [0x1966];
		[0x26] = A;
		A = [0x1968];
		[0x28] = A;
		A = [0x1AA1];
		[0x2A] = A;
		A = [0x1AA3];
		[0x2C] = A;
		Stack.Push(X);
		Stack.Push(Y);
		this.L80860D();
		Y = Stack.Pop();
		X = Stack.Pop();
		A = [0x2E];
		[0x1966] = A;
		A = [0x30];
		[0x1968] = A;
		X = 0x00F8;
	}

	public void L81A83F()
	{
		A = [0x7E3DC3 + X];
		Stack.Push(A);
		A = [0x7E40C3 + X];
		[0x7E3DC3 + X] = A;
		A = Stack.Pop();
		[0x7E40C3 + X] = A;
		A = [0x7E3DC3 + X];
		[0x26] = A;
		A = [0x7E40C3 + X];
		[0x28] = A;
		A = [0x1AA1];
		[0x2A] = A;
		A = [0x1AA3];
		[0x2C] = A;
		Stack.Push(X);
		Stack.Push(Y);
		this.L80860D();
		Y = Stack.Pop();
		X = Stack.Pop();
		A = [0x2E];
		[0x7E3DC3 + X] = A;
		A = [0x30];
		[0x7E40C3 + X] = A;
		X++;
		X++;
		temp = X - 0x02A2;
		
		if (Z == 1)
			return this.L81A885();

		return this.L81A83F();
	}

	public void L81A885()
	{
		return;
	}

	public void L81A886()
	{
		A = 0x0000;
		[0x1AA1] = A;
		A = 0x0080;
		[0x1AA3] = A;
		A = [0x1AA1];
		[0x2A] = A;
		A = [0x1AA3];
		[0x2C] = A;
		A = [0x7E3A33];
		[0x2E] = A;
		A = 0x0000;
		[0x30] = A;
		Stack.Push(X);
		Stack.Push(Y);
		this.L8086DC();
		Y = Stack.Pop();
		X = Stack.Pop();
		A = [0x2A];
		[0x1AA1] = A;
		A = [0x2C];
		[0x1AA3] = A;
		Y = 0x0020;
		X = 0x0000;
	}

	public void L81A8BF()
	{
		A = [0x7E3A33 + X];
		
		if (N == 1)
			return this.L81A901();

		A = [0x7E39F3 + X];
		Stack.Push(A);
		A = [0x7E3A33 + X];
		[0x7E39F3 + X] = A;
		A = Stack.Pop();
		[0x7E3A33 + X] = A;
		A = [0x7E39F3 + X];
		[0x26] = A;
		A = [0x7E3A33 + X];
		[0x28] = A;
		A = [0x1AA1];
		[0x2A] = A;
		A = [0x1AA3];
		[0x2C] = A;
		Stack.Push(X);
		Stack.Push(Y);
		this.L80860D();
		Y = Stack.Pop();
		X = Stack.Pop();
		A = [0x2E];
		[0x7E39F3 + X] = A;
		A = [0x30];
		[0x7E3A33 + X] = A;
	}

	public void L81A901()
	{
		A = [0x7E39F3 + X];
		[0x001826 + X] = A;
		A = [0x7E3A33 + X];
		[0x001866 + X] = A;
		A = [0x7E39F3 + X];
		[0x0018A6 + X] = A;
		A = [0x7E3A33 + X];
		[0x0018E6 + X] = A;
		A = [0x7E3A73 + X];
		Stack.Push(A);
		A = [0x7E3AB3 + X];
		[0x7E3A73 + X] = A;
		A = Stack.Pop();
		[0x7E3AB3 + X] = A;
		A = [0x7E3A73 + X];
		[0x26] = A;
		A = [0x7E3AB3 + X];
		[0x28] = A;
		A = [0x1AA1];
		[0x2A] = A;
		A = [0x1AA3];
		[0x2C] = A;
		Stack.Push(X);
		Stack.Push(Y);
		this.L80860D();
		Y = Stack.Pop();
		X = Stack.Pop();
		A = [0x2E];
		[0x7E3A73 + X] = A;
		A = [0x30];
		[0x7E3AB3 + X] = A;
		A = [0x7E3B33 + X];
		
		if (N == 1)
			return this.L81A9A2();

		A = [0x7E3AF3 + X];
		Stack.Push(A);
		A = [0x7E3B33 + X];
		[0x7E3AF3 + X] = A;
		A = Stack.Pop();
		[0x7E3B33 + X] = A;
		A = [0x7E3AF3 + X];
		[0x26] = A;
		A = [0x7E3B33 + X];
		[0x28] = A;
		A = [0x1AA1];
		[0x2A] = A;
		A = [0x1AA3];
		[0x2C] = A;
		Stack.Push(X);
		Stack.Push(Y);
		this.L80860D();
		Y = Stack.Pop();
		X = Stack.Pop();
		A = [0x2E];
		[0x7E3AF3 + X] = A;
		A = [0x30];
		[0x7E3B33 + X] = A;
		return this.L81A9AF();
	}

	public void L81A9A2()
	{
		temp = A - 0x8000;
		
		if (Z == 1)
			return this.L81A9AF();

		A = [0x7E3B33 + X];
		[0x7E3AF3 + X] = A;
	}

	public void L81A9AF()
	{
		A = [0x7E3BB3 + X];
		
		if (N == 1)
			return this.L81A9F4();

		A = [0x7E3B73 + X];
		Stack.Push(A);
		A = [0x7E3BB3 + X];
		[0x7E3B73 + X] = A;
		A = Stack.Pop();
		[0x7E3BB3 + X] = A;
		A = [0x7E3B73 + X];
		[0x26] = A;
		A = [0x7E3BB3 + X];
		[0x28] = A;
		A = [0x1AA1];
		[0x2A] = A;
		A = [0x1AA3];
		[0x2C] = A;
		Stack.Push(X);
		Stack.Push(Y);
		this.L80860D();
		Y = Stack.Pop();
		X = Stack.Pop();
		A = [0x2E];
		[0x7E3B73 + X] = A;
		A = [0x30];
		[0x7E3BB3 + X] = A;
		return this.L81AA01();
	}

	public void L81A9F4()
	{
		temp = A - 0x8000;
		
		if (Z == 1)
			return this.L81AA01();

		A = [0x7E3BB3 + X];
		[0x7E3B73 + X] = A;
	}

	public void L81AA01()
	{
		A = [0x7E3C33 + X];
		
		if (N == 1)
			return this.L81AA46();

		A = [0x7E3BF3 + X];
		Stack.Push(A);
		A = [0x7E3C33 + X];
		[0x7E3BF3 + X] = A;
		A = Stack.Pop();
		[0x7E3C33 + X] = A;
		A = [0x7E3BF3 + X];
		[0x26] = A;
		A = [0x7E3C33 + X];
		[0x28] = A;
		A = [0x1AA1];
		[0x2A] = A;
		A = [0x1AA3];
		[0x2C] = A;
		Stack.Push(X);
		Stack.Push(Y);
		this.L80860D();
		Y = Stack.Pop();
		X = Stack.Pop();
		A = [0x2E];
		[0x7E3BF3 + X] = A;
		A = [0x30];
		[0x7E3C33 + X] = A;
		return this.L81AA53();
	}

	public void L81AA46()
	{
		temp = A - 0x8000;
		
		if (Z == 1)
			return this.L81AA53();

		A = [0x7E3C33 + X];
		[0x7E3BF3 + X] = A;
	}

	public void L81AA53()
	{
		A = [0x7E3CB3 + X];
		
		if (N == 1)
			return this.L81AA98();

		A = [0x7E3C73 + X];
		Stack.Push(A);
		A = [0x7E3CB3 + X];
		[0x7E3C73 + X] = A;
		A = Stack.Pop();
		[0x7E3CB3 + X] = A;
		A = [0x7E3C73 + X];
		[0x26] = A;
		A = [0x7E3CB3 + X];
		[0x28] = A;
		A = [0x1AA1];
		[0x2A] = A;
		A = [0x1AA3];
		[0x2C] = A;
		Stack.Push(X);
		Stack.Push(Y);
		this.L80860D();
		Y = Stack.Pop();
		X = Stack.Pop();
		A = [0x2E];
		[0x7E3C73 + X] = A;
		A = [0x30];
		[0x7E3CB3 + X] = A;
		return this.L81AAA5();
	}

	public void L81AA98()
	{
		temp = A - 0x8000;
		
		if (Z == 1)
			return this.L81AAA5();

		A = [0x7E3CB3 + X];
		[0x7E3C73 + X] = A;
	}

	public void L81AAA5()
	{
		X++;
		X++;
		Y--;
		
		if (Z == 1)
			return this.L81AAAD();

		return this.L81A8BF();
	}

	public void L81AAAD()
	{
		X = 0x0000;
	}

	public void L81AAB0()
	{
		A = [0x7E3DC3 + X];
		Stack.Push(A);
		A = [0x7E40C3 + X];
		[0x7E3DC3 + X] = A;
		A = Stack.Pop();
		[0x7E40C3 + X] = A;
		A = [0x7E3DC3 + X];
		[0x26] = A;
		A = [0x7E40C3 + X];
		[0x28] = A;
		A = [0x1AA1];
		[0x2A] = A;
		A = [0x1AA3];
		[0x2C] = A;
		Stack.Push(X);
		Stack.Push(Y);
		this.L80860D();
		Y = Stack.Pop();
		X = Stack.Pop();
		A = [0x2E];
		[0x7E3DC3 + X] = A;
		A = [0x30];
		[0x7E40C3 + X] = A;
		X++;
		X++;
		temp = X - 0x0080;
		
		if (Z == 1)
			return this.L81AAF6();

		return this.L81AAB0();
	}

	public void L81AAF6()
	{
		return;
	}

	public void L81AAF7()
	{
		Stack.Push(X);
		A = [0x0381];
		A <<= 1;
		C = 0;
		A += [0x0381] + C;
		X = A;
		A = [0xAB2F + X];
		[0x01] = A;
		A = [0xAB2E + X];
		[0x00] = A;
		X = Stack.Pop();
		return;
	}

	public void L81AB0D()
	{
		Stack.Push(X);
		A = [0x0381];
		A <<= 1;
		C = 0;
		A += [0x0381] + C;
		X = A;
		A = [0xAB38 + X];
		[0x01] = A;
		A = [0xAB37 + X];
		[0x00] = A;
		X = Stack.Pop();
		return;
	}

	public void L81AB23()
	{
		A = 0x8100;
		[0x01] = A;
		A = 0xACE1;
		[0x00] = A;
		return;
	}

	public void L81AB40()
	{
		Stack.Push(X);
		A = [0x14D6];
		A <<= 1;
		C = 0;
		A += [0x14D6] + C;
		X = A;
		A = [0x81AB89 + X];
		[0x01] = A;
		A = [0x81AB88 + X];
		[0x00] = A;
		X = Stack.Pop();
		return;
	}

	public void L81AB70()
	{
		Stack.Push(X);
		A = [0x14D6];
		A <<= 1;
		C = 0;
		A += [0x14D6] + C;
		X = A;
		A = [0x81ABEF + X];
		[0x01] = A;
		A = [0x81ABEE + X];
		[0x00] = A;
		X = Stack.Pop();
		return;
	}








	public void L81E739()
	{
		Stack.Push(B);
		this.L81E741();
		B = Stack.Pop();
		return this.L81E765();
	}

	public void L81E741()
	{
		A = [0x14D6];
		temp = A - 0x0011;

		if (N == 1)
			return this.L81E74B();
	}

	public void L81E749()
	{
		return this.L81E749();
	}

	public void L81E74B()
	{
		A <<= 1;
		A += [0x14D6] + C;
		X = A;
		A = [0x81E76D + X];
		[0x0F] = A;
		P |= 0x20;
		A = [0x81E76F + X];
		[0x11] = A;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		return [[0x000F]]();    //24-Bit Address
	}








	public void L81E765()
	{
		this.R838000();
		return this.L80A0ED();
	}









	public void R81EAB4()
	{
		Stack.Push(B);
		this.L81EABC();
		B = Stack.Pop();
		return this.L81EAE0();
	}

	public void L81EABC()
	{
		A = [0x14D6];
		temp = A - 0x0011;
		
		if (N == 1)
			return this.L81EAC6();

	}

	public void L81EAC4()
	{
		return this.L81EAC4();
	}

	public void L81EAC6()
	{
		A <<= 1;
		A += [0x14D6] + C;
		X = A;
		A = [0x81EAE5 + X];
		[0x0F] = A;
		P |= 0x20;
		A = [0x81EAE7 + X];
		[0x11] = A;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		return [[0x000F]]();	//24-Bit Address
	}

	public void L81EAE0()
	{
		this.R80F159();
		return;
	}








	public void L8286B6()
	{
		Stack.Push(P);
		Stack.Push(B);
		P |= 0x30;
		A = [0xA5];
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x30;
		A = [0xB4];
		A <<= 1;
		Y = A;
		A = [(0xA3) + Y];
		C = 0;
		A += [0xA3] + C;
		Y = A;
		A = [0x0000 + Y];

		if (N == 0)
			return this.L8286E8();

		temp = A - 0xFFFE;

		if (Z == 1)
			return this.L8286DC();

		temp = A - 0xFFFF;

		if (Z == 1)
			return this.L8286E2();

		return this.L8286E8();
	}

	public void L8286DC()
	{
		this.L828875();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L8286E2()
	{
		this.L828927();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L8286E8()
	{
		[0xA1] = A;
		A = [0xA6];
		A >>= 1;
		A >>= 1;
		[0x9E] = A;
		temp = A - 0x0080;

		if (C == 1)
			return this.L828712();

		C = 0;
		A += [0xA1] + C;
		temp = A - 0x0080;

		if (C == 1)
			return this.L828703();

		A <<= 1;
		A <<= 1;
		[0xA6] = A;
		return this.L828715();
	}

	public void L828703()
	{
		A = 0x0080;
		C = 1;
		A -= [0x9E] - !C;
		[0xA1] = A;
		A = 0x0200;
		[0xA6] = A;
		return this.L828715();
	}

	public void L828712()
	{
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L828715()
	{
		A = [0x007FF6];
		A &= 0xFF00;
		A |= [0x9E];
		X = A;
		Y++;
		Y++;
	}

	public void L828721()
	{
		A = X;
		[0x007FF6] = A;
		A = [0x0000 + Y];

		if (N == 0)
			return this.L82873B();

		C = 0;
		A += [0xB0] + C;
		[0x007FF0] = A;
		A |= 0x0200;
		[0x007FF3] = A;
		return this.L828749();
	}

	public void L82873B()
	{
		C = 0;
		A += [0xB0] + C;
		[0x007FF0] = A;
		A &= 0xFDFF;
		[0x007FF3] = A;
	}

	public void L828749()
	{
		C = 0;
		A = [0x0002 + Y];
		A += [0xB2] + C;
		[0x007FF1] = A;
		A = [0x0003 + Y];
		A &= [0xA8];
		A |= [0xAA];
		[0x007FF2] = A;
		C = 0;
		A = Y;
		A += 0x0005 + C;
		Y = A;
		X++;
		[0xA1]--;

		if (Z == 0)
			return this.L828721();

		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L828875()
	{
		this.L828982();
		A = [0xB4];
		temp = A - [0xB6];

		if (Z == 0)
			return this.L828881();

		return this.L82891F();
	}

	public void L828881()
	{
		[0xB6] = A;
		A = [0xB8];
		temp = A & 0x0100;

		if (Z == 1)
			return this.L82888D();

		return this.L82891E();
	}

	public void L82888D()
	{
		A = [0xBA];
		temp = A & [0xB8];[0xB8] |= A;
		Y++;
		Y++;
	}

	public void L828893()
	{
		A = [0x0000 + Y];
		temp = A - 0xFFFF;

		if (Z == 0)
			return this.L82889E();

		return this.L82891E();
	}

	public void L82889E()
	{
		X = A;
		A = [0x0002 + Y];
		[0xA1] = A;
		Y++;
		Y++;
		Y++;
		Y++;
		temp = A & 0x0003;

		if (Z == 1)
			return this.L8288E9();

		temp = A & 0x0001;

		if (Z == 1)
			return this.L8288C4();

	}

	public void L8288B2()
	{
		A = [0x0000 + Y];
		[0x7E0000 + X] = A;
		X++;
		X++;
		Y++;
		Y++;
		[0xA1]--;

		if (Z == 0)
			return this.L8288B2();

		return this.L828893();
	}

	public void L8288C4()
	{
		A = [0x0000 + Y];
		[0x7E0000 + X] = A;
		A = [0x0002 + Y];
		[0x7E0002 + X] = A;
		A = X;
		C = 0;
		A += 0x0004 + C;
		X = A;
		A = Y;
		C = 0;
		A += 0x0004 + C;
		Y = A;
		A = [0xA1];
		A--;
		A--;
		[0xA1] = A;

		if (Z == 0)
			return this.L8288C4();

		return this.L828893();
	}

	public void L8288E9()
	{
		A = [0x0000 + Y];
		[0x7E0000 + X] = A;
		A = [0x0002 + Y];
		[0x7E0002 + X] = A;
		A = [0x0004 + Y];
		[0x7E0004 + X] = A;
		A = [0x0006 + Y];
		[0x7E0006 + X] = A;
		A = X;
		C = 0;
		A += 0x0008 + C;
		X = A;
		A = Y;
		C = 0;
		A += 0x0008 + C;
		Y = A;
		A = [0xA1];
		C = 1;
		A -= 0x0004 - !C;
		[0xA1] = A;

		if (Z == 0)
			return this.L8288E9();

		return this.L828893();
	}

	public void L82891E()
	{
		return;
	}

	public void L82891F()
	{
		A = [0xBA];
		A &= 0x0C00;
		temp = A & [0xB8];[0xB8] |= A;
		return;
	}

	public void L828927()
	{
		this.L828982();
		A = [0xB4];
		temp = A - [0xB6];

		if (Z == 0)
			return this.L828933();

		return this.L82897A();
	}

	public void L828933()
	{
		[0xB6] = A;
		A = [0xB8];
		temp = A & 0x3200;

		if (Z == 0)
			return this.L828979();

		A = [0xBC];
		temp = A & [0xB8];[0xB8] |= A;
		A = [0x0152];
		X = A;
		C = 0;
		A += 0x0009 + C;
		[0x0152] = A;
		A = [0x0002 + Y];
		[0x0155 + X] = A;
		A = [0x0006 + Y];
		[0x0159 + X] = A;
		A = [0x0008 + Y];
		[0x015B + X] = A;
		A = [0x000A + Y];
		[0x015D + X] = A;
		A = Y;
		C = 0;
		A += 0x000C + C;
		[0x0156 + X] = A;
		P |= 0x20;
		Stack.Push(B);
		A = Stack.Pop();
		[0x0158 + X] = A;
		A = 0x01;
		[0x0154] = A;
		P &= ~0x20;
	}

	public void L828979()
	{
		return;
	}

	public void L82897A()
	{
		A = [0xBC];
		A &= 0x0C00;
		temp = A & [0xB8];[0xB8] |= A;
		return;
	}

	public void L828982()
	{
		A = [0xB8];
		temp = A & 0x0080;

		if (Z == 0)
			return this.L82898D();

		this.L82898E();
	}

	public void L82898D()
	{
		return;
	}

	public void L82898E()
	{
		A = 0x0000;
		C = 1;
		A -= [0xBE] - !C;
		C = 1;
		A -= [0xB0] - !C;
		[0x010F] = A;
		A = 0x0000;
		C = 1;
		A -= [0xC0] - !C;
		C = 1;
		A -= [0xB2] - !C;
		[0x0111] = A;
		return;
	}







	public void R8391CD()
	{
		X = 0x003E;
	}

	public void L8391D0()
	{
		A = 0xFFFF;
		[0x16A6 + X] = A;
		A = 0x0000;
		[0x16E6 + X] = A;
		A = 0x8000;
		[0x1726 + X] = A;
		A = 0x0000;
		[0x1926 + X] = A;
		A = 0xFFFF;
		[0x1826 + X] = A;
		A = 0xFFFF;
		[0x1766 + X] = A;
		[0x17A6 + X] = A;
		X--;
		X--;
		
		if (N == 0)
			return this.L8391D0();

		A = 0x0000;
		[0x14DA] = A;
		[0x14DC] = A;
		[0x14DE] = A;
		[0x14E0] = A;
		[0x14E2] = A;
		[0x14E4] = A;
		[0x14E8] = A;
		[0x14EA] = A;
		[0x14EC] = A;
		[0x14EE] = A;
		[0x14F0] = A;
		[0x14F2] = A;
		[0x14F4] = A;
		[0x14F6] = A;
		[0x14F8] = A;
		[0x14FA] = A;
		[0x14FC] = A;
		[0x1504] = A;
		[0x1506] = A;
		[0x1500] = A;
		[0x1508] = A;
		A = 0x0180;
		[0x14D8] = A;
		[0x14E6] = A;
		A = 0x0000;
		[0x150E] = A;
		[0x1514] = A;
		[0x1516] = A;
		[0x151A] = A;
		[0x151E] = A;
		[0x1520] = A;
		[0x1AE1] = A;
		[0x1AE3] = A;
		[0x1AE5] = A;
		[0x1AE7] = A;
		[0x1AE9] = A;
		[0x1AEB] = A;
		[0x1AED] = A;
		[0x1AEF] = A;
		[0x1AF1] = A;
		[0x1AF3] = A;
		[0x7E39E7] = A;
		[0x7E39E9] = A;
		A |= 0x1000;
		A |= 0x0800;
		A = [0x150C];
		A &= 0x4113;
		A |= 0x2000;
		[0x150C] = A;
		this.L8393B5();
		A = 0x0000;
		[0x7E5BF1] = A;
		A = 0xFFFF;
		[0x1AC9] = A;
		A = 0x8000;
		[0x1AC5] = A;
		[0x1AC7] = A;
		A = 0x0000;
		[0x1AC1] = A;
		[0x1AC3] = A;
		[0x1AD3] = A;
		[0x1AD5] = A;
		[0x1ACF] = A;
		[0x1AD1] = A;
		A = 0x0000;
		[0x7E3987] = A;
		[0x7E398B] = A;
		[0x7E3989] = A;
		[0x7E398D] = A;
		[0x7E398F] = A;
		[0x7E3993] = A;
		[0x7E3991] = A;
		[0x7E3995] = A;
		A = 0x0000;
		[0x7E5CCC] = A;
		[0x7E5D0E] = A;
		[0x7E5DAE] = A;
		[0xB8] = 0;
		A = 0xFFFF;
		[0xB6] = A;
		A = 0x0000;
		[0x1978] = A;
		[0x197A] = A;
		[0x197C] = A;
		[0x197E] = A;
		[0x1980] = A;
		[0x1982] = A;
		[0x1984] = A;
		[0x1986] = A;
		[0x1988] = A;
		[0x198A] = A;
		[0x198C] = A;
		[0x198E] = A;
		[0x1990] = A;
		[0x1992] = A;
		[0x1994] = A;
		[0x1996] = A;
		[0x1998] = A;
		[0x199A] = A;
		[0x199C] = A;
		[0x199E] = A;
		[0x19A0] = A;
		[0x19A2] = A;
		[0x19A4] = A;
		[0x19A6] = A;
		A = 0x0000;
		[0x1976] = 0;
		[0x196A] = A;
		[0x196C] = A;
		this.R80E680();
		A = 0x0000;
		[0x7E5BEB] = A;
		[0x7E5BED] = A;
		A = 0x7FFF;
		[0x001BA5] = A;
		[0x001BA7] = A;
		[0x001BA9] = A;
		[0x001BAB] = A;
		[0x001BAD] = A;
		[0x001BAF] = A;
		[0x001BB1] = A;
		[0x001BB3] = A;
		[0x001BB5] = A;
		[0x001BB7] = A;
		[0x7E5C18] = A;
		[0x7E5C1A] = A;
		[0x7E5C1C] = A;
		[0x7E5C1E] = A;
		[0x7E5C20] = A;
		[0x7E5C22] = A;
		[0x7E5C24] = A;
		[0x7E5C26] = A;
		[0x7E5C28] = A;
		[0x7E5C2A] = A;
		return;
	}

	public void L8393B5()
	{
		A = [0x50];
		[0x1B11] = A;
		A = 0x0060;
		temp = A & [0x150C]; [0x150C] &= ~A;
		A = [0x036F];
		A--;
		
		if (Z == 0)
			return this.L8393E2();

		A = [0x0371];
		temp = A - 0x0003;
		
		if (Z == 1)
			return this.L8393E2();

		A = [0x036D];
		temp = A - 0x0004;
		
		if (C == 0)
			return this.L8393D9();

		A = 0x0003;
	}

	public void L8393D9()
	{
		A <<= 1;
		X = A;
		A = [0x83940E + X];
		temp = A & [0x150C]; [0x150C] |= A;
	}

	public void L8393E2()
	{
		A = [0x50];
		temp = A & 0x0210;
		
		if (Z == 1)
			return this.L83940D();

		A = 0x0060;
		temp = A & [0x150C]; [0x150C] &= ~A;
		X = 0x0000;
		A = [0x50];
		temp = A & 0x0020;
		
		if (Z == 1)
			return this.L8393FB();

		X++;
		X++;
	}

	public void L8393FB()
	{
		A = [0x50];
		temp = A & 0x0010;
		
		if (Z == 1)
			return this.L839406();

		X++;
		X++;
		X++;
		X++;
	}

	public void L839406()
	{
		A = [0x83940E + X];
		temp = A & [0x150C]; [0x150C] |= A;
	}

	public void L83940D()
	{
		return;
	}

	public void R839416()
	{
		X = 0x001E;
	}

	public void L839419()
	{
		A = 0x0000;
		[0x19EB + X] = A;
		[0x7E5CCE + X] = A;
		[0x7E5D6E + X] = A;
		[0x7E5D8E + X] = A;
		[0x7E5CEE + X] = A;
		[0x7E5D2E + X] = A;
		A = 0x0050;
		[0x7E5D0E + X] = A;
		[0x7E5D4E + X] = A;
		X--;
		X--;
		
		if (N == 0)
			return this.L839419();

		return;
	}








	public void L83955A()
	{
		A = [0x014C];
		A >>= 1;

		if (C == 0)
			return this.L839563();

		return this.L8396AE();
	}

	public void L839563()
	{
		A = [0x7E3963];

		if (Z == 1)
			return this.L83958C();

		A = [0x7E3903];
		[0x12] = A;
		A = [0x7E3923];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 0)
			return this.L83958C();

		A = [0x7E3943];
		[0x16] = A;
		this.L839B44();
	}

	public void L83958C()
	{
		A = [0x7E3967];

		if (Z == 1)
			return this.L8395B5();

		A = [0x7E3907];
		[0x12] = A;
		A = [0x7E3927];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 0)
			return this.L8395B5();

		A = [0x7E3947];
		[0x16] = A;
		this.L839B44();
	}

	public void L8395B5()
	{
		A = [0x7E396B];

		if (Z == 1)
			return this.L8395DE();

		A = [0x7E390B];
		[0x12] = A;
		A = [0x7E392B];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 0)
			return this.L8395DE();

		A = [0x7E394B];
		[0x16] = A;
		this.L839B44();
	}

	public void L8395DE()
	{
		A = [0x7E396F];

		if (Z == 1)
			return this.L839607();

		A = [0x7E390F];
		[0x12] = A;
		A = [0x7E392F];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 0)
			return this.L839607();

		A = [0x7E394F];
		[0x16] = A;
		this.L839B44();
	}

	public void L839607()
	{
		A = [0x7E3973];

		if (Z == 1)
			return this.L839630();

		A = [0x7E3913];
		[0x12] = A;
		A = [0x7E3933];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 0)
			return this.L839630();

		A = [0x7E3953];
		[0x16] = A;
		this.L839B44();
	}

	public void L839630()
	{
		A = [0x7E3977];

		if (Z == 1)
			return this.L839659();

		A = [0x7E3917];
		[0x12] = A;
		A = [0x7E3937];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 0)
			return this.L839659();

		A = [0x7E3957];
		[0x16] = A;
		this.L839B44();
	}

	public void L839659()
	{
		A = [0x7E397B];

		if (Z == 1)
			return this.L839682();

		A = [0x7E391B];
		[0x12] = A;
		A = [0x7E393B];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 0)
			return this.L839682();

		A = [0x7E395B];
		[0x16] = A;
		this.L839B44();
	}

	public void L839682()
	{
		A = [0x7E397F];

		if (Z == 1)
			return this.L8396AB();

		A = [0x7E391F];
		[0x12] = A;
		A = [0x7E393F];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 0)
			return this.L8396AB();

		A = [0x7E395F];
		[0x16] = A;
		this.L839B44();
	}

	public void L8396AB()
	{
		return this.L8397F6();
	}

	public void L8396AE()
	{
		A = [0x7E3965];

		if (Z == 1)
			return this.L8396D7();

		A = [0x7E3905];
		[0x12] = A;
		A = [0x7E3925];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 0)
			return this.L8396D7();

		A = [0x7E3945];
		[0x16] = A;
		this.L839B44();
	}

	public void L8396D7()
	{
		A = [0x7E3969];

		if (Z == 1)
			return this.L839700();

		A = [0x7E3909];
		[0x12] = A;
		A = [0x7E3929];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 0)
			return this.L839700();

		A = [0x7E3949];
		[0x16] = A;
		this.L839B44();
	}

	public void L839700()
	{
		A = [0x7E396D];

		if (Z == 1)
			return this.L839729();

		A = [0x7E390D];
		[0x12] = A;
		A = [0x7E392D];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 0)
			return this.L839729();

		A = [0x7E394D];
		[0x16] = A;
		this.L839B44();
	}

	public void L839729()
	{
		A = [0x7E3971];

		if (Z == 1)
			return this.L839752();

		A = [0x7E3911];
		[0x12] = A;
		A = [0x7E3931];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 0)
			return this.L839752();

		A = [0x7E3951];
		[0x16] = A;
		this.L839B44();
	}

	public void L839752()
	{
		A = [0x7E3975];

		if (Z == 1)
			return this.L83977B();

		A = [0x7E3915];
		[0x12] = A;
		A = [0x7E3935];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 0)
			return this.L83977B();

		A = [0x7E3955];
		[0x16] = A;
		this.L839B44();
	}

	public void L83977B()
	{
		A = [0x7E3979];

		if (Z == 1)
			return this.L8397A4();

		A = [0x7E3919];
		[0x12] = A;
		A = [0x7E3939];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 0)
			return this.L8397A4();

		A = [0x7E3959];
		[0x16] = A;
		this.L839B44();
	}

	public void L8397A4()
	{
		A = [0x7E397D];

		if (Z == 1)
			return this.L8397CD();

		A = [0x7E391D];
		[0x12] = A;
		A = [0x7E393D];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 0)
			return this.L8397CD();

		A = [0x7E395D];
		[0x16] = A;
		this.L839B44();
	}

	public void L8397CD()
	{
		A = [0x7E3981];

		if (Z == 1)
			return this.L8397F6();

		A = [0x7E3921];
		[0x12] = A;
		A = [0x7E3941];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 0)
			return this.L8397F6();

		A = [0x7E3961];
		[0x16] = A;
		this.L839B44();
	}

	public void L8397F6()
	{
		return;
	}

	public void L8397F7()
	{
		A = [0x014C];
		A >>= 1;

		if (C == 0)
			return this.L839800();

		return this.L83994B();
	}

	public void L839800()
	{
		A = [0x7E3963];

		if (Z == 1)
			return this.L839829();

		A = [0x7E3903];
		[0x12] = A;
		A = [0x7E3923];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 1)
			return this.L839829();

		A = [0x7E3943];
		[0x16] = A;
		this.L839BC3();
	}

	public void L839829()
	{
		A = [0x7E3967];

		if (Z == 1)
			return this.L839852();

		A = [0x7E3907];
		[0x12] = A;
		A = [0x7E3927];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 1)
			return this.L839852();

		A = [0x7E3947];
		[0x16] = A;
		this.L839BC3();
	}

	public void L839852()
	{
		A = [0x7E396B];

		if (Z == 1)
			return this.L83987B();

		A = [0x7E390B];
		[0x12] = A;
		A = [0x7E392B];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 1)
			return this.L83987B();

		A = [0x7E394B];
		[0x16] = A;
		this.L839BC3();
	}

	public void L83987B()
	{
		A = [0x7E396F];

		if (Z == 1)
			return this.L8398A4();

		A = [0x7E390F];
		[0x12] = A;
		A = [0x7E392F];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 1)
			return this.L8398A4();

		A = [0x7E394F];
		[0x16] = A;
		this.L839BC3();
	}

	public void L8398A4()
	{
		A = [0x7E3973];

		if (Z == 1)
			return this.L8398CD();

		A = [0x7E3913];
		[0x12] = A;
		A = [0x7E3933];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 1)
			return this.L8398CD();

		A = [0x7E3953];
		[0x16] = A;
		this.L839BC3();
	}

	public void L8398CD()
	{
		A = [0x7E3977];

		if (Z == 1)
			return this.L8398F6();

		A = [0x7E3917];
		[0x12] = A;
		A = [0x7E3937];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 1)
			return this.L8398F6();

		A = [0x7E3957];
		[0x16] = A;
		this.L839BC3();
	}

	public void L8398F6()
	{
		A = [0x7E397B];

		if (Z == 1)
			return this.L83991F();

		A = [0x7E391B];
		[0x12] = A;
		A = [0x7E393B];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 1)
			return this.L83991F();

		A = [0x7E395B];
		[0x16] = A;
		this.L839BC3();
	}

	public void L83991F()
	{
		A = [0x7E397F];

		if (Z == 1)
			return this.L839948();

		A = [0x7E391F];
		[0x12] = A;
		A = [0x7E393F];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 1)
			return this.L839948();

		A = [0x7E395F];
		[0x16] = A;
		this.L839BC3();
	}

	public void L839948()
	{
		return this.L839A93();
	}

	public void L83994B()
	{
		A = [0x7E3965];

		if (Z == 1)
			return this.L839974();

		A = [0x7E3905];
		[0x12] = A;
		A = [0x7E3925];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 1)
			return this.L839974();

		A = [0x7E3945];
		[0x16] = A;
		this.L839BC3();
	}

	public void L839974()
	{
		A = [0x7E3969];

		if (Z == 1)
			return this.L83999D();

		A = [0x7E3909];
		[0x12] = A;
		A = [0x7E3929];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 1)
			return this.L83999D();

		A = [0x7E3949];
		[0x16] = A;
		this.L839BC3();
	}

	public void L83999D()
	{
		A = [0x7E396D];

		if (Z == 1)
			return this.L8399C6();

		A = [0x7E390D];
		[0x12] = A;
		A = [0x7E392D];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 1)
			return this.L8399C6();

		A = [0x7E394D];
		[0x16] = A;
		this.L839BC3();
	}

	public void L8399C6()
	{
		A = [0x7E3971];

		if (Z == 1)
			return this.L8399EF();

		A = [0x7E3911];
		[0x12] = A;
		A = [0x7E3931];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 1)
			return this.L8399EF();

		A = [0x7E3951];
		[0x16] = A;
		this.L839BC3();
	}

	public void L8399EF()
	{
		A = [0x7E3975];

		if (Z == 1)
			return this.L839A18();

		A = [0x7E3915];
		[0x12] = A;
		A = [0x7E3935];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 1)
			return this.L839A18();

		A = [0x7E3955];
		[0x16] = A;
		this.L839BC3();
	}

	public void L839A18()
	{
		A = [0x7E3979];

		if (Z == 1)
			return this.L839A41();

		A = [0x7E3919];
		[0x12] = A;
		A = [0x7E3939];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 1)
			return this.L839A41();

		A = [0x7E3959];
		[0x16] = A;
		this.L839BC3();
	}

	public void L839A41()
	{
		A = [0x7E397D];

		if (Z == 1)
			return this.L839A6A();

		A = [0x7E391D];
		[0x12] = A;
		A = [0x7E393D];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 1)
			return this.L839A6A();

		A = [0x7E395D];
		[0x16] = A;
		this.L839BC3();
	}

	public void L839A6A()
	{
		A = [0x7E3981];

		if (Z == 1)
			return this.L839A93();

		A = [0x7E3921];
		[0x12] = A;
		A = [0x7E3941];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 1)
			return this.L839A93();

		A = [0x7E3961];
		[0x16] = A;
		this.L839BC3();
	}

	public void L839A93()
	{
		A = [0x7E3963];

		if (Z == 1)
			return this.L839A9E();

		A--;
		[0x7E3963] = A;
	}

	public void L839A9E()
	{
		A = [0x7E3965];

		if (Z == 1)
			return this.L839AA9();

		A--;
		[0x7E3965] = A;
	}

	public void L839AA9()
	{
		A = [0x7E3967];

		if (Z == 1)
			return this.L839AB4();

		A--;
		[0x7E3967] = A;
	}

	public void L839AB4()
	{
		A = [0x7E3969];

		if (Z == 1)
			return this.L839ABF();

		A--;
		[0x7E3969] = A;
	}

	public void L839ABF()
	{
		A = [0x7E396B];

		if (Z == 1)
			return this.L839ACA();

		A--;
		[0x7E396B] = A;
	}

	public void L839ACA()
	{
		A = [0x7E396D];

		if (Z == 1)
			return this.L839AD5();

		A--;
		[0x7E396D] = A;
	}

	public void L839AD5()
	{
		A = [0x7E396F];

		if (Z == 1)
			return this.L839AE0();

		A--;
		[0x7E396F] = A;
	}

	public void L839AE0()
	{
		A = [0x7E3971];

		if (Z == 1)
			return this.L839AEB();

		A--;
		[0x7E3971] = A;
	}

	public void L839AEB()
	{
		A = [0x7E3973];

		if (Z == 1)
			return this.L839AF6();

		A--;
		[0x7E3973] = A;
	}

	public void L839AF6()
	{
		A = [0x7E3975];

		if (Z == 1)
			return this.L839B01();

		A--;
		[0x7E3975] = A;
	}

	public void L839B01()
	{
		A = [0x7E3977];

		if (Z == 1)
			return this.L839B0C();

		A--;
		[0x7E3977] = A;
	}

	public void L839B0C()
	{
		A = [0x7E3979];

		if (Z == 1)
			return this.L839B17();

		A--;
		[0x7E3979] = A;
	}

	public void L839B17()
	{
		A = [0x7E397B];

		if (Z == 1)
			return this.L839B22();

		A--;
		[0x7E397B] = A;
	}

	public void L839B22()
	{
		A = [0x7E397D];

		if (Z == 1)
			return this.L839B2D();

		A--;
		[0x7E397D] = A;
	}

	public void L839B2D()
	{
		A = [0x7E397F];

		if (Z == 1)
			return this.L839B38();

		A--;
		[0x7E397F] = A;
	}

	public void L839B38()
	{
		A = [0x7E3981];

		if (Z == 1)
			return this.L839B43();

		A--;
		[0x7E3981] = A;
	}

	public void L839B43()
	{
		return;
	}

	public void L839B44()
	{
		A = [0x1866 + X];

		if (N == 1)
			return this.L839BA0();

		A = [[0x00]];
		temp = A & 0x0080;

		if (Z == 0)
			return this.L839B55();

		A &= 0x007F;
		return this.L839B58();
	}

	public void L839B55()
	{
		A |= 0xFF80;
	}

	public void L839B58()
	{
		C = 0;
		A += [0x15A6 + X] + C;
		[0xB0] = A;
		C = 0;
		A += 0x0020 + C;
		temp = A - 0x0140;

		if (C == 1)
			return this.L839BA0();

		Y = 0x0001;
		A = [[0x00] + Y];
		temp = A & 0x0080;

		if (Z == 0)
			return this.L839B76();

		A &= 0x007F;
		return this.L839B79();
	}

	public void L839B76()
	{
		A |= 0xFF80;
	}

	public void L839B79()
	{
		C = 0;
		A += [0x15E6 + X] + C;
		[0xB2] = A;
		C = 0;
		A += 0x0020 + C;
		temp = A - 0x00E8;

		if (C == 1)
			return this.L839BA0();

		A = 0xC1FF;
		[0xA8] = A;
		A = [0x14D6];
		A <<= 1;
		X = A;
		A = [0x839BA1 + X];
		[0xAA] = A;
		A = [0x16];
		[0xB4] = A;
		this.L8280C2();
	}

	public void L839BA0()
	{
		return;
	}

	public void L839BC3()
	{
		A = [0x1866 + X];

		if (N == 1)
			return this.L839C1F();

		A = [[0x00]];
		temp = A & 0x0080;

		if (Z == 0)
			return this.L839BD4();

		A &= 0x007F;
		return this.L839BD7();
	}

	public void L839BD4()
	{
		A |= 0xFF80;
	}

	public void L839BD7()
	{
		C = 0;
		A += [0x15A6 + X] + C;
		[0xB0] = A;
		C = 0;
		A += 0x0020 + C;
		temp = A - 0x0140;

		if (C == 1)
			return this.L839C1F();

		Y = 0x0001;
		A = [[0x00] + Y];
		temp = A & 0x0080;

		if (Z == 0)
			return this.L839BF5();

		A &= 0x007F;
		return this.L839BF8();
	}

	public void L839BF5()
	{
		A |= 0xFF80;
	}

	public void L839BF8()
	{
		C = 0;
		A += [0x15E6 + X] + C;
		[0xB2] = A;
		C = 0;
		A += 0x0020 + C;
		temp = A - 0x00E8;

		if (C == 1)
			return this.L839C1F();

		A = 0xC1FF;
		[0xA8] = A;
		A = [0x14D6];
		A <<= 1;
		X = A;
		A = [0x839C20 + X];
		[0xAA] = A;
		A = [0x16];
		[0xB4] = A;
		this.L8280C2();
	}

	public void L839C1F()
	{
		return;
	}

	public void L839C42()
	{
		A = [0x7E3901];
		[0x01] = A;
		A = [0x7E3900];
		[0x00] = A;
		A = [0x12];
		A <<= 1;
		X = A;
		A = [0x1666 + X];
		A <<= 1;
		Y = A;
		A = [[0x00] + Y];
		C = 0;
		A += [0x00] + C;
		[0x00] = A;
		A = [0x14];
		A <<= 1;
		C = 0;
		A += [0x14] + C;
		C = 0;
		A += [0x00] + C;
		[0x00] = A;
		return;
	}

	public void L839C9C()
	{
		A = [0x1A81];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L839CB0();

		A &= 0x7FFF;
		[0x1A81] = A;
		X = 0x0000;
		this.L839F1E();
	}

	public void L839CB0()
	{
		A = [0x1A83];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L839CC4();

		A &= 0x7FFF;
		[0x1A83] = A;
		X = 0x0002;
		this.L839F1E();
	}

	public void L839CC4()
	{
		A = [0x1A85];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L839CD8();

		A &= 0x7FFF;
		[0x1A85] = A;
		X = 0x0004;
		this.L839F1E();
	}

	public void L839CD8()
	{
		A = [0x1A87];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L839CEC();

		A &= 0x7FFF;
		[0x1A87] = A;
		X = 0x0006;
		this.L839F1E();
	}

	public void L839CEC()
	{
		A = [0x1A89];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L839D00();

		A &= 0x7FFF;
		[0x1A89] = A;
		X = 0x0008;
		this.L839F1E();
	}

	public void L839D00()
	{
		A = [0x1A8B];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L839D14();

		A &= 0x7FFF;
		[0x1A8B] = A;
		X = 0x000A;
		this.L839F1E();
	}

	public void L839D14()
	{
		A = [0x1A8D];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L839D28();

		A &= 0x7FFF;
		[0x1A8D] = A;
		X = 0x000C;
		this.L839F1E();
	}

	public void L839D28()
	{
		A = [0x1A8F];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L839D3C();

		A &= 0x7FFF;
		[0x1A8F] = A;
		X = 0x000E;
		this.L839F1E();
	}

	public void L839D3C()
	{
		A = [0x1A91];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L839D50();

		A &= 0x7FFF;
		[0x1A91] = A;
		X = 0x0010;
		this.L839F1E();
	}

	public void L839D50()
	{
		A = [0x1A93];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L839D64();

		A &= 0x7FFF;
		[0x1A93] = A;
		X = 0x0012;
		this.L839F1E();
	}

	public void L839D64()
	{
		A = [0x1A95];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L839D78();

		A &= 0x7FFF;
		[0x1A95] = A;
		X = 0x0014;
		this.L839F1E();
	}

	public void L839D78()
	{
		A = [0x1A97];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L839D8C();

		A &= 0x7FFF;
		[0x1A97] = A;
		X = 0x0016;
		this.L839F1E();
	}

	public void L839D8C()
	{
		A = [0x1A99];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L839DA0();

		A &= 0x7FFF;
		[0x1A99] = A;
		X = 0x0018;
		this.L839F1E();
	}

	public void L839DA0()
	{
		A = [0x1A9B];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L839DB4();

		A &= 0x7FFF;
		[0x1A9B] = A;
		X = 0x001A;
		this.L839F1E();
	}

	public void L839DB4()
	{
		A = [0x1A9D];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L839DC8();

		A &= 0x7FFF;
		[0x1A9D] = A;
		X = 0x001C;
		this.L839F1E();
	}

	public void L839DC8()
	{
		A = [0x1A9F];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L839DDC();

		A &= 0x7FFF;
		[0x1A9F] = A;
		X = 0x001E;
		this.L839F1E();
	}

	public void L839DDC()
	{
		return;
	}

	public void L839DDD()
	{
		A = [0x1A81];
		temp = A & 0x4000;

		if (Z == 1)
			return this.L839DF1();

		A &= 0xBFFF;
		[0x1A81] = A;
		X = 0x0000;
		this.L839F1E();
	}

	public void L839DF1()
	{
		A = [0x1A83];
		temp = A & 0x4000;

		if (Z == 1)
			return this.L839E05();

		A &= 0xBFFF;
		[0x1A83] = A;
		X = 0x0002;
		this.L839F1E();
	}

	public void L839E05()
	{
		A = [0x1A85];
		temp = A & 0x4000;

		if (Z == 1)
			return this.L839E19();

		A &= 0xBFFF;
		[0x1A85] = A;
		X = 0x0004;
		this.L839F1E();
	}

	public void L839E19()
	{
		A = [0x1A87];
		temp = A & 0x4000;

		if (Z == 1)
			return this.L839E2D();

		A &= 0xBFFF;
		[0x1A87] = A;
		X = 0x0006;
		this.L839F1E();
	}

	public void L839E2D()
	{
		A = [0x1A89];
		temp = A & 0x4000;

		if (Z == 1)
			return this.L839E41();

		A &= 0xBFFF;
		[0x1A89] = A;
		X = 0x0008;
		this.L839F1E();
	}

	public void L839E41()
	{
		A = [0x1A8B];
		temp = A & 0x4000;

		if (Z == 1)
			return this.L839E55();

		A &= 0xBFFF;
		[0x1A8B] = A;
		X = 0x000A;
		this.L839F1E();
	}

	public void L839E55()
	{
		A = [0x1A8D];
		temp = A & 0x4000;

		if (Z == 1)
			return this.L839E69();

		A &= 0xBFFF;
		[0x1A8D] = A;
		X = 0x000C;
		this.L839F1E();
	}

	public void L839E69()
	{
		A = [0x1A8F];
		temp = A & 0x4000;

		if (Z == 1)
			return this.L839E7D();

		A &= 0xBFFF;
		[0x1A8F] = A;
		X = 0x000E;
		this.L839F1E();
	}

	public void L839E7D()
	{
		A = [0x1A91];
		temp = A & 0x4000;

		if (Z == 1)
			return this.L839E91();

		A &= 0xBFFF;
		[0x1A91] = A;
		X = 0x0010;
		this.L839F1E();
	}

	public void L839E91()
	{
		A = [0x1A93];
		temp = A & 0x4000;

		if (Z == 1)
			return this.L839EA5();

		A &= 0xBFFF;
		[0x1A93] = A;
		X = 0x0012;
		this.L839F1E();
	}

	public void L839EA5()
	{
		A = [0x1A95];
		temp = A & 0x4000;

		if (Z == 1)
			return this.L839EB9();

		A &= 0xBFFF;
		[0x1A95] = A;
		X = 0x0014;
		this.L839F1E();
	}

	public void L839EB9()
	{
		A = [0x1A97];
		temp = A & 0x4000;

		if (Z == 1)
			return this.L839ECD();

		A &= 0xBFFF;
		[0x1A97] = A;
		X = 0x0016;
		this.L839F1E();
	}

	public void L839ECD()
	{
		A = [0x1A99];
		temp = A & 0x4000;

		if (Z == 1)
			return this.L839EE1();

		A &= 0xBFFF;
		[0x1A99] = A;
		X = 0x0018;
		this.L839F1E();
	}

	public void L839EE1()
	{
		A = [0x1A9B];
		temp = A & 0x4000;

		if (Z == 1)
			return this.L839EF5();

		A &= 0xBFFF;
		[0x1A9B] = A;
		X = 0x001A;
		this.L839F1E();
	}

	public void L839EF5()
	{
		A = [0x1A9D];
		temp = A & 0x4000;

		if (Z == 1)
			return this.L839F09();

		A &= 0xBFFF;
		[0x1A9D] = A;
		X = 0x001C;
		this.L839F1E();
	}

	public void L839F09()
	{
		A = [0x1A9F];
		temp = A & 0x4000;

		if (Z == 1)
			return this.L839F1D();

		A &= 0xBFFF;
		[0x1A9F] = A;
		X = 0x001E;
		this.L839F1E();
	}

	public void L839F1D()
	{
		return;
	}

	public void L839F1E()
	{
		A = [0x7E5C2C + X];
		[0xB0] = A;
		C = 0;
		A += 0x0020 + C;
		temp = A - 0x0140;

		if (C == 1)
			return this.L839F52();

		A = [0x7E5C4C + X];
		[0xB2] = A;
		C = 0;
		A += 0x0020 + C;
		temp = A - 0x00E8;

		if (C == 1)
			return this.L839F52();

		A = [0x7E5C6C + X];
		[0xB4] = A;
		A = [0x7E5C8C + X];
		[0xA8] = A;
		A = [0x7E5CAC + X];
		[0xAA] = A;
		this.L8280C2();
	}

	public void L839F52()
	{
		return;
	}









	// Bank 0x84

	// Bank 0x85
	public void R858000()
	{
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		C = 1;
		A = [0x7E5E2C];
		A -= [0x197C] - !C;
		[0x7E5E2C] = A;
		A = [0x7E5E2E];
		A -= [0x197E] - !C;
		[0x7E5E2E] = A;
		C = 1;
		A = [0x7E5E30];
		A -= [0x1988] - !C;
		[0x7E5E30] = A;
		A = [0x7E5E32];
		A -= [0x198A] - !C;
		[0x7E5E32] = A;
		A = [0x7E5E2E];
		temp = A - 0x8000;
		Cpu.ROR();
		[0x7E5E36] = A;
		temp = A - 0x8000;
		Cpu.ROR();
		[0x7E5E3E] = A;
		temp = A - 0x8000;
		Cpu.ROR();
		[0x7E5E46] = A;
		A = [0x7E5E32];
		temp = A - 0x8000;
		Cpu.ROR();
		[0x7E5E3A] = A;
		temp = A - 0x8000;
		Cpu.ROR();
		[0x7E5E42] = A;
		temp = A - 0x8000;
		Cpu.ROR();
		[0x7E5E4A] = A;
		A = 0x0000;
		[0xAA] = A;
		A = 0xFFFF;
		[0xA8] = A;
		A = [0x7E5E2E];
		[0x14] = A;
		A = [0x7E5E32];
		[0x16] = A;
		A = [0x14];
		C = 0;
		A += [0x8609] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;

		if (C == 1)
			return this.L858092();

		temp = A - 0x0114;

		if (C == 1)
			return this.L8580AD();

	}

	public void L858092()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x860B] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;

		if (C == 1)
			return this.L8580A7();

		temp = A - 0x00BC;

		if (C == 1)
			return this.L8580AD();

	}

	public void L8580A7()
	{
		[0xB2] = A;
		this.L858681();
	}

	public void L8580AD()
	{
		A = [0x14];
		C = 0;
		A += [0x860D] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;

		if (C == 1)
			return this.L8580C0();

		temp = A - 0x0114;

		if (C == 1)
			return this.L8580DB();

	}

	public void L8580C0()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x860F] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;

		if (C == 1)
			return this.L8580D5();

		temp = A - 0x00BC;

		if (C == 1)
			return this.L8580DB();

	}

	public void L8580D5()
	{
		[0xB2] = A;
		this.L858681();
	}

	public void L8580DB()
	{
		A = [0x7E5E36];
		[0x14] = A;
		A = [0x7E5E3A];
		[0x16] = A;
		A = [0x14];
		C = 0;
		A += [0x8611] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;

		if (C == 1)
			return this.L8580FA();

		temp = A - 0x0114;

		if (C == 1)
			return this.L858115();

	}

	public void L8580FA()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x8613] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;

		if (C == 1)
			return this.L85810F();

		temp = A - 0x00BC;

		if (C == 1)
			return this.L858115();

	}

	public void L85810F()
	{
		[0xB2] = A;
		this.L858751();
	}

	public void L858115()
	{
		A = [0x14];
		C = 0;
		A += [0x8615] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;

		if (C == 1)
			return this.L858128();

		temp = A - 0x0114;

		if (C == 1)
			return this.L858143();

	}

	public void L858128()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x8617] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;

		if (C == 1)
			return this.L85813D();

		temp = A - 0x00BC;

		if (C == 1)
			return this.L858143();

	}

	public void L85813D()
	{
		[0xB2] = A;
		this.L858751();
	}

	public void L858143()
	{
		A = [0x14];
		C = 0;
		A += [0x8619] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;

		if (C == 1)
			return this.L858156();

		temp = A - 0x0114;

		if (C == 1)
			return this.L858171();

	}

	public void L858156()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x861B] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;

		if (C == 1)
			return this.L85816B();

		temp = A - 0x00BC;

		if (C == 1)
			return this.L858171();

	}

	public void L85816B()
	{
		[0xB2] = A;
		this.L858751();
	}

	public void L858171()
	{
		A = [0x14];
		C = 0;
		A += [0x861D] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;

		if (C == 1)
			return this.L858184();

		temp = A - 0x0114;

		if (C == 1)
			return this.L85819F();

	}

	public void L858184()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x861F] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;

		if (C == 1)
			return this.L858199();

		temp = A - 0x00BC;

		if (C == 1)
			return this.L85819F();

	}

	public void L858199()
	{
		[0xB2] = A;
		this.L858751();
	}

	public void L85819F()
	{
		A = [0x7E5E3E];
		[0x14] = A;
		A = [0x7E5E42];
		[0x16] = A;
		A = [0x14];
		C = 0;
		A += [0x8621] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;

		if (C == 1)
			return this.L8581BE();

		temp = A - 0x0114;

		if (C == 1)
			return this.L8581D9();

	}

	public void L8581BE()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x8623] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;

		if (C == 1)
			return this.L8581D3();

		temp = A - 0x00BC;

		if (C == 1)
			return this.L8581D9();

	}

	public void L8581D3()
	{
		[0xB2] = A;
		this.L8587CB();
	}

	public void L8581D9()
	{
		A = [0x14];
		C = 0;
		A += [0x8625] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;

		if (C == 1)
			return this.L8581EC();

		temp = A - 0x0114;

		if (C == 1)
			return this.L858207();

	}

	public void L8581EC()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x8627] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;

		if (C == 1)
			return this.L858201();

		temp = A - 0x00BC;

		if (C == 1)
			return this.L858207();

	}

	public void L858201()
	{
		[0xB2] = A;
		this.L8587CB();
	}

	public void L858207()
	{
		A = [0x14];
		C = 0;
		A += [0x8629] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;

		if (C == 1)
			return this.L85821A();

		temp = A - 0x0114;

		if (C == 1)
			return this.L858235();

	}

	public void L85821A()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x862B] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;

		if (C == 1)
			return this.L85822F();

		temp = A - 0x00BC;

		if (C == 1)
			return this.L858235();

	}

	public void L85822F()
	{
		[0xB2] = A;
		this.L8587CB();
	}

	public void L858235()
	{
		A = [0x14];
		C = 0;
		A += [0x862D] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;

		if (C == 1)
			return this.L858248();

		temp = A - 0x0114;

		if (C == 1)
			return this.L858263();

	}

	public void L858248()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x862F] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;

		if (C == 1)
			return this.L85825D();

		temp = A - 0x00BC;

		if (C == 1)
			return this.L858263();

	}

	public void L85825D()
	{
		[0xB2] = A;
		this.L8587CB();
	}

	public void L858263()
	{
		A = [0x14];
		C = 0;
		A += [0x8631] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;

		if (C == 1)
			return this.L858276();

		temp = A - 0x0114;

		if (C == 1)
			return this.L858291();

	}

	public void L858276()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x8633] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;

		if (C == 1)
			return this.L85828B();

		temp = A - 0x00BC;

		if (C == 1)
			return this.L858291();

	}

	public void L85828B()
	{
		[0xB2] = A;
		this.L8587CB();
	}

	public void L858291()
	{
		A = [0x14];
		C = 0;
		A += [0x8635] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;

		if (C == 1)
			return this.L8582A4();

		temp = A - 0x0114;

		if (C == 1)
			return this.L8582BF();

	}

	public void L8582A4()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x8637] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;

		if (C == 1)
			return this.L8582B9();

		temp = A - 0x00BC;

		if (C == 1)
			return this.L8582BF();

	}

	public void L8582B9()
	{
		[0xB2] = A;
		this.L8587CB();
	}

	public void L8582BF()
	{
		A = [0x14];
		C = 0;
		A += [0x8639] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;

		if (C == 1)
			return this.L8582D2();

		temp = A - 0x0114;

		if (C == 1)
			return this.L8582ED();

	}

	public void L8582D2()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x863B] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;

		if (C == 1)
			return this.L8582E7();

		temp = A - 0x00BC;

		if (C == 1)
			return this.L8582ED();

	}

	public void L8582E7()
	{
		[0xB2] = A;
		this.L8587CB();
	}

	public void L8582ED()
	{
		A = [0x14];
		C = 0;
		A += [0x863D] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;

		if (C == 1)
			return this.L858300();

		temp = A - 0x0114;

		if (C == 1)
			return this.L85831B();

	}

	public void L858300()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x863F] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;

		if (C == 1)
			return this.L858315();

		temp = A - 0x00BC;

		if (C == 1)
			return this.L85831B();

	}

	public void L858315()
	{
		[0xB2] = A;
		this.L8587CB();
	}

	public void L85831B()
	{
		A = [0x7E5E46];
		[0x14] = A;
		A = [0x7E5E4A];
		[0x16] = A;
		A = [0x14];
		C = 0;
		A += [0x8641] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;

		if (C == 1)
			return this.L85833A();

		temp = A - 0x0114;

		if (C == 1)
			return this.L858355();

	}

	public void L85833A()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x8643] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;

		if (C == 1)
			return this.L85834F();

		temp = A - 0x00BC;

		if (C == 1)
			return this.L858355();

	}

	public void L85834F()
	{
		[0xB2] = A;
		this.L858816();
	}

	public void L858355()
	{
		A = [0x14];
		C = 0;
		A += [0x8645] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;

		if (C == 1)
			return this.L858368();

		temp = A - 0x0114;

		if (C == 1)
			return this.L858383();

	}

	public void L858368()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x8647] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;

		if (C == 1)
			return this.L85837D();

		temp = A - 0x00BC;

		if (C == 1)
			return this.L858383();

	}

	public void L85837D()
	{
		[0xB2] = A;
		this.L858816();
	}

	public void L858383()
	{
		A = [0x14];
		C = 0;
		A += [0x8649] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;

		if (C == 1)
			return this.L858396();

		temp = A - 0x0114;

		if (C == 1)
			return this.L8583B1();

	}

	public void L858396()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x864B] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;

		if (C == 1)
			return this.L8583AB();

		temp = A - 0x00BC;

		if (C == 1)
			return this.L8583B1();

	}

	public void L8583AB()
	{
		[0xB2] = A;
		this.L858816();
	}

	public void L8583B1()
	{
		A = [0x14];
		C = 0;
		A += [0x864D] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;

		if (C == 1)
			return this.L8583C4();

		temp = A - 0x0114;

		if (C == 1)
			return this.L8583DF();

	}

	public void L8583C4()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x864F] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;

		if (C == 1)
			return this.L8583D9();

		temp = A - 0x00BC;

		if (C == 1)
			return this.L8583DF();

	}

	public void L8583D9()
	{
		[0xB2] = A;
		this.L858816();
	}

	public void L8583DF()
	{
		A = [0x14];
		C = 0;
		A += [0x8651] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;

		if (C == 1)
			return this.L8583F2();

		temp = A - 0x0114;

		if (C == 1)
			return this.L85840D();

	}

	public void L8583F2()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x8653] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;

		if (C == 1)
			return this.L858407();

		temp = A - 0x00BC;

		if (C == 1)
			return this.L85840D();

	}

	public void L858407()
	{
		[0xB2] = A;
		this.L858816();
	}

	public void L85840D()
	{
		A = [0x14];
		C = 0;
		A += [0x8655] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;

		if (C == 1)
			return this.L858420();

		temp = A - 0x0114;

		if (C == 1)
			return this.L85843B();

	}

	public void L858420()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x8657] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;

		if (C == 1)
			return this.L858435();

		temp = A - 0x00BC;

		if (C == 1)
			return this.L85843B();

	}

	public void L858435()
	{
		[0xB2] = A;
		this.L858816();
	}

	public void L85843B()
	{
		A = [0x14];
		C = 0;
		A += [0x8659] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;

		if (C == 1)
			return this.L85844E();

		temp = A - 0x0114;

		if (C == 1)
			return this.L858469();

	}

	public void L85844E()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x865B] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;

		if (C == 1)
			return this.L858463();

		temp = A - 0x00BC;

		if (C == 1)
			return this.L858469();

	}

	public void L858463()
	{
		[0xB2] = A;
		this.L858816();
	}

	public void L858469()
	{
		A = [0x14];
		C = 0;
		A += [0x865D] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;

		if (C == 1)
			return this.L85847C();

		temp = A - 0x0114;

		if (C == 1)
			return this.L858497();

	}

	public void L85847C()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x865F] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;

		if (C == 1)
			return this.L858491();

		temp = A - 0x00BC;

		if (C == 1)
			return this.L858497();

	}

	public void L858491()
	{
		[0xB2] = A;
		this.L858816();
	}

	public void L858497()
	{
		A = [0x14];
		C = 0;
		A += [0x8661] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;

		if (C == 1)
			return this.L8584AA();

		temp = A - 0x0114;

		if (C == 1)
			return this.L8584C5();

	}

	public void L8584AA()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x8663] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;

		if (C == 1)
			return this.L8584BF();

		temp = A - 0x00BC;

		if (C == 1)
			return this.L8584C5();

	}

	public void L8584BF()
	{
		[0xB2] = A;
		this.L858816();
	}

	public void L8584C5()
	{
		A = [0x14];
		C = 0;
		A += [0x8665] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;

		if (C == 1)
			return this.L8584D8();

		temp = A - 0x0114;

		if (C == 1)
			return this.L8584F3();

	}

	public void L8584D8()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x8667] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;

		if (C == 1)
			return this.L8584ED();

		temp = A - 0x00BC;

		if (C == 1)
			return this.L8584F3();

	}

	public void L8584ED()
	{
		[0xB2] = A;
		this.L858816();
	}

	public void L8584F3()
	{
		A = [0x14];
		C = 0;
		A += [0x8669] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;

		if (C == 1)
			return this.L858506();

		temp = A - 0x0114;

		if (C == 1)
			return this.L858521();

	}

	public void L858506()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x866B] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;

		if (C == 1)
			return this.L85851B();

		temp = A - 0x00BC;

		if (C == 1)
			return this.L858521();

	}

	public void L85851B()
	{
		[0xB2] = A;
		this.L858816();
	}

	public void L858521()
	{
		A = [0x14];
		C = 0;
		A += [0x866D] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;

		if (C == 1)
			return this.L858534();

		temp = A - 0x0114;

		if (C == 1)
			return this.L85854F();

	}

	public void L858534()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x866F] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;

		if (C == 1)
			return this.L858549();

		temp = A - 0x00BC;

		if (C == 1)
			return this.L85854F();

	}

	public void L858549()
	{
		[0xB2] = A;
		this.L858816();
	}

	public void L85854F()
	{
		A = [0x14];
		C = 0;
		A += [0x8671] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;

		if (C == 1)
			return this.L858562();

		temp = A - 0x0114;

		if (C == 1)
			return this.L85857D();

	}

	public void L858562()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x8673] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;

		if (C == 1)
			return this.L858577();

		temp = A - 0x00BC;

		if (C == 1)
			return this.L85857D();

	}

	public void L858577()
	{
		[0xB2] = A;
		this.L858816();
	}

	public void L85857D()
	{
		A = [0x14];
		C = 0;
		A += [0x8675] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;

		if (C == 1)
			return this.L858590();

		temp = A - 0x0114;

		if (C == 1)
			return this.L8585AB();

	}

	public void L858590()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x8677] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;

		if (C == 1)
			return this.L8585A5();

		temp = A - 0x00BC;

		if (C == 1)
			return this.L8585AB();

	}

	public void L8585A5()
	{
		[0xB2] = A;
		this.L858816();
	}

	public void L8585AB()
	{
		A = [0x14];
		C = 0;
		A += [0x8679] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;

		if (C == 1)
			return this.L8585BE();

		temp = A - 0x0114;

		if (C == 1)
			return this.L8585D9();

	}

	public void L8585BE()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x867B] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;

		if (C == 1)
			return this.L8585D3();

		temp = A - 0x00BC;

		if (C == 1)
			return this.L8585D9();

	}

	public void L8585D3()
	{
		[0xB2] = A;
		this.L858816();
	}

	public void L8585D9()
	{
		A = [0x14];
		C = 0;
		A += [0x867D] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;

		if (C == 1)
			return this.L8585EC();

		temp = A - 0x0114;

		if (C == 1)
			return this.L858607();

	}

	public void L8585EC()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x867F] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;

		if (C == 1)
			return this.L858601();

		temp = A - 0x00BC;

		if (C == 1)
			return this.L858607();

	}

	public void L858601()
	{
		[0xB2] = A;
		this.L858816();
	}

	public void L858607()
	{
		B = Stack.Pop();
		return;
	}

	public void L858681()
	{
		Stack.Push(B);
		Stack.Push(P);
		P &= ~0x30;
		Y = [0xA6];
		temp = Y - 0x01F1;

		if (C == 0)
			return this.L85868F();

		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L85868F()
	{
		A = Y;
		C = 0;
		A += 0x0010 + C;
		[0xA6] = A;
		P |= 0x20;
		A = 0x82;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		A = [0xB0];
		[0x7800 + Y] = A;
		temp = A & 0x0100;

		if (Z == 1)
			return this.L8586B2();

		X = [0x82B6 + Y];
		A = [0x00 + X];
		A |= [0x82B8 + Y];
		[0x00 + X] = A;
	}

	public void L8586B2()
	{
		A = [0xB2];
		[0x7801 + Y] = A;
		A = 0x0EA6;
		[0x7802 + Y] = A;
		A = [0xB0];
		C = 0;
		A += 0x01F0 + C;
		[0x7804 + Y] = A;
		temp = A & 0x0100;

		if (Z == 1)
			return this.L8586D7();

		X = [0x82BA + Y];
		A = [0x00 + X];
		A |= [0x84BC + Y];
		[0x00 + X] = A;
		return this.L8586E1();
	}

	public void L8586D7()
	{
		X = [0x82BA + Y];
		A = [0x00 + X];
		A |= [0x84BA + Y];
		[0x00 + X] = A;
	}

	public void L8586E1()
	{
		A = [0xB2];
		[0x7805 + Y] = A;
		A = 0x0EA4;
		[0x7806 + Y] = A;
		A = [0xB0];
		[0x7808 + Y] = A;
		temp = A & 0x0100;

		if (Z == 1)
			return this.L858702();

		X = [0x82BE + Y];
		A = [0x00 + X];
		A |= [0x84C0 + Y];
		[0x00 + X] = A;
		return this.L85870C();
	}

	public void L858702()
	{
		X = [0x82BE + Y];
		A = [0x00 + X];
		A |= [0x84BE + Y];
		[0x00 + X] = A;
	}

	public void L85870C()
	{
		A = [0xB2];
		C = 0;
		A += 0x01F0 + C;
		[0x7809 + Y] = A;
		A = 0x0E86;
		[0x780A + Y] = A;
		A = [0xB0];
		C = 0;
		A += 0x01F0 + C;
		[0x780C + Y] = A;
		temp = A & 0x0100;

		if (Z == 1)
			return this.L858735();

		X = [0x82C2 + Y];
		A = [0x00 + X];
		A |= [0x84C4 + Y];
		[0x00 + X] = A;
		return this.L85873F();
	}

	public void L858735()
	{
		X = [0x82C2 + Y];
		A = [0x00 + X];
		A |= [0x84C2 + Y];
		[0x00 + X] = A;
	}

	public void L85873F()
	{
		A = [0xB2];
		C = 0;
		A += 0x01F0 + C;
		[0x780D + Y] = A;
		A = 0x0E84;
		[0x780E + Y] = A;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L858751()
	{
		Stack.Push(B);
		Stack.Push(P);
		P &= ~0x30;
		Y = [0xA6];
		temp = Y - 0x01F9;

		if (C == 0)
			return this.L85875F();

		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L85875F()
	{
		A = Y;
		C = 0;
		A += 0x0008 + C;
		[0xA6] = A;
		P |= 0x20;
		A = 0x82;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		A = [0xB0];
		[0x7800 + Y] = A;
		temp = A & 0x0100;

		if (Z == 1)
			return this.L858784();

		X = [0x82B6 + Y];
		A = [0x00 + X];
		A |= [0x84B8 + Y];
		[0x00 + X] = A;
		return this.L85878E();
	}

	public void L858784()
	{
		X = [0x82B6 + Y];
		A = [0x00 + X];
		A |= [0x84B6 + Y];
		[0x00 + X] = A;
	}

	public void L85878E()
	{
		A = [0xB2];
		[0x7801 + Y] = A;
		A = 0x0EA8;
		[0x7802 + Y] = A;
		A = [0xB0];
		[0x7804 + Y] = A;
		temp = A & 0x0100;

		if (Z == 1)
			return this.L8587AF();

		X = [0x82BA + Y];
		A = [0x00 + X];
		A |= [0x84BC + Y];
		[0x00 + X] = A;
		return this.L8587B9();
	}

	public void L8587AF()
	{
		X = [0x82BA + Y];
		A = [0x00 + X];
		A |= [0x84BA + Y];
		[0x00 + X] = A;
	}

	public void L8587B9()
	{
		A = [0xB2];
		C = 0;
		A += 0x01F0 + C;
		[0x7805 + Y] = A;
		A = 0x0E88;
		[0x7806 + Y] = A;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L8587CB()
	{
		Stack.Push(B);
		Stack.Push(P);
		P &= ~0x30;
		Y = [0xA6];
		temp = Y - 0x01FD;

		if (C == 0)
			return this.L8587D9();

		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L8587D9()
	{
		A = Y;
		C = 0;
		A += 0x0004 + C;
		[0xA6] = A;
		P |= 0x20;
		A = 0x82;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		A = [0xB0];
		[0x7800 + Y] = A;
		temp = A & 0x0100;

		if (Z == 1)
			return this.L8587FE();

		X = [0x82B6 + Y];
		A = [0x00 + X];
		A |= [0x84B8 + Y];
		[0x00 + X] = A;
		return this.L858808();
	}

	public void L8587FE()
	{
		X = [0x82B6 + Y];
		A = [0x00 + X];
		A |= [0x84B6 + Y];
		[0x00 + X] = A;
	}

	public void L858808()
	{
		A = [0xB2];
		[0x7801 + Y] = A;
		A = 0x0E8A;
		[0x7802 + Y] = A;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L858816()
	{
		Stack.Push(B);
		Stack.Push(P);
		P &= ~0x30;
		Y = [0xA6];
		temp = Y - 0x01FD;

		if (C == 0)
			return this.L858824();

		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L858824()
	{
		A = Y;
		C = 0;
		A += 0x0004 + C;
		[0xA6] = A;
		P |= 0x20;
		A = 0x82;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		A = [0xB0];
		[0x7800 + Y] = A;
		temp = A & 0x0100;

		if (Z == 1)
			return this.L858847();

		X = [0x82B6 + Y];
		A = [0x00 + X];
		A |= [0x82B8 + Y];
		[0x00 + X] = A;
	}

	public void L858847()
	{
		A = [0xB2];
		[0x7801 + Y] = A;
		A = 0x0E8C;
		[0x7802 + Y] = A;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L86CA27()
	{
		A = 0x0080;
		[0xB0] = A;
		A = [0x014C];
		A ^= 0xFFFF;
		A++;
		A &= 0x00FF;
		A <<= 1;
		A <<= 1;
		A <<= 1;
		[0xB2] = A;
		A = [0x7FB3EF];

		if (N == 1)
			return this.L86CA69();

		temp = A - 0x01E0;

		if (C == 0)
			return this.L86CA4B();

		A = 0x00C9;
		return this.L86CA6C();
	}

	public void L86CA4B()
	{
		temp = A - 0x0168;

		if (C == 0)
			return this.L86CA55();

		A = 0x00C8;
		return this.L86CA6C();
	}

	public void L86CA55()
	{
		temp = A - 0x00F0;

		if (C == 0)
			return this.L86CA5F();

		A = 0x00C7;
		return this.L86CA6C();
	}

	public void L86CA5F()
	{
		temp = A - 0x0078;

		if (C == 0)
			return this.L86CA69();

		A = 0x00C6;
		return this.L86CA6C();
	}

	public void L86CA69()
	{
		A = 0x00C0;
	}

	public void L86CA6C()
	{
		[0xB4] = A;
		A = 0xCFFF;
		[0xA8] = A;
		A = 0x2000;
		[0xAA] = A;
		this.L8286B6();
	}

	public void L86CA7C()
	{
		return;
	}

	public void L86CA88()
	{
		A = 0x0080;
		[0xB0] = A;
		A = [0x014C];
		A ^= 0xFFFF;
		A++;
		A &= 0x00FF;
		A <<= 1;
		A <<= 1;
		[0x26] = A;
		A <<= 1;
		C = 0;
		A += [0x26] + C;
		[0xB2] = A;
		A = [0x7FB3EF];

		if (N == 1)
			return this.L86CAD6();

		temp = A - 0x01E0;

		if (C == 0)
			return this.L86CAB1();

		A = 0x00C5;
		return this.L86CAD9();
	}

	public void L86CAB1()
	{
		temp = A - 0x0168;

		if (C == 0)
			return this.L86CABB();

		A = 0x00C4;
		return this.L86CAD9();
	}

	public void L86CABB()
	{
		temp = A - 0x00F0;

		if (C == 0)
			return this.L86CAC5();

		A = 0x00C3;
		return this.L86CAD9();
	}

	public void L86CAC5()
	{
		temp = A - 0x0078;

		if (C == 0)
			return this.L86CACF();

		A = 0x00C2;
		return this.L86CAD9();
	}

	public void L86CACF()
	{

		if (N == 1)
			return this.L86CAD6();

		A = 0x00C1;
		return this.L86CAD9();
	}

	public void L86CAD6()
	{
		A = 0x00BF;
	}

	public void L86CAD9()
	{
		[0xB4] = A;
		A = 0xCFFF;
		[0xA8] = A;
		A = 0x2000;
		[0xAA] = A;
		this.L8286B6();
	}

	public void L86CAE9()
	{
		return;
	}







	public void R809FDF()
	{
		Stack.Push(P);
		P &= ~0x30;
		A = [0x14CE];

		if (Z == 1)
			return this.L80A003_Done();

		A = [0x0265];
		temp = A & 0x1000;

		if (Z == 1)
			return this.L80A003_Done();

		A = [0x14CC];

		if (Z == 0)
			return this.L80A003_Done();

		[0x0265] = 0;
		A = [0x026D];
		[0x14CA] = A;
		A = 0x001B;
		[0x026D] = A;
	}

	public void L80A003_Done()
	{
		P = Stack.Pop();
		return;
	}








	public void R80A005()
	{
		A = [0x58];
		temp = A & 0x1000;

		if (Z == 0)
			return this.L80A00F();

		return this.L80A093_Done();
	}

	public void L80A00F()
	{
		A = [0x026D];
		temp = A - 0x001A;

		if (Z == 0)
			return this.L80A020_Done();

		A = [0x0371];
		A--;

		if (Z == 1)
			return this.L80A022();

		A--;

		if (Z == 1)
			return this.L80A022();

	}

	public void L80A020_Done()
	{
		return this.L80A093_Done();
	}

	public void L80A022()
	{
		P |= 0x20;
		A = [0x4A];
		Stack.Push(A);
		P &= ~0x20;
		this.R808202_WaitFor014BFlag1();
		P |= 0x20;
		A = Stack.Pop();
		[0x4A] = A;
		P &= ~0x20;
		A = [0x026D];
		temp = A - 0x001A;

		if (Z == 0)
			return this.L80A05C();

		this.R909993_ResetRam();
		this.R80A094_ResetRam();
		A = 0x8000;
		[0x01] = A;
		A = 0xA053;
		[0x00] = A;
		this.R8087A4_LoadDmaTransferRecord();
		return this.L80A05C();
	}

	public byte[] DmaTransferRecord80A053 = new byte[]
	{
		// Type 0x02, RAM Address 0x7E3000, Length 0x0780, VRAM Control 0x80, VRAM Address 0x1000
		0x02, 0x00, 0x30, 0x7E, 0x80, 0x07, 0x80, 0x00, 0x10
	}

	public void L80A05C()
	{
		P |= 0x20;
		A = [0x4A];
		Stack.Push(A);
		P &= ~0x20;
		this.R808202_WaitFor014BFlag1();
		P |= 0x20;
		A = Stack.Pop();
		[0x4A] = A;
		P &= ~0x20;
		A = [0x58];
		temp = A & 0x1000;

		if (Z == 0)
			return this.L80A07E();

		A = [0x5A];
		temp = A & 0x1000;

		if (Z == 0)
			return this.L80A07E();

		return this.L80A05C();
	}

	public void L80A07E()
	{
		this.R80A0C6_ResetRam();
		P |= 0x20;
		A = [0x4A];
		Stack.Push(A);
		P &= ~0x20;
		this.R808202_WaitFor014BFlag1();
		P |= 0x20;
		A = Stack.Pop();
		[0x4A] = A;
		P &= ~0x20;
	}

	public void L80A093_Done()
	{
		return;
	}








	public void R80A094_ResetRam()
	{
		A = 0x2199;
		[0x7E3318] = A;
		A = 0x2194;
		[0x7E331A] = A;
		A = 0x2195;
		[0x7E331C] = A;
		A = 0x2196;
		[0x7E331E] = A;
		A = 0x2197;
		[0x7E3320] = A;
		A = 0x2198;
		[0x7E3322] = A;
		A = 0x2199;
		[0x7E3324] = A;
		return;
	}








	public void R80A0C6_ResetRam()
	{
		A = 0x0080;
		[0x7E3318] = A;
		[0x7E331A] = A;
		[0x7E331C] = A;
		[0x7E331E] = A;
		[0x7E3320] = A;
		[0x7E3322] = A;
		[0x7E3324] = A;
		return;
	}








	public void L80A0E6()
	{
		[0x026D]++;
		return this.L81E739();
	}









	public void R80A1E2()
	{
		P &= ~0x30;
		A = 0x0000;
		[0x0B36] = A;
		A = 0x0000;
		[0x0B38] = A;
		A = 0x0000;
		[0x0B3A] = A;
		A = 0x0000;
		[0x14D6] = A;
		A = 0x0000;
		[0x0381] = A;
		A = 0x0001;
		[0x7E3983] = A;
		A = 0x0000;
		[0x7E3985] = A;
		A = 0x0000;
		[0x7E5BF3] = A;
		[0x1B0E] = A;
		A = 0xFFDD;
		[0x025D] = A;
		A = 0xFFE4;
		[0x025F] = A;
		A = 0x0000;
		[0x150C] = A;
		A = 0x0002;
		[0x4E] = A;
		A = 0x001B;
		[0x4C] = A;
		return;
	}








		public void L80CC06()
	{
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x117C];
		
		if (N == 1)
			return this.L80CC14();

		Y = 0x0000;
		this.L80CE15();
	}

	public void L80CC14()
	{
		A = [0x117E];
		
		if (N == 1)
			return this.L80CC1F();

		Y = 0x0002;
		this.L80CE15();
	}

	public void L80CC1F()
	{
		A = [0x1180];
		
		if (N == 1)
			return this.L80CC2A();

		Y = 0x0004;
		this.L80CE15();
	}

	public void L80CC2A()
	{
		A = [0x1182];
		
		if (N == 1)
			return this.L80CC35();

		Y = 0x0006;
		this.L80CE15();
	}

	public void L80CC35()
	{
		A = [0x1184];
		
		if (N == 1)
			return this.L80CC40();

		Y = 0x0008;
		this.L80CE15();
	}

	public void L80CC40()
	{
		A = [0x1186];
		
		if (N == 1)
			return this.L80CC4B();

		Y = 0x000A;
		this.L80CE15();
	}

	public void L80CC4B()
	{
		A = [0x1188];
		
		if (N == 1)
			return this.L80CC56();

		Y = 0x000C;
		this.L80CE15();
	}

	public void L80CC56()
	{
		A = [0x118A];
		
		if (N == 1)
			return this.L80CC61();

		Y = 0x000E;
		this.L80CE15();
	}

	public void L80CC61()
	{
		A = [0x118C];
		
		if (N == 1)
			return this.L80CC6C();

		Y = 0x0010;
		this.L80CE15();
	}

	public void L80CC6C()
	{
		A = [0x118E];
		
		if (N == 1)
			return this.L80CC77();

		Y = 0x0012;
		this.L80CE15();
	}

	public void L80CC77()
	{
		A = [0x1190];
		
		if (N == 1)
			return this.L80CC82();

		Y = 0x0014;
		this.L80CE15();
	}

	public void L80CC82()
	{
		A = [0x1192];
		
		if (N == 1)
			return this.L80CC8D();

		Y = 0x0016;
		this.L80CE15();
	}

	public void L80CC8D()
	{
		A = [0x1194];
		
		if (N == 1)
			return this.L80CC98();

		Y = 0x0018;
		this.L80CE15();
	}

	public void L80CC98()
	{
		A = [0x1196];
		
		if (N == 1)
			return this.L80CCA3();

		Y = 0x001A;
		this.L80CE15();
	}

	public void L80CCA3()
	{
		A = [0x1198];
		
		if (N == 1)
			return this.L80CCAE();

		Y = 0x001C;
		this.L80CE15();
	}

	public void L80CCAE()
	{
		A = [0x119A];
		
		if (N == 1)
			return this.L80CCB9();

		Y = 0x001E;
		this.L80CE15();
	}

	public void L80CCB9()
	{
		A = [0x119C];
		
		if (N == 1)
			return this.L80CCC4();

		Y = 0x0020;
		this.L80CE15();
	}

	public void L80CCC4()
	{
		A = [0x119E];
		
		if (N == 1)
			return this.L80CCCF();

		Y = 0x0022;
		this.L80CE15();
	}

	public void L80CCCF()
	{
		A = [0x11A0];
		
		if (N == 1)
			return this.L80CCDA();

		Y = 0x0024;
		this.L80CE15();
	}

	public void L80CCDA()
	{
		A = [0x11A2];
		
		if (N == 1)
			return this.L80CCE5();

		Y = 0x0026;
		this.L80CE15();
	}

	public void L80CCE5()
	{
		A = [0x11A4];
		
		if (N == 1)
			return this.L80CCF0();

		Y = 0x0028;
		this.L80CE15();
	}

	public void L80CCF0()
	{
		A = [0x11A6];
		
		if (N == 1)
			return this.L80CCFB();

		Y = 0x002A;
		this.L80CE15();
	}

	public void L80CCFB()
	{
		A = [0x11A8];
		
		if (N == 1)
			return this.L80CD06();

		Y = 0x002C;
		this.L80CE15();
	}

	public void L80CD06()
	{
		A = [0x11AA];
		
		if (N == 1)
			return this.L80CD11();

		Y = 0x002E;
		this.L80CE15();
	}

	public void L80CD11()
	{
		A = [0x11AC];
		
		if (N == 1)
			return this.L80CD1C();

		Y = 0x0030;
		this.L80CE15();
	}

	public void L80CD1C()
	{
		A = [0x11AE];
		
		if (N == 1)
			return this.L80CD27();

		Y = 0x0032;
		this.L80CE15();
	}

	public void L80CD27()
	{
		A = [0x11B0];
		
		if (N == 1)
			return this.L80CD32();

		Y = 0x0034;
		this.L80CE15();
	}

	public void L80CD32()
	{
		A = [0x11B2];
		
		if (N == 1)
			return this.L80CD3D();

		Y = 0x0036;
		this.L80CE15();
	}

	public void L80CD3D()
	{
		A = [0x11B4];
		
		if (N == 1)
			return this.L80CD48();

		Y = 0x0038;
		this.L80CE15();
	}

	public void L80CD48()
	{
		A = [0x11B6];
		
		if (N == 1)
			return this.L80CD53();

		Y = 0x003A;
		this.L80CE15();
	}

	public void L80CD53()
	{
		A = [0x11B8];
		
		if (N == 1)
			return this.L80CD5E();

		Y = 0x003C;
		this.L80CE15();
	}

	public void L80CD5E()
	{
		A = [0x11BA];
		
		if (N == 1)
			return this.L80CD69();

		Y = 0x003E;
		this.L80CE15();
	}

	public void L80CD69()
	{
		A = [0x11BC];
		
		if (N == 1)
			return this.L80CD74();

		Y = 0x0040;
		this.L80CE15();
	}

	public void L80CD74()
	{
		A = [0x11BE];
		
		if (N == 1)
			return this.L80CD7F();

		Y = 0x0042;
		this.L80CE15();
	}

	public void L80CD7F()
	{
		A = [0x11C0];
		
		if (N == 1)
			return this.L80CD8A();

		Y = 0x0044;
		this.L80CE15();
	}

	public void L80CD8A()
	{
		A = [0x11C2];
		
		if (N == 1)
			return this.L80CD95();

		Y = 0x0046;
		this.L80CE15();
	}

	public void L80CD95()
	{
		A = [0x11C4];
		
		if (N == 1)
			return this.L80CDA0();

		Y = 0x0048;
		this.L80CE15();
	}

	public void L80CDA0()
	{
		A = [0x11C6];
		
		if (N == 1)
			return this.L80CDAB();

		Y = 0x004A;
		this.L80CE15();
	}

	public void L80CDAB()
	{
		A = [0x11C8];
		
		if (N == 1)
			return this.L80CDB6();

		Y = 0x004C;
		this.L80CE15();
	}

	public void L80CDB6()
	{
		A = [0x11CA];
		
		if (N == 1)
			return this.L80CDC1();

		Y = 0x004E;
		this.L80CE15();
	}

	public void L80CDC1()
	{
		A = [0x11CC];
		
		if (N == 1)
			return this.L80CDCC();

		Y = 0x0050;
		this.L80CE15();
	}

	public void L80CDCC()
	{
		A = [0x11CE];
		
		if (N == 1)
			return this.L80CDD7();

		Y = 0x0052;
		this.L80CE15();
	}

	public void L80CDD7()
	{
		A = [0x11D0];
		
		if (N == 1)
			return this.L80CDE2();

		Y = 0x0054;
		this.L80CE15();
	}

	public void L80CDE2()
	{
		B = Stack.Pop();
		return;
	}








	public void R80CDE4()
	{
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x11D2];
		
		if (N == 1)
			return this.L80CDF2();

		Y = 0x0056;
		this.L80CE15();
	}

	public void L80CDF2()
	{
		A = [0x11D4];
		
		if (N == 1)
			return this.L80CDFD();

		Y = 0x0058;
		this.L80CE15();
	}

	public void L80CDFD()
	{
		A = [0x11D6];
		
		if (N == 1)
			return this.L80CE08();

		Y = 0x005A;
		this.L80CE15();
	}

	public void L80CE08()
	{
		A = [0x11D8];
		
		if (N == 1)
			return this.L80CE13();

		Y = 0x005C;
		this.L80CE15();
	}

	public void L80CE13()
	{
		B = Stack.Pop();
		return;
	}

	public void L80CE15()
	{
		Stack.Push(B);
		this.R80CE1C();
		B = Stack.Pop();
		return;
	}








	public void R80CE1C()
	{
		A = [0x117C + Y];
		A <<= 1;
		C = 0;
		A += [0x117C + Y] + C;
		X = A;
		A = [0xCE86 + X];
		[0x00] = A;
		P |= 0x20;
		A = [0xCE88 + X];
		[0x02] = A;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		return [[0x0000]]();	//24-Bit Address
	}







	// Bank 0x82
	public void R828000()
	{
		Stack.Push(P);
		P &= ~0x30;
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0xB4];
		A <<= 1;
		X = A;
		A = [0x8A2A + X];
		C = 0;
		A += 0x8A2A + C;
		Y = A;
		A = [0x0000 + Y];
		
		if (N == 0)
			return this.L82802A();

		A = 0x8200;
		[0x01] = A;
		Y++;
		Y++;
		[0x00] = Y;
		this.L828027();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L828027()
	{
		return [[0x0000]]();	//24-Bit Address
	}

	public void L82802A()
	{
		[0xA1] = A;
		A = [0xA6];
		A >>= 1;
		A >>= 1;
		[0x9E] = A;
		temp = A - 0x0080;
		
		if (C == 1)
			return this.L828054();

		C = 0;
		A += [0xA1] + C;
		temp = A - 0x0080;
		
		if (C == 1)
			return this.L828045();

		A <<= 1;
		A <<= 1;
		[0xA6] = A;
		return this.L828057();
	}

	public void L828045()
	{
		A = 0x0080;
		C = 1;
		A -= [0x9E] - !C;
		[0xA1] = A;
		A = 0x0200;
		[0xA6] = A;
		return this.L828057();
	}

	public void L828054()
	{
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L828057()
	{
		A = [0x9E];
		A <<= 1;
		A <<= 1;
		X = A;
		Y++;
		Y++;
	}

	public void L82805E()
	{
		A = [0x0000 + Y];
		
		if (N == 1)
			return this.L82807C();

		C = 0;
		A += [0xB0] + C;
		[0x7800 + X] = A;
		temp = A & 0x0100;
		
		if (Z == 1)
			return this.L8280A1();

		A = [0x82B6 + X];
		[0x9E] = A;
		A = [(0x9E)];
		A |= [0x82B8 + X];
		[(0x9E)] = A;
		return this.L8280A1();
	}

	public void L82807C()
	{
		C = 0;
		A += [0xB0] + C;
		[0x7800 + X] = A;
		temp = A & 0x0100;
		
		if (Z == 1)
			return this.L828095();

		A = [0x82B6 + X];
		[0x9E] = A;
		A = [(0x9E)];
		A |= [0x84B8 + X];
		[(0x9E)] = A;
		return this.L8280A1();
	}

	public void L828095()
	{
		A = [0x82B6 + X];
		[0x9E] = A;
		A = [(0x9E)];
		A |= [0x84B6 + X];
		[(0x9E)] = A;
	}

	public void L8280A1()
	{
		A = [0x0002 + Y];
		C = 0;
		A += [0xB2] + C;
		[0x7801 + X] = A;
		A = [0x0003 + Y];
		[0x7802 + X] = A;
		Y++;
		Y++;
		Y++;
		Y++;
		Y++;
		X++;
		X++;
		X++;
		X++;
		[0xA1]--;
		
		if (Z == 0)
			return this.L82805E();

		[0xA6] = X;
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void R8280C2()
	{
		Stack.Push(P);
		P &= ~0x30;
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0xB4];
		A <<= 1;
		X = A;
		A = [0x8A2A + X];
		C = 0;
		A += 0x8A2A + C;
		Y = A;
		A = [0x0000 + Y];
		
		if (N == 0)
			return this.L8280EC();

		A = 0x8200;
		[0x01] = A;
		Y++;
		Y++;
		[0x00] = Y;
		this.R8280E9();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void R8280E9()
	{
		return [[0x0000]]();	//24-Bit Address
	}

	public void L8280EC()
	{
		[0xA1] = A;
		A = [0xA6];
		A >>= 1;
		A >>= 1;
		[0x9E] = A;
		temp = A - 0x0080;
		
		if (C == 1)
			return this.L828116();

		C = 0;
		A += [0xA1] + C;
		temp = A - 0x0080;
		
		if (C == 1)
			return this.L828107();

		A <<= 1;
		A <<= 1;
		[0xA6] = A;
		return this.L828119();
	}

	public void L828107()
	{
		A = 0x0080;
		C = 1;
		A -= [0x9E] - !C;
		[0xA1] = A;
		A = 0x0200;
		[0xA6] = A;
		return this.L828119();
	}

	public void L828116()
	{
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L828119()
	{
		A = [0x7FF6];
		A &= 0xFF00;
		A |= [0x9E];
		X = A;
		Y++;
		Y++;
	}

	public void L828124()
	{
		[0x7FF6] = X;
		A = [0x0000 + Y];
		
		if (N == 0)
			return this.L82813A();

		C = 0;
		A += [0xB0] + C;
		[0x7FF0] = A;
		A |= 0x0200;
		[0x7FF3] = A;
		return this.L828146();
	}

	public void L82813A()
	{
		C = 0;
		A += [0xB0] + C;
		[0x7FF0] = A;
		A &= 0xFDFF;
		[0x7FF3] = A;
	}

	public void L828146()
	{
		C = 0;
		A = [0x0002 + Y];
		A += [0xB2] + C;
		[0x7FF1] = A;
		A = [0x0003 + Y];
		A &= [0xA8];
		A |= [0xAA];
		[0x7FF2] = A;
		C = 0;
		A = Y;
		A += 0x0005 + C;
		Y = A;
		X++;
		[0xA1]--;
		
		if (Z == 0)
			return this.L828124();

		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}






	// Bank 0x83
	public void L838000()
	{
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x19EB];
		temp = A & 0x2000;

		if (Z == 1)
			return this.L83800E();

		return this.L83813E();
	}

	public void L83800E()
	{
		A = [0x19EB];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L838021();

		temp = A & 0x4000;

		if (Z == 0)
			return this.L838021();

		Y = 0x0000;
		this.L838160();
	}

	public void L838021()
	{
		A = [0x19ED];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L838034();

		temp = A & 0x4000;

		if (Z == 0)
			return this.L838034();

		Y = 0x0001;
		this.L838160();
	}

	public void L838034()
	{
		A = [0x19EF];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L838047();

		temp = A & 0x4000;

		if (Z == 0)
			return this.L838047();

		Y = 0x0002;
		this.L838160();
	}

	public void L838047()
	{
		A = [0x19F1];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L83805A();

		temp = A & 0x4000;

		if (Z == 0)
			return this.L83805A();

		Y = 0x0003;
		this.L838160();
	}

	public void L83805A()
	{
		A = [0x19F3];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L83806D();

		temp = A & 0x4000;

		if (Z == 0)
			return this.L83806D();

		Y = 0x0004;
		this.L838160();
	}

	public void L83806D()
	{
		A = [0x19F5];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L838080();

		temp = A & 0x4000;

		if (Z == 0)
			return this.L838080();

		Y = 0x0005;
		this.L838160();
	}

	public void L838080()
	{
		A = [0x19F7];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L838093();

		temp = A & 0x4000;

		if (Z == 0)
			return this.L838093();

		Y = 0x0006;
		this.L838160();
	}

	public void L838093()
	{
		A = [0x19F9];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L8380A6();

		temp = A & 0x4000;

		if (Z == 0)
			return this.L8380A6();

		Y = 0x0007;
		this.L838160();
	}

	public void L8380A6()
	{
		A = [0x19FB];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L8380B9();

		temp = A & 0x4000;

		if (Z == 0)
			return this.L8380B9();

		Y = 0x0008;
		this.L838160();
	}

	public void L8380B9()
	{
		A = [0x19FD];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L8380CC();

		temp = A & 0x4000;

		if (Z == 0)
			return this.L8380CC();

		Y = 0x0009;
		this.L838160();
	}

	public void L8380CC()
	{
		A = [0x19FF];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L8380DF();

		temp = A & 0x4000;

		if (Z == 0)
			return this.L8380DF();

		Y = 0x000A;
		this.L838160();
	}

	public void L8380DF()
	{
		A = [0x1A01];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L8380F2();

		temp = A & 0x4000;

		if (Z == 0)
			return this.L8380F2();

		Y = 0x000B;
		this.L838160();
	}

	public void L8380F2()
	{
		A = [0x1A03];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L838105();

		temp = A & 0x4000;

		if (Z == 0)
			return this.L838105();

		Y = 0x000C;
		this.L838160();
	}

	public void L838105()
	{
		A = [0x1A05];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L838118();

		temp = A & 0x4000;

		if (Z == 0)
			return this.L838118();

		Y = 0x000D;
		this.L838160();
	}

	public void L838118()
	{
		A = [0x1A07];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L83812B();

		temp = A & 0x4000;

		if (Z == 0)
			return this.L83812B();

		Y = 0x000E;
		this.L838160();
	}

	public void L83812B()
	{
		A = [0x1A09];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L83813E();

		temp = A & 0x4000;

		if (Z == 0)
			return this.L83813E();

		Y = 0x000F;
		this.L838160();
	}

	public void L83813E()
	{
		B = Stack.Pop();
		return;
	}

	public void L838160()
	{
		[0x1A7B] = Y;
		A = [0x8140 + Y];
		A &= 0x00FF;
		[0x1A7D] = A;
		A = [0x8150 + Y];
		A &= 0x00FF;
		[0x1A7F] = A;
		A = [0x19DB + Y];
		A &= 0x00FF;

		if (Z == 0)
			return this.L8381CB();

		X = [0x1A7F];
		A = [0x19AC + X];
		[0x9C] = A;
		A = [0x19AB + X];
		[0x9B] = A;
	}

	public void L83818A()
	{
		A = [[0x9B]];
		A &= 0x00FF;
		temp = A & 0x0080;

		if (Z == 0)
			return this.L838199();

		this.L838442();
		return this.L8381A8();
	}

	public void L838199()
	{
		A ^= 0x00FF;
		temp = A - 0x0039;

		if (C == 0)
			return this.L8381A3();

	}

	public void L8381A1()
	{
		return this.L8381A1();
	}

	public void L8381A3()
	{
		A <<= 1;
		X = A;
		Cpu.JSR((0x81D6 + X));
	}

	public void L8381A8()
	{
		X = [0x1A7D];
		A = [0x19EB + X];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L8381D5();

		Y = [0x1A7B];
		A = [0x19DB + Y];
		A &= 0x00FF;

		if (Z == 1)
			return this.L83818A();

		X = [0x1A7F];
		A = [0x9C];
		[0x19AC + X] = A;
		A = [0x9B];
		[0x19AB + X] = A;
	}

	public void L8381CB()
	{
		X = [0x1A7B];
		P |= 0x20;
		[0x19DB + X]--;
		P &= ~0x20;
	}

	public void L8381D5()
	{
		return;
	}

	public void L838442()
	{
		X = [0x1A7F];
		A = [0x1A1B + X];
		[0x8F] = A;
		A = [0x1A1C + X];
		[0x90] = A;
		A = [[0x9B]];
		A &= 0x00FF;
		[[]] = A;
		[0xAE9BE6] = A;
		Cpu.TDC();
		A++;
		P |= 0x20;
		A = [[0x9B]];
		[0x19DB + X] = A;
		P &= ~0x20;
		[0x9B]++;
		return;
	}

	public void L838EE1()
	{
		A = [0x150C];
		temp = A & 0x4000;

		if (Z == 0)
			return this.L838EFF();

		A = [0x197A];
		[0x12] = A;
		A = 0x0000;
		[0x14] = A;
		A = [0x1986];
		[0x16] = A;
		A = 0x0000;
		[0x18] = A;
		return this.L838F15();
	}

	public void L838EFF()
	{
		A = [0x14DC];
		[0x12] = A;
		A = 0xFFD8;
		[0x14] = A;
		A = [0x14EA];
		[0x16] = A;
		A = 0xFFE8;
		[0x18] = A;
		return this.L838F15();
	}

	public void L838F15()
	{
		A = [0x14DC];
		C = 1;
		A -= [0x12] - !C;
		[0x7E5BC3] = A;
		C = 0;
		A += 0x0080 + C;
		C = 0;
		A += [0x14] + C;
		C = 0;
		A += [0x14F6] + C;
		[0x14D8] = A;
		A = [0x14EA];
		C = 1;
		A -= [0x16] - !C;
		[0x7E5BC5] = A;
		C = 0;
		A += [0x1500] + C;
		C = 0;
		A += [0x1508] + C;
		C = 0;
		A += [0x150A] + C;
		C = 0;
		A += [0x18] + C;
		C = 0;
		A += [0x14F8] + C;
		[0x14E6] = A;
		A = [0x7E5BC3];
		C = 0;
		A += [0x7E5BCB] + C;
		[0x7E5BC3] = A;
		A = [0x7E5BC5];
		C = 0;
		A += [0x7E5BCD] + C;
		[0x7E5BC5] = A;
		A = [0x14D8];
		[0x1502] = A;
		A = [0x1500];
		C = 1;
		A -= [0x16] - !C;
		C = 0;
		A += [0x1506] + C;
		C = 0;
		A += [0x150A] + C;
		C = 0;
		A += [0x18] + C;
		[0x1504] = A;
		return;
	}








	public void R839443()
	{
		A = 0x4110;
		temp = A & [0x150C];[0x150C] &= ~A;
		return;
	}








	public void R839CEC()
	{
		A = [0x1A89];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L839D00();

		A &= 0x7FFF;
		[0x1A89] = A;
		X = 0x0008;
		this.R839F1E();
	}

	public void L839D00()
	{
		A = [0x1A8B];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L839D14();

		A &= 0x7FFF;
		[0x1A8B] = A;
		X = 0x000A;
		this.R839F1E();
	}

	public void L839D14()
	{
		A = [0x1A8D];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L839D28();

		A &= 0x7FFF;
		[0x1A8D] = A;
		X = 0x000C;
		this.R839F1E();
	}

	public void L839D28()
	{
		A = [0x1A8F];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L839D3C();

		A &= 0x7FFF;
		[0x1A8F] = A;
		X = 0x000E;
		this.R839F1E();
	}

	public void L839D3C()
	{
		A = [0x1A91];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L839D50();

		A &= 0x7FFF;
		[0x1A91] = A;
		X = 0x0010;
		this.R839F1E();
	}

	public void L839D50()
	{
		A = [0x1A93];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L839D64();

		A &= 0x7FFF;
		[0x1A93] = A;
		X = 0x0012;
		this.R839F1E();
	}

	public void L839D64()
	{
		A = [0x1A95];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L839D78();

		A &= 0x7FFF;
		[0x1A95] = A;
		X = 0x0014;
		this.R839F1E();
	}

	public void L839D78()
	{
		A = [0x1A97];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L839D8C();

		A &= 0x7FFF;
		[0x1A97] = A;
		X = 0x0016;
		this.R839F1E();
	}

	public void L839D8C()
	{
		A = [0x1A99];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L839DA0();

		A &= 0x7FFF;
		[0x1A99] = A;
		X = 0x0018;
		this.R839F1E();
	}

	public void L839DA0()
	{
		A = [0x1A9B];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L839DB4();

		A &= 0x7FFF;
		[0x1A9B] = A;
		X = 0x001A;
		this.R839F1E();
	}

	public void L839DB4()
	{
		A = [0x1A9D];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L839DC8();

		A &= 0x7FFF;
		[0x1A9D] = A;
		X = 0x001C;
		this.R839F1E();
	}

	public void L839DC8()
	{
		A = [0x1A9F];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L839DDC_Done();

		A &= 0x7FFF;
		[0x1A9F] = A;
		X = 0x001E;
		this.R839F1E();
	}

	public void L839DDC_Done()
	{
		return;
	}








	public void R839DDD()
	{
		A = [0x1A81];
		temp = A & 0x4000;
		
		if (Z == 1)
			return this.L839DF1();

		A &= 0xBFFF;
		[0x1A81] = A;
		X = 0x0000;
		this.R839F1E();
	}

	public void L839DF1()
	{
		A = [0x1A83];
		temp = A & 0x4000;
		
		if (Z == 1)
			return this.L839E05();

		A &= 0xBFFF;
		[0x1A83] = A;
		X = 0x0002;
		this.R839F1E();
	}

	public void L839E05()
	{
		A = [0x1A85];
		temp = A & 0x4000;
		
		if (Z == 1)
			return this.L839E19();

		A &= 0xBFFF;
		[0x1A85] = A;
		X = 0x0004;
		this.R839F1E();
	}

	public void L839E19()
	{
		A = [0x1A87];
		temp = A & 0x4000;
		
		if (Z == 1)
			return this.L839E2D();

		A &= 0xBFFF;
		[0x1A87] = A;
		X = 0x0006;
		this.R839F1E();
	}

	public void L839E2D()
	{
		A = [0x1A89];
		temp = A & 0x4000;
		
		if (Z == 1)
			return this.L839E41();

		A &= 0xBFFF;
		[0x1A89] = A;
		X = 0x0008;
		this.R839F1E();
	}

	public void L839E41()
	{
		A = [0x1A8B];
		temp = A & 0x4000;
		
		if (Z == 1)
			return this.L839E55();

		A &= 0xBFFF;
		[0x1A8B] = A;
		X = 0x000A;
		this.R839F1E();
	}

	public void L839E55()
	{
		A = [0x1A8D];
		temp = A & 0x4000;
		
		if (Z == 1)
			return this.L839E69();

		A &= 0xBFFF;
		[0x1A8D] = A;
		X = 0x000C;
		this.R839F1E();
	}

	public void L839E69()
	{
		A = [0x1A8F];
		temp = A & 0x4000;
		
		if (Z == 1)
			return this.L839E7D();

		A &= 0xBFFF;
		[0x1A8F] = A;
		X = 0x000E;
		this.R839F1E();
	}

	public void L839E7D()
	{
		A = [0x1A91];
		temp = A & 0x4000;
		
		if (Z == 1)
			return this.L839E91();

		A &= 0xBFFF;
		[0x1A91] = A;
		X = 0x0010;
		this.R839F1E();
	}

	public void L839E91()
	{
		A = [0x1A93];
		temp = A & 0x4000;
		
		if (Z == 1)
			return this.L839EA5();

		A &= 0xBFFF;
		[0x1A93] = A;
		X = 0x0012;
		this.R839F1E();
	}

	public void L839EA5()
	{
		A = [0x1A95];
		temp = A & 0x4000;
		
		if (Z == 1)
			return this.L839EB9();

		A &= 0xBFFF;
		[0x1A95] = A;
		X = 0x0014;
		this.R839F1E();
	}

	public void L839EB9()
	{
		A = [0x1A97];
		temp = A & 0x4000;
		
		if (Z == 1)
			return this.L839ECD();

		A &= 0xBFFF;
		[0x1A97] = A;
		X = 0x0016;
		this.R839F1E();
	}

	public void L839ECD()
	{
		A = [0x1A99];
		temp = A & 0x4000;
		
		if (Z == 1)
			return this.L839EE1();

		A &= 0xBFFF;
		[0x1A99] = A;
		X = 0x0018;
		this.R839F1E();
	}

	public void L839EE1()
	{
		A = [0x1A9B];
		temp = A & 0x4000;
		
		if (Z == 1)
			return this.L839EF5();

		A &= 0xBFFF;
		[0x1A9B] = A;
		X = 0x001A;
		this.R839F1E();
	}

	public void L839EF5()
	{
		A = [0x1A9D];
		temp = A & 0x4000;
		
		if (Z == 1)
			return this.L839F09();

		A &= 0xBFFF;
		[0x1A9D] = A;
		X = 0x001C;
		this.R839F1E();
	}

	public void L839F09()
	{
		A = [0x1A9F];
		temp = A & 0x4000;
		
		if (Z == 1)
			return this.L839F1D_Done();

		A &= 0xBFFF;
		[0x1A9F] = A;
		X = 0x001E;
		this.R839F1E();
	}

	public void L839F1D_Done()
	{
		return;
	}








	public void R839F1E()
	{
		A = [0x7E5C2C + X];
		[0xB0] = A;
		C = 0;
		A += 0x0020 + C;
		temp = A - 0x0140;
		
		if (C == 1)
			return this.L839F52_Done();

		A = [0x7E5C4C + X];
		[0xB2] = A;
		C = 0;
		A += 0x0020 + C;
		temp = A - 0x00E8;
		
		if (C == 1)
			return this.L839F52_Done();

		A = [0x7E5C6C + X];
		[0xB4] = A;
		A = [0x7E5C8C + X];
		[0xA8] = A;
		A = [0x7E5CAC + X];
		[0xAA] = A;
		this.R8280C2();
	}

	public void L839F52_Done()
	{
		return;
	}






	// Bank 0x86
	public void R86CA1C()
	{
		A = [0x7FB3EF];

		if (N == 1)
			return this.L86CA27();

		temp = A - 0x02D0;

		if (C == 1)
			return this.L86CA7C();

	}

	public void L86CA27()
	{
		A = 0x0080;
		[0xB0] = A;
		A = [0x014C];
		A ^= 0xFFFF;
		A++;
		A &= 0x00FF;
		A <<= 1;
		A <<= 1;
		A <<= 1;
		[0xB2] = A;
		A = [0x7FB3EF];

		if (N == 1)
			return this.L86CA69();

		temp = A - 0x01E0;

		if (C == 0)
			return this.L86CA4B();

		A = 0x00C9;
		return this.L86CA6C();
	}

	public void L86CA4B()
	{
		temp = A - 0x0168;

		if (C == 0)
			return this.L86CA55();

		A = 0x00C8;
		return this.L86CA6C();
	}

	public void L86CA55()
	{
		temp = A - 0x00F0;

		if (C == 0)
			return this.L86CA5F();

		A = 0x00C7;
		return this.L86CA6C();
	}

	public void L86CA5F()
	{
		temp = A - 0x0078;

		if (C == 0)
			return this.L86CA69();

		A = 0x00C6;
		return this.L86CA6C();
	}

	public void L86CA69()
	{
		A = 0x00C0;
	}

	public void L86CA6C()
	{
		[0xB4] = A;
		A = 0xCFFF;
		[0xA8] = A;
		A = 0x2000;
		[0xAA] = A;
		this.L8286B6();
	}

	public void L86CA7C()
	{
		return;
	}

	public void R86CA7D()
	{
		A = [0x7FB3EF];

		if (N == 1)
			return this.L86CA88();

		temp = A - 0x0258;

		if (C == 1)
			return this.L86CAE9_Done();

	}

	public void L86CA88()
	{
		A = 0x0080;
		[0xB0] = A;
		A = [0x014C];
		A ^= 0xFFFF;
		A++;
		A &= 0x00FF;
		A <<= 1;
		A <<= 1;
		[0x26] = A;
		A <<= 1;
		C = 0;
		A += [0x26] + C;
		[0xB2] = A;
		A = [0x7FB3EF];

		if (N == 1)
			return this.L86CAD6();

		temp = A - 0x01E0;

		if (C == 0)
			return this.L86CAB1();

		A = 0x00C5;
		return this.L86CAD9();
	}

	public void L86CAB1()
	{
		temp = A - 0x0168;

		if (C == 0)
			return this.L86CABB();

		A = 0x00C4;
		return this.L86CAD9();
	}

	public void L86CABB()
	{
		temp = A - 0x00F0;

		if (C == 0)
			return this.L86CAC5();

		A = 0x00C3;
		return this.L86CAD9();
	}

	public void L86CAC5()
	{
		temp = A - 0x0078;

		if (C == 0)
			return this.L86CACF();

		A = 0x00C2;
		return this.L86CAD9();
	}

	public void L86CACF()
	{

		if (N == 1)
			return this.L86CAD6();

		A = 0x00C1;
		return this.L86CAD9();
	}

	public void L86CAD6()
	{
		A = 0x00BF;
	}

	public void L86CAD9()
	{
		[0xB4] = A;
		A = 0xCFFF;
		[0xA8] = A;
		A = 0x2000;
		[0xAA] = A;
		this.L8286B6();
	}

	public void L86CAE9_Done()
	{
		return;
	}






	// Bank 0x8B
	public void R8B8000()
	{
		A = 0x0000;
		[0x7E6A82] = A;
		[0x7E6A84] = A;
		this.R8B8018();
		return;
	}

	public void L8B8010()
	{
		this.R8B8000();
		[0x026D]++;
		return;
	}

	public void R8B8018()
	{
		P &= ~0x20;
		A = 0x0000;
		[0x7E6A82] = A;
		[0x7E6A84] = A;
		this.R8B85FF();
		this.R8B863B();
		A = 0xFFFF;
		[0x7E6AC6] = A;
		[0x7E6AC8] = A;
		[0x7E6ACA] = A;
		[0x7E6ACC] = A;
		[0x7E6ACE] = A;
		[0x7E6AD0] = A;
		[0x7E6AD2] = A;
		[0x7E6AD4] = A;
		[0x7E6A80] = A;
		A = [0x014D];
		[0x7E6A8E] = A;
		A &= 0x0001;
		[0x7E6AB1] = A;
		A = 0x0000;
		[0x7E6AB3] = A;
		[0x7E6AA1] = A;
		[0x7E6AA5] = A;
		[0x7E6A7A] = A;
		[0x7E6A7E] = A;
		[0x7E6AA9] = A;
		[0x7E6AAB] = A;
		[0x7E6AAD] = A;
		[0x7E6AA7] = A;
		[0x7E6A8A] = A;
		P |= 0x20;
		A = 0xFF;
		[0x7E6AB5] = A;
		P &= ~0x20;
		A = 0xFFFF;
		[0x7E6A88] = A;
		[0x7E6A7C] = A;
		this.R8B80AD();
		this.R8B86C6();
		this.R8B80E8();
		this.R8B80C9();
		return;
	}

	public void R8B80AD()
	{
		Stack.Push(P);
		P |= 0x20;
		A = 0x00;
		[0x7E6A90] = A;
		X = 0x000F;
	}

	public void L8B80B9()
	{
		A = X;
		A &= 0x0F;
		[0x7E6A91 + X] = A;
		X--;
		
		if (N == 0)
			return this.L8B80B9();

		P = Stack.Pop();
		return;
	}








	public void R8B80C9()
	{
		A = [0x0B3C];
		A &= 0xFFFC;
	}

	public void L8B80CF()
	{
		
		if (Z == 0)
			return this.L8B80CF();

		X = [0x0381];
		A = [0x8B80E4 + X];
		A &= 0x00FF;
		C = 0;
		A += [0x0B3C] + C;
		[0x7E6AD6] = A;
		return;
	}








	public void R8B80E8()
	{
		Stack.Push(P);
		P |= 0x20;
		P &= ~0x10;
		X = 0x000F;
		A = 0x00;
	}

	public void L8B80F2()
	{
		[0x7E6AD8 + X] = A;
		X--;
		
		if (N == 0)
			return this.L8B80F2();

		P = Stack.Pop();
		A = [0x014D];
		C = 0;
		A += [0x014C] + C;
		[0x7E6AD8] = A;
		A = [0x014D];
		[0x7E6ADC] = A;
		return;
	}








	public void R8B85FF()
	{
		A = [0x7E3D73];
		[0x7E6AB6] = A;
		[0x7E6AC6] = A;
		A = [0x7E3D75];
		[0x7E6AB8] = A;
		[0x7E6AC8] = A;
		A = [0x7E3D87];
		[0x7E6ABA] = A;
		[0x7E6ACA] = A;
		A = [0x7E3D89];
		[0x7E6ABC] = A;
		[0x7E6ACC] = A;
		A = 0x2000;
		A |= [0x7E6AE0];
		[0x7E6AE0] = A;
		return;
	}








	public void R8B863B()
	{
		A = [0x7E3D9B];
		[0x7E6ABE] = A;
		[0x7E6ACE] = A;
		A = [0x7E3D9D];
		[0x7E6AC0] = A;
		[0x7E6AD0] = A;
		A = [0x7E3DAF];
		[0x7E6AC2] = A;
		[0x7E6AD2] = A;
		A = [0x7E3DB1];
		[0x7E6AC4] = A;
		[0x7E6AD4] = A;
		A = 0x2000;
		A |= [0x7E6AE0];
		[0x7E6AE0] = A;
		return;
	}








	public void R8B86C6()
	{
		A = [0x14D6];
		A <<= 1;
		X = A;
		A = [0x8B8EEC + X];
		[0x12] = A;
		A = [0x7E6AD6];
		A <<= 1;
		C = 0;
		A += [0x12] + C;
		X = A;
		A = [0x8B0000 + X];
		[0x7E6AA3] = A;
		return;
	}




	// Bank 0x8C
	public void R8CC0E8_ResetRegistersAndRam()
	{
		P &= ~0x30;
		this.R80823D_Set0100Flag80();
		P |= 0x20;
		A = 0x8F;
		[0x2100] = A;
		[0x0100] = A;
		A = 0x10;
		[0x2102] = A;
		[0x0102] = A;
		A = 0x00;
		[0x2103] = A;
		[0x0103] = A;
		A = 0x09;
		[0x2105] = A;
		[0x0104] = A;
		A = 0x10;
		[0x2109] = A;
		[0x0108] = A;
		A = 0x00;
		[0x210C] = A;
		[0x010B] = A;
		A = 0x04;
		[0x212C] = A;
		[0x0126] = A;
		A = 0x00;
		[0x212D] = A;
		[0x0127] = A;
		A = 0x81;
		[0x4200] = A;
		[0x013C] = A;
		P &= ~0x20;
		A = 0x8C00;
		[0x01] = A;
		A = 0xC1C2;
		[0x00] = A;
		this.R8087A4_LoadDmaTransferRecord();
		A = 0x8C00;
		[0x01] = A;
		A = 0xC1D4;
		[0x00] = A;
		this.R8087A4_LoadDmaTransferRecord();
		this.R808202_WaitFor014BFlag1();
		A = 0x0000;
		Y = 0x0800;
		X = 0x0000;
	}

	public void L8CC163_Loop()
	{
		[0x7E2000 + X] = A;
		X++;
		Y--;
		X++;
		Y--;

		if (Z == 0)
			return this.L8CC163_Loop();

		Y = 0x0050;
		X = 0x0000;
	}

	public void L8CC173_Loop()
	{
		A = [0x8CC1DB + X];
		[0x7E2318 + X] = A;
		X++;
		Y--;
		X++;
		Y--;

		if (Z == 0)
			return this.L8CC173_Loop();

		A = 0x8C00;
		[0x01] = A;
		A = 0xC1CB;
		[0x00] = A;
		this.R8087A4_LoadDmaTransferRecord();
		this.R808202_WaitFor014BFlag1();
		this.R808252_Clear0100Flag80();
		return;
	}

	public byte[] Table8CC1C2 = new byte[]
	{
		//02 E4 BF 8C 00 01 80 00 00
	}

	public byte[] Table8CC1CB = new byte[]
	{
		//02 00 20 7E 00 08 80 00 10
	}

	public byte[] Table8CC1D4 = new byte[]
	{
		//01 2B C2 8C 04 00 00
	}








	public void L8CC456()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = 0x0163;
		C = 0;
		A += 0x000C + C;
		[0xB4] = A;
		this.R828000();
		A = [0x014C];
		A &= 0x0003;
		temp = A - 0x0003;

		if (Z == 0)
			return this.L8CC48F_Done();

		A = [0x014C];
		A &= 0x001F;
		C = 1;
		A -= 0x0001 - !C;
		X = A;
		A = [0x8FA060 + X];
		[0x7F0669] = A;
		X--;
		X--;
		A = [0x8FA060 + X];
		[0x7F0667] = A;
	}

	public void L8CC48F_Done()
	{
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}







	// Bank 0x8E
	public void R8E98BE()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x7E6AF6];
		A &= 0x00FF;
		A <<= 1;
		X = A;
		Cpu.JSR((0x98D4 + X));
		this.R8EAB4D();
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void R8EAB4D()
	{
		Stack.Push(P);
		P &= ~0x30;
		this.R91B091();
		this.R90829B();
		A = [0x7E6B09];

		if (Z == 1)
			return this.L8EAB61();

		this.R8EABEC();
	}

	public void L8EAB61()
	{
		A = [0x7E6AF6];
		temp = A - 0x0006;

		if (Z == 1)
			return this.L8EAB73();


		if (C == 0)
			return this.L8EAB7F_Done();

		temp = A - 0x000D;

		if (C == 1)
			return this.L8EAB7F_Done();

		return this.L8EAB7C();
	}

	public void L8EAB73()
	{
		A = [0x7E6B26];
		temp = A - 0x0002;

		if (C == 0)
			return this.L8EAB7F_Done();

	}

	public void L8EAB7C()
	{
		this.L8EAB81();
	}

	public void L8EAB7F_Done()
	{
		P = Stack.Pop();
		return;
	}

	public void L8EAB81()
	{
		P &= ~0x30;
		A = 0x0080;
		[0xB0] = A;
		A = 0x002C;
		[0xB2] = A;
		A = [0x7E6AF6];
		temp = A - 0x0006;

		if (Z == 1)
			return this.L8EABB8();

		A = [0x7E6B26];
		temp = A - 0x0002;

		if (C == 0)
			return this.L8EABAD();

		A = [0x7E6AF6];
		temp = A - 0x000A;

		if (Z == 1)
			return this.L8EABC3();

		temp = A - 0x000D;

		if (Z == 1)
			return this.L8EABC3();

	}

	public void L8EABAD()
	{
		A = 0x01F0;
		[0xB4] = A;
		this.R828000();
		return this.L8EABCE();
	}

	public void L8EABB8()
	{
		A = 0x01F1;
		[0xB4] = A;
		this.R828000();
		return this.L8EABCE();
	}

	public void L8EABC3()
	{
		A = 0x01F2;
		[0xB4] = A;
		this.R828000();
		return this.L8EABCE();
	}

	public void L8EABCE()
	{
		A = 0x01F3;
		[0xB4] = A;
		this.R828000();
		A = [0x7E6B0E];

		if (Z == 1)
			return this.L8EABEB();

		A = 0x007E;
		[0xB0] = A;
		A = 0x00AD;
		[0xB2] = A;
		this.L8CC456();
	}

	public void L8EABEB()
	{
		return;
	}

	public void R8EABEC()
	{
		A = 0x0001;
		[0x0AB9] = A;
		A = 0x0004;
		[0x0AB5] = A;
		this.L91AD8B();
		A = [0x0AB5];

		if (N == 1)
			return this.L8EAC02();

		return;
	}

	public void L8EAC02()
	{
		A = 0x0000;
		[0x7E6B09] = A;
		return;
	}





	// Bank 0x90
	public void R9082B7()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		X = 0x07FE;
		A = 0x0000;
	}

	public void L9082C3()
	{
		[0x7E3000 + X] = A;
		X--;
		X--;

		if (N == 0)
			return this.L9082C3();

		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}






	public void R90829B()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = 0x9000;
		[0x01] = A;
		A = 0x82B0;
		[0x00] = A;
		this.R8087A4_LoadDmaTransferRecord();
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}








	public void R909CDE()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		this.R80823D_Set0100Flag80();
		this.R9081B1_ResetRam();
		this.R94E94E();
		this.R908000_ResetRam();
		[0x026D]++;
		P = Stack.Pop();
		I = 0;
		B = Stack.Pop();
		return;
	}








	public void L90D15F()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x0371];
		temp = A - 0x0004;
		
		if (Z == 1)
			return this.L90D175();

		temp = A - 0x0003;
		
		if (Z == 0)
			return this.L90D17D();

		A = [0x0369];
		
		if (Z == 1)
			return this.L90D17D();

	}

	public void L90D175()
	{
		[0x026D]++;
		[0x035D] = 0;
		return this.L90D1B3();
	}

	public void L90D17D()
	{
		A = [0x0367];
		A &= 0x00FF;
		A <<= 1;
		X = A;
		Cpu.JSR((0xD1B6 + X));
		A = [0x0100];
		A &= 0x0080;
		
		if (Z == 0)
			return this.L90D1B3();

		this.L90E4C8();
		[0x0B34] = 0;
		this.L91B091();
		this.L90829B();
		P |= 0x20;
		A = [0x0126];
		[0x0996] = A;
		[0x0998] = A;
		A = [0x7F65EB];
		A |= 0x06;
		[0x4A] = A;
		P &= ~0x20;
	}

	public void L90D1B3()
	{
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L90E4C8()
	{
		A = [0x043A];
		C = 0;
		A += 0x8000 + C;
		[0x043A] = A;
		A = [0x043C];
		[0x12] = A;
		A += 0x0000 + C;
		[0x043C] = A;
		P |= 0x20;
		A = [0x043C];
		A &= 0x1F;
		A ^= 0x1F;
		A++;
		[0x7F3BEB] = A;
		[0x7F3CEB] = A;
		P &= ~0x20;
		A = [0x043C];
		A ^= [0x12];
		A &= 0xFFE0;
		
		if (Z == 0)
			return this.L90E4FC();

		return;
	}

	public void L90E4FC()
	{
		A = [0x0472];
		A++;
		A &= 0x0007;
		[0x0472] = A;
		A <<= 1;
		Y = A;
		X = 0x0000;
		A = [0x7F3BE9];
		
		if (Z == 0)
			return this.L90E514();

		X = 0x0100;
	}

	public void L90E514()
	{
		A = [0xE560 + Y];
		[0x7F3BEE + X] = A;
		A = [0xE562 + Y];
		[0x7F3BF3 + X] = A;
		A = [0xE564 + Y];
		[0x7F3BF8 + X] = A;
		A = [0xE566 + Y];
		[0x7F3BFD + X] = A;
		A = [0xE568 + Y];
		[0x7F3C02 + X] = A;
		A = [0xE56A + Y];
		[0x7F3C07 + X] = A;
		A = [0xE56C + Y];
		[0x7F3C0C + X] = A;
		A = [0x7F3BE9];
		A ^= 0x0001;
		[0x7F3BE9] = A;
		
		if (Z == 0)
			return this.L90E559();

		A = 0x3BEB;
		[0x0952] = A;
		return;
	}

	public void L90E559()
	{
		A = 0x3CEB;
		[0x0952] = A;
		return;
	}














	public void R908000_ResetRam()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = 0xFFFF;
		[0x03AD] = A;
		[0x03AF] = A;
		[0x036F] = 0;
		[0x03FA] = 0;
		[0x03FC] = 0;
		A = 0x0000;
		[0x7F0512] = A;
		[0x7F0527] = A;
		A = 0xFFFF;
		[0x7F051B] = A;
		[0x7F051D] = A;
		[0x7F051F] = A;
		[0x7F0521] = A;
		[0x7F0523] = A;
		[0x7F0525] = A;
		P |= 0x20;
		A = 0x01;
		[0x03B2] = A;
		A = 0x02;
		[0x03CF] = A;
		A = 0xFF;
		[0x03B1] = A;
		P &= ~0x20;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}







	public void R908052()
	{
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		this.L91B06F();
		this.L91AA56();
		this.L91AD68();
		P |= 0x20;
		A = 0xFF;
		[0x03EA] = A;
		P &= ~0x20;
		A = 0x0080;
		[0x0375] = A;
		[0x0379] = A;
		[0x0377] = A;
		[0x037B] = A;
		A = 0xFFFF;
		[0x00037F] = A;
		[0x0393] = 0;
		[0x0395] = 0;
		[0x0404] = 0;
		[0x0408] = 0;
		[0x0408] = 0;
		[0x040A] = 0;
		[0x040C] = 0;
		[0x040E] = 0;
		[0x045A] = 0;
		[0x045C] = 0;
		[0x045E] = 0;
		[0x0460] = 0;
		[0x0462] = 0;
		[0x0464] = 0;
		[0x0466] = 0;
		[0x0468] = 0;
		[0x046A] = 0;
		[0x046C] = 0;
		[0x046E] = 0;
		[0x0470] = 0;
		[0x0452] = 0;
		[0x0454] = 0;
		[0x0456] = 0;
		[0x0458] = 0;
		[0x1BF5] = 0;
		[0x03BB] = 0;
		[0x03BD] = 0;
		[0x03BF] = 0;
		A = 0x0005;
		[0x03DE] = A;
		this.R9082B7();
		this.R949B0B();
		this.R9089DB();
		this.R908A56();
		this.R9088FD();
		this.R94B383();
		this.R948D87();
		A = 0xFFFF;
		[0x0312] = A;
		[0x0402] = A;
		[0x03AD] = A;
		[0x03AF] = A;
		[0x038D] = A;
		[0x035D] = 0;
		[0x035F] = 0;
		B = Stack.Pop();
		return;
	}








	public void R9081B1_ResetRam()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		this.R80823D_Set0100Flag80();
		this.R80827B_Clear013CAnd4200Flag10();
		this.R8082A3_Clear013CAnd4200Flag20();
		P |= 0x20;
		A = 0x80;
		[0x4340] = A;
		A = 0x32;
		[0x4341] = A;
		A = 0x5C;
		[0x4342] = A;
		A = 0x82;
		[0x4343] = A;
		A = 0x90;
		[0x4344] = A;
		P &= ~0x20;
		P |= 0x20;
		A = 0x80;
		[0x4350] = A;
		A = 0x32;
		[0x4351] = A;
		A = 0x5C;
		[0x4352] = A;
		A = 0x82;
		[0x4353] = A;
		A = 0x90;
		[0x4354] = A;
		P &= ~0x20;
		P |= 0x20;
		A = 0x80;
		[0x4360] = A;
		A = 0x32;
		[0x4361] = A;
		A = 0x5C;
		[0x4362] = A;
		A = 0x82;
		[0x4363] = A;
		A = 0x90;
		[0x4364] = A;
		P &= ~0x20;
		P |= 0x20;
		A = 0x80;
		[0x4370] = A;
		A = 0x32;
		[0x4371] = A;
		A = 0x5C;
		[0x4372] = A;
		A = 0x82;
		[0x4373] = A;
		A = 0x90;
		[0x4374] = A;
		P &= ~0x20;
		P |= 0x20;
		A = [0x013C];
		A &= 0x81;
		[0x013C] = A;
		[0x420C] = 0;
		[0x0141] = 0;
		[0x4A] = 0;
		[0x434A] = 0;
		[0x435A] = 0;
		[0x436A] = 0;
		[0x437A] = 0;
		P &= ~0x20;
		this.R808202_WaitFor014BFlag1();
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}








	public void L9084BD()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x0367];
		temp = A - 0x0007;

		if (Z == 1)
			return this.L9084D6();

		temp = A - 0x0001;

		if (Z == 1)
			return this.L9084F4();

		temp = A - 0x0002;

		if (Z == 1)
			return this.L9084FA();
	}

	public void L9084D3()
	{
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L9084D6()
	{
		A = [0x7FB3EF];

		if (N == 0)
			return this.L9084E4();

		this.R86CA7D();
		this.R86CA1C();
	}

	public void L9084E4()
	{
		A = [0x036F];

		if (Z == 0)
			return this.L9084F2();

		A = [0x0381];

		if (Z == 0)
			return this.L9084F2();

		this.R90C047();
	}

	public void L9084F2()
	{
		return this.L9084D3();
	}

	public void L9084F4()
	{
		this.R9BD1EC();
		return this.L9084D3();
	}

	public void L9084FA()
	{
		this.R858000();
		return this.L9084D3();
	}







	public void L9089DB()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		P |= 0x20;
		P &= ~0x10;
		X = 0xC0E1;
		[0x3E] = X;
		A = 0xA2;
		[0x40] = A;
		X = 0xAB38;
		[0x43] = X;
		A = 0x7E;
		[0x45] = A;
		this.L808888();
		P &= ~0x30;
		A = 0x9000;
		[0x01] = A;
		A = 0x8A44;
		[0x00] = A;
		this.R8087A4_LoadDmaTransferRecord();
		A = 0x9000;
		[0x01] = A;
		A = 0x8A4D;
		[0x00] = A;
		this.R8087A4_LoadDmaTransferRecord();
		P &= ~0x20;
		Y = 0x003E;
		X = 0x0000;
	}

	public void L908A1F()
	{
		A = [0x95D700 + X];
		[0x7F0563 + X] = A;
		X++;
		Y--;
		X++;
		Y--;

		if (Z == 0)
			return this.L908A1F();

		Y = 0x003E;
		X = 0x0000;
	}

	public void L908A33()
	{
		A = [0x95D700 + X];
		[0x7F1063 + X] = A;
		X++;
		Y--;
		X++;
		Y--;

		if (Z == 0)
			return this.L908A33();

		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}








	public void L9094E4()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		this.R9094EE();
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void R9094EE()
	{
		A = [0x0458];

		if (N == 0)
			return this.L9094F7();

		A ^= 0xFFFF;
		A++;
	}

	public void L9094F7()
	{
		A &= 0x000E;
		A ^= 0x000E;
		A >>= 1;
		[0x12] = A;
		A = [0x03E2];
		[0x03E2]++;
		temp = A - [0x12];

		if (C == 0)
			return this.L90952D();

		[0x03E2] = 0;
		A = [0x03E0];
		A--;

		if (N == 0)
			return this.L909516();

		A = 0x0003;
	}

	public void L909516()
	{
		[0x03E0] = A;
		A <<= 1;
		C = 0;
		A += [0x03E0] + C;
		X = A;
		A = [0x952F + X];
		[0x01] = A;
		A = [0x952E + X];
		[0x00] = A;
		this.R8087A4_LoadDmaTransferRecord();
	}

	public void L90952D()
	{
		return;
	}







	public void R909EE5()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		this.L908453();
		this.L9084BD();
		A = [0x0367];
		temp = A - 0x0009;

		if (Z == 1)
			return this.L909EFF();

		[0x026D]++;
	}

	public void L909EFC()
	{
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L909EFF()
	{
		A = 0x0055;
		[0x026D] = A;
		return this.L909EFC();
	}

	public void L90C047()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
	}

	public void L90C04B()
	{
		A = [0x7FB3F1];

		if (N == 0)
			return this.L90C054();

		return this.L90C0DA();
	}

	public void L90C054()
	{
		X = A;
		A = [0x7FB3F5];
		[0x03E6] = A;
		A = [0xC104 + X];
		temp = A - 0x8000;

		if (Z == 1)
			return this.L90C0DD();

		temp = A - 0x8001;

		if (Z == 1)
			return this.L90C0E6();

		temp = A - 0x8002;

		if (Z == 0)
			return this.L90C071();

		return this.L90C0F9();
	}

	public void L90C071()
	{
		A &= 0x0F00;

		if (Z == 1)
			return this.L90C0A0();

		A = 0x0001;
		[0x7FB3F5] = A;
		P |= 0x20;
		A = 0x20;
		[0x012E] = A;
		A = 0xCF;
		[0x012D] = A;
		[0x012C] = A;
		A = 0x00;
		[0x012A] = A;
		A = 0xBF;
		[0x012B] = A;
		A = [0x4A];
		A &= 0xFC;
		[0x4A] = A;
		P &= ~0x20;
		return this.L90C0BA();
	}

	public void L90C0A0()
	{
		A = 0x0000;
		[0x7FB3F5] = A;
		P |= 0x20;
		A = 0xB3;
		[0x012B] = A;
		A = 0x12;
		[0x012A] = A;
		A = 0xE0;
		[0x012C] = A;
		P &= ~0x20;
	}

	public void L90C0BA()
	{
		A = [0xC104 + X];

		if (N == 1)
			return this.L90C0C4();

		A &= 0x000F;
		return this.L90C0C7();
	}

	public void L90C0C4()
	{
		A |= 0x0F00;
	}

	public void L90C0C7()
	{
		[0x0117] = A;
		[0x7F0002] = A;
		A = [0x7FB3F1];
		C = 0;
		A += 0x0002 + C;
		[0x7FB3F1] = A;
	}

	public void L90C0DA()
	{
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L90C0DD()
	{
		A = 0xFFFF;
		[0x7FB3F1] = A;
		return this.L90C0DA();
	}

	public void L90C0E6()
	{
		A = [0x7FB3F1];
		C = 0;
		A += 0x0002 + C;
		[0x7FB3F1] = A;
		[0x7FB3F3] = A;
		return this.L90C04B();
	}

	public void L90C0F9()
	{
		A = [0x7FB3F3];
		[0x7FB3F1] = A;
		return this.L90C04B();
	}








	public void R90C047()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
	}

	public void L90C04B()
	{
		A = [0x7FB3F1];

		if (N == 0)
			return this.L90C054();

		return this.L90C0DA();
	}

	public void L90C054()
	{
		X = A;
		A = [0x7FB3F5];
		[0x03E6] = A;
		A = [0xC104 + X];
		temp = A - 0x8000;

		if (Z == 1)
			return this.L90C0DD();

		temp = A - 0x8001;

		if (Z == 1)
			return this.L90C0E6();

		temp = A - 0x8002;

		if (Z == 0)
			return this.L90C071();

		return this.L90C0F9();
	}

	public void L90C071()
	{
		A &= 0x0F00;

		if (Z == 1)
			return this.L90C0A0();

		A = 0x0001;
		[0x7FB3F5] = A;
		P |= 0x20;
		A = 0x20;
		[0x012E] = A;
		A = 0xCF;
		[0x012D] = A;
		[0x012C] = A;
		A = 0x00;
		[0x012A] = A;
		A = 0xBF;
		[0x012B] = A;
		A = [0x4A];
		A &= 0xFC;
		[0x4A] = A;
		P &= ~0x20;
		return this.L90C0BA();
	}

	public void L90C0A0()
	{
		A = 0x0000;
		[0x7FB3F5] = A;
		P |= 0x20;
		A = 0xB3;
		[0x012B] = A;
		A = 0x12;
		[0x012A] = A;
		A = 0xE0;
		[0x012C] = A;
		P &= ~0x20;
	}

	public void L90C0BA()
	{
		A = [0xC104 + X];

		if (N == 1)
			return this.L90C0C4();

		A &= 0x000F;
		return this.L90C0C7();
	}

	public void L90C0C4()
	{
		A |= 0x0F00;
	}

	public void L90C0C7()
	{
		[0x0117] = A;
		[0x7F0002] = A;
		A = [0x7FB3F1];
		C = 0;
		A += 0x0002 + C;
		[0x7FB3F1] = A;
	}

	public void L90C0DA()
	{
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L90C0DD()
	{
		A = 0xFFFF;
		[0x7FB3F1] = A;
		return this.L90C0DA();
	}

	public void L90C0E6()
	{
		A = [0x7FB3F1];
		C = 0;
		A += 0x0002 + C;
		[0x7FB3F1] = A;
		[0x7FB3F3] = A;
		return this.L90C04B();
	}

	public void L90C0F9()
	{
		A = [0x7FB3F3];
		[0x7FB3F1] = A;
		return this.L90C04B();
	}







	public void L91AD8B()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x0AB5];
		temp = A - [0x0AB7];

		if (Z == 0)
			return this.L91ADCC();

		temp = A - 0xFFFF;

		if (Z == 1)
			return this.L91ADC3();

		A = [0x0AB9];

		if (Z == 1)
			return this.L91ADAC();

		A = [0x0ABB];
		A |= [0x0ABD];
		A |= [0x0ABF];

		if (Z == 1)
			return this.L91ADC6();

	}

	public void L91ADAC()
	{
		X = 0x0004;
	}

	public void L91ADAF()
	{
		A = [0x0ABB + X];

		if (Z == 1)
			return this.L91ADBF();

		A = [0x0AC1 + X];

		if (Z == 1)
			return this.L91AE08();

		this.L91AFFA();
		[0x0AC1 + X]--;
	}

	public void L91ADBF()
	{
		X--;
		X--;

		if (N == 0)
			return this.L91ADAF();

	}

	public void L91ADC3()
	{
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L91ADC6()
	{
		A = 0xFFFF;
		[0x0AB5] = A;
	}

	public void L91ADCC()
	{
		[0x0ABB] = 0;
		[0x0ABD] = 0;
		[0x0ABF] = 0;
		[0x0ADF] = 0;
		[0x0AE1] = 0;
		[0x0AE3] = 0;
		A = [0x0AB5];
		[0x0AB7] = A;
		temp = A - 0xFFFF;

		if (Z == 1)
			return this.L91ADC3();

		A <<= 1;
		C = 0;
		A += [0x0AB5] + C;
		X = A;
		this.L91ADF5();
		return this.L91ADAC();
	}

	public void L91ADF5()
	{
		A = [0xE0F3 + X];
		[0x00] = A;
		P |= 0x20;
		A = [0xE0F5 + X];
		[0x02] = A;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		return [[0x0000]]();    //24-Bit Address
	}

	public void L91AE08()
	{
		A = [0x0AC7 + X];
		[0x00] = A;
		A = [(0x00)];
		A &= 0x00FF;
		temp = A & 0x0080;

		if (Z == 1)
			return this.L91AE1A();

		return this.L91AE8C();
	}

	public void L91AE1A()
	{
		temp = A - 0x0003;

		if (Z == 0)
			return this.L91AE22();

		return this.L91AEDB();
	}

	public void L91AE22()
	{
		temp = A - 0x0004;

		if (Z == 0)
			return this.L91AE2A();

		return this.L91AEE1();
	}

	public void L91AE2A()
	{
		temp = A - 0x0005;

		if (Z == 0)
			return this.L91AE32();

		return this.L91AEE4();
	}

	public void L91AE32()
	{
		temp = A - 0x0007;

		if (Z == 0)
			return this.L91AE3A();

		return this.L91AF0C();
	}

	public void L91AE3A()
	{
		temp = A - 0x0008;

		if (Z == 0)
			return this.L91AE42();

		return this.L91AF4C();
	}

	public void L91AE42()
	{
		temp = A - 0x0002;

		if (Z == 0)
			return this.L91AE4A();

		return this.L91AEC1();
	}

	public void L91AE4A()
	{
		temp = A - 0x0009;

		if (Z == 0)
			return this.L91AE52();

		return this.L91AF57();
	}

	public void L91AE52()
	{
		temp = A - 0x000A;

		if (Z == 0)
			return this.L91AE5A();

		return this.L91AF6C();
	}

	public void L91AE5A()
	{
		temp = A - 0x000B;

		if (Z == 0)
			return this.L91AE62();

		return this.L91AF75();
	}

	public void L91AE62()
	{
		temp = A - 0x000C;

		if (Z == 0)
			return this.L91AE6A();

		return this.L91AF8D();
	}

	public void L91AE6A()
	{
		temp = A - 0x0006;

		if (Z == 0)
			return this.L91AE72();

		return this.L91AF24();
	}

	public void L91AE72()
	{
		temp = A - 0x000D;

		if (Z == 0)
			return this.L91AE7A();

		return this.L91AFC2();
	}

	public void L91AE7A()
	{
		temp = A - 0x0001;

		if (Z == 0)
			return this.L91AE82();

		return this.L91AEA1();
	}

	public void L91AE82()
	{
		temp = A - 0x000E;

		if (Z == 0)
			return this.L91AE8A();

		return this.L91AFDD();
	}

	public void L91AE8A()
	{
		return this.L91AE8A();
	}

	public void L91AE8C()
	{
		A &= 0x007F;
		[0x0AC1 + X] = A;
		A = 0x0001;
		[0x0ADF + X] = A;
		[0x0AFB] = 0;
		[0x0AC7 + X]++;
		return this.L91ADAF();
	}

	public void L91AEA1()
	{
		Y = 0x0001;
		A = [(0x00) + Y];
		A &= 0x007F;
		[0x0AC1 + X] = A;
		A = 0x0001;
		[0x0ADF + X] = A;
		A = 0x0001;
		[0x0AFB] = A;
		[0x0AC7 + X]++;
		[0x0AC7 + X]++;
		return this.L91ADAF();
	}

	public void L91AEC1()
	{
		Y = 0x0001;
		A = [(0x00) + Y];
		A &= 0x007F;
		[0x0AC1 + X] = A;
		[0x0AFB] = 0;
		[0x0ADF + X] = 0;
		[0x0AC7 + X]++;
		[0x0AC7 + X]++;
		return this.L91ADAF();
	}

	public void L91AEDB()
	{
		[0x0ABB + X] = 0;
		return this.L91ADBF();
	}

	public void L91AEE1()
	{
		return this.L91ADC6();
	}

	public void L91AEE4()
	{
		Y = 0x0001;
		A = [(0x00) + Y];
		[0x0ACD + X] = A;
		Y = 0x0003;
		A = [(0x00) + Y];
		[0x0AD3 + X] = A;
		Y = 0x0005;
		A = [(0x00) + Y];
		[0x0AD9 + X] = A;
		A = [0x0AC7 + X];
		C = 0;
		A += 0x0007 + C;
		[0x0AC7 + X] = A;
		[0x0AFB] = 0;
		return this.L91ADAF();
	}

	public void L91AF0C()
	{
		Y = 0x0001;
		A = [(0x00) + Y];
		[0x0AD9 + X] = A;
		A = [0x0AC7 + X];
		C = 0;
		A += 0x0003 + C;
		[0x0AC7 + X] = A;
		[0x0AFB] = 0;
		return this.L91ADAF();
	}

	public void L91AF24()
	{
		Y = 0x0001;
		A = [(0x00) + Y];
		A &= 0x00FF;
		C = 0;
		A += [0x0AF1] + C;
		[0x0AD9 + X] = A;
		A = [0x0AF3];
		[0x0AF5] = A;
		A = [0x0AF7];
		[0x0AF9] = A;
		A = [0x0AC7 + X];
		C = 0;
		A += 0x0002 + C;
		[0x0AC7 + X] = A;
		return this.L91ADAF();
	}

	public void L91AF4C()
	{
		Y = 0x0001;
		A = [(0x00) + Y];
		[0x0AC7 + X] = A;
		return this.L91ADAF();
	}

	public void L91AF57()
	{
		Y = 0x0001;
		A = [0x0AC7 + X];
		C = 0;
		A += 0x0003 + C;
		[0x0AEB + X] = A;
		A = [(0x00) + Y];
		[0x0AC7 + X] = A;
		return this.L91ADAF();
	}

	public void L91AF6C()
	{
		A = [0x0AEB + X];
		[0x0AC7 + X] = A;
		return this.L91ADAF();
	}

	public void L91AF75()
	{
		Stack.Push(X);
		Y = 0x0001;
		A = [(0x00) + Y];
		X = A;
		[0x0AE5 + X] = 0;
		X = Stack.Pop();
		A = [0x0AC7 + X];
		C = 0;
		A += 0x0003 + C;
		[0x0AC7 + X] = A;
		return this.L91ADAF();
	}

	public void L91AF8D()
	{
		Y = 0x0001;
		A = [(0x00) + Y];
		Y = A;
		A = [0x0AE5 + Y];
		A++;
		[0x0AE5 + Y] = A;
		[0x12] = A;
		Y = 0x0003;
		A = [(0x00) + Y];
		A &= 0x00FF;
		temp = A - [0x12];

		if (Z == 1)
			return this.L91AFB5();


		if (C == 0)
			return this.L91AFB5();

		Y = 0x0004;
		A = [(0x00) + Y];
		[0x0AC7 + X] = A;
		return this.L91ADAF();
	}

	public void L91AFB5()
	{
		A = [0x0AC7 + X];
		C = 0;
		A += 0x0006 + C;
		[0x0AC7 + X] = A;
		return this.L91ADAF();
	}

	public void L91AFC2()
	{
		Y = 0x0001;
		A = [(0x00) + Y];
		[0x03] = A;
		Y = 0x0003;
		A = [(0x00) + Y];
		[(0x03)] = A;
		A = [0x0AC7 + X];
		C = 0;
		A += 0x0005 + C;
		[0x0AC7 + X] = A;
		return this.L91ADAF();
	}

	public void L91AFDD()
	{
		Y = 0x0001;
		A = [(0x00) + Y];
		[0x0AF5] = A;
		Y = 0x0003;
		A = [(0x00) + Y];
		[0x0AF9] = A;
		A = [0x0AC7 + X];
		C = 0;
		A += 0x0005 + C;
		[0x0AC7 + X] = A;
		return this.L91ADAF();
	}

	public void L91AFFA()
	{
		A = [0x0ADF + X];

		if (Z == 1)
			return this.L91B020();

		A = [0x0AFD];

		if (Z == 0)
			return this.L91B043();

		A = [0x0AFB];

		if (Z == 0)
			return this.L91B021();

		A = [0x0ACD + X];
		[0xB0] = A;
		A = [0x0AD3 + X];
		[0xB2] = A;
		A = [0x0AD9 + X];
		[0xB4] = A;
		Stack.Push(X);
		Stack.Push(Y);
		this.R828000();
		Y = Stack.Pop();
		X = Stack.Pop();
	}

	public void L91B020()
	{
		return;
	}

	public void L91B021()
	{
		A = [0x0ACD + X];
		[0xB0] = A;
		A = [0x0AD3 + X];
		[0xB2] = A;
		A = [0x0AD9 + X];
		[0xB4] = A;
		A = [0x0AF5];
		[0xA8] = A;
		A = [0x0AF9];
		[0xAA] = A;
		Stack.Push(X);
		Stack.Push(Y);
		this.L8280C2();
		Y = Stack.Pop();
		X = Stack.Pop();
		return;
	}

	public void L91B043()
	{
		A = [0x0ACD + X];
		[0xB0] = A;
		A = [0x0AD3 + X];
		[0xB2] = A;
		A = [0x0AD9 + X];
		[0xB4] = A;
		A = [0x0AF5];
		[0xA8] = A;
		A = [0x0AF9];
		[0xAA] = A;
		A = [0x0AFE];
		[0xA4] = A;
		A = [0x0AFD];
		[0xA3] = A;
		Stack.Push(X);
		Stack.Push(Y);
		this.L8286B6();
		Y = Stack.Pop();
		X = Stack.Pop();
		return;
	}

	// Bank 0x91
	public void R91B091()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x0B00];
		temp = A - [0x0B02];

		if (Z == 0)
			return this.L91B0D2();

		temp = A - 0xFFFF;

		if (Z == 1)
			return this.L91B0C9();

		A = [0x0B04];
		A |= [0x0B06];
		A |= [0x0B08];
		A |= [0x0B0A];
		A |= [0x0B0C];
		A |= [0x0B0E];

		if (Z == 0)
			return this.L91B0BB();

		A = [0x0B34];

		if (Z == 0)
			return this.L91B0CC();

	}

	public void L91B0BB()
	{
		X = 0x000A;
	}

	public void L91B0BE()
	{
		A = [0x0B04 + X];

		if (Z == 1)
			return this.L91B0C5();


		if (N == 0)
			return this.L91B117();

	}

	public void L91B0C5()
	{
		X--;
		X--;

		if (N == 0)
			return this.L91B0BE();

	}

	public void L91B0C9()
	{
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L91B0CC()
	{
		A = 0xFFFF;
		[0x0B00] = A;
	}

	public void L91B0D2()
	{
		[0x0B0E] = 0;
		[0x0B26] = 0;
		A = [0x0B00];
		[0x0B02] = A;
		temp = A - 0xFFFF;

		if (Z == 1)
			return this.L91B0F0();

		[0x12] = A;
		A <<= 1;
		C = 0;
		A += [0x12] + C;
		X = A;
		this.L91B104();
		return this.L91B0BB();
	}

	public void L91B0F0()
	{
		[0x0B04] = 0;
		[0x0B06] = 0;
		[0x0B08] = 0;
		[0x0B0A] = 0;
		[0x0B0C] = 0;
		[0x0B0E] = 0;
		return this.L91B0C9();
	}

	public void L91B104()
	{
		A = [0xB2A5 + X];
		[0x00] = A;
		P |= 0x20;
		A = [0xB2A7 + X];
		[0x02] = A;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		return [[0x0000]]();    //24-Bit Address
	}

	public void L91B117()
	{
		A = [0x0B1C + X];

		if (Z == 1)
			return this.L91B121();

		[0x0B1C + X]--;
		return this.L91B0C5();
	}

	public void L91B121()
	{
		A = [0x0B10 + X];
		[0x00] = A;
		A = [(0x00)];
		A &= 0x00FF;
		temp = A - 0x0081;

		if (Z == 0)
			return this.L91B133();

		return this.L91B17E();
	}

	public void L91B133()
	{
		temp = A - 0x0083;

		if (Z == 0)
			return this.L91B13B();

		return this.L91B216();
	}

	public void L91B13B()
	{
		Y = A;
		A &= 0x00C0;
		temp = A - 0x00C0;

		if (Z == 0)
			return this.L91B147();

		return this.L91B221();
	}

	public void L91B147()
	{
		A = Y;
		A &= 0x00A0;
		temp = A - 0x00A0;

		if (Z == 0)
			return this.L91B153();

		return this.L91B23B();
	}

	public void L91B153()
	{
		A = Y;
		temp = A - 0x0085;

		if (Z == 0)
			return this.L91B15C();

		return this.L91B29F();
	}

	public void L91B15C()
	{
		temp = A - 0x0086;

		if (Z == 0)
			return this.L91B164();

		return this.L91B263();
	}

	public void L91B164()
	{
		temp = A - 0x0087;

		if (Z == 0)
			return this.L91B16C();

		return this.L91B281();
	}

	public void L91B16C()
	{
		temp = A - 0x0082;

		if (Z == 0)
			return this.L91B174();

		return this.L91B1C8();
	}

	public void L91B174()
	{
		A &= 0x0080;

		if (Z == 0)
			return this.L91B17C();

		return this.L91B208();
	}

	public void L91B17C()
	{
		return this.L91B17C();
	}

	public void L91B17E()
	{
		Stack.Push(X);
		Y = 0x0001;
		A = [(0x00) + Y];
		A &= 0x00FF;
		A <<= 1;
		[0x12] = A;
		Y++;
		A = [(0x00) + Y];
		A &= 0x00FF;
		[0x14] = A;
		Y++;
		A = [(0x00) + Y];
		A <<= 1;
		[0x16] = A;
	}

	public void L91B198()
	{
		X = [0x16];
		A = [0x7F0761 + X];
		Y = A;
		A = [0x7F1261 + X];
		X = [0x12];
		[0x7F1061 + X] = A;
		A = Y;
		[0x7F0561 + X] = A;
		[0x12]++;
		[0x12]++;
		[0x16]++;
		[0x16]++;
		[0x14]--;

		if (Z == 0)
			return this.L91B198();

		X = Stack.Pop();
		A = [0x0B10 + X];
		C = 0;
		A += 0x0005 + C;
		[0x0B10 + X] = A;
		return this.L91B121();
	}

	public void L91B1C8()
	{
		Stack.Push(X);
		Y = 0x0001;
		A = [(0x00) + Y];
		A &= 0x00FF;
		A <<= 1;
		[0x12] = A;
		Y++;
		A = [(0x00) + Y];
		A &= 0x00FF;
		[0x14] = A;
		Y++;
		A = [(0x00) + Y];
		A <<= 1;
		[0x16] = A;
	}

	public void L91B1E2()
	{
		X = [0x16];
		A = [0x7F0761 + X];
		X = [0x12];
		[0x7F0561 + X] = A;
		[0x12]++;
		[0x12]++;
		[0x16]++;
		[0x16]++;
		[0x14]--;

		if (Z == 0)
			return this.L91B1E2();

		X = Stack.Pop();
		A = [0x0B10 + X];
		C = 0;
		A += 0x0005 + C;
		[0x0B10 + X] = A;
		return this.L91B121();
	}

	public void L91B208()
	{
		A = [(0x00)];
		A &= 0x00FF;
		[0x0B1C + X] = A;
		[0x0B10 + X]++;
		return this.L91B0C5();
	}

	public void L91B216()
	{
		Y = 0x0001;
		A = [(0x00) + Y];
		[0x0B10 + X] = A;
		return this.L91B121();
	}

	public void L91B221()
	{
		A = [(0x00)];
		A &= 0x001F;
		A <<= 1;
		Y = A;
		[0x00]++;
		A = [(0x00)];
		A &= 0x00FF;
		[0x0B28 + Y] = A;
		[0x0B10 + X]++;
		[0x0B10 + X]++;
		return this.L91B121();
	}

	public void L91B23B()
	{
		A = [(0x00)];
		A &= 0x001F;
		A <<= 1;
		Y = A;
		A = [0x0B28 + Y];
		A--;
		[0x0B28 + Y] = A;

		if (Z == 1)
			return this.L91B256();

		Y = 0x0001;
		A = [(0x00) + Y];
		[0x0B10 + X] = A;
		return this.L91B121();
	}

	public void L91B256()
	{
		A = [0x0B10 + X];
		C = 0;
		A += 0x0003 + C;
		[0x0B10 + X] = A;
		return this.L91B121();
	}

	public void L91B263()
	{
		Y = 0x0001;
		A = [(0x00) + Y];
		Y = A;
		A = [0x0B04 + Y];

		if (Z == 1)
			return this.L91B274();

		A = 0xFFFF;
		[0x0B04 + Y] = A;
	}

	public void L91B274()
	{
		A = [0x0B10 + X];
		C = 0;
		A += 0x0002 + C;
		[0x0B10 + X] = A;
		return this.L91B0C5();
	}

	public void L91B281()
	{
		Y = 0x0001;
		A = [(0x00) + Y];
		Y = A;
		A = [0x0B04 + Y];

		if (Z == 1)
			return this.L91B292();

		A = 0x0001;
		[0x0B04 + Y] = A;
	}

	public void L91B292()
	{
		A = [0x0B10 + X];
		C = 0;
		A += 0x0002 + C;
		[0x0B10 + X] = A;
		return this.L91B0C5();
	}

	public void L91B29F()
	{
		[0x0B04 + X] = 0;
		return this.L91B0C5();
	}







	public void R8ECB6E()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x7E6AF6];
		A &= 0x00FF;
		A <<= 1;
		X = A;
		Cpu.JSR((0xCB84 + X));
		this.R8ECB90();
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}








	public void R8ECB90()
	{
		this.R8EDC74();
		return;
	}








	public void R8EDC74()
	{
		P &= ~0x20;
		A = [0x0B00];
		
		if (N == 1)
			return this.L8EDC8C_Done();

		A = [0x7E6AEA];
		temp = A - 0x0001;
		
		if (Z == 1)
			return this.L8EDC8C_Done();

		this.R91B091();
		this.R90829B();
	}

	public void L8EDC8C_Done()
	{
		return;
	}








	public void R90829B()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = 0x9000;
		[0x01] = A;
		A = 0x82B0;
		[0x00] = A;
		this.R8087A4_LoadDmaTransferRecord();
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}








	public void R91B091()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x0B00];
		temp = A - [0x0B02];
		
		if (Z == 0)
			return this.L91B0D2();

		temp = A - 0xFFFF;
		
		if (Z == 1)
			return this.L91B0C9();

		A = [0x0B04];
		A |= [0x0B06];
		A |= [0x0B08];
		A |= [0x0B0A];
		A |= [0x0B0C];
		A |= [0x0B0E];
		
		if (Z == 0)
			return this.L91B0BB();

		A = [0x0B34];
		
		if (Z == 0)
			return this.L91B0CC();
	}

	public void L91B0BB()
	{
		X = 0x000A;
	}

	public void L91B0BE()
	{
		A = [0x0B04 + X];
		
		if (Z == 1)
			return this.L91B0C5();

		
		if (N == 0)
			return this.L91B117();

	}

	public void L91B0C5()
	{
		X--;
		X--;
		
		if (N == 0)
			return this.L91B0BE();

	}

	public void L91B0C9_Done()
	{
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L91B0CC()
	{
		A = 0xFFFF;
		[0x0B00] = A;
	}

	public void L91B0D2()
	{
		[0x0B0E] = 0;
		[0x0B26] = 0;
		A = [0x0B00];
		[0x0B02] = A;
		temp = A - 0xFFFF;
		
		if (Z == 1)
			return this.L91B0F0();

		[0x12] = A;
		A <<= 1;
		C = 0;
		A += [0x12] + C;
		X = A;
		this.L91B104();
		return this.L91B0BB();
	}

	public void L91B0F0()
	{
		[0x0B04] = 0;
		[0x0B06] = 0;
		[0x0B08] = 0;
		[0x0B0A] = 0;
		[0x0B0C] = 0;
		[0x0B0E] = 0;
		return this.L91B0C9();
	}

	public void L91B104()
	{
		A = [0xB2A5 + X];
		[0x00] = A;
		P |= 0x20;
		A = [0xB2A7 + X];
		[0x02] = A;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		return [[0x0000]]();	//24-Bit Address
	}

	public void L91B117()
	{
		A = [0x0B1C + X];
		
		if (Z == 1)
			return this.L91B121();

		[0x0B1C + X]--;
		return this.L91B0C5();
	}

	public void L91B121()
	{
		A = [0x0B10 + X];
		[0x00] = A;
		A = [(0x00)];
		A &= 0x00FF;
		temp = A - 0x0081;
		
		if (Z == 0)
			return this.L91B133();

		return this.L91B17E();
	}

	public void L91B133()
	{
		temp = A - 0x0083;
		
		if (Z == 0)
			return this.L91B13B();

		return this.L91B216();
	}

	public void L91B13B()
	{
		Y = A;
		A &= 0x00C0;
		temp = A - 0x00C0;
		
		if (Z == 0)
			return this.L91B147();

		return this.L91B221();
	}

	public void L91B147()
	{
		A = Y;
		A &= 0x00A0;
		temp = A - 0x00A0;
		
		if (Z == 0)
			return this.L91B153();

		return this.L91B23B();
	}

	public void L91B153()
	{
		A = Y;
		temp = A - 0x0085;
		
		if (Z == 0)
			return this.L91B15C();

		return this.L91B29F();
	}

	public void L91B15C()
	{
		temp = A - 0x0086;
		
		if (Z == 0)
			return this.L91B164();

		return this.L91B263();
	}

	public void L91B164()
	{
		temp = A - 0x0087;
		
		if (Z == 0)
			return this.L91B16C();

		return this.L91B281();
	}

	public void L91B16C()
	{
		temp = A - 0x0082;
		
		if (Z == 0)
			return this.L91B174();

		return this.L91B1C8();
	}

	public void L91B174()
	{
		A &= 0x0080;
		
		if (Z == 0)
			return this.L91B17C();

		return this.L91B208();
	}

	public void L91B17C()
	{
		return this.L91B17C();
	}

	public void L91B17E()
	{
		Stack.Push(X);
		Y = 0x0001;
		A = [(0x00) + Y];
		A &= 0x00FF;
		A <<= 1;
		[0x12] = A;
		Y++;
		A = [(0x00) + Y];
		A &= 0x00FF;
		[0x14] = A;
		Y++;
		A = [(0x00) + Y];
		A <<= 1;
		[0x16] = A;
	}

	public void L91B198()
	{
		X = [0x16];
		A = [0x7F0761 + X];
		Y = A;
		A = [0x7F1261 + X];
		X = [0x12];
		[0x7F1061 + X] = A;
		A = Y;
		[0x7F0561 + X] = A;
		[0x12]++;
		[0x12]++;
		[0x16]++;
		[0x16]++;
		[0x14]--;
		
		if (Z == 0)
			return this.L91B198();

		X = Stack.Pop();
		A = [0x0B10 + X];
		C = 0;
		A += 0x0005 + C;
		[0x0B10 + X] = A;
		return this.L91B121();
	}

	public void L91B1C8()
	{
		Stack.Push(X);
		Y = 0x0001;
		A = [(0x00) + Y];
		A &= 0x00FF;
		A <<= 1;
		[0x12] = A;
		Y++;
		A = [(0x00) + Y];
		A &= 0x00FF;
		[0x14] = A;
		Y++;
		A = [(0x00) + Y];
		A <<= 1;
		[0x16] = A;
	}

	public void L91B1E2()
	{
		X = [0x16];
		A = [0x7F0761 + X];
		X = [0x12];
		[0x7F0561 + X] = A;
		[0x12]++;
		[0x12]++;
		[0x16]++;
		[0x16]++;
		[0x14]--;
		
		if (Z == 0)
			return this.L91B1E2();

		X = Stack.Pop();
		A = [0x0B10 + X];
		C = 0;
		A += 0x0005 + C;
		[0x0B10 + X] = A;
		return this.L91B121();
	}

	public void L91B208()
	{
		A = [(0x00)];
		A &= 0x00FF;
		[0x0B1C + X] = A;
		[0x0B10 + X]++;
		return this.L91B0C5();
	}

	public void L91B216()
	{
		Y = 0x0001;
		A = [(0x00) + Y];
		[0x0B10 + X] = A;
		return this.L91B121();
	}

	public void L91B221()
	{
		A = [(0x00)];
		A &= 0x001F;
		A <<= 1;
		Y = A;
		[0x00]++;
		A = [(0x00)];
		A &= 0x00FF;
		[0x0B28 + Y] = A;
		[0x0B10 + X]++;
		[0x0B10 + X]++;
		return this.L91B121();
	}

	public void L91B23B()
	{
		A = [(0x00)];
		A &= 0x001F;
		A <<= 1;
		Y = A;
		A = [0x0B28 + Y];
		A--;
		[0x0B28 + Y] = A;
		
		if (Z == 1)
			return this.L91B256();

		Y = 0x0001;
		A = [(0x00) + Y];
		[0x0B10 + X] = A;
		return this.L91B121();
	}

	public void L91B256()
	{
		A = [0x0B10 + X];
		C = 0;
		A += 0x0003 + C;
		[0x0B10 + X] = A;
		return this.L91B121();
	}

	public void L91B263()
	{
		Y = 0x0001;
		A = [(0x00) + Y];
		Y = A;
		A = [0x0B04 + Y];
		
		if (Z == 1)
			return this.L91B274();

		A = 0xFFFF;
		[0x0B04 + Y] = A;
	}

	public void L91B274()
	{
		A = [0x0B10 + X];
		C = 0;
		A += 0x0002 + C;
		[0x0B10 + X] = A;
		return this.L91B0C5();
	}

	public void L91B281()
	{
		Y = 0x0001;
		A = [(0x00) + Y];
		Y = A;
		A = [0x0B04 + Y];
		
		if (Z == 1)
			return this.L91B292();

		A = 0x0001;
		[0x0B04 + Y] = A;
	}

	public void L91B292()
	{
		A = [0x0B10 + X];
		C = 0;
		A += 0x0002 + C;
		[0x0B10 + X] = A;
		return this.L91B0C5();
	}

	public void L91B29F()
	{
		[0x0B04 + X] = 0;
		return this.L91B0C5();
	}







	public void L91B091()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x0B00];
		temp = A - [0x0B02];

		if (Z == 0)
			return this.L91B0D2();

		temp = A - 0xFFFF;

		if (Z == 1)
			return this.L91B0C9();

		A = [0x0B04];
		A |= [0x0B06];
		A |= [0x0B08];
		A |= [0x0B0A];
		A |= [0x0B0C];
		A |= [0x0B0E];

		if (Z == 0)
			return this.L91B0BB();

		A = [0x0B34];

		if (Z == 0)
			return this.L91B0CC();

	}

	public void L91B0BB()
	{
		X = 0x000A;
	}

	public void L91B0BE()
	{
		A = [0x0B04 + X];

		if (Z == 1)
			return this.L91B0C5();


		if (N == 0)
			return this.L91B117();

	}

	public void L91B0C5()
	{
		X--;
		X--;

		if (N == 0)
			return this.L91B0BE();

	}

	public void L91B0C9()
	{
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L91B0CC()
	{
		A = 0xFFFF;
		[0x0B00] = A;
	}

	public void L91B0D2()
	{
		[0x0B0E] = 0;
		[0x0B26] = 0;
		A = [0x0B00];
		[0x0B02] = A;
		temp = A - 0xFFFF;

		if (Z == 1)
			return this.L91B0F0();

		[0x12] = A;
		A <<= 1;
		C = 0;
		A += [0x12] + C;
		X = A;
		this.L91B104();
		return this.L91B0BB();
	}

	public void L91B0F0()
	{
		[0x0B04] = 0;
		[0x0B06] = 0;
		[0x0B08] = 0;
		[0x0B0A] = 0;
		[0x0B0C] = 0;
		[0x0B0E] = 0;
		return this.L91B0C9();
	}

	public void L91B104()
	{
		A = [0xB2A5 + X];
		[0x00] = A;
		P |= 0x20;
		A = [0xB2A7 + X];
		[0x02] = A;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		return [[0x0000]]();    //24-Bit Address
	}

	public void L91B117()
	{
		A = [0x0B1C + X];

		if (Z == 1)
			return this.L91B121();

		[0x0B1C + X]--;
		return this.L91B0C5();
	}

	public void L91B121()
	{
		A = [0x0B10 + X];
		[0x00] = A;
		A = [(0x00)];
		A &= 0x00FF;
		temp = A - 0x0081;

		if (Z == 0)
			return this.L91B133();

		return this.L91B17E();
	}

	public void L91B133()
	{
		temp = A - 0x0083;

		if (Z == 0)
			return this.L91B13B();

		return this.L91B216();
	}

	public void L91B13B()
	{
		Y = A;
		A &= 0x00C0;
		temp = A - 0x00C0;

		if (Z == 0)
			return this.L91B147();

		return this.L91B221();
	}

	public void L91B147()
	{
		A = Y;
		A &= 0x00A0;
		temp = A - 0x00A0;

		if (Z == 0)
			return this.L91B153();

		return this.L91B23B();
	}

	public void L91B153()
	{
		A = Y;
		temp = A - 0x0085;

		if (Z == 0)
			return this.L91B15C();

		return this.L91B29F();
	}

	public void L91B15C()
	{
		temp = A - 0x0086;

		if (Z == 0)
			return this.L91B164();

		return this.L91B263();
	}

	public void L91B164()
	{
		temp = A - 0x0087;

		if (Z == 0)
			return this.L91B16C();

		return this.L91B281();
	}

	public void L91B16C()
	{
		temp = A - 0x0082;

		if (Z == 0)
			return this.L91B174();

		return this.L91B1C8();
	}

	public void L91B174()
	{
		A &= 0x0080;

		if (Z == 0)
			return this.L91B17C();

		return this.L91B208();
	}

	public void L91B17C()
	{
		return this.L91B17C();
	}

	public void L91B17E()
	{
		Stack.Push(X);
		Y = 0x0001;
		A = [(0x00) + Y];
		A &= 0x00FF;
		A <<= 1;
		[0x12] = A;
		Y++;
		A = [(0x00) + Y];
		A &= 0x00FF;
		[0x14] = A;
		Y++;
		A = [(0x00) + Y];
		A <<= 1;
		[0x16] = A;
	}

	public void L91B198()
	{
		X = [0x16];
		A = [0x7F0761 + X];
		Y = A;
		A = [0x7F1261 + X];
		X = [0x12];
		[0x7F1061 + X] = A;
		A = Y;
		[0x7F0561 + X] = A;
		[0x12]++;
		[0x12]++;
		[0x16]++;
		[0x16]++;
		[0x14]--;

		if (Z == 0)
			return this.L91B198();

		X = Stack.Pop();
		A = [0x0B10 + X];
		C = 0;
		A += 0x0005 + C;
		[0x0B10 + X] = A;
		return this.L91B121();
	}

	public void L91B1C8()
	{
		Stack.Push(X);
		Y = 0x0001;
		A = [(0x00) + Y];
		A &= 0x00FF;
		A <<= 1;
		[0x12] = A;
		Y++;
		A = [(0x00) + Y];
		A &= 0x00FF;
		[0x14] = A;
		Y++;
		A = [(0x00) + Y];
		A <<= 1;
		[0x16] = A;
	}

	public void L91B1E2()
	{
		X = [0x16];
		A = [0x7F0761 + X];
		X = [0x12];
		[0x7F0561 + X] = A;
		[0x12]++;
		[0x12]++;
		[0x16]++;
		[0x16]++;
		[0x14]--;

		if (Z == 0)
			return this.L91B1E2();

		X = Stack.Pop();
		A = [0x0B10 + X];
		C = 0;
		A += 0x0005 + C;
		[0x0B10 + X] = A;
		return this.L91B121();
	}

	public void L91B208()
	{
		A = [(0x00)];
		A &= 0x00FF;
		[0x0B1C + X] = A;
		[0x0B10 + X]++;
		return this.L91B0C5();
	}

	public void L91B216()
	{
		Y = 0x0001;
		A = [(0x00) + Y];
		[0x0B10 + X] = A;
		return this.L91B121();
	}

	public void L91B221()
	{
		A = [(0x00)];
		A &= 0x001F;
		A <<= 1;
		Y = A;
		[0x00]++;
		A = [(0x00)];
		A &= 0x00FF;
		[0x0B28 + Y] = A;
		[0x0B10 + X]++;
		[0x0B10 + X]++;
		return this.L91B121();
	}

	public void L91B23B()
	{
		A = [(0x00)];
		A &= 0x001F;
		A <<= 1;
		Y = A;
		A = [0x0B28 + Y];
		A--;
		[0x0B28 + Y] = A;

		if (Z == 1)
			return this.L91B256();

		Y = 0x0001;
		A = [(0x00) + Y];
		[0x0B10 + X] = A;
		return this.L91B121();
	}

	public void L91B256()
	{
		A = [0x0B10 + X];
		C = 0;
		A += 0x0003 + C;
		[0x0B10 + X] = A;
		return this.L91B121();
	}

	public void L91B263()
	{
		Y = 0x0001;
		A = [(0x00) + Y];
		Y = A;
		A = [0x0B04 + Y];

		if (Z == 1)
			return this.L91B274();

		A = 0xFFFF;
		[0x0B04 + Y] = A;
	}

	public void L91B274()
	{
		A = [0x0B10 + X];
		C = 0;
		A += 0x0002 + C;
		[0x0B10 + X] = A;
		return this.L91B0C5();
	}

	public void L91B281()
	{
		Y = 0x0001;
		A = [(0x00) + Y];
		Y = A;
		A = [0x0B04 + Y];

		if (Z == 1)
			return this.L91B292();

		A = 0x0001;
		[0x0B04 + Y] = A;
	}

	public void L91B292()
	{
		A = [0x0B10 + X];
		C = 0;
		A += 0x0002 + C;
		[0x0B10 + X] = A;
		return this.L91B0C5();
	}

	public void L91B29F()
	{
		[0x0B04 + X] = 0;
		return this.L91B0C5();
	}









	public void L91B0BB()
	{
		X = 0x000A;
	}

	public void L91B0BE()
	{
		A = [0x0B04 + X];

		if (Z == 1)
			return this.L91B0C5();


		if (N == 0)
			return this.L91B117();

	}

	public void L91B0C5()
	{
		X--;
		X--;

		if (N == 0)
			return this.L91B0BE();

	}

	public void L91B0C9()
	{
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L91B0CC()
	{
		A = 0xFFFF;
		[0x0B00] = A;
	}

	public void L91B0D2()
	{
		[0x0B0E] = 0;
		[0x0B26] = 0;
		A = [0x0B00];
		[0x0B02] = A;
		temp = A - 0xFFFF;

		if (Z == 1)
			return this.L91B0F0();

		[0x12] = A;
		A <<= 1;
		C = 0;
		A += [0x12] + C;
		X = A;
		this.L91B104();
		return this.L91B0BB();
	}

	public void L91B0F0()
	{
		[0x0B04] = 0;
		[0x0B06] = 0;
		[0x0B08] = 0;
		[0x0B0A] = 0;
		[0x0B0C] = 0;
		[0x0B0E] = 0;
		return this.L91B0C9();
	}

	public void L91B104()
	{
		A = [0xB2A5 + X];
		[0x00] = A;
		P |= 0x20;
		A = [0xB2A7 + X];
		[0x02] = A;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		return [[0x0000]]();    //24-Bit Address
	}

	public void L91B117()
	{
		A = [0x0B1C + X];

		if (Z == 1)
			return this.L91B121();

		[0x0B1C + X]--;
		return this.L91B0C5();
	}

	public void L91B121()
	{
		A = [0x0B10 + X];
		[0x00] = A;
		A = [(0x00)];
		A &= 0x00FF;
		temp = A - 0x0081;

		if (Z == 0)
			return this.L91B133();

		return this.L91B17E();
	}

	public void L91B133()
	{
		temp = A - 0x0083;

		if (Z == 0)
			return this.L91B13B();

		return this.L91B216();
	}

	public void L91B13B()
	{
		Y = A;
		A &= 0x00C0;
		temp = A - 0x00C0;

		if (Z == 0)
			return this.L91B147();

		return this.L91B221();
	}

	public void L91B147()
	{
		A = Y;
		A &= 0x00A0;
		temp = A - 0x00A0;

		if (Z == 0)
			return this.L91B153();

		return this.L91B23B();
	}

	public void L91B153()
	{
		A = Y;
		temp = A - 0x0085;

		if (Z == 0)
			return this.L91B15C();

		return this.L91B29F();
	}

	public void L91B15C()
	{
		temp = A - 0x0086;

		if (Z == 0)
			return this.L91B164();

		return this.L91B263();
	}

	public void L91B164()
	{
		temp = A - 0x0087;

		if (Z == 0)
			return this.L91B16C();

		return this.L91B281();
	}

	public void L91B16C()
	{
		temp = A - 0x0082;

		if (Z == 0)
			return this.L91B174();

		return this.L91B1C8();
	}

	public void L91B174()
	{
		A &= 0x0080;

		if (Z == 0)
			return this.L91B17C();

		return this.L91B208();
	}

	public void L91B17C()
	{
		return this.L91B17C();
	}

	public void L91B17E()
	{
		Stack.Push(X);
		Y = 0x0001;
		A = [(0x00) + Y];
		A &= 0x00FF;
		A <<= 1;
		[0x12] = A;
		Y++;
		A = [(0x00) + Y];
		A &= 0x00FF;
		[0x14] = A;
		Y++;
		A = [(0x00) + Y];
		A <<= 1;
		[0x16] = A;
	}

	public void L91B198()
	{
		X = [0x16];
		A = [0x7F0761 + X];
		Y = A;
		A = [0x7F1261 + X];
		X = [0x12];
		[0x7F1061 + X] = A;
		A = Y;
		[0x7F0561 + X] = A;
		[0x12]++;
		[0x12]++;
		[0x16]++;
		[0x16]++;
		[0x14]--;

		if (Z == 0)
			return this.L91B198();

		X = Stack.Pop();
		A = [0x0B10 + X];
		C = 0;
		A += 0x0005 + C;
		[0x0B10 + X] = A;
		return this.L91B121();
	}

	public void L91B1C8()
	{
		Stack.Push(X);
		Y = 0x0001;
		A = [(0x00) + Y];
		A &= 0x00FF;
		A <<= 1;
		[0x12] = A;
		Y++;
		A = [(0x00) + Y];
		A &= 0x00FF;
		[0x14] = A;
		Y++;
		A = [(0x00) + Y];
		A <<= 1;
		[0x16] = A;
	}

	public void L91B1E2()
	{
		X = [0x16];
		A = [0x7F0761 + X];
		X = [0x12];
		[0x7F0561 + X] = A;
		[0x12]++;
		[0x12]++;
		[0x16]++;
		[0x16]++;
		[0x14]--;

		if (Z == 0)
			return this.L91B1E2();

		X = Stack.Pop();
		A = [0x0B10 + X];
		C = 0;
		A += 0x0005 + C;
		[0x0B10 + X] = A;
		return this.L91B121();
	}

	public void L91B208()
	{
		A = [(0x00)];
		A &= 0x00FF;
		[0x0B1C + X] = A;
		[0x0B10 + X]++;
		return this.L91B0C5();
	}

	public void L91B216()
	{
		Y = 0x0001;
		A = [(0x00) + Y];
		[0x0B10 + X] = A;
		return this.L91B121();
	}

	public void L91B221()
	{
		A = [(0x00)];
		A &= 0x001F;
		A <<= 1;
		Y = A;
		[0x00]++;
		A = [(0x00)];
		A &= 0x00FF;
		[0x0B28 + Y] = A;
		[0x0B10 + X]++;
		[0x0B10 + X]++;
		return this.L91B121();
	}

	public void L91B23B()
	{
		A = [(0x00)];
		A &= 0x001F;
		A <<= 1;
		Y = A;
		A = [0x0B28 + Y];
		A--;
		[0x0B28 + Y] = A;

		if (Z == 1)
			return this.L91B256();

		Y = 0x0001;
		A = [(0x00) + Y];
		[0x0B10 + X] = A;
		return this.L91B121();
	}

	public void L91B256()
	{
		A = [0x0B10 + X];
		C = 0;
		A += 0x0003 + C;
		[0x0B10 + X] = A;
		return this.L91B121();
	}

	public void L91B263()
	{
		Y = 0x0001;
		A = [(0x00) + Y];
		Y = A;
		A = [0x0B04 + Y];

		if (Z == 1)
			return this.L91B274();

		A = 0xFFFF;
		[0x0B04 + Y] = A;
	}

	public void L91B274()
	{
		A = [0x0B10 + X];
		C = 0;
		A += 0x0002 + C;
		[0x0B10 + X] = A;
		return this.L91B0C5();
	}

	public void L91B281()
	{
		Y = 0x0001;
		A = [(0x00) + Y];
		Y = A;
		A = [0x0B04 + Y];

		if (Z == 1)
			return this.L91B292();

		A = 0x0001;
		[0x0B04 + Y] = A;
	}

	public void L91B292()
	{
		A = [0x0B10 + X];
		C = 0;
		A += 0x0002 + C;
		[0x0B10 + X] = A;
		return this.L91B0C5();
	}

	public void L91B29F()
	{
		[0x0B04 + X] = 0;
		return this.L91B0C5();
	}

	public void L9BD1EC()
	{
		A = [0x197C];
		[0x12] = A;
		A = [0x197E];
		[0x14] = A;
		A = [0x14];
		Cpu.ROL();
		Cpu.ROR(0x14);
		Cpu.ROR(0x12);
		A = [0x14];
		Cpu.ROL();
		Cpu.ROR(0x14);
		Cpu.ROR(0x12);
		C = 1;
		A = [0x7E5DDC];
		A -= [0x12] - !C;
		[0x7E5DDC] = A;
		A = [0x7E5DE4];
		A -= [0x14] - !C;
		[0x7E5DE4] = A;
		A = [0x14];
		Cpu.ROL();
		Cpu.ROR(0x14);
		Cpu.ROR(0x12);
		C = 1;
		A = [0x7E5DDE];
		A -= [0x12] - !C;
		[0x7E5DDE] = A;
		A = [0x7E5DE6];
		A -= [0x14] - !C;
		[0x7E5DE6] = A;
		A = [0x1988];
		[0x12] = A;
		A = [0x198A];
		[0x14] = A;
		A = [0x14];
		Cpu.ROL();
		Cpu.ROR(0x14);
		Cpu.ROR(0x12);
		A = [0x14];
		Cpu.ROL();
		Cpu.ROR(0x14);
		Cpu.ROR(0x12);
		C = 1;
		A = [0x7E5DEC];
		A -= [0x12] - !C;
		[0x7E5DEC] = A;
		A = [0x7E5DF4];
		A -= [0x14] - !C;
		[0x7E5DF4] = A;
		A = [0x14];
		Cpu.ROL();
		Cpu.ROR(0x14);
		Cpu.ROR(0x12);
		C = 1;
		A = [0x7E5DEE];
		A -= [0x12] - !C;
		[0x7E5DEE] = A;
		A = [0x7E5DF6];
		A -= [0x14] - !C;
		[0x7E5DF6] = A;
		A = [0x7E5DE4];
		C = 0;
		A += 0x00A0 + C;
		A &= 0x01FF;
		[0xB0] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x0128;

		if (C == 1)
			return this.L9BD2AE();

		A = [0x7E5DF4];
		C = 0;
		A += 0x00E0 + C;
		A &= 0x00FF;
		[0xB2] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x00D0;

		if (C == 1)
			return this.L9BD2AE();

		this.R9BD54D();
	}

	public void L9BD2AE()
	{
		A = [0x7E5DE4];
		C = 0;
		A += 0x0004 + C;
		A &= 0x01FF;
		[0xB0] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x0128;

		if (C == 1)
			return this.L9BD2DE();

		A = [0x7E5DF4];
		C = 0;
		A += 0x0040 + C;
		A &= 0x00FF;
		[0xB2] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x00D0;

		if (C == 1)
			return this.L9BD2DE();

		this.R9BD54D();
	}

	public void L9BD2DE()
	{
		A = [0x7E5DE4];
		C = 0;
		A += 0x00FC + C;
		A &= 0x01FF;
		[0xB0] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x0128;

		if (C == 1)
			return this.L9BD30E();

		A = [0x7E5DF4];
		C = 0;
		A += 0x0003 + C;
		A &= 0x00FF;
		[0xB2] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x00D0;

		if (C == 1)
			return this.L9BD30E();

		this.R9BD54D();
	}

	public void L9BD30E()
	{
		A = [0x7E5DE4];
		C = 0;
		A += 0x0000 + C;
		A &= 0x01FF;
		[0xB0] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x0128;

		if (C == 1)
			return this.L9BD33E();

		A = [0x7E5DF4];
		C = 0;
		A += 0x0060 + C;
		A &= 0x00FF;
		[0xB2] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x00D0;

		if (C == 1)
			return this.L9BD33E();

		this.L9BD594();
	}

	public void L9BD33E()
	{
		A = [0x7E5DE4];
		C = 0;
		A += 0x0060 + C;
		A &= 0x01FF;
		[0xB0] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x0128;

		if (C == 1)
			return this.L9BD36E();

		A = [0x7E5DF4];
		C = 0;
		A += 0x0000 + C;
		A &= 0x00FF;
		[0xB2] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x00D0;

		if (C == 1)
			return this.L9BD36E();

		this.L9BD594();
	}

	public void L9BD36E()
	{
		A = [0x7E5DE4];
		C = 0;
		A += 0x0080 + C;
		A &= 0x01FF;
		[0xB0] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x0128;

		if (C == 1)
			return this.L9BD39E();

		A = [0x7E5DF4];
		C = 0;
		A += 0x0080 + C;
		A &= 0x00FF;
		[0xB2] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x00D0;

		if (C == 1)
			return this.L9BD39E();

		this.L9BD594();
	}

	public void L9BD39E()
	{
		A = [0x7E5DE6];
		C = 0;
		A += 0x00E4 + C;
		A &= 0x01FF;
		[0xB0] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x0128;

		if (C == 1)
			return this.L9BD3CE();

		A = [0x7E5DF6];
		C = 0;
		A += 0x0020 + C;
		A &= 0x00FF;
		[0xB2] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x00D0;

		if (C == 1)
			return this.L9BD3CE();

		this.L9BD4BF();
	}

	public void L9BD3CE()
	{
		A = [0x7E5DE6];
		C = 0;
		A += 0x002E + C;
		A &= 0x01FF;
		[0xB0] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x0128;

		if (C == 1)
			return this.L9BD3FE();

		A = [0x7E5DF6];
		C = 0;
		A += 0x0005 + C;
		A &= 0x00FF;
		[0xB2] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x00D0;

		if (C == 1)
			return this.L9BD3FE();

		this.L9BD4BF();
	}

	public void L9BD3FE()
	{
		A = [0x7E5DE6];
		C = 0;
		A += 0x00B8 + C;
		A &= 0x01FF;
		[0xB0] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x0128;

		if (C == 1)
			return this.L9BD42E();

		A = [0x7E5DF6];
		C = 0;
		A += 0x002E + C;
		A &= 0x00FF;
		[0xB2] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x00D0;

		if (C == 1)
			return this.L9BD42E();

		this.L9BD4BF();
	}

	public void L9BD42E()
	{
		A = [0x7E5DE6];
		C = 0;
		A += 0x0066 + C;
		A &= 0x01FF;
		[0xB0] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x0128;

		if (C == 1)
			return this.L9BD45E();

		A = [0x7E5DF6];
		C = 0;
		A += 0x0066 + C;
		A &= 0x00FF;
		[0xB2] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x00D0;

		if (C == 1)
			return this.L9BD45E();

		this.L9BD506();
	}

	public void L9BD45E()
	{
		A = [0x7E5DE6];
		C = 0;
		A += 0x0080 + C;
		A &= 0x01FF;
		[0xB0] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x0128;

		if (C == 1)
			return this.L9BD48E();

		A = [0x7E5DF6];
		C = 0;
		A += 0x009C + C;
		A &= 0x00FF;
		[0xB2] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x00D0;

		if (C == 1)
			return this.L9BD48E();

		this.L9BD506();
	}

	public void L9BD48E()
	{
		A = [0x7E5DE6];
		C = 0;
		A += 0x0020 + C;
		A &= 0x01FF;
		[0xB0] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x0128;

		if (C == 1)
			return this.L9BD4BE();

		A = [0x7E5DF6];
		C = 0;
		A += 0x0040 + C;
		A &= 0x00FF;
		[0xB2] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x00D0;

		if (C == 1)
			return this.L9BD4BE();

		this.L9BD506();
	}

	public void L9BD4BE()
	{
		return;
	}

	public void L9BD4BF()
	{
		Stack.Push(B);
		Stack.Push(P);
		P &= ~0x30;
		Y = [0xA6];
		temp = Y - 0x01FD;

		if (C == 0)
			return this.L9BD4CD();

		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L9BD4CD()
	{
		A = Y;
		C = 0;
		A += 0x0004 + C;
		[0xA6] = A;
		P |= 0x20;
		A = 0x82;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		A = [0xB0];
		C = 0;
		A += 0x01FC + C;
		[0x7800 + Y] = A;
		temp = A & 0x0100;

		if (Z == 1)
			return this.L9BD4F4();

		X = [0x82B6 + Y];
		A = [0x00 + X];
		A |= [0x82B8 + Y];
		[0x00 + X] = A;
	}

	public void L9BD4F4()
	{
		A = [0xB2];
		C = 0;
		A += 0x01FC + C;
		[0x7801 + Y] = A;
		A = 0x2E87;
		[0x7802 + Y] = A;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L9BD506()
	{
		Stack.Push(B);
		Stack.Push(P);
		P &= ~0x30;
		Y = [0xA6];
		temp = Y - 0x01FD;

		if (C == 0)
			return this.L9BD514();

		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L9BD514()
	{
		A = Y;
		C = 0;
		A += 0x0004 + C;
		[0xA6] = A;
		P |= 0x20;
		A = 0x82;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		A = [0xB0];
		C = 0;
		A += 0x01FB + C;
		[0x7800 + Y] = A;
		temp = A & 0x0100;

		if (Z == 1)
			return this.L9BD53B();

		X = [0x82B6 + Y];
		A = [0x00 + X];
		A |= [0x82B8 + Y];
		[0x00 + X] = A;
	}

	public void L9BD53B()
	{
		A = [0xB2];
		C = 0;
		A += 0x01FB + C;
		[0x7801 + Y] = A;
		A = 0x2E9C;
		[0x7802 + Y] = A;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void R9BD54D()
	{
		Stack.Push(B);
		Stack.Push(P);
		P &= ~0x30;
		Y = [0xA6];
		temp = Y - 0x01FD;

		if (C == 0)
			return this.L9BD55B();

		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L9BD55B()
	{
		A = Y;
		C = 0;
		A += 0x0004 + C;
		[0xA6] = A;
		P |= 0x20;
		A = 0x82;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		A = [0xB0];
		C = 0;
		A += 0x01FC + C;
		[0x7800 + Y] = A;
		temp = A & 0x0100;

		if (Z == 1)
			return this.L9BD582();

		X = [0x82B6 + Y];
		A = [0x00 + X];
		A |= [0x82B8 + Y];
		[0x00 + X] = A;
	}

	public void L9BD582()
	{
		A = [0xB2];
		C = 0;
		A += 0x01FC + C;
		[0x7801 + Y] = A;
		A = 0x2ED5;
		[0x7802 + Y] = A;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L9BD594()
	{
		Stack.Push(B);
		Stack.Push(P);
		P &= ~0x30;
		Y = [0xA6];
		temp = Y - 0x01FD;

		if (C == 0)
			return this.L9BD5A2();

		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L9BD5A2()
	{
		A = Y;
		C = 0;
		A += 0x0004 + C;
		[0xA6] = A;
		P |= 0x20;
		A = 0x82;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		A = [0xB0];
		C = 0;
		A += 0x01FC + C;
		[0x7800 + Y] = A;
		temp = A & 0x0100;

		if (Z == 1)
			return this.L9BD5C9();

		X = [0x82B6 + Y];
		A = [0x00 + X];
		A |= [0x82B8 + Y];
		[0x00 + X] = A;
	}

	public void L9BD5C9()
	{
		A = [0xB2];
		C = 0;
		A += 0x01FC + C;
		[0x7801 + Y] = A;
		A = 0x2ED4;
		[0x7802 + Y] = A;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}
















	public void L94C700()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x035D];
		A &= 0x00FF;
		A <<= 1;
		X = A;
		Cpu.JSR((0xC722 + X));
		A = [0x0100];
		A &= 0x0080;
		
		if (Z == 0)
			return this.L94C71F();

		this.L9094E4();
		this.L9084BD();
	}

	public void L94C71F()
	{
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}








	// Bank 0x9B
	public void R9BD1EC()
	{
		A = [0x197C];
		[0x12] = A;
		A = [0x197E];
		[0x14] = A;
		A = [0x14];
		Cpu.ROL();
		Cpu.ROR(0x14);
		Cpu.ROR(0x12);
		A = [0x14];
		Cpu.ROL();
		Cpu.ROR(0x14);
		Cpu.ROR(0x12);
		C = 1;
		A = [0x7E5DDC];
		A -= [0x12] - !C;
		[0x7E5DDC] = A;
		A = [0x7E5DE4];
		A -= [0x14] - !C;
		[0x7E5DE4] = A;
		A = [0x14];
		Cpu.ROL();
		Cpu.ROR(0x14);
		Cpu.ROR(0x12);
		C = 1;
		A = [0x7E5DDE];
		A -= [0x12] - !C;
		[0x7E5DDE] = A;
		A = [0x7E5DE6];
		A -= [0x14] - !C;
		[0x7E5DE6] = A;
		A = [0x1988];
		[0x12] = A;
		A = [0x198A];
		[0x14] = A;
		A = [0x14];
		Cpu.ROL();
		Cpu.ROR(0x14);
		Cpu.ROR(0x12);
		A = [0x14];
		Cpu.ROL();
		Cpu.ROR(0x14);
		Cpu.ROR(0x12);
		C = 1;
		A = [0x7E5DEC];
		A -= [0x12] - !C;
		[0x7E5DEC] = A;
		A = [0x7E5DF4];
		A -= [0x14] - !C;
		[0x7E5DF4] = A;
		A = [0x14];
		Cpu.ROL();
		Cpu.ROR(0x14);
		Cpu.ROR(0x12);
		C = 1;
		A = [0x7E5DEE];
		A -= [0x12] - !C;
		[0x7E5DEE] = A;
		A = [0x7E5DF6];
		A -= [0x14] - !C;
		[0x7E5DF6] = A;
		A = [0x7E5DE4];
		C = 0;
		A += 0x00A0 + C;
		A &= 0x01FF;
		[0xB0] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x0128;
		
		if (C == 1)
			return this.L9BD2AE();

		A = [0x7E5DF4];
		C = 0;
		A += 0x00E0 + C;
		A &= 0x00FF;
		[0xB2] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x00D0;
		
		if (C == 1)
			return this.L9BD2AE();

		this.R9BD54D();
	}

	public void L9BD2AE()
	{
		A = [0x7E5DE4];
		C = 0;
		A += 0x0004 + C;
		A &= 0x01FF;
		[0xB0] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x0128;
		
		if (C == 1)
			return this.L9BD2DE();

		A = [0x7E5DF4];
		C = 0;
		A += 0x0040 + C;
		A &= 0x00FF;
		[0xB2] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x00D0;
		
		if (C == 1)
			return this.L9BD2DE();

		this.R9BD54D();
	}

	public void L9BD2DE()
	{
		A = [0x7E5DE4];
		C = 0;
		A += 0x00FC + C;
		A &= 0x01FF;
		[0xB0] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x0128;
		
		if (C == 1)
			return this.L9BD30E();

		A = [0x7E5DF4];
		C = 0;
		A += 0x0003 + C;
		A &= 0x00FF;
		[0xB2] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x00D0;
		
		if (C == 1)
			return this.L9BD30E();

		this.R9BD54D();
	}

	public void L9BD30E()
	{
		A = [0x7E5DE4];
		C = 0;
		A += 0x0000 + C;
		A &= 0x01FF;
		[0xB0] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x0128;
		
		if (C == 1)
			return this.L9BD33E();

		A = [0x7E5DF4];
		C = 0;
		A += 0x0060 + C;
		A &= 0x00FF;
		[0xB2] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x00D0;
		
		if (C == 1)
			return this.L9BD33E();

		this.L9BD594();
	}

	public void L9BD33E()
	{
		A = [0x7E5DE4];
		C = 0;
		A += 0x0060 + C;
		A &= 0x01FF;
		[0xB0] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x0128;
		
		if (C == 1)
			return this.L9BD36E();

		A = [0x7E5DF4];
		C = 0;
		A += 0x0000 + C;
		A &= 0x00FF;
		[0xB2] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x00D0;
		
		if (C == 1)
			return this.L9BD36E();

		this.L9BD594();
	}

	public void L9BD36E()
	{
		A = [0x7E5DE4];
		C = 0;
		A += 0x0080 + C;
		A &= 0x01FF;
		[0xB0] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x0128;
		
		if (C == 1)
			return this.L9BD39E();

		A = [0x7E5DF4];
		C = 0;
		A += 0x0080 + C;
		A &= 0x00FF;
		[0xB2] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x00D0;
		
		if (C == 1)
			return this.L9BD39E();

		this.L9BD594();
	}

	public void L9BD39E()
	{
		A = [0x7E5DE6];
		C = 0;
		A += 0x00E4 + C;
		A &= 0x01FF;
		[0xB0] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x0128;
		
		if (C == 1)
			return this.L9BD3CE();

		A = [0x7E5DF6];
		C = 0;
		A += 0x0020 + C;
		A &= 0x00FF;
		[0xB2] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x00D0;
		
		if (C == 1)
			return this.L9BD3CE();

		this.L9BD4BF();
	}

	public void L9BD3CE()
	{
		A = [0x7E5DE6];
		C = 0;
		A += 0x002E + C;
		A &= 0x01FF;
		[0xB0] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x0128;
		
		if (C == 1)
			return this.L9BD3FE();

		A = [0x7E5DF6];
		C = 0;
		A += 0x0005 + C;
		A &= 0x00FF;
		[0xB2] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x00D0;
		
		if (C == 1)
			return this.L9BD3FE();

		this.L9BD4BF();
	}

	public void L9BD3FE()
	{
		A = [0x7E5DE6];
		C = 0;
		A += 0x00B8 + C;
		A &= 0x01FF;
		[0xB0] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x0128;
		
		if (C == 1)
			return this.L9BD42E();

		A = [0x7E5DF6];
		C = 0;
		A += 0x002E + C;
		A &= 0x00FF;
		[0xB2] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x00D0;
		
		if (C == 1)
			return this.L9BD42E();

		this.L9BD4BF();
	}

	public void L9BD42E()
	{
		A = [0x7E5DE6];
		C = 0;
		A += 0x0066 + C;
		A &= 0x01FF;
		[0xB0] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x0128;
		
		if (C == 1)
			return this.L9BD45E();

		A = [0x7E5DF6];
		C = 0;
		A += 0x0066 + C;
		A &= 0x00FF;
		[0xB2] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x00D0;
		
		if (C == 1)
			return this.L9BD45E();

		this.L9BD506();
	}

	public void L9BD45E()
	{
		A = [0x7E5DE6];
		C = 0;
		A += 0x0080 + C;
		A &= 0x01FF;
		[0xB0] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x0128;
		
		if (C == 1)
			return this.L9BD48E();

		A = [0x7E5DF6];
		C = 0;
		A += 0x009C + C;
		A &= 0x00FF;
		[0xB2] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x00D0;
		
		if (C == 1)
			return this.L9BD48E();

		this.L9BD506();
	}

	public void L9BD48E()
	{
		A = [0x7E5DE6];
		C = 0;
		A += 0x0020 + C;
		A &= 0x01FF;
		[0xB0] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x0128;
		
		if (C == 1)
			return this.L9BD4BE();

		A = [0x7E5DF6];
		C = 0;
		A += 0x0040 + C;
		A &= 0x00FF;
		[0xB2] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x00D0;
		
		if (C == 1)
			return this.L9BD4BE();

		this.L9BD506();
	}

	public void L9BD4BE()
	{
		return;
	}

	public void L9BD4BF()
	{
		Stack.Push(B);
		Stack.Push(P);
		P &= ~0x30;
		Y = [0xA6];
		temp = Y - 0x01FD;
		
		if (C == 0)
			return this.L9BD4CD();

		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L9BD4CD()
	{
		A = Y;
		C = 0;
		A += 0x0004 + C;
		[0xA6] = A;
		P |= 0x20;
		A = 0x82;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		A = [0xB0];
		C = 0;
		A += 0x01FC + C;
		[0x7800 + Y] = A;
		temp = A & 0x0100;
		
		if (Z == 1)
			return this.L9BD4F4();

		X = [0x82B6 + Y];
		A = [0x00 + X];
		A |= [0x82B8 + Y];
		[0x00 + X] = A;
	}

	public void L9BD4F4()
	{
		A = [0xB2];
		C = 0;
		A += 0x01FC + C;
		[0x7801 + Y] = A;
		A = 0x2E87;
		[0x7802 + Y] = A;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L9BD506()
	{
		Stack.Push(B);
		Stack.Push(P);
		P &= ~0x30;
		Y = [0xA6];
		temp = Y - 0x01FD;
		
		if (C == 0)
			return this.L9BD514();

		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L9BD514()
	{
		A = Y;
		C = 0;
		A += 0x0004 + C;
		[0xA6] = A;
		P |= 0x20;
		A = 0x82;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		A = [0xB0];
		C = 0;
		A += 0x01FB + C;
		[0x7800 + Y] = A;
		temp = A & 0x0100;
		
		if (Z == 1)
			return this.L9BD53B();

		X = [0x82B6 + Y];
		A = [0x00 + X];
		A |= [0x82B8 + Y];
		[0x00 + X] = A;
	}

	public void L9BD53B()
	{
		A = [0xB2];
		C = 0;
		A += 0x01FB + C;
		[0x7801 + Y] = A;
		A = 0x2E9C;
		[0x7802 + Y] = A;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}









	// Bank 0x94
	public void R94E94E()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		P |= 0x20;
		Y = 0x0017;
		X = 0x0000;
	}

	public void L94E95A()
	{
		A = [0x706002 + X];
		temp = A - [0xE90F + X];
		
		if (Z == 0)
			return this.L94E974();

		X++;
		Y--;
		
		if (N == 0)
			return this.L94E95A();

		P &= ~0x20;
		this.R94E9F3();
		A = [0x12];
		temp = A - [0x706000];
		
		if (Z == 1)
			return this.L94E977();

	}

	public void L94E974()
	{
		this.R94E97A();
	}

	public void L94E977()
	{
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void R94E97A()
	{
		P |= 0x20;
		Y = 0x0387;
		X = 0x0000;
	}

	public void L94E982()
	{
		A = 0xFF;
		[0x706002 + X] = A;
		X++;
		Y--;
		
		if (N == 0)
			return this.L94E982();

		Y = 0x0017;
		X = 0x0000;
	}

	public void L94E992()
	{
		A = [0xE90F + X];
		[0x706002 + X] = A;
		X++;
		Y--;
		
		if (N == 0)
			return this.L94E992();

		A = 0x00;
		[0x706058] = A;
		[0x706059] = A;
		[0x706057] = A;
		A = 0x07;
		[0x706056] = A;
		Y = 0x001F;
		X = 0x0000;
		A = 0x00;
	}

	public void L94E9B9()
	{
		[0x706028 + X] = A;
		[0x706090 + X] = A;
		X++;
		Y--;
		
		if (N == 0)
			return this.L94E9B9();

		P &= ~0x20;
		A = 0x001F;
		[0x70601A] = A;
		A = 0x0000;
		[0x70601E] = A;
		[0x70601C] = A;
		[0x706020] = A;
		[0x706022] = A;
		[0x706024] = A;
		[0x706026] = A;
		this.R94E9F3();
		A = [0x12];
		[0x706000] = A;
		return;
	}

	public void R94E9F3()
	{
		Stack.Push(P);
		P &= ~0x20;
		[0x12] = 0;
		P |= 0x20;
		Y = 0x0387;
		X = 0x0000;
	}

	public void L94EA00()
	{
		A = [0x706002 + X];
		C = 0;
		A += [0x12] + C;
		[0x12] = A;
		A = [0x13];
		A += 0x00 + C;
		[0x13] = A;
		X++;
		Y--;
		
		if (N == 0)
			return this.L94EA00();

		P = Stack.Pop();
		return;
	}







	public void R909993_ResetRam()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = 0xFFFF;
		[0x037F] = A;
		X = 0x0216;
		this.R909ACF_ResetRam3000();
		X = 0x04C6;
		this.R909ACF_ResetRam3000();
		A = 0xFFFF;
		[0x02F3] = A;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}








	public void R909ACF_ResetRam3000()
	{
		A = 0x0080;
		[0x7E3000 + X] = A;
		[0x7E3002 + X] = A;
		[0x7E3004 + X] = A;
		[0x7E3006 + X] = A;
		[0x7E3008 + X] = A;
		[0x7E300A + X] = A;
		[0x7E300C + X] = A;
		[0x7E300E + X] = A;
		[0x7E3010 + X] = A;
		[0x7E3012 + X] = A;
		[0x7E3040 + X] = A;
		[0x7E3042 + X] = A;
		[0x7E3044 + X] = A;
		[0x7E3046 + X] = A;
		[0x7E3048 + X] = A;
		[0x7E304A + X] = A;
		[0x7E304C + X] = A;
		[0x7E304E + X] = A;
		[0x7E3050 + X] = A;
		[0x7E3052 + X] = A;
		return;
	}







	public void R909CF9()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		this.R91B06F();
		A = 0x0000;
		[0x7E6AF6] = A;
		[0x7E5BF3] = A;
		[0x035D] = 0;
		[0x035F] = 0;
		[0x0365] = 0;
		[0x0371] = 0;
		[0x1BC7] = 0;
		[0x03C1] = 0;
		A = 0x0001;
		[0x0373] = A;
		A = 0x0002;
		[0x7E6B22] = A;
		[0x7E6B24] = A;
		A = 0x0000;
		[0x7FE717] = A;
		[0x7F052B] = A;
		this.R90A5AD();
		A = 0x0000;
		[0x7F0527] = A;
		A = 0x0009;
		[0x7F051B] = A;
		[0x7F051D] = A;
		[0x7F051F] = A;
		[0x7F0521] = A;
		[0x7F0523] = A;
		[0x7F0525] = A;
		this.R809559_InitializeRam();
		A = 0x00E0;
		this.R809517();
		A = 0x00F9;
		this.R8094E2();
		P |= 0x20;
		A = 0xFF;
		[0x03B1] = A;
		P &= ~0x20;
		[0x026D]++;
		P = Stack.Pop();
		I = 0;
		B = Stack.Pop();
		return;
	}








	public void R909D97()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		[0x026D]++;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}







	public void R909DA1()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		this.R9081B1();
		this.R9086B7();
		this.R908052();
		A = [0x0371];
		
		if (Z == 1)
			return this.L909DC5();

		temp = A - 0x0003;
		
		if (C == 0)
			return this.L909DCB();

		temp = A - 0x0005;
		
		if (C == 1)
			return this.L909DCB();

		this.R90A597();
		return this.L909DCB();
	}

	public void L909DC5()
	{
		this.L90A7DE();
		this.L90A8CF();
	}

	public void L909DCB()
	{
		A = [0x0381];
		
		if (Z == 0)
			return this.L909DE5();

		A = [0x0367];
		temp = A - 0x000E;
		
		if (Z == 0)
			return this.L909DE5();

		A = [0x7F052B];
		A--;
		
		if (Z == 0)
			return this.L909DE5();

		this.L90955E();
		return this.L909DE9();
	}

	public void L909DE5()
	{
		this.L90EF24();
	}

	public void L909DE9()
	{
		A = [0x0367];
		temp = A - 0x0009;
		
		if (Z == 1)
			return this.L909DF8();

	}

	public void L909DF1()
	{
		[0x026D]++;
		P = Stack.Pop();
		I = 0;
		B = Stack.Pop();
		return;
	}

	public void L909DF8()
	{
		A = [0x150C];
		temp = A & 0x0100;
		
		if (Z == 0)
			return this.L909DF1();

		A = 0x8033;
		[0x02EB] = A;
		return this.L909DF1();
	}

	public void R90A597()
	{
		A = 0x0000;
		[0x7E3983] = A;
		[0x7E3985] = A;
		[0x0B3A] = A;
		[0x0B38] = A;
		this.L90A5AD();
		return;
	}

	public void L90A5AD()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = 0x0001;
		[0x03FE] = A;
		A = 0x0000;
		[0x03F2] = A;
		[0x03FA] = A;
		A = 0x0003;
		[0x03F4] = A;
		A = 0xFFFF;
		[0x03F6] = A;
		[0x03F8] = A;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}







	public void R9086B7()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		P |= 0x30;
		A = 0x8F;
		[0x2100] = A;
		[0x0100] = A;
		A = 0x01;
		[0x2101] = A;
		[0x0101] = A;
		[0x2102] = 0;
		[0x0102] = 0;
		A = 0x80;
		[0x2103] = A;
		[0x0103] = A;
		[0x2104] = 0;
		[0x2104] = 0;
		A = 0x09;
		[0x2105] = A;
		[0x0104] = A;
		[0x2106] = 0;
		[0x0105] = 0;
		A = 0x01;
		[0x2107] = A;
		[0x0106] = A;
		A = 0x09;
		[0x2108] = A;
		[0x0107] = A;
		A = 0x10;
		[0x2109] = A;
		[0x0108] = A;
		A = 0x00;
		[0x210A] = A;
		[0x0109] = A;
		A = 0x44;
		[0x210B] = A;
		[0x010A] = A;
		A = 0x41;
		[0x210C] = A;
		[0x010B] = A;
		[0x210D] = 0;
		[0x210D] = 0;
		[0x210E] = 0;
		[0x210E] = 0;
		[0x210F] = 0;
		[0x210F] = 0;
		[0x2110] = 0;
		[0x2110] = 0;
		[0x2111] = 0;
		[0x2111] = 0;
		[0x2112] = 0;
		[0x2112] = 0;
		[0x2113] = 0;
		[0x2113] = 0;
		[0x2114] = 0;
		[0x2114] = 0;
		[0x2115] = 0;
		[0x211A] = 0;
		[0x010C] = 0;
		[0x211B] = 0;
		[0x211C] = 0;
		[0x211D] = 0;
		[0x211E] = 0;
		[0x211F] = 0;
		[0x2120] = 0;
		[0x2123] = 0;
		[0x010D] = 0;
		[0x2123] = 0;
		[0x010D] = 0;
		[0x2124] = 0;
		[0x010E] = 0;
		[0x2125] = 0;
		[0x011F] = 0;
		[0x2126] = 0;
		[0x0120] = 0;
		[0x2127] = 0;
		[0x0121] = 0;
		[0x2128] = 0;
		[0x0122] = 0;
		[0x2129] = 0;
		[0x0123] = 0;
		[0x212A] = 0;
		[0x0124] = 0;
		[0x212B] = 0;
		[0x0125] = 0;
		A = 0x17;
		[0x212C] = A;
		[0x0126] = A;
		[0x212E] = 0;
		[0x0128] = 0;
		A = 0x00;
		[0x212D] = A;
		[0x0127] = A;
		[0x212F] = 0;
		[0x0129] = 0;
		A = 0x02;
		[0x2130] = A;
		[0x012A] = A;
		A = 0x3F;
		[0x2131] = A;
		[0x012B] = A;
		A = 0xE0;
		[0x2132] = A;
		[0x012C] = A;
		[0x012E] = A;
		[0x012D] = A;
		[0x012C] = A;
		A = 0x00;
		[0x2133] = A;
		[0x012F] = A;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L90A7DE()
	{
		A = [0x7F0512];
		
		if (Z == 0)
			return this.L90A7F6();

		A = [0x1BC7];
		
		if (Z == 0)
			return this.L90A7F6();

		A = [0x036F];
		temp = A - 0x0002;
		
		if (Z == 1)
			return this.L90A7F6();

		A = [0x0371];
		
		if (Z == 1)
			return this.L90A7F7();

	}

	public void L90A7F6()
	{
		return;
	}

	public void L90A7F7()
	{
		P &= ~0x20;
		A = 0x0000;
		[0x706020] = A;
		A = [0x0381];
		[0x70605A] = A;
		A = [0x0365];
		[0x70605C] = A;
		A = [0x036D];
		[0x70605E] = A;
		A = [0x036F];
		[0x706060] = A;
		A = [0x0371];
		[0x706062] = A;
		A = [0x03FE];
		[0x70606C] = A;
		A = [0x7F052B];
		[0x70607C] = A;
		A = [0x7F0527];
		[0x70607A] = A;
		A = [0x03F2];
		[0x706064] = A;
		A = [0x03F4];
		[0x706066] = A;
		A = [0x03F6];
		[0x706068] = A;
		A = [0x03F8];
		[0x70606A] = A;
		A = [0x7F051B];
		[0x70606E] = A;
		A = [0x7F051D];
		[0x706070] = A;
		A = [0x7F051F];
		[0x706072] = A;
		A = [0x7F0521];
		[0x706074] = A;
		A = [0x7F0523];
		[0x706076] = A;
		A = [0x7F0525];
		[0x706078] = A;
		A = [0x7E3983];
		[0x70607E] = A;
		A = [0x7E3985];
		[0x706080] = A;
		A = [0x0B36];
		[0x706082] = A;
		A = [0x0B38];
		[0x706084] = A;
		A = [0x0B3A];
		[0x706086] = A;
		A = [0x0B3C];
		[0x706088] = A;
		A = [0x7F055B];
		[0x70608A] = A;
		A = [0x7F055D];
		[0x70608C] = A;
		A = [0x7F055F];
		[0x70608E] = A;
		this.L94E927();
		return;
	}

	public void L90A8CF()
	{
		A = [0x7F0512];
		
		if (Z == 0)
			return this.L90A8E7();

		A = [0x1BC7];
		
		if (Z == 0)
			return this.L90A8E7();

		A = [0x036F];
		temp = A - 0x0002;
		
		if (Z == 1)
			return this.L90A8E7();

		A = [0x0371];
		
		if (Z == 1)
			return this.L90A8E8();

	}

	public void L90A8E7()
	{
		return;
	}

	public void L90A8E8()
	{
		A = 0x0001;
		[0x706020] = A;
		this.L94E927();
		return;
	}

	public void L90EEAE()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		[0x12] = A;
		A &= 0xFFFF;
		
		if (N == 0)
			return this.L90EEBC();

		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L90EEBC()
	{
		Y = 0x0005;
		X = 0x0008;
	}

	public void L90EEC2()
	{
		A = [0x7F051B + X];
		[0x7F051D + X] = A;
		X--;
		X--;
		Y--;
		
		if (Z == 0)
			return this.L90EEC2();

		A = [0x12];
		[0x7F051B] = A;
		A = [0x7F0527];
		A++;
		[0x7F0527] = A;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L90EF07()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x7F0527];
		A <<= 1;
		X = A;
		A = 0xFFFF;
	}

	public void L90EF14()
	{
		temp = X - 0x000C;
		
		if (N == 0)
			return this.L90EF21();

		[0x7F051B + X] = A;
		X++;
		X++;
		return this.L90EF14();
	}

	public void L90EF21()
	{
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L90EF24()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x03F8];
		this.L90EEAE();
		A = [0x03F6];
		this.L90EEAE();
		A = 0xFFFF;
		[0x03F6] = A;
		[0x03F8] = A;
		this.L90EF07();
		A = [0x0381];
		
		if (Z == 0)
			return this.L90EF6A();

		A = [0x7F0527];
		temp = A - 0x0003;
		
		if (C == 1)
			return this.L90EF6A();

		A = [0x7F051B];
		[0x03F6] = A;
		A = [0x7F051D];
		[0x03F8] = A;
		A = 0x0000;
		[0x7F0527] = A;
		this.L90EF07();
	}

	public void L90EF6A()
	{
		this.L90955E();
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L91AA56()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = 0xFFFF;
		[0x09FC] = A;
		[0x09FE] = A;
		[0x09FA] = 0;
		X = 0x0000;
	}

	public void L91AA69()
	{
		[0x0A01 + X] = 0;
		X++;
		X++;
		temp = X - 0x001E;
		
		if (C == 0)
			return this.L91AA69();

		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L91AD68()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = 0xFFFF;
		[0x0AB5] = A;
		[0x0AB7] = A;
		[0x0AFB] = A;
		X = 0x0000;
	}

	public void L91AD7B()
	{
		[0x0ABB + X] = 0;
		[0x0ADF + X] = 0;
		X++;
		X++;
		temp = X - 0x0006;
		
		if (C == 0)
			return this.L91AD7B();

		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L91B06F()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		A = 0xFFFF;
		[0x0B00] = A;
		[0x0B02] = A;
		X = 0x0000;
	}

	public void L91B081()
	{
		[0x0B04 + X] = 0;
		[0x0B1C + X] = 0;
		X++;
		X++;
		temp = X - 0x000C;
		
		if (C == 0)
			return this.L91B081();

		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void R948D87()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x040C];
		C = 0;
		A += [0x0408] + C;
		[0x040C] = A;
		A = [0x040E];
		A += [0x040A] + C;
		[0x040E] = A;
		A = [0x040E];
		A &= [0x0406];
		A <<= 1;
		X = A;
		A = [0x7FB361 + X];
		[0x7FB3E1] = A;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void R949B0B()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = 0x0000;
		X = [0x0367];
		
		if (Z == 1)
			return this.L949B1E();

	}

	public void L949B17()
	{
		C = 0;
		A += 0x0020 + C;
		X--;
		
		if (Z == 0)
			return this.L949B17();

	}

	public void L949B1E()
	{
		X = A;
		A = [0x94990B + X];
		[0x1BA3] = A;
		A = [0x94990D + X];
		[0x049E] = A;
		A = [0x94990F + X];
		[0x0498] = A;
		A = [0x949911 + X];
		[0x0481] = A;
		A <<= 1;
		[0x047B] = A;
		A <<= 1;
		A <<= 1;
		A <<= 1;
		[0x0487] = A;
		A = [0x949913 + X];
		[0x041C] = A;
		A = [0x949915 + X];
		[0x0428] = A;
		A = [0x949917 + X];
		[0x04A0] = A;
		A = [0x949919 + X];
		[0x049A] = A;
		A = [0x94991B + X];
		[0x0483] = A;
		A <<= 1;
		[0x047D] = A;
		A <<= 1;
		A <<= 1;
		A <<= 1;
		[0x0489] = A;
		A = [0x94991D + X];
		[0x041E] = A;
		A = [0x94991F + X];
		[0x042A] = A;
		A = [0x949921 + X];
		[0x04A2] = A;
		A = [0x949923 + X];
		[0x049C] = A;
		A = [0x949925 + X];
		[0x0485] = A;
		A <<= 1;
		[0x047F] = A;
		A <<= 1;
		A <<= 1;
		A <<= 1;
		[0x048B] = A;
		A = [0x949927 + X];
		[0x0420] = A;
		A = [0x949929 + X];
		[0x042C] = A;
		A = 0xFFFF;
		[0x7FE4E3] = A;
		A = [0x0367];
		A &= 0x00FF;
		A <<= 1;
		X = A;
		Cpu.JSR((0x9BC2 + X));
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void R94B383()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = 0x0000;
		[0x7F0000] = A;
		[0x7F0002] = A;
		A = 0x0100;
		[0x7F0004] = A;
		A = [0x0367];
		A &= 0x00FF;
		A <<= 1;
		X = A;
		Cpu.JSR((0xB3A7 + X));
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L94E927()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		P |= 0x20;
		P &= ~0x10;
		Y = 0x0017;
		X = 0x0000;
	}

	public void L94E935()
	{
		A = [0xE90F + X];
		[0x706002 + X] = A;
		X++;
		Y--;
		
		if (N == 0)
			return this.L94E935();

		P &= ~0x20;
		this.L94E9F3();
		A = [0x12];
		[0x706000] = A;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L94E9F3()
	{
		Stack.Push(P);
		P &= ~0x20;
		[0x12] = 0;
		P |= 0x20;
		Y = 0x0387;
		X = 0x0000;
	}

	public void L94EA00()
	{
		A = [0x706002 + X];
		C = 0;
		A += [0x12] + C;
		[0x12] = A;
		A = [0x13];
		A += 0x00 + C;
		[0x13] = A;
		X++;
		Y--;
		
		if (N == 0)
			return this.L94EA00();

		P = Stack.Pop();
		return;
	}







	public void L90A267()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = 0x0000;
		[0x7F052B] = A;
		[0x7F055B] = A;
		[0x7F055D] = A;
		[0x7F055F] = A;
		A = [0x0371];
		temp = A - 0x0003;
		
		if (Z == 1)
			return this.L90A29A();

		temp = A - 0x0004;
		
		if (Z == 1)
			return this.L90A29A();

		this.L90A9A8();
		this.L90A7DE();
		this.L90A8CF();
	}

	public void L90A294()
	{
		[0x026D]++;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L90A29A()
	{
		A = 0x0001;
		[0x0373] = A;
		A = [0x036D];
		A--;
		A <<= 1;
		A <<= 1;
		A <<= 1;
		A <<= 1;
		[0x12] = A;
		A = [0x0365];
		A <<= 1;
		A <<= 1;
		C = 0;
		A += [0x12] + C;
		X = A;
		A = [0x036F];
		
		if (Z == 0)
			return this.L90A2D3();

		A = [0x9C76 + X];
		[0x0367] = A;
		A = [0x9C78 + X];
		[0x14D6] = A;
		A = [0x036D];
		A--;
		A <<= 1;
		X = A;
		A = [0xA2EE + X];
		[0x7F052D] = A;
		return this.L90A294();
	}

	public void L90A2D3()
	{
		A = [0x9CA6 + X];
		[0x0367] = A;
		A = [0x9CA8 + X];
		[0x14D6] = A;
		A = [0x036D];
		A--;
		A <<= 1;
		X = A;
		A = [0xA2F4 + X];
		[0x7F052D] = A;
		return this.L90A294();
	}

	public void L90A7DE()
	{
		A = [0x7F0512];
		
		if (Z == 0)
			return this.L90A7F6();

		A = [0x1BC7];
		
		if (Z == 0)
			return this.L90A7F6();

		A = [0x036F];
		temp = A - 0x0002;
		
		if (Z == 1)
			return this.L90A7F6();

		A = [0x0371];
		
		if (Z == 1)
			return this.L90A7F7();

	}

	public void L90A7F6()
	{
		return;
	}

	public void L90A7F7()
	{
		P &= ~0x20;
		A = 0x0000;
		[0x706020] = A;
		A = [0x0381];
		[0x70605A] = A;
		A = [0x0365];
		[0x70605C] = A;
		A = [0x036D];
		[0x70605E] = A;
		A = [0x036F];
		[0x706060] = A;
		A = [0x0371];
		[0x706062] = A;
		A = [0x03FE];
		[0x70606C] = A;
		A = [0x7F052B];
		[0x70607C] = A;
		A = [0x7F0527];
		[0x70607A] = A;
		A = [0x03F2];
		[0x706064] = A;
		A = [0x03F4];
		[0x706066] = A;
		A = [0x03F6];
		[0x706068] = A;
		A = [0x03F8];
		[0x70606A] = A;
		A = [0x7F051B];
		[0x70606E] = A;
		A = [0x7F051D];
		[0x706070] = A;
		A = [0x7F051F];
		[0x706072] = A;
		A = [0x7F0521];
		[0x706074] = A;
		A = [0x7F0523];
		[0x706076] = A;
		A = [0x7F0525];
		[0x706078] = A;
		A = [0x7E3983];
		[0x70607E] = A;
		A = [0x7E3985];
		[0x706080] = A;
		A = [0x0B36];
		[0x706082] = A;
		A = [0x0B38];
		[0x706084] = A;
		A = [0x0B3A];
		[0x706086] = A;
		A = [0x0B3C];
		[0x706088] = A;
		A = [0x7F055B];
		[0x70608A] = A;
		A = [0x7F055D];
		[0x70608C] = A;
		A = [0x7F055F];
		[0x70608E] = A;
		this.L94E927();
		return;
	}

	public void L90A8CF()
	{
		A = [0x7F0512];
		
		if (Z == 0)
			return this.L90A8E7();

		A = [0x1BC7];
		
		if (Z == 0)
			return this.L90A8E7();

		A = [0x036F];
		temp = A - 0x0002;
		
		if (Z == 1)
			return this.L90A8E7();

		A = [0x0371];
		
		if (Z == 1)
			return this.L90A8E8();

	}

	public void L90A8E7()
	{
		return;
	}

	public void L90A8E8()
	{
		A = 0x0001;
		[0x706020] = A;
		this.L94E927();
		return;
	}

	public void L90A9A8()
	{
		A = [0x0365];
		A <<= 1;
		A <<= 1;
		X = A;
		A = [0x9C28 + X];
		[0x0367] = A;
		A = [0x9C2A + X];
		[0x14D6] = A;
		A = [0x0367];
		temp = A - 0x0009;
		
		if (Z == 0)
			return this.L90A9CE();

		A = [0x7F052B];
		
		if (Z == 1)
			return this.L90A9CE();

		A = 0x0004;
		[0x0367] = A;
	}

	public void L90A9CE()
	{
		return;
	}

	public void L94E927()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		P |= 0x20;
		P &= ~0x10;
		Y = 0x0017;
		X = 0x0000;
	}

	public void L94E935()
	{
		A = [0xE90F + X];
		[0x706002 + X] = A;
		X++;
		Y--;
		
		if (N == 0)
			return this.L94E935();

		P &= ~0x20;
		this.L94E9F3();
		A = [0x12];
		[0x706000] = A;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L94E9F3()
	{
		Stack.Push(P);
		P &= ~0x20;
		[0x12] = 0;
		P |= 0x20;
		Y = 0x0387;
		X = 0x0000;
	}

	public void L94EA00()
	{
		A = [0x706002 + X];
		C = 0;
		A += [0x12] + C;
		[0x12] = A;
		A = [0x13];
		A += 0x00 + C;
		[0x13] = A;
		X++;
		Y--;
		
		if (N == 0)
			return this.L94EA00();

		P = Stack.Pop();
		return;
	}







	public void R90A5AD()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = 0x0001;
		[0x03FE] = A;
		A = 0x0000;
		[0x03F2] = A;
		[0x03FA] = A;
		A = 0x0003;
		[0x03F4] = A;
		A = 0xFFFF;
		[0x03F6] = A;
		[0x03F8] = A;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}







	public void R90ACD4()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = 0x0000;
		[0x026B] = A;
		A = [0x0367];
		temp = A - 0x000E;
		
		if (Z == 1)
			return this.L90ACEC();
	}

	public void L90ACE6_Done()
	{
		[0x026D]++;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L90ACEC()
	{
		A = [0x7F052B];
		[0x7FE725] = A;
		return this.L90ACE6_Done();
	}







	public void R91B06F()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		A = 0xFFFF;
		[0x0B00] = A;
		[0x0B02] = A;
		X = 0x0000;
	}

	public void L91B081_Loop()
	{
		[0x0B04 + X] = 0;
		[0x0B1C + X] = 0;
		X++;
		X++;
		temp = X - 0x000C;

		if (C == 0)
			return this.L91B081_Loop();

		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}







	public void R8EAE4F()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		this.R80CC06();
		this.R839C9C();
		A = [0x7E6AF6];
		A &= 0x00FF;
		A <<= 1;
		X = A;
		Cpu.JSR((0xAE75 + X));
		this.R839DDD();
		this.R80CDE4();
		this.R8EAFF1();
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}








	public void R8EAFF1()
	{
		Stack.Push(P);
		P &= ~0x30;
		A = [0x7E6AF6];
		temp = A - 0x0002;

		if (C == 0)
			return this.L8EB009();

		A = [0x7E6AF6];
		temp = A - 0x0011;

		if (C == 1)
			return this.L8EB009();

		this.L8EB1FF();
	}

	public void L8EB009()
	{
		A = [0x7E6AEA];

		if (Z == 1)
			return this.L8EB023();

		A = 0x007C;
		[0xB0] = A;
		A = 0x0084;
		[0xB2] = A;
		this.L8CC456();
		this.L8EB09F();
		this.L8EB172();
	}

	public void L8EB023()
	{
		A = [0x7E6AF6];
		temp = A - 0x000D;

		if (C == 0)
			return this.L8EB082();

		A = 0xFFFF;
		[0xA8] = A;
		A = 0x0000;
		[0xAA] = A;
		A = 0x0078;
		[0xB0] = A;
		A = 0x008E;
		C = 1;
		A -= 0x000B - !C;
		[0xB2] = A;
		A = [0x7E6AF6];
		temp = A - 0x0010;

		if (C == 1)
			return this.L8EB054();

		A = 0x01F9;
		[0xB4] = A;
		return this.L8EB059();
	}

	public void L8EB054()
	{
		A = 0x0204;
		[0xB4] = A;
	}

	public void L8EB059()
	{
		this.R828000();
		P |= 0x20;
		A = 0x40;
		temp = A & [0x4A];[0x4A] |= A;
		P &= ~0x20;
		P |= 0x20;
		A = 0x02;
		[0x4360] = A;
		A = 0x0D;
		[0x4361] = A;
		A = 0x8C;
		[0x4362] = A;
		A = 0xB0;
		[0x4363] = A;
		A = 0x8E;
		[0x4364] = A;
		P &= ~0x20;
	}

	public void L8EB082()
	{
		this.R91B091();
		this.R90829B();
		P = Stack.Pop();
		return;
	}

	public void L8EB09F()
	{
		A = 0x0082;
		[0xB0] = A;
		A = 0x0056;
		[0xB2] = A;
		A = 0x020A;
		[0xB4] = A;
		this.R828000();
		A = 0x0080;
		[0xB0] = A;
		A = 0x00C8;
		[0xB2] = A;
		A = 0x0205;
		[0xB4] = A;
		this.R828000();
		A = [0x7E6B12];

		if (Z == 0)
			return this.L8EB0F4();

		A = [0x7E6B14];
		A <<= 1;
		X = A;
		A = [0xB116 + X];
		[0x7E6AF0] = A;
		A = [0xB144 + X];
		[0x7E6B12] = A;
		A = [0x7E6B14];
		A++;
		[0x7E6B14] = A;
		temp = A - 0x0017;

		if (C == 0)
			return this.L8EB0F4();

		A = 0x0000;
		[0x7E6B14] = A;
	}

	public void L8EB0F4()
	{
		A = 0x0080;
		[0xB0] = A;
		A = 0x00C8;
		[0xB2] = A;
		A = 0x0205;
		C = 0;
		A += [0x7E6AF0] + C;
		[0xB4] = A;
		this.R828000();
		A = [0x7E6B12];
		A--;
		[0x7E6B12] = A;
		return;
	}

	public void L8EB172()
	{
		A = [0x70601A];
		A &= 0x00FF;

		if (Z == 1)
			return this.L8EB17C();

		return;
	}

	public void L8EB17C()
	{
		A = [0x7E6B18];

		if (Z == 0)
			return this.L8EB1C6();

		A = [0x7E6B16];
		A <<= 1;
		X = A;
		A = [0xB1EB + X];
		[0x7E6B18] = A;
		A = [0xB1D7 + X];
		X = A;
		A = [0x8FD860 + X];
		[0x7F0633] = A;
		A = [0x8FD862 + X];
		[0x7F0635] = A;
		A = 0x8E00;
		[0x01] = A;
		A = 0xB1D0;
		[0x00] = A;
		this.R8087A4_LoadDmaTransferRecord();
		A = [0x7E6B16];
		A++;
		[0x7E6B16] = A;
		temp = A - 0x000A;

		if (C == 0)
			return this.L8EB1C6();

		A = 0x0000;
		[0x7E6B16] = A;
	}

	public void L8EB1C6()
	{
		A = [0x7E6B18];
		A--;
		[0x7E6B18] = A;
		return;
	}

	public void L8EB1FF()
	{
		Stack.Push(P);
		P &= ~0x30;
		A = [0x7E6B10];

		if (Z == 0)
			return this.L8EB237();

		A = [0x0265];
		A &= 0x8000;

		if (Z == 1)
			return this.L8EB237();

		A = 0x0005;
		this.L809492();
		A = [0x7E6B10];
		A++;
		[0x7E6B10] = A;
		P |= 0x20;
		A = 0x00;
		[0x0100] = A;
		[0x2100] = A;
		P &= ~0x20;
		this.R9081B1();
		A = 0x000A;
		[0x7E6AF6] = A;
	}

	public void L8EB237()
	{
		P = Stack.Pop();
		return;
	}

	public void R9081B1()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		this.L80823D();
		this.L80827B();
		this.L8082A3();
		P |= 0x20;
		A = 0x80;
		[0x4340] = A;
		A = 0x32;
		[0x4341] = A;
		A = 0x5C;
		[0x4342] = A;
		A = 0x82;
		[0x4343] = A;
		A = 0x90;
		[0x4344] = A;
		P &= ~0x20;
		P |= 0x20;
		A = 0x80;
		[0x4350] = A;
		A = 0x32;
		[0x4351] = A;
		A = 0x5C;
		[0x4352] = A;
		A = 0x82;
		[0x4353] = A;
		A = 0x90;
		[0x4354] = A;
		P &= ~0x20;
		P |= 0x20;
		A = 0x80;
		[0x4360] = A;
		A = 0x32;
		[0x4361] = A;
		A = 0x5C;
		[0x4362] = A;
		A = 0x82;
		[0x4363] = A;
		A = 0x90;
		[0x4364] = A;
		P &= ~0x20;
		P |= 0x20;
		A = 0x80;
		[0x4370] = A;
		A = 0x32;
		[0x4371] = A;
		A = 0x5C;
		[0x4372] = A;
		A = 0x82;
		[0x4373] = A;
		A = 0x90;
		[0x4374] = A;
		P &= ~0x20;
		P |= 0x20;
		A = [0x013C];
		A &= 0x81;
		[0x013C] = A;
		[0x420C] = 0;
		[0x0141] = 0;
		[0x4A] = 0;
		[0x434A] = 0;
		[0x435A] = 0;
		[0x436A] = 0;
		[0x437A] = 0;
		P &= ~0x20;
		this.L808202();
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void R90829B()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = 0x9000;
		[0x01] = A;
		A = 0x82B0;
		[0x00] = A;
		this.R8087A4_LoadDmaTransferRecord();
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void R91B091()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x0B00];
		temp = A - [0x0B02];

		if (Z == 0)
			return this.L91B0D2();

		temp = A - 0xFFFF;

		if (Z == 1)
			return this.L91B0C9();

		A = [0x0B04];
		A |= [0x0B06];
		A |= [0x0B08];
		A |= [0x0B0A];
		A |= [0x0B0C];
		A |= [0x0B0E];

		if (Z == 0)
			return this.L91B0BB();

		A = [0x0B34];

		if (Z == 0)
			return this.L91B0CC();

	}

	public void L91B0BB()
	{
		X = 0x000A;
	}

	public void L91B0BE()
	{
		A = [0x0B04 + X];

		if (Z == 1)
			return this.L91B0C5();


		if (N == 0)
			return this.L91B117();

	}

	public void L91B0C5()
	{
		X--;
		X--;

		if (N == 0)
			return this.L91B0BE();

	}

	public void L91B0C9()
	{
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L91B0CC()
	{
		A = 0xFFFF;
		[0x0B00] = A;
	}

	public void L91B0D2()
	{
		[0x0B0E] = 0;
		[0x0B26] = 0;
		A = [0x0B00];
		[0x0B02] = A;
		temp = A - 0xFFFF;

		if (Z == 1)
			return this.L91B0F0();

		[0x12] = A;
		A <<= 1;
		C = 0;
		A += [0x12] + C;
		X = A;
		this.L91B104();
		return this.L91B0BB();
	}

	public void L91B0F0()
	{
		[0x0B04] = 0;
		[0x0B06] = 0;
		[0x0B08] = 0;
		[0x0B0A] = 0;
		[0x0B0C] = 0;
		[0x0B0E] = 0;
		return this.L91B0C9();
	}

	public void L91B104()
	{
		A = [0xB2A5 + X];
		[0x00] = A;
		P |= 0x20;
		A = [0xB2A7 + X];
		[0x02] = A;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		return [[0x0000]]();    //24-Bit Address
	}

	public void L91B117()
	{
		A = [0x0B1C + X];

		if (Z == 1)
			return this.L91B121();

		[0x0B1C + X]--;
		return this.L91B0C5();
	}

	public void L91B121()
	{
		A = [0x0B10 + X];
		[0x00] = A;
		A = [(0x00)];
		A &= 0x00FF;
		temp = A - 0x0081;

		if (Z == 0)
			return this.L91B133();

		return this.L91B17E();
	}

	public void L91B133()
	{
		temp = A - 0x0083;

		if (Z == 0)
			return this.L91B13B();

		return this.L91B216();
	}

	public void L91B13B()
	{
		Y = A;
		A &= 0x00C0;
		temp = A - 0x00C0;

		if (Z == 0)
			return this.L91B147();

		return this.L91B221();
	}

	public void L91B147()
	{
		A = Y;
		A &= 0x00A0;
		temp = A - 0x00A0;

		if (Z == 0)
			return this.L91B153();

		return this.L91B23B();
	}

	public void L91B153()
	{
		A = Y;
		temp = A - 0x0085;

		if (Z == 0)
			return this.L91B15C();

		return this.L91B29F();
	}

	public void L91B15C()
	{
		temp = A - 0x0086;

		if (Z == 0)
			return this.L91B164();

		return this.L91B263();
	}

	public void L91B164()
	{
		temp = A - 0x0087;

		if (Z == 0)
			return this.L91B16C();

		return this.L91B281();
	}

	public void L91B16C()
	{
		temp = A - 0x0082;

		if (Z == 0)
			return this.L91B174();

		return this.L91B1C8();
	}

	public void L91B174()
	{
		A &= 0x0080;

		if (Z == 0)
			return this.L91B17C();

		return this.L91B208();
	}

	public void L91B17C()
	{
		return this.L91B17C();
	}

	public void L91B17E()
	{
		Stack.Push(X);
		Y = 0x0001;
		A = [(0x00) + Y];
		A &= 0x00FF;
		A <<= 1;
		[0x12] = A;
		Y++;
		A = [(0x00) + Y];
		A &= 0x00FF;
		[0x14] = A;
		Y++;
		A = [(0x00) + Y];
		A <<= 1;
		[0x16] = A;
	}

	public void L91B198()
	{
		X = [0x16];
		A = [0x7F0761 + X];
		Y = A;
		A = [0x7F1261 + X];
		X = [0x12];
		[0x7F1061 + X] = A;
		A = Y;
		[0x7F0561 + X] = A;
		[0x12]++;
		[0x12]++;
		[0x16]++;
		[0x16]++;
		[0x14]--;

		if (Z == 0)
			return this.L91B198();

		X = Stack.Pop();
		A = [0x0B10 + X];
		C = 0;
		A += 0x0005 + C;
		[0x0B10 + X] = A;
		return this.L91B121();
	}

	public void L91B1C8()
	{
		Stack.Push(X);
		Y = 0x0001;
		A = [(0x00) + Y];
		A &= 0x00FF;
		A <<= 1;
		[0x12] = A;
		Y++;
		A = [(0x00) + Y];
		A &= 0x00FF;
		[0x14] = A;
		Y++;
		A = [(0x00) + Y];
		A <<= 1;
		[0x16] = A;
	}

	public void L91B1E2()
	{
		X = [0x16];
		A = [0x7F0761 + X];
		X = [0x12];
		[0x7F0561 + X] = A;
		[0x12]++;
		[0x12]++;
		[0x16]++;
		[0x16]++;
		[0x14]--;

		if (Z == 0)
			return this.L91B1E2();

		X = Stack.Pop();
		A = [0x0B10 + X];
		C = 0;
		A += 0x0005 + C;
		[0x0B10 + X] = A;
		return this.L91B121();
	}

	public void L91B208()
	{
		A = [(0x00)];
		A &= 0x00FF;
		[0x0B1C + X] = A;
		[0x0B10 + X]++;
		return this.L91B0C5();
	}

	public void L91B216()
	{
		Y = 0x0001;
		A = [(0x00) + Y];
		[0x0B10 + X] = A;
		return this.L91B121();
	}

	public void L91B221()
	{
		A = [(0x00)];
		A &= 0x001F;
		A <<= 1;
		Y = A;
		[0x00]++;
		A = [(0x00)];
		A &= 0x00FF;
		[0x0B28 + Y] = A;
		[0x0B10 + X]++;
		[0x0B10 + X]++;
		return this.L91B121();
	}

	public void L91B23B()
	{
		A = [(0x00)];
		A &= 0x001F;
		A <<= 1;
		Y = A;
		A = [0x0B28 + Y];
		A--;
		[0x0B28 + Y] = A;

		if (Z == 1)
			return this.L91B256();

		Y = 0x0001;
		A = [(0x00) + Y];
		[0x0B10 + X] = A;
		return this.L91B121();
	}

	public void L91B256()
	{
		A = [0x0B10 + X];
		C = 0;
		A += 0x0003 + C;
		[0x0B10 + X] = A;
		return this.L91B121();
	}

	public void L91B263()
	{
		Y = 0x0001;
		A = [(0x00) + Y];
		Y = A;
		A = [0x0B04 + Y];

		if (Z == 1)
			return this.L91B274();

		A = 0xFFFF;
		[0x0B04 + Y] = A;
	}

	public void L91B274()
	{
		A = [0x0B10 + X];
		C = 0;
		A += 0x0002 + C;
		[0x0B10 + X] = A;
		return this.L91B0C5();
	}

	public void L91B281()
	{
		Y = 0x0001;
		A = [(0x00) + Y];
		Y = A;
		A = [0x0B04 + Y];

		if (Z == 1)
			return this.L91B292();

		A = 0x0001;
		[0x0B04 + Y] = A;
	}

	public void L91B292()
	{
		A = [0x0B10 + X];
		C = 0;
		A += 0x0002 + C;
		[0x0B10 + X] = A;
		return this.L91B0C5();
	}

	public void L91B29F()
	{
		[0x0B04 + X] = 0;
		return this.L91B0C5();
	}







	public void R94EB88_ReadCartridgeRam()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x0371];

		if (Z == 0)
			return this.L94EBBE();

		A = [0x0367];
		A <<= 1;
		A <<= 1;
		X = A;
		A = [0x7060B5 + X];
		A &= 0x00FF;
		[0x26] = A;
		A = [0x7060B6 + X];
		A &= 0x00FF;
		[0x28] = A;
		A = [0x7060B7 + X];
		A &= 0x00FF;
		[0x2A] = A;
		A = [0x7060B8 + X];
		A &= 0x00FF;
		[0x2C] = A;
	}

	public void L94EBBB_Done()
	{
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L94EBBE()
	{
		A = [0x0369];
		A <<= 1;
		A <<= 1;
		C = 0;
		A += [0x0365] + C;
		A <<= 1;
		A <<= 1;
		X = A;
		A = [0x7060F5 + X];
		A &= 0x00FF;
		[0x26] = A;
		A = [0x7060F6 + X];
		A &= 0x00FF;
		[0x28] = A;
		A = [0x7060F7 + X];
		A &= 0x00FF;
		[0x2A] = A;
		A = [0x7060F8 + X];
		A &= 0x00FF;
		[0x2C] = A;
		return this.L94EBBB_Done();
	}








	public void L968144_ResetRam()
	{
		this.R9681D4();
		this.R9694A7_ResetRam();
		A = 0x0000;
		[0x1B3F] = A;
		[0x1B75] = A;
		[0x1B65] = A;
		[0x1B79] = A;
		[0x1B7B] = A;
		[0x1B81] = A;
		[0x1B2B] = A;
		[0x1B41] = A;
		[0x1B25] = A;
		[0x1B27] = A;
		[0x1B23] = A;
		[0x1B29] = A;
		[0x1B43] = A;
		[0x1B13] = A;
		[0x1B15] = A;
		[0x1B17] = A;
		[0x1B1B] = A;
		[0x1B1D] = A;
		[0x1B19] = A;
		[0x1B1F] = A;
		[0x1B21] = A;
		[0x1B23] = A;
		[0x1B2D] = A;
		[0x1B2F] = A;
		[0x1B31] = A;
		[0x1B33] = A;
		[0x1B99] = A;
		[0x1B9B] = A;
		[0x1B9D] = A;
		[0x1B9F] = A;
		[0x1BA1] = A;
		A = 0xFFFF;
		[0x1B45] = A;
		[0x1B47] = A;
		[0x1B49] = A;
		[0x1B4B] = A;
		[0x1B8F] = A;
		[0x1B91] = A;
		[0x1B93] = A;
		[0x1B95] = A;
		[0x1B97] = A;
		A = 0x0120;
		[0x1BA3] = A;
		[0x026D]++;
		return;
	}







	// Bank 0x96
	public void R9681D4()
	{
		X = 0x00E2;
	}

	public void L9681D7_Loop()
	{
		A = [0x8000 + X];
		[0x7F0861 + X] = A;
		X--;
		X--;
		
		if (N == 0)
			return this.L9681D7_Loop();

		X = 0x001E;
	}

	public void L9681E5_Loop()
	{
		A = [0x80E6 + X];
		[0x7F0F61 + X] = A;
		X--;
		X--;
		
		if (N == 0)
			return this.L9681E5_Loop();

		X = 0x003E;
	}

	public void L9681F3_Loop()
	{
		A = [0x8104 + X];
		[0x7F0FC1 + X] = A;
		X--;
		X--;
		
		if (N == 0)
			return this.L9681F3_Loop();

		return;
	}

	public void R9694A7_ResetRam()
	{
		this.R9698CF_ResetRam();
		P |= 0x20;
		A = 0x41;
		[0x4320] = A;
		A = 0x26;
		[0x4321] = A;
		A = 0xD8;
		[0x4322] = A;
		A = 0x61;
		[0x4323] = A;
		A = 0x7E;
		[0x4324] = A;
		A = 0x7E;
		[0x4327] = A;
		P &= ~0x20;
		return;
	}

	public void R9698CF_ResetRam()
	{
		A = 0x0000;
		[0x7E61D8] = A;
		A = 0x0000;
		[0x7E61F8] = A;
		P |= 0x20;
		A = [0x4A];
		A &= 0xFB;
		[0x4A] = A;
		P &= ~0x20;
		return;
	}


	// 80a0ed
	public void L808306()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P |= 0x20;
		A = [0x0154];

		if (Z == 1)
			return this.L808345();

		[0x0154] = 0;
		[0x420B] = 0;
		[0x420C] = 0;
		P &= ~0x30;
		[0x0152] = 0;
		Y = 0x0000;
		temp = Y - 0x0100;

		if (C == 0)
			return this.L808329();

	}

	public void L808327()
	{
		return this.L808327();
	}

	public void L808329()
	{
		A = [0x0155 + Y];
		A &= 0x00FF;
		temp = A - 0x0005;

		if (C == 0)
			return this.L808336();

	}

	public void L808334()
	{
		return this.L808334();
	}

	public void L808336()
	{
		A <<= 1;
		X = A;
		return [(0x833B + X)]();
	}

	public void L808345()
	{
		P |= 0x20;
		[0x0155] = 0;
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L8085A5()
	{
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		Stack.Push(X);
		Stack.Push(Y);
		Stack.Push(A);
		Stack.Push(P);
		P &= ~0x20;
		P |= 0x10;
		X = [0x26];
		[0x4202] = X;
		X = [0x28];
		[0x4203] = X;
		Cpu.NOP();
		Cpu.NOP();
		Cpu.NOP();
		A = [0x4216];
		[0x2A] = A;
		X = [0x27];
		[0x4202] = X;
		X = [0x29];
		[0x4203] = X;
		Cpu.NOP();
		Cpu.NOP();
		Cpu.NOP();
		X = [0x4216];
		[0x2C] = X;
		Y = [0x4217];
		X = [0x27];
		[0x4202] = X;
		X = [0x28];
		[0x4203] = X;
		Cpu.NOP();
		Cpu.NOP();
		A = [0x2B];
		C = 0;
		A += [0x4216] + C;
		[0x2B] = A;

		if (C == 0)
			return this.L8085EE();

		Y++;
	}

	public void L8085EE()
	{
		X = [0x26];
		[0x4202] = X;
		X = [0x29];
		[0x4203] = X;
		Cpu.NOP();
		Cpu.NOP();
		A = [0x2B];
		C = 0;
		A += [0x4216] + C;
		[0x2B] = A;

		if (C == 0)
			return this.L808605();

		Y++;
	}

	public void L808605()
	{
		[0x2D] = Y;
		P = Stack.Pop();
		A = Stack.Pop();
		Y = Stack.Pop();
		X = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L80860D()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		[0x2E] = 0;
		[0x30] = 0;
		[0x32] = 0;
		[0x34] = 0;
		P |= 0x10;
		X = [0x2A];
		this.L80863D();
		this.L80869C();
		X = [0x2B];
		this.L80863D();
		this.L80869C();
		X = [0x2C];
		this.L80863D();
		this.L80869C();
		X = [0x2D];
		this.L80863D();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L80863D()
	{
		[0x4202] = X;
		C = 0;
		X = [0x26];
		[0x4203] = X;
		Cpu.NOP();
		C = 0;
		A = [0x31];
		A += [0x4216] + C;
		[0x31] = A;
		A = [0x33];
		A += 0x0000 + C;
		[0x33] = A;
		P |= 0x20;
		A = [0x35];
		A += 0x00 + C;
		[0x35] = A;
		P &= ~0x20;
		X = [0x27];
		[0x4203] = X;
		Cpu.NOP();
		C = 0;
		A = [0x32];
		A += [0x4216] + C;
		[0x32] = A;
		A = [0x34];
		A += 0x0000 + C;
		[0x34] = A;
		X = [0x28];
		[0x4203] = X;
		Cpu.NOP();
		C = 0;
		A = [0x33];
		A += [0x4216] + C;
		[0x33] = A;
		P |= 0x20;
		A = [0x35];
		A += 0x00 + C;
		[0x35] = A;
		P &= ~0x20;
		X = [0x29];
		[0x4203] = X;
		Cpu.NOP();
		C = 0;
		A = [0x34];
		A += [0x4216] + C;
		[0x34] = A;
		return;
	}

	public void L80869C()
	{
		A = [0x2F];
		[0x2E] = A;
		A = [0x31];
		[0x30] = A;
		A = [0x33];
		[0x32] = A;
		X = [0x35];
		[0x34] = X;
		X = 0x00;
		[0x35] = X;
		return;
	}

	public void L8086B1()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		[0x26] = 0;
		A = [0x2E];

		if (Z == 0)
			return this.L8086C1();

		[0x2C] = 0;
		return this.L8086D9();
	}

	public void L8086C1()
	{
		X = 0x0011;
		C = 0;
	}

	public void L8086C5()
	{
		Cpu.ROL(0x2C);
		X--;

		if (Z == 1)
			return this.L8086D9();

		Cpu.ROL(0x26);
		A = [0x26];

		if (Z == 1)
			return this.L8086C5();

		C = 1;
		A -= [0x2E] - !C;

		if (C == 0)
			return this.L8086C5();

		[0x26] = A;
		return this.L8086C5();
	}

	public void L8086D9()
	{
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L8086DC()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		[0x28] = 0;
		[0x26] = 0;
		A = [0x30];
		A |= [0x2E];

		if (Z == 0)
			return this.L8086F2();

		[0x2C] = 0;
		[0x2A] = 0;
		return this.L808719();
	}

	public void L8086F2()
	{
		X = 0x0021;
		C = 0;
		return this.L808712();
	}

	public void L8086F8()
	{
		Cpu.ROL(0x26);
		Cpu.ROL(0x28);

		if (Z == 0)
			return this.L808702();

		A = [0x26];

		if (Z == 1)
			return this.L808712();

	}

	public void L808702()
	{
		C = 1;
		A = [0x26];
		A -= [0x2E] - !C;
		Y = A;
		A = [0x28];
		A -= [0x30] - !C;

		if (C == 0)
			return this.L808712();

		[0x28] = A;
		[0x26] = Y;
	}

	public void L808712()
	{
		Cpu.ROL(0x2A);
		Cpu.ROL(0x2C);
		X--;

		if (Z == 0)
			return this.L8086F8();

	}

	public void L808719()
	{
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L8087A4()
	{
		Stack.Push(P);
		P &= ~0x30;
		X = [0x0152];
		Y = 0x0000;
		P |= 0x20;
		A = [[0x00] + Y];
		Y++;
		[0x0155 + X] = A;
		A--;

		if (Z == 0)
			return this.L8087BB();

		return this.L808822();
	}

	public void L8087BB()
	{
		A--;

		if (Z == 0)
			return this.L8087C1();

		return this.L8087CD();
	}

	public void L8087C1()
	{
		A--;

		if (Z == 0)
			return this.L8087C7();

		return this.L8087CD();
	}

	public void L8087C7()
	{
		A--;

		if (Z == 0)
			return this.L8087CD();

		return this.L8087F3();
	}

	public void L8087CD()
	{
		[0x015E + X] = 0;
		P &= ~0x20;
		A = [[0x00] + Y];
		[0x0156 + X] = A;
		Y++;
		Y++;
		A = [[0x00] + Y];
		[0x0158 + X] = A;
		Y++;
		Y++;
		A = [[0x00] + Y];
		[0x015A + X] = A;
		Y++;
		Y++;
		A = [[0x00] + Y];
		[0x015C + X] = A;
		A = X;
		C = 0;
		A += 0x0009 + C;
		return this.L80883F();
	}

	public void L8087F3()
	{
		[0x0160 + X] = 0;
		P &= ~0x20;
		A = [[0x00] + Y];
		[0x0156 + X] = A;
		Y++;
		Y++;
		A = [[0x00] + Y];
		[0x0158 + X] = A;
		Y++;
		Y++;
		A = [[0x00] + Y];
		[0x015A + X] = A;
		Y++;
		Y++;
		A = [[0x00] + Y];
		[0x015C + X] = A;
		Y++;
		Y++;
		A = [[0x00] + Y];
		[0x015E + X] = A;
		Y++;
		Y++;
		A = X;
		C = 0;
		A += 0x000B + C;
		return this.L80883F();
	}

	public void L808822()
	{
		[0x015C + X] = 0;
		P &= ~0x20;
		A = [[0x00] + Y];
		[0x0156 + X] = A;
		Y++;
		Y++;
		A = [[0x00] + Y];
		[0x0158 + X] = A;
		Y++;
		Y++;
		A = [[0x00] + Y];
		[0x015A + X] = A;
		A = X;
		C = 0;
		A += 0x0007 + C;
	}

	public void L80883F()
	{
		[0x0152] = A;
		P |= 0x30;
		A = 0x01;
		[0x0154] = A;
		A = [0x02D6];

		if (N == 0)
			return this.L808852();

		this.L808306();
	}

	public void L808852()
	{
		P = Stack.Pop();
		return;
	}

	public void L809D7D()
	{
		A = [0x28];
		A ^= [0x2C];
		Stack.Push(P);
		A = [0x28];

		if (N == 0)
			return this.L809D9B();

		C = 0;
		A = [0x26];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x26] = A;
		A = [0x28];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x28] = A;
	}

	public void L809D9B()
	{
		A = [0x2C];

		if (N == 0)
			return this.L809DB4();

		C = 0;
		A = [0x2A];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x2A] = A;
		A = [0x2C];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x2C] = A;
	}

	public void L809DB4()
	{
		this.L80860D();
		P = Stack.Pop();

		if (N == 0)
			return this.L809DE4();

		C = 0;
		A = [0x2E];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x2E] = A;
		A = [0x30];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x30] = A;
		A = [0x32];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x32] = A;
		A = [0x34];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x34] = A;
	}

	public void L809DE4()
	{
		return;
	}

	public void L809DE5()
	{
		A = [0x2C];
		A ^= [0x30];
		Stack.Push(P);
		A = [0x2C];

		if (N == 0)
			return this.L809E03();

		C = 0;
		A = [0x2A];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x2A] = A;
		A = [0x2C];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x2C] = A;
	}

	public void L809E03()
	{
		A = [0x30];

		if (N == 0)
			return this.L809E1C();

		C = 0;
		A = [0x2E];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x2E] = A;
		A = [0x30];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x30] = A;
	}

	public void L809E1C()
	{
		P |= 0x20;
		A = [0x2C];
		[0x2D] = A;
		A = [0x2B];
		[0x2C] = A;
		A = [0x2A];
		[0x2B] = A;
		A = 0x00;
		[0x2A] = A;
		P &= ~0x20;
		this.L8086DC();
		P |= 0x20;
		A = [0x2C];
		[0x2D] = A;
		A = [0x2B];
		[0x2C] = A;
		A = [0x2A];
		[0x2B] = A;
		A = 0x00;
		[0x2A] = A;
		P &= ~0x20;
		P = Stack.Pop();

		if (N == 0)
			return this.L809E60();

		C = 0;
		A = [0x2A];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x2A] = A;
		A = [0x2C];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x2C] = A;
	}

	public void L809E60()
	{
		return;
	}

	public void L80A0ED()
	{
		this.L908453();
		this.L80A10A();
		A = [0x150C];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L80A100();

		[0x026D]++;
	}

	public void L80A100()
	{
		return;
	}

	public void L80A10A()
	{
		this.L80A1B7();
		this.L81EB18();
		this.L81E7A7();
		this.L80D927();
		this.L81ECAB();
		this.L80DC2A();
		this.L81E9F4();
		this.L838EE1();
		this.L81E870();
		this.L81EA54();
		this.L80CC06();
		this.L839C9C();
		this.L83955A();
		this.L81E934();
		this.L8397F7();
		this.L839DDD();
		this.L80CDE4();
		this.L81E994();
		this.L8289A7();
		this.L80D7A7();
		this.L80D7F3();
		this.L838000();
		this.L80D852();
		A = 0x3C00;
		temp = A & [0xB8];[0xB8] &= ~A;
		return;
	}

	public void L80A1B7()
	{
		A = [0x14D6];
		temp = A - 0x000F;

		if (Z == 0)
			return this.L80A1E1();

		A = [0x14D8];
		C = 0;
		A += [0x14FA] + C;
		[0xB0] = A;
		A = [0x14E6];
		C = 0;
		A += [0x14FC] + C;
		[0xB2] = A;
		this.L82898E();
		A = [0x010F];
		[0x0113] = A;
		A = [0x0111];
		[0x0115] = A;
	}

	public void L80A1E1()
	{
		return;
	}

	public void L80CC06()
	{
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x117C];

		if (N == 1)
			return this.L80CC14();

		Y = 0x0000;
		this.L80CE15();
	}

	public void L80CC14()
	{
		A = [0x117E];

		if (N == 1)
			return this.L80CC1F();

		Y = 0x0002;
		this.L80CE15();
	}

	public void L80CC1F()
	{
		A = [0x1180];

		if (N == 1)
			return this.L80CC2A();

		Y = 0x0004;
		this.L80CE15();
	}

	public void L80CC2A()
	{
		A = [0x1182];

		if (N == 1)
			return this.L80CC35();

		Y = 0x0006;
		this.L80CE15();
	}

	public void L80CC35()
	{
		A = [0x1184];

		if (N == 1)
			return this.L80CC40();

		Y = 0x0008;
		this.L80CE15();
	}

	public void L80CC40()
	{
		A = [0x1186];

		if (N == 1)
			return this.L80CC4B();

		Y = 0x000A;
		this.L80CE15();
	}

	public void L80CC4B()
	{
		A = [0x1188];

		if (N == 1)
			return this.L80CC56();

		Y = 0x000C;
		this.L80CE15();
	}

	public void L80CC56()
	{
		A = [0x118A];

		if (N == 1)
			return this.L80CC61();

		Y = 0x000E;
		this.L80CE15();
	}

	public void L80CC61()
	{
		A = [0x118C];

		if (N == 1)
			return this.L80CC6C();

		Y = 0x0010;
		this.L80CE15();
	}

	public void L80CC6C()
	{
		A = [0x118E];

		if (N == 1)
			return this.L80CC77();

		Y = 0x0012;
		this.L80CE15();
	}

	public void L80CC77()
	{
		A = [0x1190];

		if (N == 1)
			return this.L80CC82();

		Y = 0x0014;
		this.L80CE15();
	}

	public void L80CC82()
	{
		A = [0x1192];

		if (N == 1)
			return this.L80CC8D();

		Y = 0x0016;
		this.L80CE15();
	}

	public void L80CC8D()
	{
		A = [0x1194];

		if (N == 1)
			return this.L80CC98();

		Y = 0x0018;
		this.L80CE15();
	}

	public void L80CC98()
	{
		A = [0x1196];

		if (N == 1)
			return this.L80CCA3();

		Y = 0x001A;
		this.L80CE15();
	}

	public void L80CCA3()
	{
		A = [0x1198];

		if (N == 1)
			return this.L80CCAE();

		Y = 0x001C;
		this.L80CE15();
	}

	public void L80CCAE()
	{
		A = [0x119A];

		if (N == 1)
			return this.L80CCB9();

		Y = 0x001E;
		this.L80CE15();
	}

	public void L80CCB9()
	{
		A = [0x119C];

		if (N == 1)
			return this.L80CCC4();

		Y = 0x0020;
		this.L80CE15();
	}

	public void L80CCC4()
	{
		A = [0x119E];

		if (N == 1)
			return this.L80CCCF();

		Y = 0x0022;
		this.L80CE15();
	}

	public void L80CCCF()
	{
		A = [0x11A0];

		if (N == 1)
			return this.L80CCDA();

		Y = 0x0024;
		this.L80CE15();
	}

	public void L80CCDA()
	{
		A = [0x11A2];

		if (N == 1)
			return this.L80CCE5();

		Y = 0x0026;
		this.L80CE15();
	}

	public void L80CCE5()
	{
		A = [0x11A4];

		if (N == 1)
			return this.L80CCF0();

		Y = 0x0028;
		this.L80CE15();
	}

	public void L80CCF0()
	{
		A = [0x11A6];

		if (N == 1)
			return this.L80CCFB();

		Y = 0x002A;
		this.L80CE15();
	}

	public void L80CCFB()
	{
		A = [0x11A8];

		if (N == 1)
			return this.L80CD06();

		Y = 0x002C;
		this.L80CE15();
	}

	public void L80CD06()
	{
		A = [0x11AA];

		if (N == 1)
			return this.L80CD11();

		Y = 0x002E;
		this.L80CE15();
	}

	public void L80CD11()
	{
		A = [0x11AC];

		if (N == 1)
			return this.L80CD1C();

		Y = 0x0030;
		this.L80CE15();
	}

	public void L80CD1C()
	{
		A = [0x11AE];

		if (N == 1)
			return this.L80CD27();

		Y = 0x0032;
		this.L80CE15();
	}

	public void L80CD27()
	{
		A = [0x11B0];

		if (N == 1)
			return this.L80CD32();

		Y = 0x0034;
		this.L80CE15();
	}

	public void L80CD32()
	{
		A = [0x11B2];

		if (N == 1)
			return this.L80CD3D();

		Y = 0x0036;
		this.L80CE15();
	}

	public void L80CD3D()
	{
		A = [0x11B4];

		if (N == 1)
			return this.L80CD48();

		Y = 0x0038;
		this.L80CE15();
	}

	public void L80CD48()
	{
		A = [0x11B6];

		if (N == 1)
			return this.L80CD53();

		Y = 0x003A;
		this.L80CE15();
	}

	public void L80CD53()
	{
		A = [0x11B8];

		if (N == 1)
			return this.L80CD5E();

		Y = 0x003C;
		this.L80CE15();
	}

	public void L80CD5E()
	{
		A = [0x11BA];

		if (N == 1)
			return this.L80CD69();

		Y = 0x003E;
		this.L80CE15();
	}

	public void L80CD69()
	{
		A = [0x11BC];

		if (N == 1)
			return this.L80CD74();

		Y = 0x0040;
		this.L80CE15();
	}

	public void L80CD74()
	{
		A = [0x11BE];

		if (N == 1)
			return this.L80CD7F();

		Y = 0x0042;
		this.L80CE15();
	}

	public void L80CD7F()
	{
		A = [0x11C0];

		if (N == 1)
			return this.L80CD8A();

		Y = 0x0044;
		this.L80CE15();
	}

	public void L80CD8A()
	{
		A = [0x11C2];

		if (N == 1)
			return this.L80CD95();

		Y = 0x0046;
		this.L80CE15();
	}

	public void L80CD95()
	{
		A = [0x11C4];

		if (N == 1)
			return this.L80CDA0();

		Y = 0x0048;
		this.L80CE15();
	}

	public void L80CDA0()
	{
		A = [0x11C6];

		if (N == 1)
			return this.L80CDAB();

		Y = 0x004A;
		this.L80CE15();
	}

	public void L80CDAB()
	{
		A = [0x11C8];

		if (N == 1)
			return this.L80CDB6();

		Y = 0x004C;
		this.L80CE15();
	}

	public void L80CDB6()
	{
		A = [0x11CA];

		if (N == 1)
			return this.L80CDC1();

		Y = 0x004E;
		this.L80CE15();
	}

	public void L80CDC1()
	{
		A = [0x11CC];

		if (N == 1)
			return this.L80CDCC();

		Y = 0x0050;
		this.L80CE15();
	}

	public void L80CDCC()
	{
		A = [0x11CE];

		if (N == 1)
			return this.L80CDD7();

		Y = 0x0052;
		this.L80CE15();
	}

	public void L80CDD7()
	{
		A = [0x11D0];

		if (N == 1)
			return this.L80CDE2();

		Y = 0x0054;
		this.L80CE15();
	}

	public void L80CDE2()
	{
		B = Stack.Pop();
		return;
	}

	public void L80CDE4()
	{
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x11D2];

		if (N == 1)
			return this.L80CDF2();

		Y = 0x0056;
		this.L80CE15();
	}

	public void L80CDF2()
	{
		A = [0x11D4];

		if (N == 1)
			return this.L80CDFD();

		Y = 0x0058;
		this.L80CE15();
	}

	public void L80CDFD()
	{
		A = [0x11D6];

		if (N == 1)
			return this.L80CE08();

		Y = 0x005A;
		this.L80CE15();
	}

	public void L80CE08()
	{
		A = [0x11D8];

		if (N == 1)
			return this.L80CE13();

		Y = 0x005C;
		this.L80CE15();
	}

	public void L80CE13()
	{
		B = Stack.Pop();
		return;
	}

	public void L80CE15()
	{
		Stack.Push(B);
		this.L80CE1C();
		B = Stack.Pop();
		return;
	}

	public void L80CE1C()
	{
		A = [0x117C + Y];
		A <<= 1;
		C = 0;
		A += [0x117C + Y] + C;
		X = A;
		A = [0xCE86 + X];
		[0x00] = A;
		P |= 0x20;
		A = [0xCE88 + X];
		[0x02] = A;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		return [[0x0000]]();    //24-Bit Address
	}

	public void L80D7A7()
	{
		C = 1;
		A = [0x196A];
		A -= [0x1972] - !C;
		[0x196A] = A;
		A = [0x196C];
		A -= [0x1974] - !C;
		[0x196C] = A;
		A = [0x196C];

		if (N == 0)
			return this.L80D7C8();

		A = 0x0000;
		[0x196A] = A;
		[0x196C] = A;
	}

	public void L80D7C8()
	{
		C = 1;
		A = [0x7E39E7];
		A -= [0x7E39EF] - !C;
		[0x7E39E7] = A;
		A = [0x7E39E9];
		A -= [0x7E39F1] - !C;
		[0x7E39E9] = A;
		A = [0x7E39E9];

		if (N == 0)
			return this.L80D7F2();

		A = 0x0000;
		[0x7E39E7] = A;
		[0x7E39E9] = A;
	}

	public void L80D7F2()
	{
		return;
	}

	public void L80D7F3()
	{
		A = [0x1976];
		temp = A & 0x0008;

		if (Z == 0)
			return this.L80D819();

		A = [0x1968];

		if (N == 1)
			return this.L80D813();

		temp = A - 0x0080;

		if (N == 0)
			return this.L80D80B();

		A++;
		[0x0375] = A;
		return this.L80D819();
	}

	public void L80D80B()
	{
		A = 0x0080;
		[0x0375] = A;
		return this.L80D819();
	}

	public void L80D813()
	{
		A = 0x0000;
		[0x0375] = A;
	}

	public void L80D819()
	{
		A = [0x1976];
		temp = A & 0x0004;

		if (Z == 0)
			return this.L80D83F();

		A = [0x1866];

		if (N == 1)
			return this.L80D839();

		temp = A - 0x0080;

		if (N == 0)
			return this.L80D831();

		A++;
		[0x0377] = A;
		return this.L80D83F();
	}

	public void L80D831()
	{
		A = 0x0080;
		[0x0377] = A;
		return this.L80D83F();
	}

	public void L80D839()
	{
		A = 0x0000;
		[0x0377] = A;
	}

	public void L80D83F()
	{
		A = [0x1968];

		if (N == 1)
			return this.L80D84B();

		A = [0x1866];

		if (N == 1)
			return this.L80D84B();

		return this.L80D851();
	}

	public void L80D84B()
	{
		A = 0x1800;
		temp = A & [0x150C];[0x150C] |= A;
	}

	public void L80D851()
	{
		return;
	}

	public void L80D852()
	{
		A = 0x0008;
		temp = A & [0x1726];[0x1726] &= ~A;
		temp = A & [0x1728];[0x1728] &= ~A;
		temp = A & [0x172A];[0x172A] &= ~A;
		temp = A & [0x172C];[0x172C] &= ~A;
		temp = A & [0x172E];[0x172E] &= ~A;
		temp = A & [0x1730];[0x1730] &= ~A;
		temp = A & [0x1732];[0x1732] &= ~A;
		temp = A & [0x1734];[0x1734] &= ~A;
		temp = A & [0x1736];[0x1736] &= ~A;
		temp = A & [0x1738];[0x1738] &= ~A;
		temp = A & [0x173A];[0x173A] &= ~A;
		temp = A & [0x173C];[0x173C] &= ~A;
		temp = A & [0x173E];[0x173E] &= ~A;
		temp = A & [0x1740];[0x1740] &= ~A;
		temp = A & [0x1742];[0x1742] &= ~A;
		temp = A & [0x1744];[0x1744] &= ~A;
		temp = A & [0x1746];[0x1746] &= ~A;
		temp = A & [0x1748];[0x1748] &= ~A;
		temp = A & [0x174A];[0x174A] &= ~A;
		temp = A & [0x174C];[0x174C] &= ~A;
		temp = A & [0x174E];[0x174E] &= ~A;
		temp = A & [0x1750];[0x1750] &= ~A;
		temp = A & [0x1752];[0x1752] &= ~A;
		temp = A & [0x1754];[0x1754] &= ~A;
		temp = A & [0x1756];[0x1756] &= ~A;
		temp = A & [0x1758];[0x1758] &= ~A;
		temp = A & [0x175A];[0x175A] &= ~A;
		temp = A & [0x175C];[0x175C] &= ~A;
		temp = A & [0x175E];[0x175E] &= ~A;
		temp = A & [0x1760];[0x1760] &= ~A;
		temp = A & [0x1762];[0x1762] &= ~A;
		temp = A & [0x1764];[0x1764] &= ~A;
		return;
	}

	public void L80D927()
	{
		A = [0x150C];
		temp = A & 0x2000;

		if (Z == 0)
			return this.L80D945();

		this.L80D954();
		this.L80E40D();
		this.L80DF8B();
		this.L80D97C();
		this.L80DF3F();
		this.L80D967();
	}

	public void L80D945()
	{
		A = [0x14DC];
		[0x7E5BDF] = A;
		A = [0x14EA];
		[0x7E5BE1] = A;
		return;
	}

	public void L80D954()
	{
		A = [0x1B79];

		if (Z == 0)
			return this.L80D960();

		A = 0x00C0;
		temp = A & [0x1976];[0x1976] &= ~A;
		return;
	}

	public void L80D960()
	{
		A = 0x00C0;
		temp = A & [0x1976];[0x1976] |= A;
		return;
	}

	public void L80D967()
	{
		A = [0x1968];
		A |= [0x1866];

		if (N == 0)
			return this.L80D97B();

		A = 0x03F0;
		temp = A & [0x1976];[0x1976] &= ~A;
		A = 0x0008;
		temp = A & [0x150C];[0x150C] &= ~A;
	}

	public void L80D97B()
	{
		return;
	}

	public void L80D97C()
	{
		A = [0x1976];
		temp = A & 0x1000;

		if (Z == 0)
			return this.L80D987();

		return this.L80DB31();
	}

	public void L80D987()
	{
		A = [0x1990];
		[0x12] = A;
		A = [0x1992];
		[0x14] = A;
		C = 0;
		A = [0x12];
		A += 0xFFFF + C;
		[0x12] = A;
		A = [0x14];
		A += 0x0000 + C;
		[0x14] = A;
		A = [0x14];
		A <<= 1;
		A <<= 1;
		X = A;
		A = [0x1976];
		temp = A & 0xC800;

		if (Z == 1)
			return this.L80D9B0();

		return this.L80DA67();
	}

	public void L80D9B0()
	{
		C = 1;
		A = [0x1980];
		A -= 0x0000 - !C;
		[0x88] = A;
		A = [0x1982];
		A -= 0x0000 - !C;
		[0x8A] = A;
		A |= [0x88];

		if (Z == 1)
			return this.L80D9C9();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80D9C9()
	{

		if (Z == 0)
			return this.L80D9CE();

		return this.L80DA67();
	}

	public void L80D9CE()
	{
		A = [0x1982];

		if (N == 1)
			return this.L80D9F0();

		C = 1;
		A = [0x197C];
		A -= 0x0000 - !C;
		[0x88] = A;
		A = [0x197E];
		A -= 0x0003 - !C;
		[0x8A] = A;
		A |= [0x88];

		if (Z == 1)
			return this.L80D9EC();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80D9EC()
	{

		if (N == 0)
			return this.L80DA67();

		return this.L80DA0D();
	}

	public void L80D9F0()
	{
		C = 1;
		A = [0x197C];
		A -= 0x0000 - !C;
		[0x88] = A;
		A = [0x197E];
		A -= 0xFFFD - !C;
		[0x8A] = A;
		A |= [0x88];

		if (Z == 1)
			return this.L80DA09();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80DA09()
	{

		if (N == 1)
			return this.L80DA67();

		return this.L80DA0D();
	}

	public void L80DA0D()
	{
		A = [0x1980];
		[0x12] = A;
		A = [0x1982];
		[0x14] = A;
		A = [0x14];

		if (N == 0)
			return this.L80DA30();

		C = 0;
		A = [0x12];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x12] = A;
		A = [0x14];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x14] = A;
	}

	public void L80DA30()
	{
		[0x12] <<= 1;
		Cpu.ROL(0x14);
		C = 0;
		A = [0x12];
		A += 0x8000 + C;
		[0x12] = A;
		A = [0x14];
		A += 0x0000 + C;
		[0x14] = A;
		C = 1;
		A = [0x12];
		A -= [0x80DB32 + X] - !C;
		[0x12] = A;
		A = [0x14];
		A -= [0x80DB34 + X] - !C;
		[0x14] = A;
		C = 0;
		A = [0x1990];
		A += [0x12] + C;
		[0x1990] = A;
		A = [0x1992];
		A += [0x14] + C;
		[0x1992] = A;
		return this.L80DA7E();
	}

	public void L80DA67()
	{
		C = 1;
		A = [0x1990];
		A -= [0x80DBA6 + X] - !C;
		[0x1990] = A;
		A = [0x1992];
		A -= [0x80DBA8 + X] - !C;
		[0x1992] = A;
		return this.L80DA7E();
	}

	public void L80DA7E()
	{
		C = 1;
		A = [0x1990];
		A -= 0x0000 - !C;
		[0x88] = A;
		A = [0x1992];
		A -= 0x0000 - !C;
		[0x8A] = A;
		A |= [0x88];

		if (Z == 1)
			return this.L80DA97();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80DA97()
	{

		if (N == 0)
			return this.L80DAA5();

		A = 0x0000;
		[0x1990] = A;
		A = 0x0000;
		[0x1992] = A;
	}

	public void L80DAA5()
	{
		A = [0x1990];
		[0x1994] = A;
		A = [0x1992];
		[0x1996] = A;
		C = 1;
		A = [0x1994];
		A -= [0x199C] - !C;
		[0x1994] = A;
		A = [0x1996];
		A -= [0x199E] - !C;
		[0x1996] = A;
		A = [0x1994];
		[0x1998] = A;
		A = [0x1996];
		[0x199A] = A;
		C = 1;
		A = [0x1998];
		A -= [0x19A0] - !C;
		[0x1998] = A;
		A = [0x199A];
		A -= [0x19A2] - !C;
		[0x199A] = A;
		A = [0x1998];
		[0x12] = A;
		A = [0x199A];
		[0x14] = A;
		C = 1;
		A = [0x12];
		A -= [0x19A4] - !C;
		[0x12] = A;
		A = [0x14];
		A -= [0x19A6] - !C;
		[0x14] = A;
		A = [0x1990];
		[0x199C] = A;
		A = [0x1992];
		[0x199E] = A;
		A = [0x1994];
		[0x19A0] = A;
		A = [0x1996];
		[0x19A2] = A;
		A = [0x1998];
		[0x19A4] = A;
		A = [0x199A];
		[0x19A6] = A;
		C = 0;
		A = [0x198C];
		A += [0x12] + C;
		[0x198C] = A;
		A = [0x198E];
		A += [0x14] + C;
		[0x198E] = A;
	}

	public void L80DB31()
	{
		return;
	}

	public void L80DC2A()
	{
		A = 0xC000;
		temp = A & [0x1976];[0x1976] &= ~A;
		C = 0;
		A = [0x197C];
		A += [0x1980] + C;
		[0x197C] = A;
		A = [0x197E];
		A += [0x1982] + C;
		[0x197E] = A;
		A = [0x7E3997];
		[0x12] = A;
		A = [0x7E3999];
		[0x14] = A;
		A = [0x7E39AB];
		[0x16] = A;
		A = [0x7E39AD];
		[0x18] = A;
		this.L80DD8A();
		A = [0x197E];

		if (N == 1)
			return this.L80DC91();

		C = 1;
		A = [0x197C];
		A -= [0x12] - !C;
		[0x88] = A;
		A = [0x197E];
		A -= [0x14] - !C;
		[0x8A] = A;
		A |= [0x88];

		if (Z == 1)
			return this.L80DC7A();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80DC7A()
	{

		if (N == 0)
			return this.L80DC7F();

		return this.L80DCC1();
	}

	public void L80DC7F()
	{
		A = [0x12];
		[0x197C] = A;
		A = [0x14];
		[0x197E] = A;
		A = 0x8000;
		temp = A & [0x1976];[0x1976] |= A;
		return this.L80DCC1();
	}

	public void L80DC91()
	{
		C = 1;
		A = [0x197C];
		A -= [0x16] - !C;
		[0x88] = A;
		A = [0x197E];
		A -= [0x18] - !C;
		[0x8A] = A;
		A |= [0x88];

		if (Z == 1)
			return this.L80DCA8();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80DCA8()
	{

		if (Z == 1)
			return this.L80DCAF();


		if (N == 1)
			return this.L80DCAF();

		return this.L80DCC1();
	}

	public void L80DCAF()
	{
		A = [0x16];
		[0x197C] = A;
		A = [0x18];
		[0x197E] = A;
		A = 0x8000;
		temp = A & [0x1976];[0x1976] |= A;
		return this.L80DCC1();
	}

	public void L80DCC1()
	{
		C = 0;
		A = [0x1978];
		A += [0x197C] + C;
		[0x1978] = A;
		A = [0x197A];
		A += [0x197E] + C;
		[0x197A] = A;
		C = 0;
		A = [0x1988];
		A += [0x198C] + C;
		[0x1988] = A;
		A = [0x198A];
		A += [0x198E] + C;
		[0x198A] = A;
		A = [0x198A];

		if (N == 1)
			return this.L80DD22();

		C = 1;
		A = [0x1988];
		A -= [0x7E39BF] - !C;
		[0x88] = A;
		A = [0x198A];
		A -= [0x7E39C1] - !C;
		[0x8A] = A;
		A |= [0x88];

		if (Z == 1)
			return this.L80DD07();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80DD07()
	{

		if (N == 0)
			return this.L80DD0C();

		return this.L80DD5A();
	}

	public void L80DD0C()
	{
		A = [0x7E39BF];
		[0x1988] = A;
		A = [0x7E39C1];
		[0x198A] = A;
		A = 0x4000;
		temp = A & [0x1976];[0x1976] |= A;
		return this.L80DD5A();
	}

	public void L80DD22()
	{
		C = 1;
		A = [0x1988];
		A -= [0x7E39D3] - !C;
		[0x88] = A;
		A = [0x198A];
		A -= [0x7E39D5] - !C;
		[0x8A] = A;
		A |= [0x88];

		if (Z == 1)
			return this.L80DD3D();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80DD3D()
	{

		if (Z == 1)
			return this.L80DD44();


		if (N == 1)
			return this.L80DD44();

		return this.L80DD5A();
	}

	public void L80DD44()
	{
		A = [0x7E39D3];
		[0x1988] = A;
		A = [0x7E39D5];
		[0x198A] = A;
		A = 0x4000;
		temp = A & [0x1976];[0x1976] |= A;
		return this.L80DD5A();
	}

	public void L80DD5A()
	{
		C = 0;
		A = [0x1984];
		A += [0x1988] + C;
		[0x1984] = A;
		A = [0x1986];
		A += [0x198A] + C;
		[0x1986] = A;
		this.L80DE80();
		Cpu.NOP();
		A = [0x197C];
		[0x0456] = A;
		A = [0x197E];
		[0x0458] = A;
		A = [0x1988];
		[0x0452] = A;
		A = [0x198A];
		[0x0454] = A;
		return;
	}

	public void L80DD8A()
	{
		A = [0x1AED];
		temp = A - 0x0001;

		if (C == 1)
			return this.L80DD95();

		return this.L80DE5F();
	}

	public void L80DD95()
	{
		A = [0x7E5BC3];

		if (N == 0)
			return this.L80DD9F();

		A ^= 0xFFFF;
		A++;
	}

	public void L80DD9F()
	{
		temp = A - 0x00A0;

		if (C == 0)
			return this.L80DDA9();

		X = 0x001C;
		return this.L80DDF1();
	}

	public void L80DDA9()
	{
		temp = A - 0x0090;

		if (C == 0)
			return this.L80DDB3();

		X = 0x0018;
		return this.L80DDF1();
	}

	public void L80DDB3()
	{
		temp = A - 0x0080;

		if (C == 0)
			return this.L80DDBD();

		X = 0x0014;
		return this.L80DDF1();
	}

	public void L80DDBD()
	{
		temp = A - 0x0070;

		if (C == 0)
			return this.L80DDC7();

		X = 0x0010;
		return this.L80DDF1();
	}

	public void L80DDC7()
	{
		temp = A - 0x0060;

		if (C == 0)
			return this.L80DDD1();

		X = 0x000C;
		return this.L80DDF1();
	}

	public void L80DDD1()
	{
		temp = A - 0x0050;

		if (C == 0)
			return this.L80DDDB();

		X = 0x0008;
		return this.L80DDF1();
	}

	public void L80DDDB()
	{
		temp = A - 0x0040;

		if (C == 0)
			return this.L80DDE5();

		X = 0x0004;
		return this.L80DDF1();
	}

	public void L80DDE5()
	{
		temp = A - 0x0030;

		if (C == 0)
			return this.L80DDEF();

		X = 0x0000;
		return this.L80DDF1();
	}

	public void L80DDEF()
	{
		return this.L80DE5F();
	}

	public void L80DDF1()
	{
		A = [0x7E5BC3];

		if (N == 1)
			return this.L80DE2B();

		C = 1;
		A = [0x14E2];
		A -= 0x0000 - !C;
		[0x88] = A;
		A = [0x14E4];
		A -= 0x0000 - !C;
		[0x8A] = A;
		A |= [0x88];

		if (Z == 1)
			return this.L80DE10();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80DE10()
	{

		if (Z == 1)
			return this.L80DE5F();


		if (N == 1)
			return this.L80DE5F();

		C = 0;
		A = [0x197C];
		A += [0x80DE60 + X] + C;
		[0x197C] = A;
		A = [0x197E];
		A += [0x80DE62 + X] + C;
		[0x197E] = A;
		return this.L80DE5F();
	}

	public void L80DE2B()
	{
		C = 1;
		A = [0x14E2];
		A -= 0x0000 - !C;
		[0x88] = A;
		A = [0x14E4];
		A -= 0x0000 - !C;
		[0x8A] = A;
		A |= [0x88];

		if (Z == 1)
			return this.L80DE44();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80DE44()
	{

		if (Z == 1)
			return this.L80DE5F();


		if (N == 0)
			return this.L80DE5F();

		C = 1;
		A = [0x197C];
		A -= [0x80DE60 + X] - !C;
		[0x197C] = A;
		A = [0x197E];
		A -= [0x80DE62 + X] - !C;
		[0x197E] = A;
		return this.L80DE5F();
	}

	public void L80DE5F()
	{
		return;
	}

	public void L80DE80()
	{
		return;
	}

	public void L80DF3F()
	{
		A = [0x1976];
		temp = A & 0x0800;

		if (Z == 0)
			return this.L80DF52();

		temp = A & 0x0400;

		if (Z == 0)
			return this.L80DF4F();

		return this.L80DF8A();
	}

	public void L80DF4F()
	{
		return this.L80DF8A();
	}

	public void L80DF52()
	{
		A = [0x19A9];
		[0x01] = A;
		A = [0x19A8];
		[0x00] = A;
		A = [[0x00]];
		temp = A & 0x0080;

		if (Z == 0)
			return this.L80DF68();

		A &= 0x007F;
		return this.L80DF6B();
	}

	public void L80DF68()
	{
		A |= 0xFF80;
	}

	public void L80DF6B()
	{
		temp = A - 0x007F;

		if (Z == 0)
			return this.L80DF79();

		A = 0x0800;
		temp = A & [0x1976];[0x1976] &= ~A;
		return this.L80DF8A();
	}

	public void L80DF79()
	{
		C = 0;
		A += [0x198E] + C;
		[0x198E] = A;
		A = [0x19A8];
		C = 0;
		A += 0x0001 + C;
		[0x19A8] = A;
	}

	public void L80DF8A()
	{
		return;
	}

	public void L80DF8B()
	{
		A = [0x150C];
		temp = A & 0x4000;

		if (Z == 0)
			return this.L80DFF2();

		A = [0x7E3985];

		if (Z == 0)
			return this.L80DF9C();

		return this.L80DFF2();
	}

	public void L80DF9C()
	{
		A = [0x50];
		temp = A & 0x4300;

		if (Z == 0)
			return this.L80DFA6();

		this.L80E0B3();
	}

	public void L80DFA6()
	{
		A = [0x50];
		temp = A & 0x4C00;

		if (Z == 0)
			return this.L80DFB0();

		this.L80E1E9();
	}

	public void L80DFB0()
	{
		A = [0x50];
		temp = A & 0x4000;

		if (Z == 1)
			return this.L80DFBA();

		this.L80E374();
	}

	public void L80DFBA()
	{
		A = [0x50];
		temp = A & 0x0200;

		if (Z == 1)
			return this.L80DFC4();

		this.L80E023();
	}

	public void L80DFC4()
	{
		A = [0x50];
		temp = A & 0x0100;

		if (Z == 1)
			return this.L80DFCE();

		this.L80DFF3();
	}

	public void L80DFCE()
	{
		A = [0x50];
		temp = A & 0x0800;

		if (Z == 1)
			return this.L80DFDB();

		this.L80E083();
		this.L80E31F();
	}

	public void L80DFDB()
	{
		A = [0x50];
		temp = A & 0x0400;

		if (Z == 1)
			return this.L80DFE5();

		this.L80E053();
	}

	public void L80DFE5()
	{
		A = [0x50];
		temp = A & 0x8040;

		if (Z == 1)
			return this.L80DFF2();

		this.L80E14E();
		this.L80E284();
	}

	public void L80DFF2()
	{
		return;
	}

	public void L80DFF3()
	{
		A = [0x1976];
		temp = A & 0x2000;

		if (Z == 0)
			return this.L80E022();

		A = [0x50];
		temp = A & 0x4000;

		if (Z == 1)
			return this.L80E012();

		A = [0x7E39A7];
		[0x1980] = A;
		A = [0x7E39A9];
		[0x1982] = A;
		return this.L80E022();
	}

	public void L80E012()
	{
		A = [0x7E39A3];
		[0x1980] = A;
		A = [0x7E39A5];
		[0x1982] = A;
		return this.L80E022();
	}

	public void L80E022()
	{
		return;
	}

	public void L80E023()
	{
		A = [0x1976];
		temp = A & 0x2000;

		if (Z == 0)
			return this.L80E052();

		A = [0x50];
		temp = A & 0x4000;

		if (Z == 1)
			return this.L80E042();

		A = [0x7E39BB];
		[0x1980] = A;
		A = [0x7E39BD];
		[0x1982] = A;
		return this.L80E052();
	}

	public void L80E042()
	{
		A = [0x7E39B7];
		[0x1980] = A;
		A = [0x7E39B9];
		[0x1982] = A;
		return this.L80E052();
	}

	public void L80E052()
	{
		return;
	}

	public void L80E053()
	{
		A = [0x1976];
		temp = A & 0x1000;

		if (Z == 0)
			return this.L80E082();

		A = [0x50];
		temp = A & 0x4000;

		if (Z == 1)
			return this.L80E072();

		A = [0x7E39CF];
		[0x198C] = A;
		A = [0x7E39D1];
		[0x198E] = A;
		return this.L80E082();
	}

	public void L80E072()
	{
		A = [0x7E39CB];
		[0x198C] = A;
		A = [0x7E39CD];
		[0x198E] = A;
		return this.L80E082();
	}

	public void L80E082()
	{
		return;
	}

	public void L80E083()
	{
		A = [0x1976];
		temp = A & 0x1000;

		if (Z == 0)
			return this.L80E0B2();

		A = [0x50];
		temp = A & 0x4000;

		if (Z == 1)
			return this.L80E0A2();

		A = [0x7E39E3];
		[0x198C] = A;
		A = [0x7E39E5];
		[0x198E] = A;
		return this.L80E0B2();
	}

	public void L80E0A2()
	{
		A = [0x7E39DF];
		[0x198C] = A;
		A = [0x7E39E1];
		[0x198E] = A;
		return this.L80E0B2();
	}

	public void L80E0B2()
	{
		return;
	}

	public void L80E0B3()
	{
		A = [0x1976];
		temp = A & 0x2000;

		if (Z == 1)
			return this.L80E0BE();

		return this.L80E14D();
	}

	public void L80E0BE()
	{
		C = 1;
		A = [0x197C];
		A -= 0x0000 - !C;
		[0x88] = A;
		A = [0x197E];
		A -= 0x0000 - !C;
		[0x8A] = A;
		A |= [0x88];

		if (Z == 1)
			return this.L80E0D7();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80E0D7()
	{

		if (Z == 1)
			return this.L80E135();


		if (N == 0)
			return this.L80E108();

		C = 1;
		A = [0x197C];
		A -= [0x7E39AF] - !C;
		[0x88] = A;
		A = [0x197E];
		A -= [0x7E39B1] - !C;
		[0x8A] = A;
		A |= [0x88];

		if (Z == 1)
			return this.L80E0F6();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80E0F6()
	{

		if (N == 0)
			return this.L80E135();

		A = [0x7E399B];
		[0x1980] = A;
		A = [0x7E399D];
		[0x1982] = A;
		return this.L80E14D();
	}

	public void L80E108()
	{
		C = 1;
		A = [0x197C];
		A -= [0x7E399B] - !C;
		[0x88] = A;
		A = [0x197E];
		A -= [0x7E399D] - !C;
		[0x8A] = A;
		A |= [0x88];

		if (Z == 1)
			return this.L80E123();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80E123()
	{

		if (N == 1)
			return this.L80E135();

		A = [0x7E39AF];
		[0x1980] = A;
		A = [0x7E39B1];
		[0x1982] = A;
		return this.L80E14D();
	}

	public void L80E135()
	{
		A = 0x0000;
		[0x1980] = A;
		A = 0x0000;
		[0x1982] = A;
		A = 0x0000;
		[0x197C] = A;
		A = 0x0000;
		[0x197E] = A;
	}

	public void L80E14D()
	{
		return;
	}

	public void L80E14E()
	{
		A = [0x1976];
		temp = A & 0x2000;

		if (Z == 1)
			return this.L80E159();

		return this.L80E1E8();
	}

	public void L80E159()
	{
		C = 1;
		A = [0x197C];
		A -= 0x0000 - !C;
		[0x88] = A;
		A = [0x197E];
		A -= 0x0000 - !C;
		[0x8A] = A;
		A |= [0x88];

		if (Z == 1)
			return this.L80E172();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80E172()
	{

		if (Z == 1)
			return this.L80E1D0();


		if (N == 0)
			return this.L80E1A3();

		C = 1;
		A = [0x197C];
		A -= [0x7E39B3] - !C;
		[0x88] = A;
		A = [0x197E];
		A -= [0x7E39B5] - !C;
		[0x8A] = A;
		A |= [0x88];

		if (Z == 1)
			return this.L80E191();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80E191()
	{

		if (N == 0)
			return this.L80E1D0();

		A = [0x7E399F];
		[0x1980] = A;
		A = [0x7E39A1];
		[0x1982] = A;
		return this.L80E1E8();
	}

	public void L80E1A3()
	{
		C = 1;
		A = [0x197C];
		A -= [0x7E399F] - !C;
		[0x88] = A;
		A = [0x197E];
		A -= [0x7E39A1] - !C;
		[0x8A] = A;
		A |= [0x88];

		if (Z == 1)
			return this.L80E1BE();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80E1BE()
	{

		if (N == 1)
			return this.L80E1D0();

		A = [0x7E39B3];
		[0x1980] = A;
		A = [0x7E39B5];
		[0x1982] = A;
		return this.L80E1E8();
	}

	public void L80E1D0()
	{
		A = 0x0000;
		[0x1980] = A;
		A = 0x0000;
		[0x1982] = A;
		A = 0x0000;
		[0x197C] = A;
		A = 0x0000;
		[0x197E] = A;
	}

	public void L80E1E8()
	{
		return;
	}

	public void L80E1E9()
	{
		A = [0x1976];
		temp = A & 0x1000;

		if (Z == 1)
			return this.L80E1F4();

		return this.L80E283();
	}

	public void L80E1F4()
	{
		C = 1;
		A = [0x1988];
		A -= 0x0000 - !C;
		[0x88] = A;
		A = [0x198A];
		A -= 0x0000 - !C;
		[0x8A] = A;
		A |= [0x88];

		if (Z == 1)
			return this.L80E20D();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80E20D()
	{

		if (Z == 1)
			return this.L80E26B();


		if (N == 0)
			return this.L80E23E();

		C = 1;
		A = [0x1988];
		A -= [0x7E39D7] - !C;
		[0x88] = A;
		A = [0x198A];
		A -= [0x7E39D9] - !C;
		[0x8A] = A;
		A |= [0x88];

		if (Z == 1)
			return this.L80E22C();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80E22C()
	{

		if (N == 0)
			return this.L80E26B();

		A = [0x7E39C3];
		[0x198C] = A;
		A = [0x7E39C5];
		[0x198E] = A;
		return this.L80E283();
	}

	public void L80E23E()
	{
		C = 1;
		A = [0x1988];
		A -= [0x7E39C3] - !C;
		[0x88] = A;
		A = [0x198A];
		A -= [0x7E39C5] - !C;
		[0x8A] = A;
		A |= [0x88];

		if (Z == 1)
			return this.L80E259();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80E259()
	{

		if (N == 1)
			return this.L80E26B();

		A = [0x7E39D7];
		[0x198C] = A;
		A = [0x7E39D9];
		[0x198E] = A;
		return this.L80E283();
	}

	public void L80E26B()
	{
		A = 0x0000;
		[0x198C] = A;
		A = 0x0000;
		[0x198E] = A;
		A = 0x0000;
		[0x1988] = A;
		A = 0x0000;
		[0x198A] = A;
	}

	public void L80E283()
	{
		return;
	}

	public void L80E284()
	{
		A = [0x1976];
		temp = A & 0x1000;

		if (Z == 1)
			return this.L80E28F();

		return this.L80E31E();
	}

	public void L80E28F()
	{
		C = 1;
		A = [0x1988];
		A -= 0x0000 - !C;
		[0x88] = A;
		A = [0x198A];
		A -= 0x0000 - !C;
		[0x8A] = A;
		A |= [0x88];

		if (Z == 1)
			return this.L80E2A8();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80E2A8()
	{

		if (Z == 1)
			return this.L80E306();


		if (N == 0)
			return this.L80E2D9();

		C = 1;
		A = [0x1988];
		A -= [0x7E39DB] - !C;
		[0x88] = A;
		A = [0x198A];
		A -= [0x7E39DD] - !C;
		[0x8A] = A;
		A |= [0x88];

		if (Z == 1)
			return this.L80E2C7();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80E2C7()
	{

		if (N == 0)
			return this.L80E306();

		A = [0x7E39C7];
		[0x198C] = A;
		A = [0x7E39C9];
		[0x198E] = A;
		return this.L80E31E();
	}

	public void L80E2D9()
	{
		C = 1;
		A = [0x1988];
		A -= [0x7E39C7] - !C;
		[0x88] = A;
		A = [0x198A];
		A -= [0x7E39C9] - !C;
		[0x8A] = A;
		A |= [0x88];

		if (Z == 1)
			return this.L80E2F4();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80E2F4()
	{

		if (N == 1)
			return this.L80E306();

		A = [0x7E39DB];
		[0x198C] = A;
		A = [0x7E39DD];
		[0x198E] = A;
		return this.L80E31E();
	}

	public void L80E306()
	{
		A = 0x0000;
		[0x198C] = A;
		A = 0x0000;
		[0x198E] = A;
		A = 0x0000;
		[0x1988] = A;
		A = 0x0000;
		[0x198A] = A;
	}

	public void L80E31E()
	{
		return;
	}

	public void L80E31F()
	{
		A = [0x1976];
		temp = A & 0x0400;

		if (Z == 1)
			return this.L80E33D();

		temp = A & 0x1000;

		if (Z == 1)
			return this.L80E33D();

		A = [0x0381];

		if (Z == 1)
			return this.L80E33A();

		A--;

		if (Z == 1)
			return this.L80E337();

		return this.L80E33D();
	}

	public void L80E337()
	{
		return this.L80E359();
	}

	public void L80E33A()
	{
		return this.L80E33E();
	}

	public void L80E33D()
	{
		return;
	}

	public void L80E33E()
	{
		A = [0x1976];
		temp = A & 0x0800;

		if (Z == 0)
			return this.L80E358();

		A = 0x8000;
		[0x19A9] = A;
		A = 0xF979;
		[0x19A8] = A;
		A = 0x0800;
		temp = A & [0x1976];[0x1976] |= A;
	}

	public void L80E358()
	{
		return;
	}

	public void L80E359()
	{
		A = [0x1976];
		temp = A & 0x0800;

		if (Z == 0)
			return this.L80E373();

		A = 0x8000;
		[0x19A9] = A;
		A = 0xF9BF;
		[0x19A8] = A;
		A = 0x0800;
		temp = A & [0x1976];[0x1976] |= A;
	}

	public void L80E373()
	{
		return;
	}

	public void L80E374()
	{
		A = [0x1976];
		temp = A & 0x2000;

		if (Z == 0)
			return this.L80E3C0();

		A = [0x7E5BC3];
		C = 0;
		A += 0x0040 + C;
		temp = A - 0x0180;

		if (C == 0)
			return this.L80E3B2();

		A = [0x7E5BC3];
		temp = A - 0x0080;

		if (N == 0)
			return this.L80E3A2();

		A = [0x7E39AF];
		[0x1980] = A;
		A = [0x7E39B1];
		[0x1982] = A;
		return this.L80E3C0();
	}

	public void L80E3A2()
	{
		A = [0x7E399B];
		[0x1980] = A;
		A = [0x7E399D];
		[0x1982] = A;
		return this.L80E3C0();
	}

	public void L80E3B2()
	{
		A = 0x0000;
		[0x1980] = A;
		A = 0x0000;
		[0x1982] = A;
		return this.L80E3C0();
	}

	public void L80E3C0()
	{
		A = [0x1976];
		temp = A & 0x1000;

		if (Z == 0)
			return this.L80E40C();

		A = [0x7E5BC5];
		C = 0;
		A += 0x0040 + C;
		temp = A - 0x0128;

		if (C == 0)
			return this.L80E3FE();

		A = [0x7E5BC5];
		temp = A - 0x0060;

		if (N == 0)
			return this.L80E3EE();

		A = [0x7E39D7];
		[0x198C] = A;
		A = [0x7E39D9];
		[0x198E] = A;
		return this.L80E40C();
	}

	public void L80E3EE()
	{
		A = [0x7E39C3];
		[0x198C] = A;
		A = [0x7E39C5];
		[0x198E] = A;
		return this.L80E40C();
	}

	public void L80E3FE()
	{
		A = 0x0000;
		[0x198C] = A;
		A = 0x0000;
		[0x198E] = A;
		return this.L80E40C();
	}

	public void L80E40C()
	{
		return;
	}

	public void L80E40D()
	{
		A = [0x150C];
		temp = A & 0x4000;

		if (Z == 0)
			return this.L80E454();

		A = [0x7E3985];

		if (Z == 0)
			return this.L80E454();

		this.L80E50B();
		A = [0x1976];
		temp = A & 0x2000;

		if (Z == 0)
			return this.L80E434();

		A = [0x7E3983];

		if (Z == 1)
			return this.L80E431();

		this.L80EE67();
		return this.L80E434();
	}

	public void L80E431()
	{
		this.L80EF67();
	}

	public void L80E434()
	{
		A = [0x1976];
		temp = A & 0x1000;

		if (Z == 0)
			return this.L80E43F();

		this.L80F060();
	}

	public void L80E43F()
	{
		A = [0x1976];
		temp = A & 0x1000;

		if (Z == 1)
			return this.L80E454();

		temp = A & 0x0400;

		if (Z == 1)
			return this.L80E454();

		temp = A & 0x0800;

		if (Z == 0)
			return this.L80E454();

		this.L80E4E3();
	}

	public void L80E454()
	{
		return;
	}

	public void L80E455()
	{
		A = [0x1976];
		temp = A & 0x02B0;

		if (Z == 1)
			return this.L80E499();

		A = [0x14D8];
		temp = A - [0x7E5BE3];

		if (N == 1)
			return this.L80E499();

		temp = A - [0x7E5BE7];

		if (N == 0)
			return this.L80E499();

		A = [0x14DE];
		[0x197C] = A;
		A = [0x14E0];
		[0x197E] = A;
		C = 1;
		A = [0x197C];
		A -= [0x14E2] - !C;
		[0x197C] = A;
		A = [0x197E];
		A -= [0x14E4] - !C;
		[0x197E] = A;
		A = [0x14E2];
		[0x1980] = A;
		A = [0x14E4];
		[0x1982] = A;
		C = 1;
		return;
	}

	public void L80E499()
	{
		C = 0;
		return;
	}

	public void L80E49B()
	{
		A = [0x1976];
		temp = A & 0x0170;

		if (Z == 1)
			return this.L80E4DF();

		A = [0x14E6];
		temp = A - [0x7E5BE5];

		if (N == 1)
			return this.L80E4DF();

		temp = A - [0x7E5BE9];

		if (N == 0)
			return this.L80E4DF();

		A = [0x14EC];
		[0x1988] = A;
		A = [0x14EE];
		[0x198A] = A;
		C = 1;
		A = [0x1988];
		A -= [0x14F0] - !C;
		[0x1988] = A;
		A = [0x198A];
		A -= [0x14F2] - !C;
		[0x198A] = A;
		A = [0x14F0];
		[0x198C] = A;
		A = [0x14F2];
		[0x198E] = A;
		C = 1;
		return;
	}

	public void L80E4DF()
	{
		C = 0;
		return;
	}

	public void L80E4E3()
	{
		A = [0x14EA];
		temp = A - 0xFFE0;

		if (N == 0)
			return this.L80E507();

		A = [0x14EA];
		temp = A - [0x7E5BE1];

		if (N == 0)
			return this.L80E507();

		A = [0x14D8];
		temp = A - 0xFFF0;

		if (N == 1)
			return this.L80E507();

		temp = A - 0x0110;

		if (N == 0)
			return this.L80E507();

		this.L80E31F();
		return this.L80E50A();
	}

	public void L80E507()
	{
		return this.L80E50A();
	}

	public void L80E50A()
	{
		return;
	}

	public void L80E50B()
	{
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		this.L80E5C2();

		if (C == 0)
			return this.L80E51F();

		A = [0x1866];

		if (N == 1)
			return this.L80E51F();

		A = [0x1968];

		if (N == 1)
			return this.L80E51F();

		return this.L80E52D();
	}

	public void L80E51F()
	{
		A = 0x0000;
		[0x7E5BC7] = A;
		[0x7E5BC9] = A;
		return this.L80E59E();
	}

	public void L80E52D()
	{
		A = [0x7E5BDB];

		if (Z == 1)
			return this.L80E53F();

		A = [0x7E5BDB];
		A--;
		[0x7E5BDB] = A;
		return this.L80E59E();
	}

	public void L80E53F()
	{
		A = [0x14D6];
		A <<= 1;
		X = A;
		A = [0xE5A0 + X];
		C = 0;
		A += [0x7E5BDD] + C;
		X = A;
		A = [0x0000 + X];
		A |= [0x0001 + X];

		if (Z == 0)
			return this.L80E55F();

		A = 0x0000;
		[0x7E5BDD] = A;
		return this.L80E53F();
	}

	public void L80E55F()
	{
		A = [0x0002 + X];
		A &= 0x00FF;
		A--;
		[0x7E5BDB] = A;
		A = [0x0000 + X];
		temp = A & 0x0080;

		if (Z == 0)
			return this.L80E577();

		A &= 0x007F;
		return this.L80E57A();
	}

	public void L80E577()
	{
		A |= 0xFF80;
	}

	public void L80E57A()
	{
		[0x7E5BC7] = A;
		A = [0x0001 + X];
		temp = A & 0x0080;

		if (Z == 0)
			return this.L80E58B();

		A &= 0x007F;
		return this.L80E58E();
	}

	public void L80E58B()
	{
		A |= 0xFF80;
	}

	public void L80E58E()
	{
		[0x7E5BC9] = A;
		A = [0x7E5BDD];
		C = 0;
		A += 0x0003 + C;
		[0x7E5BDD] = A;
	}

	public void L80E59E()
	{
		B = Stack.Pop();
		return;
	}

	public void L80E5C2()
	{
		A = [0x14];

		if (N == 0)
			return this.L80E5DB();

		C = 0;
		A = [0x12];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x12] = A;
		A = [0x14];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x14] = A;
	}

	public void L80E5DB()
	{
		A = [0x14D6];
		A <<= 1;
		A <<= 1;
		A <<= 1;
		X = A;
		A = [0x14E0];

		if (N == 0)
			return this.L80E600();

		C = 0;
		A = [0x14DE];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x12] = A;
		A = [0x14E0];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x14] = A;
		return this.L80E60A();
	}

	public void L80E600()
	{
		A = [0x14DE];
		[0x12] = A;
		A = [0x14E0];
		[0x14] = A;
	}

	public void L80E60A()
	{
		A = [0xF2BD + X];

		if (N == 0)
			return this.L80E616();

		A = [0x151E];

		if (Z == 0)
			return this.L80E67E();

		return this.L80E62F();
	}

	public void L80E616()
	{
		C = 1;
		A = [0x12];
		A -= [0xF2BB + X] - !C;
		[0x88] = A;
		A = [0x14];
		A -= [0xF2BD + X] - !C;
		[0x8A] = A;
		A |= [0x88];

		if (Z == 1)
			return this.L80E62D();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80E62D()
	{

		if (N == 0)
			return this.L80E67E();

	}

	public void L80E62F()
	{
		A = [0x14EE];

		if (N == 0)
			return this.L80E64D();

		C = 0;
		A = [0x14EC];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x12] = A;
		A = [0x14EE];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x14] = A;
		return this.L80E657();
	}

	public void L80E64D()
	{
		A = [0x14EC];
		[0x12] = A;
		A = [0x14EE];
		[0x14] = A;
	}

	public void L80E657()
	{
		A = [0xF2C1 + X];

		if (N == 0)
			return this.L80E663();

		A = [0x1520];

		if (Z == 0)
			return this.L80E67E();

		return this.L80E67C();
	}

	public void L80E663()
	{
		C = 1;
		A = [0x12];
		A -= [0xF2BF + X] - !C;
		[0x88] = A;
		A = [0x14];
		A -= [0xF2C1 + X] - !C;
		[0x8A] = A;
		A |= [0x88];

		if (Z == 1)
			return this.L80E67A();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80E67A()
	{

		if (N == 0)
			return this.L80E67E();

	}

	public void L80E67C()
	{
		C = 0;
		return;
	}

	public void L80E67E()
	{
		C = 1;
		return;
	}

	public void L80E6EB()
	{
		X = [0x14D6];
		A = [0x80EA32 + X];
		A &= 0x00FF;

		if (Z == 0)
			return this.L80E6FA();

		return this.L80EF67();
	}

	public void L80E6FA()
	{
		this.L80E455();

		if (C == 0)
			return this.L80E702();

		return this.L80E89C();
	}

	public void L80E702()
	{
		A = [0x197C];
		[0x1A] = A;
		A = [0x197E];
		[0x1C] = A;
		A = [0x1C];

		if (N == 0)
			return this.L80E725();

		C = 0;
		A = [0x1A];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x1A] = A;
		A = [0x1C];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x1C] = A;
	}

	public void L80E725()
	{
		A = [0x14D8];
		temp = A - 0xFFD0;

		if (N == 1)
			return this.L80E740();

		temp = A - 0x0130;

		if (N == 0)
			return this.L80E740();

		A = [0x7E39A3];
		[0x22] = A;
		A = [0x7E39A5];
		[0x24] = A;
		return this.L80E74E();
	}

	public void L80E740()
	{
		A = [0x7E39A7];
		[0x22] = A;
		A = [0x7E39A9];
		[0x24] = A;
		return this.L80E74E();
	}

	public void L80E74E()
	{
		A = [0x197C];
		[0x00] = A;
		A = [0x197E];
		[0x03] = A;
		C = 1;
		A = [0x00];
		A -= [0x14DE] - !C;
		[0x00] = A;
		A = [0x03];
		A -= [0x14E0] - !C;
		[0x03] = A;
		A = [0x22];
		[0x06] = A;
		A = [0x24];
		[0x09] = A;
		A = [0x03];

		if (N == 0)
			return this.L80E788();

		C = 0;
		A = [0x00];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x00] = A;
		A = [0x03];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x03] = A;
	}

	public void L80E788()
	{
		A = [0x09];

		if (N == 0)
			return this.L80E7A1();

		C = 0;
		A = [0x06];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x06] = A;
		A = [0x09];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x09] = A;
	}

	public void L80E7A1()
	{
		A = [0x01];
		[0x2C] = A;
		A = [0x03];
		[0x2D] = A;
		A = [0x07];
		[0x2E] = A;
		A = [0x09];
		[0x2F] = A;
		this.L8086B1();
		A = [0x2C];
		A >>= 1;
		[0x26] = A;
		A = [0x1B];
		[0x28] = A;
		this.L8085A5();
		A = [0x7E5BC3];
		C = 1;
		A -= [0x7E5BC7] - !C;

		if (N == 0)
			return this.L80E7D1();

		A ^= 0xFFFF;
		A++;
	}

	public void L80E7D1()
	{
		temp = A - [0x2B];

		if (Z == 1)
			return this.L80E7DA();


		if (N == 1)
			return this.L80E7DA();

		return this.L80E871();
	}

	public void L80E7DA()
	{
		A = [0x197C];
		[0x00] = A;
		A = [0x197E];
		[0x03] = A;
		C = 1;
		A = [0x00];
		A -= [0x14DE] - !C;
		[0x00] = A;
		A = [0x03];
		A -= [0x14E0] - !C;
		[0x03] = A;
		A = [0x03];

		if (N == 0)
			return this.L80E80C();

		C = 0;
		A = [0x00];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x00] = A;
		A = [0x03];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x03] = A;
	}

	public void L80E80C()
	{
		C = 1;
		A = [0x00];
		A -= [0x22] - !C;
		[0x88] = A;
		A = [0x03];
		A -= [0x24] - !C;
		[0x8A] = A;
		A |= [0x88];

		if (Z == 1)
			return this.L80E821();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80E821()
	{

		if (N == 0)
			return this.L80E83B();

		A = 0x0000;
		[0x22] = A;
		A = 0x0000;
		[0x24] = A;
		A = [0x14DE];
		[0x197C] = A;
		A = [0x14E0];
		[0x197E] = A;
		return this.L80E86F();
	}

	public void L80E83B()
	{
		C = 1;
		A = [0x197C];
		A -= [0x14DE] - !C;
		[0x88] = A;
		A = [0x197E];
		A -= [0x14E0] - !C;
		[0x8A] = A;
		A |= [0x88];

		if (Z == 1)
			return this.L80E854();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80E854()
	{

		if (N == 1)
			return this.L80E86D();

		C = 0;
		A = [0x22];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x22] = A;
		A = [0x24];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x24] = A;
		return this.L80E86F();
	}

	public void L80E86D()
	{
		return this.L80E86F();
	}

	public void L80E86F()
	{
		return this.L80E892();
	}

	public void L80E871()
	{
		A = [0x7E5BC3];
		temp = A - [0x7E5BC7];

		if (N == 0)
			return this.L80E890();

		C = 0;
		A = [0x22];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x22] = A;
		A = [0x24];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x24] = A;
	}

	public void L80E890()
	{
		return this.L80E892();
	}

	public void L80E892()
	{
		A = [0x22];
		[0x1980] = A;
		A = [0x24];
		[0x1982] = A;
	}

	public void L80E89C()
	{
		return;
	}

	public void L80E89D()
	{
		X = [0x14D6];
		A = [0x80EA32 + X];
		A &= 0x00FF;

		if (Z == 0)
			return this.L80E8AC();

		return this.L80F060();
	}

	public void L80E8AC()
	{
		this.L80E49B();

		if (C == 0)
			return this.L80E8B4();

		return this.L80EA31();
	}

	public void L80E8B4()
	{
		A = [0x1988];
		[0x1A] = A;
		A = [0x198A];
		[0x1C] = A;
		A = [0x1C];

		if (N == 0)
			return this.L80E8D7();

		C = 0;
		A = [0x1A];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x1A] = A;
		A = [0x1C];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x1C] = A;
	}

	public void L80E8D7()
	{
		A = [0x7E39CB];
		[0x22] = A;
		A = [0x7E39CD];
		[0x24] = A;
		A = [0x1988];
		[0x00] = A;
		A = [0x198A];
		[0x03] = A;
		C = 1;
		A = [0x00];
		A -= [0x14EC] - !C;
		[0x00] = A;
		A = [0x03];
		A -= [0x14EE] - !C;
		[0x03] = A;
		A = [0x22];
		[0x06] = A;
		A = [0x24];
		[0x09] = A;
		A = [0x03];

		if (N == 0)
			return this.L80E91D();

		C = 0;
		A = [0x00];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x00] = A;
		A = [0x03];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x03] = A;
	}

	public void L80E91D()
	{
		A = [0x09];

		if (N == 0)
			return this.L80E936();

		C = 0;
		A = [0x06];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x06] = A;
		A = [0x09];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x09] = A;
	}

	public void L80E936()
	{
		A = [0x01];
		[0x2C] = A;
		A = [0x03];
		[0x2D] = A;
		A = [0x07];
		[0x2E] = A;
		A = [0x09];
		[0x2F] = A;
		this.L8086B1();
		A = [0x2C];
		A >>= 1;
		[0x26] = A;
		A = [0x1B];
		[0x28] = A;
		this.L8085A5();
		A = [0x7E5BC5];
		C = 1;
		A -= [0x7E5BC9] - !C;

		if (N == 0)
			return this.L80E966();

		A ^= 0xFFFF;
		A++;
	}

	public void L80E966()
	{
		temp = A - [0x2B];

		if (Z == 1)
			return this.L80E96F();


		if (N == 1)
			return this.L80E96F();

		return this.L80EA06();
	}

	public void L80E96F()
	{
		A = [0x1988];
		[0x00] = A;
		A = [0x198A];
		[0x03] = A;
		C = 1;
		A = [0x00];
		A -= [0x14EC] - !C;
		[0x00] = A;
		A = [0x03];
		A -= [0x14EE] - !C;
		[0x03] = A;
		A = [0x03];

		if (N == 0)
			return this.L80E9A1();

		C = 0;
		A = [0x00];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x00] = A;
		A = [0x03];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x03] = A;
	}

	public void L80E9A1()
	{
		C = 1;
		A = [0x00];
		A -= [0x22] - !C;
		[0x88] = A;
		A = [0x03];
		A -= [0x24] - !C;
		[0x8A] = A;
		A |= [0x88];

		if (Z == 1)
			return this.L80E9B6();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80E9B6()
	{

		if (N == 0)
			return this.L80E9D0();

		A = 0x0000;
		[0x22] = A;
		A = 0x0000;
		[0x24] = A;
		A = [0x14EC];
		[0x1988] = A;
		A = [0x14EE];
		[0x198A] = A;
		return this.L80EA04();
	}

	public void L80E9D0()
	{
		C = 1;
		A = [0x1988];
		A -= [0x14EC] - !C;
		[0x88] = A;
		A = [0x198A];
		A -= [0x14EE] - !C;
		[0x8A] = A;
		A |= [0x88];

		if (Z == 1)
			return this.L80E9E9();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80E9E9()
	{

		if (N == 1)
			return this.L80EA02();

		C = 0;
		A = [0x22];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x22] = A;
		A = [0x24];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x24] = A;
		return this.L80EA04();
	}

	public void L80EA02()
	{
		return this.L80EA04();
	}

	public void L80EA04()
	{
		return this.L80EA27();
	}

	public void L80EA06()
	{
		A = [0x7E5BC5];
		temp = A - [0x7E5BC9];

		if (N == 0)
			return this.L80EA25();

		C = 0;
		A = [0x22];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x22] = A;
		A = [0x24];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x24] = A;
	}

	public void L80EA25()
	{
		return this.L80EA27();
	}

	public void L80EA27()
	{
		A = [0x22];
		[0x198C] = A;
		A = [0x24];
		[0x198E] = A;
	}

	public void L80EA31()
	{
		return;
	}

	public void L80EA43()
	{
		A = [0x7E3983];

		if (Z == 0)
			return this.L80EA4C();

		return this.L80E6EB();
	}

	public void L80EA4C()
	{
		this.L80E455();

		if (C == 0)
			return this.L80EA54();

		return this.L80ECB0();
	}

	public void L80EA54()
	{
		A = [0x14E2];
		A |= [0x14E4];

		if (Z == 1)
			return this.L80EAB7();

		A = [0x1980];
		A |= [0x1982];

		if (Z == 1)
			return this.L80EAB7();

		A = [0x14DE];
		[0x12] = A;
		A = [0x14E0];
		[0x14] = A;
		C = 1;
		A = [0x12];
		A -= [0x197C] - !C;
		[0x12] = A;
		A = [0x14];
		A -= [0x197E] - !C;
		[0x14] = A;
		A = [0x14];

		if (N == 0)
			return this.L80EA96();

		C = 0;
		A = [0x12];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x12] = A;
		A = [0x14];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x14] = A;
	}

	public void L80EA96()
	{
		C = 1;
		A = [0x12];
		A -= 0x0000 - !C;
		[0x88] = A;
		A = [0x14];
		A -= 0x0002 - !C;
		[0x8A] = A;
		A |= [0x88];

		if (Z == 1)
			return this.L80EAAD();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80EAAD()
	{

		if (C == 1)
			return this.L80EAC5();

		A = [0x14E0];
		A ^= [0x197E];

		if (N == 1)
			return this.L80EAC5();

	}

	public void L80EAB7()
	{
		A = [0x7E39A3];
		[0x22] = A;
		A = [0x7E39A5];
		[0x24] = A;
		return this.L80EAD3();
	}

	public void L80EAC5()
	{
		A = [0x7E39A7];
		[0x22] = A;
		A = [0x7E39A9];
		[0x24] = A;
		return this.L80EAD3();
	}

	public void L80EAD3()
	{
		A = [0x197C];
		[0x12] = A;
		A = [0x197E];
		[0x14] = A;
		C = 1;
		A = [0x12];
		A -= [0x14DE] - !C;
		[0x12] = A;
		A = [0x14];
		A -= [0x14E0] - !C;
		[0x14] = A;
		A = [0x14];

		if (N == 0)
			return this.L80EB05();

		C = 0;
		A = [0x12];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x12] = A;
		A = [0x14];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x14] = A;
	}

	public void L80EB05()
	{
		A = [0x12];
		[0x2A] = A;
		A = [0x14];
		[0x2C] = A;
		A = [0x22];
		[0x2E] = A;
		A = [0x24];
		[0x30] = A;
		this.L809DE5();
		A = [0x2A];
		[0x12] = A;
		A = [0x2C];
		[0x14] = A;
		A = [0x14E2];
		[0x1A] = A;
		A = [0x14E4];
		[0x1C] = A;
		A = [0x1A];
		[0x26] = A;
		A = [0x1C];
		[0x28] = A;
		A = [0x12];
		[0x2A] = A;
		A = [0x14];
		[0x2C] = A;
		this.L809D7D();
		A = [0x30];
		[0x1A] = A;
		A = [0x32];
		[0x1C] = A;
		A = [0x1C];
		Cpu.ROL();
		Cpu.ROR(0x1C);
		Cpu.ROR(0x1A);
		C = 0;
		A = [0x1A];
		A += [0x14DE] + C;
		[0x1A] = A;
		A = [0x1C];
		A += [0x14E0] + C;
		[0x1C] = A;
		A = [0x1A];
		[0x26] = A;
		A = [0x1C];
		[0x28] = A;
		A = [0x12];
		[0x2A] = A;
		A = [0x14];
		[0x2C] = A;
		this.L809D7D();
		A = [0x30];
		[0x1A] = A;
		A = [0x32];
		[0x1C] = A;
		C = 0;
		A = [0x1A];
		A += 0x0000 + C;
		[0x1A] = A;
		A = [0x1C];
		A += [0x7E5BC3] + C;
		[0x1C] = A;
		C = 1;
		A = [0x1A];
		A -= 0x0000 - !C;
		[0x1A] = A;
		A = [0x1C];
		A -= [0x7E5BC7] - !C;
		[0x1C] = A;
		A = [0x197C];
		[0x16] = A;
		A = [0x197E];
		[0x18] = A;
		C = 0;
		A = [0x16];
		A += [0x14DE] + C;
		[0x16] = A;
		A = [0x18];
		A += [0x14E0] + C;
		[0x18] = A;
		A = [0x16];
		[0x26] = A;
		A = [0x18];
		[0x28] = A;
		A = [0x12];
		[0x2A] = A;
		A = [0x14];
		[0x2C] = A;
		this.L809D7D();
		A = [0x30];
		[0x16] = A;
		A = [0x32];
		[0x18] = A;
		A = [0x18];
		Cpu.ROL();
		Cpu.ROR(0x18);
		Cpu.ROR(0x16);
		A = [0x7E5BC3];
		C = 1;
		A -= [0x7E5BC7] - !C;

		if (N == 0)
			return this.L80EBE4();

		A ^= 0xFFFF;
		A++;
	}

	public void L80EBE4()
	{
		temp = A - 0x0002;

		if (C == 0)
			return this.L80EBEC();

		return this.L80EC53();
	}

	public void L80EBEC()
	{
		A = [0x197C];
		[0x12] = A;
		A = [0x197E];
		[0x14] = A;
		C = 1;
		A = [0x12];
		A -= [0x14DE] - !C;
		[0x12] = A;
		A = [0x14];
		A -= [0x14E0] - !C;
		[0x14] = A;
		A = [0x14];

		if (N == 0)
			return this.L80EC1E();

		C = 0;
		A = [0x12];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x12] = A;
		A = [0x14];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x14] = A;
	}

	public void L80EC1E()
	{
		C = 1;
		A = [0x12];
		A -= [0x22] - !C;
		[0x88] = A;
		A = [0x14];
		A -= [0x24] - !C;
		[0x8A] = A;
		A |= [0x88];

		if (Z == 1)
			return this.L80EC33();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80EC33()
	{

		if (Z == 1)
			return this.L80EC39();


		if (C == 0)
			return this.L80EC39();

		return this.L80EC53();
	}

	public void L80EC39()
	{
		A = 0x0000;
		[0x1980] = A;
		A = 0x0000;
		[0x1982] = A;
		A = [0x14DE];
		[0x197C] = A;
		A = [0x14E0];
		[0x197E] = A;
		return this.L80ECB0();
	}

	public void L80EC53()
	{
		C = 1;
		A = [0x1A];
		A -= [0x16] - !C;
		[0x88] = A;
		A = [0x1C];
		A -= [0x18] - !C;
		[0x8A] = A;
		A |= [0x88];

		if (Z == 1)
			return this.L80EC68();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80EC68()
	{

		if (N == 1)
			return this.L80EC87();

		return this.L80EC7A();
	}

	public void L80EC7A()
	{
		A = [0x22];
		[0x1980] = A;
		A = [0x24];
		[0x1982] = A;
		return this.L80ECB0();
	}

	public void L80EC87()
	{
		C = 0;
		A = [0x22];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x1980] = A;
		A = [0x24];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x1982] = A;
		return this.L80ECB0();
	}

	public void L80ECB0()
	{
		return;
	}

	public void L80EE37()
	{
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x14E0];
		A ^= [0x197E];

		if (N == 0)
			return this.L80EE47();

		this.L80EA43();
		return this.L80EE59();
	}

	public void L80EE47()
	{
		A = [0x1AED];
		A <<= 1;
		A <<= 1;
		X = A;
		A = [0x81EF48 + X];
		A &= 0x00FF;
		A <<= 1;
		X = A;
		Cpu.JSR((0xEE5B + X));
	}

	public void L80EE59()
	{
		B = Stack.Pop();
		return;
	}

	public void L80EE67()
	{
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		this.L80EE97();
		A = [0x14E0];
		A ^= [0x197E];

		if (N == 0)
			return this.L80EE7B();

		this.L80EE37();
		return this.L80EE83();
	}

	public void L80EE7B()
	{
		A = [0x1AED];
		A <<= 1;
		X = A;
		Cpu.JSR((0xEE85 + X));
	}

	public void L80EE83()
	{
		B = Stack.Pop();
		return;
	}

	public void L80EE97()
	{
		A = [0x1AED];
		A <<= 1;
		X = A;
		A = [0x80EF45 + X];
		[0x14] = A;
		A ^= 0xFFFF;
		A++;
		[0x12] = A;
		A = [0x7E5BC3];
		temp = A - [0x12];

		if (N == 1)
			return this.L80EEBC();

		temp = A - [0x14];

		if (N == 0)
			return this.L80EEBC();

		this.L80EEC5();
		this.L80EEED();
		return this.L80EEC4();
	}

	public void L80EEBC()
	{
		this.L80EED8();
		this.L80EF17();
		return this.L80EEC4();
	}

	public void L80EEC4()
	{
		return;
	}

	public void L80EEC5()
	{
		A = [0x1AE1];
		A++;

		if (Z == 1)
			return this.L80EECE();

		[0x1AE1] = A;
	}

	public void L80EECE()
	{
		A = [0x1AE3];

		if (Z == 1)
			return this.L80EED7();

		A--;
		[0x1AE3] = A;
	}

	public void L80EED7()
	{
		return;
	}

	public void L80EED8()
	{
		A = [0x1AE1];
		temp = A - 0x0258;

		if (C == 1)
			return this.L80EEE6();

		A = 0x000A;
		[0x1AE3] = A;
	}

	public void L80EEE6()
	{
		A = 0x0000;
		[0x1AE1] = A;
		return;
	}

	public void L80EEED()
	{
		A = [0x1AE9];
		A++;

		if (Z == 1)
			return this.L80EEF6();

		[0x1AE9] = A;
	}

	public void L80EEF6()
	{
		A = [0x1AEB];

		if (Z == 1)
			return this.L80EEFF();

		A--;
		[0x1AEB] = A;
	}

	public void L80EEFF()
	{
		A = [0x1AED];
		A <<= 1;
		X = A;
		A = [0x80EF55 + X];
		temp = A - [0x1AEB];

		if (C == 0)
			return this.L80EF16();

		A = [0x1AED];

		if (Z == 1)
			return this.L80EF16();

		A--;
		[0x1AED] = A;
	}

	public void L80EF16()
	{
		return;
	}

	public void L80EF17()
	{
		A = [0x1AE9];

		if (Z == 1)
			return this.L80EF2F();

		A = [0x1AEB];

		if (Z == 0)
			return this.L80EF23();

		return this.L80EF2F();
	}

	public void L80EF23()
	{
		A = [0x1AED];
		A++;
		temp = A - 0x0008;

		if (C == 1)
			return this.L80EF2F();

		[0x1AED] = A;
	}

	public void L80EF2F()
	{
		A = [0x1AE9];
		temp = A - 0x0258;

		if (C == 1)
			return this.L80EF3E();

		A = [0x80EF65];
		[0x1AEB] = A;
	}

	public void L80EF3E()
	{
		A = 0x0000;
		[0x1AE9] = A;
		return;
	}

	public void L80EF67()
	{
		X = [0x14D6];
		A = [0x80EA32 + X];
		A &= 0x00FF;

		if (Z == 1)
			return this.L80EF76();

		return this.L80E6EB();
	}

	public void L80EF76()
	{
		this.L80E455();

		if (C == 0)
			return this.L80EF7E();

		return this.L80F05F();
	}

	public void L80EF7E()
	{
		A = [0x14D8];
		temp = A - 0xFFD0;

		if (N == 1)
			return this.L80EF99();

		temp = A - 0x0130;

		if (N == 0)
			return this.L80EF99();

		A = [0x7E39A3];
		[0x22] = A;
		A = [0x7E39A5];
		[0x24] = A;
		return this.L80EFA7();
	}

	public void L80EF99()
	{
		A = [0x7E39A7];
		[0x22] = A;
		A = [0x7E39A9];
		[0x24] = A;
		return this.L80EFA7();
	}

	public void L80EFA7()
	{
		P |= 0x20;
		A = [0x197D];
		[0x12] = A;
		A = [0x197E];
		[0x13] = A;
		A = [0x14DF];
		[0x14] = A;
		A = [0x14E0];
		[0x15] = A;
		P &= ~0x20;
		A = [0x12];
		C = 1;
		A -= [0x14] - !C;
		[0x12] = A;
		A = [0x12];

		if (N == 1)
			return this.L80EFD2();

		A <<= 1;
		A <<= 1;
		A = (A >> 4) | (A << 4);
		A &= 0x00FF;
		return this.L80EFE0();
	}

	public void L80EFD2()
	{
		A ^= 0xFFFF;
		A++;
		A <<= 1;
		A <<= 1;
		A = (A >> 4) | (A << 4);
		A &= 0x00FF;
		A ^= 0xFFFF;
		A++;
	}

	public void L80EFE0()
	{
		[0x12] = A;
		A = [0x7E5BC7];
		C = 1;
		A -= [0x7E5BC3] - !C;
		[0x14] = A;
		A = [0x14];

		if (N == 0)
			return this.L80EFF5();

		A ^= 0xFFFF;
		A++;
	}

	public void L80EFF5()
	{
		temp = A - 0x0003;

		if (C == 1)
			return this.L80F01E();

		A = [0x12];

		if (N == 0)
			return this.L80F002();

		A ^= 0xFFFF;
		A++;
	}

	public void L80F002()
	{
		temp = A - 0x0004;

		if (C == 1)
			return this.L80F01E();

		A = 0x0000;
		[0x1980] = A;
		[0x1982] = A;
		A = [0x14DE];
		[0x197C] = A;
		A = [0x14E0];
		[0x197E] = A;
		return this.L80F05F();
	}

	public void L80F01E()
	{
		A = [0x12];

		if (N == 1)
			return this.L80F02D();

		A <<= 1;
		X = A;
		A = [0x14];
		C = 1;
		A -= [0x7F0412 + X] - !C;
		return this.L80F03A();
	}

	public void L80F02D()
	{
		A ^= 0xFFFF;
		A++;
		A <<= 1;
		X = A;
		A = [0x14];
		C = 0;
		A += [0x7F0412 + X] + C;
	}

	public void L80F03A()
	{

		if (N == 1)
			return this.L80F055();

		C = 0;
		A = [0x22];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x1980] = A;
		A = [0x24];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x1982] = A;
		return this.L80F05F();
	}

	public void L80F055()
	{
		A = [0x22];
		[0x1980] = A;
		A = [0x24];
		[0x1982] = A;
	}

	public void L80F05F()
	{
		return;
	}

	public void L80F060()
	{
		X = [0x14D6];
		A = [0x80EA32 + X];
		A &= 0x00FF;

		if (Z == 1)
			return this.L80F06F();

		return this.L80E89D();
	}

	public void L80F06F()
	{
		this.L80E49B();

		if (C == 0)
			return this.L80F077();

		return this.L80F158();
	}

	public void L80F077()
	{
		A = [0x14E6];
		temp = A - 0xFFD0;

		if (N == 1)
			return this.L80F092();

		temp = A - 0x0130;

		if (N == 0)
			return this.L80F092();

		A = [0x7E39CB];
		[0x22] = A;
		A = [0x7E39CD];
		[0x24] = A;
		return this.L80F0A0();
	}

	public void L80F092()
	{
		A = [0x7E39CF];
		[0x22] = A;
		A = [0x7E39D1];
		[0x24] = A;
		return this.L80F0A0();
	}

	public void L80F0A0()
	{
		P |= 0x20;
		A = [0x1989];
		[0x12] = A;
		A = [0x198A];
		[0x13] = A;
		A = [0x14ED];
		[0x14] = A;
		A = [0x14EE];
		[0x15] = A;
		P &= ~0x20;
		A = [0x12];
		C = 1;
		A -= [0x14] - !C;
		[0x12] = A;
		A = [0x12];

		if (N == 1)
			return this.L80F0CB();

		A <<= 1;
		A <<= 1;
		A = (A >> 4) | (A << 4);
		A &= 0x00FF;
		return this.L80F0D9();
	}

	public void L80F0CB()
	{
		A ^= 0xFFFF;
		A++;
		A <<= 1;
		A <<= 1;
		A = (A >> 4) | (A << 4);
		A &= 0x00FF;
		A ^= 0xFFFF;
		A++;
	}

	public void L80F0D9()
	{
		[0x12] = A;
		A = [0x7E5BC9];
		C = 1;
		A -= [0x7E5BC5] - !C;
		[0x14] = A;
		A = [0x14];

		if (N == 0)
			return this.L80F0EE();

		A ^= 0xFFFF;
		A++;
	}

	public void L80F0EE()
	{
		temp = A - 0x0003;

		if (C == 1)
			return this.L80F117();

		A = [0x12];

		if (N == 0)
			return this.L80F0FB();

		A ^= 0xFFFF;
		A++;
	}

	public void L80F0FB()
	{
		temp = A - 0x0004;

		if (C == 1)
			return this.L80F117();

		A = 0x0000;
		[0x198C] = A;
		[0x198E] = A;
		A = [0x14EC];
		[0x1988] = A;
		A = [0x14EE];
		[0x198A] = A;
		return this.L80F158();
	}

	public void L80F117()
	{
		A = [0x12];

		if (N == 1)
			return this.L80F126();

		A <<= 1;
		X = A;
		A = [0x14];
		C = 1;
		A -= [0x7F0412 + X] - !C;
		return this.L80F133();
	}

	public void L80F126()
	{
		A ^= 0xFFFF;
		A++;
		A <<= 1;
		X = A;
		A = [0x7F0412 + X];
		C = 0;
		A += [0x14] + C;
	}

	public void L80F133()
	{

		if (N == 1)
			return this.L80F14E();

		C = 0;
		A = [0x22];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x198C] = A;
		A = [0x24];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x198E] = A;
		return this.L80F158();
	}

	public void L80F14E()
	{
		A = [0x22];
		[0x198C] = A;
		A = [0x24];
		[0x198E] = A;
	}

	public void L80F158()
	{
		return;
	}

	public void L81E7A7()
	{
		Stack.Push(B);
		this.L81E7AF();
		B = Stack.Pop();
		return this.L81E7D3();
	}

	public void L81E7AF()
	{
		A = [0x14D6];
		temp = A - 0x0011;

		if (N == 1)
			return this.L81E7B9();

	}

	public void L81E7B7()
	{
		return this.L81E7B7();
	}

	public void L81E7B9()
	{
		A <<= 1;
		A += [0x14D6] + C;
		X = A;
		A = [0x81E7D4 + X];
		[0x0F] = A;
		P |= 0x20;
		A = [0x81E7D6 + X];
		[0x11] = A;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		return [[0x000F]]();    //24-Bit Address
	}

	public void L81E7D3()
	{
		return;
	}

	public void L81E870()
	{
		A = 0x0010;
		temp = A & [0x1726];[0x1726] &= ~A;
		temp = A & [0x1728];[0x1728] &= ~A;
		temp = A & [0x172A];[0x172A] &= ~A;
		temp = A & [0x172C];[0x172C] &= ~A;
		temp = A & [0x172E];[0x172E] &= ~A;
		temp = A & [0x1730];[0x1730] &= ~A;
		temp = A & [0x1732];[0x1732] &= ~A;
		temp = A & [0x1734];[0x1734] &= ~A;
		temp = A & [0x1736];[0x1736] &= ~A;
		temp = A & [0x1738];[0x1738] &= ~A;
		temp = A & [0x173A];[0x173A] &= ~A;
		temp = A & [0x173C];[0x173C] &= ~A;
		temp = A & [0x173E];[0x173E] &= ~A;
		temp = A & [0x1740];[0x1740] &= ~A;
		temp = A & [0x1742];[0x1742] &= ~A;
		temp = A & [0x1744];[0x1744] &= ~A;
		temp = A & [0x1746];[0x1746] &= ~A;
		temp = A & [0x1748];[0x1748] &= ~A;
		temp = A & [0x174A];[0x174A] &= ~A;
		temp = A & [0x174C];[0x174C] &= ~A;
		temp = A & [0x174E];[0x174E] &= ~A;
		temp = A & [0x1750];[0x1750] &= ~A;
		temp = A & [0x1752];[0x1752] &= ~A;
		temp = A & [0x1754];[0x1754] &= ~A;
		temp = A & [0x1756];[0x1756] &= ~A;
		temp = A & [0x1758];[0x1758] &= ~A;
		temp = A & [0x175A];[0x175A] &= ~A;
		temp = A & [0x175C];[0x175C] &= ~A;
		temp = A & [0x175E];[0x175E] &= ~A;
		temp = A & [0x1760];[0x1760] &= ~A;
		temp = A & [0x1762];[0x1762] &= ~A;
		temp = A & [0x1764];[0x1764] &= ~A;
		Stack.Push(B);
		this.L81E8DB();
		B = Stack.Pop();
		return this.L81E8FF();
	}

	public void L81E8DB()
	{
		A = [0x14D6];
		temp = A - 0x0011;

		if (N == 1)
			return this.L81E8E5();

	}

	public void L81E8E3()
	{
		return this.L81E8E3();
	}

	public void L81E8E5()
	{
		A <<= 1;
		A += [0x14D6] + C;
		X = A;
		A = [0x81E900 + X];
		[0x0F] = A;
		P |= 0x20;
		A = [0x81E902 + X];
		[0x11] = A;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		return [[0x000F]]();    //24-Bit Address
	}

	public void L81E8FF()
	{
		return;
	}

	public void L81E934()
	{
		Stack.Push(B);
		this.L81E93C();
		B = Stack.Pop();
		return this.L81E960();
	}

	public void L81E93C()
	{
		A = [0x14D6];
		temp = A - 0x0011;

		if (N == 1)
			return this.L81E946();

	}

	public void L81E944()
	{
		return this.L81E944();
	}

	public void L81E946()
	{
		A <<= 1;
		A += [0x14D6] + C;
		X = A;
		A = [0x81E961 + X];
		[0x0F] = A;
		P |= 0x20;
		A = [0x81E963 + X];
		[0x11] = A;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		return [[0x000F]]();    //24-Bit Address
	}

	public void L81E960()
	{
		return;
	}

	public void L81E994()
	{
		Stack.Push(B);
		this.L81E99C();
		B = Stack.Pop();
		return this.L81E9C0();
	}

	public void L81E99C()
	{
		A = [0x14D6];
		temp = A - 0x0011;

		if (N == 1)
			return this.L81E9A6();

	}

	public void L81E9A4()
	{
		return this.L81E9A4();
	}

	public void L81E9A6()
	{
		A <<= 1;
		A += [0x14D6] + C;
		X = A;
		A = [0x81E9C1 + X];
		[0x0F] = A;
		P |= 0x20;
		A = [0x81E9C3 + X];
		[0x11] = A;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		return [[0x000F]]();    //24-Bit Address
	}

	public void L81E9C0()
	{
		return;
	}

	public void L81E9F4()
	{
		Stack.Push(B);
		this.L81E9FC();
		B = Stack.Pop();
		return this.L81EA20();
	}

	public void L81E9FC()
	{
		A = [0x14D6];
		temp = A - 0x0011;

		if (N == 1)
			return this.L81EA06();

	}

	public void L81EA04()
	{
		return this.L81EA04();
	}

	public void L81EA06()
	{
		A <<= 1;
		A += [0x14D6] + C;
		X = A;
		A = [0x81EA21 + X];
		[0x0F] = A;
		P |= 0x20;
		A = [0x81EA23 + X];
		[0x11] = A;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		return [[0x000F]]();    //24-Bit Address
	}

	public void L81EA20()
	{
		return;
	}

	public void L81EA54()
	{
		Stack.Push(B);
		this.L81EA5C();
		B = Stack.Pop();
		return this.L81EA80();
	}

	public void L81EA5C()
	{
		A = [0x14D6];
		temp = A - 0x0011;

		if (N == 1)
			return this.L81EA66();

	}

	public void L81EA64()
	{
		return this.L81EA64();
	}

	public void L81EA66()
	{
		A <<= 1;
		A += [0x14D6] + C;
		X = A;
		A = [0x81EA81 + X];
		[0x0F] = A;
		P |= 0x20;
		A = [0x81EA83 + X];
		[0x11] = A;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		return [[0x000F]]();    //24-Bit Address
	}

	public void L81EA80()
	{
		return;
	}

	public void L81EB18()
	{
		Stack.Push(B);
		this.L81EB20();
		B = Stack.Pop();
		return this.L81EB44();
	}

	public void L81EB20()
	{
		A = [0x14D6];
		temp = A - 0x0011;

		if (N == 1)
			return this.L81EB2A();

	}

	public void L81EB28()
	{
		return this.L81EB28();
	}

	public void L81EB2A()
	{
		A <<= 1;
		A += [0x14D6] + C;
		X = A;
		A = [0x81EB45 + X];
		[0x0F] = A;
		P |= 0x20;
		A = [0x81EB47 + X];
		[0x11] = A;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		return [[0x000F]]();    //24-Bit Address
	}

	public void L81EB44()
	{
		return;
	}

	public void L81ECAB()
	{
		A = [0x14D6];
		temp = A - 0x000F;

		if (Z == 0)
			return this.L81ECB4();

		return;
	}

	public void L81ECB4()
	{
		this.L81EE0C();
		[0x151E] = 0;
		A = [0x14E0];

		if (N == 1)
			return this.L81ECF5();

		C = 1;
		A = [0x14DE];
		A -= [0x7E3D73] - !C;
		[0x88] = A;
		A = [0x14E0];
		A -= [0x7E3D75] - !C;
		[0x8A] = A;
		A |= [0x88];

		if (Z == 1)
			return this.L81ECDA();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L81ECDA()
	{

		if (N == 0)
			return this.L81ECDF();

		return this.L81ED2D();
	}

	public void L81ECDF()
	{
		A = [0x7E3D73];
		[0x14DE] = A;
		A = [0x7E3D75];
		[0x14E0] = A;
		A = 0x0001;
		[0x151E] = A;
		return this.L81ED2D();
	}

	public void L81ECF5()
	{
		C = 1;
		A = [0x14DE];
		A -= [0x7E3D87] - !C;
		[0x88] = A;
		A = [0x14E0];
		A -= [0x7E3D89] - !C;
		[0x8A] = A;
		A |= [0x88];

		if (Z == 1)
			return this.L81ED10();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L81ED10()
	{

		if (Z == 1)
			return this.L81ED17();


		if (N == 1)
			return this.L81ED17();

		return this.L81ED2D();
	}

	public void L81ED17()
	{
		A = [0x7E3D87];
		[0x14DE] = A;
		A = [0x7E3D89];
		[0x14E0] = A;
		A = 0x0001;
		[0x151E] = A;
		return this.L81ED2D();
	}

	public void L81ED2D()
	{
		C = 0;
		A = [0x14DA];
		A += [0x14DE] + C;
		[0x14DA] = A;
		A = [0x14DC];
		A += [0x14E0] + C;
		[0x14DC] = A;
		C = 0;
		A = [0x14EC];
		A += [0x14F0] + C;
		[0x14EC] = A;
		A = [0x14EE];
		A += [0x14F2] + C;
		[0x14EE] = A;
		[0x1520] = 0;
		A = [0x14EE];

		if (N == 1)
			return this.L81ED91();

		C = 1;
		A = [0x14EC];
		A -= [0x7E3D9B] - !C;
		[0x88] = A;
		A = [0x14EE];
		A -= [0x7E3D9D] - !C;
		[0x8A] = A;
		A |= [0x88];

		if (Z == 1)
			return this.L81ED76();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L81ED76()
	{

		if (N == 0)
			return this.L81ED7B();

		return this.L81EDC9();
	}

	public void L81ED7B()
	{
		A = [0x7E3D9B];
		[0x14EC] = A;
		A = [0x7E3D9D];
		[0x14EE] = A;
		A = 0x0001;
		[0x1520] = A;
		return this.L81EDC9();
	}

	public void L81ED91()
	{
		C = 1;
		A = [0x14EC];
		A -= [0x7E3DAF] - !C;
		[0x88] = A;
		A = [0x14EE];
		A -= [0x7E3DB1] - !C;
		[0x8A] = A;
		A |= [0x88];

		if (Z == 1)
			return this.L81EDAC();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L81EDAC()
	{

		if (Z == 1)
			return this.L81EDB3();


		if (N == 1)
			return this.L81EDB3();

		return this.L81EDC9();
	}

	public void L81EDB3()
	{
		A = [0x7E3DAF];
		[0x14EC] = A;
		A = [0x7E3DB1];
		[0x14EE] = A;
		A = 0x0001;
		[0x1520] = A;
		return this.L81EDC9();
	}

	public void L81EDC9()
	{
		C = 0;
		A = [0x14E8];
		A += [0x14EC] + C;
		[0x14E8] = A;
		A = [0x14EA];
		A += [0x14EE] + C;
		[0x14EA] = A;
		C = 1;
		A = [0x14E2];
		A -= 0x0000 - !C;
		[0x88] = A;
		A = [0x14E4];
		A -= 0x0000 - !C;
		[0x8A] = A;
		A |= [0x88];

		if (Z == 1)
			return this.L81EDF5();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L81EDF5()
	{

		if (Z == 1)
			return this.L81EDFE();


		if (N == 1)
			return this.L81EE03();

		A = 0x0001;
		return this.L81EE08();
	}

	public void L81EDFE()
	{
		A = 0x0000;
		return this.L81EE08();
	}

	public void L81EE03()
	{
		A = 0xFFFF;
		return this.L81EE08();
	}

	public void L81EE08()
	{
		[0x1516] = A;
		return;
	}

	public void L81EE0C()
	{
		C = 0;
		A = [0x14DE];
		A += [0x14E2] + C;
		[0x14DE] = A;
		A = [0x14E0];
		A += [0x14E4] + C;
		[0x14E0] = A;
		return;
	}

	public void L8280C2()
	{
		Stack.Push(P);
		P &= ~0x30;
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0xB4];
		A <<= 1;
		X = A;
		A = [0x8A2A + X];
		C = 0;
		A += 0x8A2A + C;
		Y = A;
		A = [0x0000 + Y];

		if (N == 0)
			return this.L8280EC();

		A = 0x8200;
		[0x01] = A;
		Y++;
		Y++;
		[0x00] = Y;
		this.L8280E9();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L8280E9()
	{
		return [[0x0000]]();    //24-Bit Address
	}

	public void L8280EC()
	{
		[0xA1] = A;
		A = [0xA6];
		A >>= 1;
		A >>= 1;
		[0x9E] = A;
		temp = A - 0x0080;

		if (C == 1)
			return this.L828116();

		C = 0;
		A += [0xA1] + C;
		temp = A - 0x0080;

		if (C == 1)
			return this.L828107();

		A <<= 1;
		A <<= 1;
		[0xA6] = A;
		return this.L828119();
	}

	public void L828107()
	{
		A = 0x0080;
		C = 1;
		A -= [0x9E] - !C;
		[0xA1] = A;
		A = 0x0200;
		[0xA6] = A;
		return this.L828119();
	}

	public void L828116()
	{
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L828119()
	{
		A = [0x7FF6];
		A &= 0xFF00;
		A |= [0x9E];
		X = A;
		Y++;
		Y++;
	}

	public void L828124()
	{
		[0x7FF6] = X;
		A = [0x0000 + Y];

		if (N == 0)
			return this.L82813A();

		C = 0;
		A += [0xB0] + C;
		[0x7FF0] = A;
		A |= 0x0200;
		[0x7FF3] = A;
		return this.L828146();
	}

	public void L82813A()
	{
		C = 0;
		A += [0xB0] + C;
		[0x7FF0] = A;
		A &= 0xFDFF;
		[0x7FF3] = A;
	}

	public void L828146()
	{
		C = 0;
		A = [0x0002 + Y];
		A += [0xB2] + C;
		[0x7FF1] = A;
		A = [0x0003 + Y];
		A &= [0xA8];
		A |= [0xAA];
		[0x7FF2] = A;
		C = 0;
		A = Y;
		A += 0x0005 + C;
		Y = A;
		X++;
		[0xA1]--;

		if (Z == 0)
			return this.L828124();

		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L82898E()
	{
		A = 0x0000;
		C = 1;
		A -= [0xBE] - !C;
		C = 1;
		A -= [0xB0] - !C;
		[0x010F] = A;
		A = 0x0000;
		C = 1;
		A -= [0xC0] - !C;
		C = 1;
		A -= [0xB2] - !C;
		[0x0111] = A;
		return;
	}

	public void L8289A7()
	{
		A = [0xB8];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L8289E8();

		A = [0xB8];
		temp = A & 0x0040;

		if (Z == 0)
			return this.L8289C8();

		temp = A & 0x0800;

		if (Z == 1)
			return this.L8289C2();

		A = 0x0001;
		[0x0400] = A;
		return this.L8289C8();
	}

	public void L8289C2()
	{
		A = 0x0000;
		[0x0400] = A;
	}

	public void L8289C8()
	{
		A = [0xB8];
		temp = A & 0x2000;

		if (Z == 1)
			return this.L8289E8();

		A = 0x8200;
		[0x01] = A;
		A = 0x89DF;
		[0x00] = A;
		this.L8087A4();
		return this.L8289E8();
	}

	public void L8289E8()
	{
		A = [0xB8];
		temp = A & 0x4000;

		if (Z == 1)
			return this.L828A29();

		A = [0xB8];
		temp = A & 0x0020;

		if (Z == 0)
			return this.L828A09();

		temp = A & 0x0400;

		if (Z == 1)
			return this.L828A03();

		A = 0x0001;
		[0x0400] = A;
		return this.L828A09();
	}

	public void L828A03()
	{
		A = 0x0000;
		[0x0400] = A;
	}

	public void L828A09()
	{
		A = [0xB8];
		temp = A & 0x1000;

		if (Z == 1)
			return this.L828A29();

		A = 0x8200;
		[0x01] = A;
		A = 0x8A20;
		[0x00] = A;
		this.L8087A4();
		return this.L828A29();
	}

	public void L828A29()
	{
		return;
	}

	public void L838000()
	{
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x19EB];
		temp = A & 0x2000;

		if (Z == 1)
			return this.L83800E();

		return this.L83813E();
	}

	public void L83800E()
	{
		A = [0x19EB];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L838021();

		temp = A & 0x4000;

		if (Z == 0)
			return this.L838021();

		Y = 0x0000;
		this.L838160();
	}

	public void L838021()
	{
		A = [0x19ED];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L838034();

		temp = A & 0x4000;

		if (Z == 0)
			return this.L838034();

		Y = 0x0001;
		this.L838160();
	}

	public void L838034()
	{
		A = [0x19EF];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L838047();

		temp = A & 0x4000;

		if (Z == 0)
			return this.L838047();

		Y = 0x0002;
		this.L838160();
	}

	public void L838047()
	{
		A = [0x19F1];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L83805A();

		temp = A & 0x4000;

		if (Z == 0)
			return this.L83805A();

		Y = 0x0003;
		this.L838160();
	}

	public void L83805A()
	{
		A = [0x19F3];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L83806D();

		temp = A & 0x4000;

		if (Z == 0)
			return this.L83806D();

		Y = 0x0004;
		this.L838160();
	}

	public void L83806D()
	{
		A = [0x19F5];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L838080();

		temp = A & 0x4000;

		if (Z == 0)
			return this.L838080();

		Y = 0x0005;
		this.L838160();
	}

	public void L838080()
	{
		A = [0x19F7];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L838093();

		temp = A & 0x4000;

		if (Z == 0)
			return this.L838093();

		Y = 0x0006;
		this.L838160();
	}

	public void L838093()
	{
		A = [0x19F9];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L8380A6();

		temp = A & 0x4000;

		if (Z == 0)
			return this.L8380A6();

		Y = 0x0007;
		this.L838160();
	}

	public void L8380A6()
	{
		A = [0x19FB];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L8380B9();

		temp = A & 0x4000;

		if (Z == 0)
			return this.L8380B9();

		Y = 0x0008;
		this.L838160();
	}

	public void L8380B9()
	{
		A = [0x19FD];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L8380CC();

		temp = A & 0x4000;

		if (Z == 0)
			return this.L8380CC();

		Y = 0x0009;
		this.L838160();
	}

	public void L8380CC()
	{
		A = [0x19FF];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L8380DF();

		temp = A & 0x4000;

		if (Z == 0)
			return this.L8380DF();

		Y = 0x000A;
		this.L838160();
	}

	public void L8380DF()
	{
		A = [0x1A01];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L8380F2();

		temp = A & 0x4000;

		if (Z == 0)
			return this.L8380F2();

		Y = 0x000B;
		this.L838160();
	}

	public void L8380F2()
	{
		A = [0x1A03];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L838105();

		temp = A & 0x4000;

		if (Z == 0)
			return this.L838105();

		Y = 0x000C;
		this.L838160();
	}

	public void L838105()
	{
		A = [0x1A05];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L838118();

		temp = A & 0x4000;

		if (Z == 0)
			return this.L838118();

		Y = 0x000D;
		this.L838160();
	}

	public void L838118()
	{
		A = [0x1A07];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L83812B();

		temp = A & 0x4000;

		if (Z == 0)
			return this.L83812B();

		Y = 0x000E;
		this.L838160();
	}

	public void L83812B()
	{
		A = [0x1A09];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L83813E();

		temp = A & 0x4000;

		if (Z == 0)
			return this.L83813E();

		Y = 0x000F;
		this.L838160();
	}

	public void L83813E()
	{
		B = Stack.Pop();
		return;
	}

	public void L838160()
	{
		[0x1A7B] = Y;
		A = [0x8140 + Y];
		A &= 0x00FF;
		[0x1A7D] = A;
		A = [0x8150 + Y];
		A &= 0x00FF;
		[0x1A7F] = A;
		A = [0x19DB + Y];
		A &= 0x00FF;

		if (Z == 0)
			return this.L8381CB();

		X = [0x1A7F];
		A = [0x19AC + X];
		[0x9C] = A;
		A = [0x19AB + X];
		[0x9B] = A;
	}

	public void L83818A()
	{
		A = [[0x9B]];
		A &= 0x00FF;
		temp = A & 0x0080;

		if (Z == 0)
			return this.L838199();

		this.L838442();
		return this.L8381A8();
	}

	public void L838199()
	{
		A ^= 0x00FF;
		temp = A - 0x0039;

		if (C == 0)
			return this.L8381A3();

	}

	public void L8381A1()
	{
		return this.L8381A1();
	}

	public void L8381A3()
	{
		A <<= 1;
		X = A;
		Cpu.JSR((0x81D6 + X));
	}

	public void L8381A8()
	{
		X = [0x1A7D];
		A = [0x19EB + X];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L8381D5();

		Y = [0x1A7B];
		A = [0x19DB + Y];
		A &= 0x00FF;

		if (Z == 1)
			return this.L83818A();

		X = [0x1A7F];
		A = [0x9C];
		[0x19AC + X] = A;
		A = [0x9B];
		[0x19AB + X] = A;
	}

	public void L8381CB()
	{
		X = [0x1A7B];
		P |= 0x20;
		[0x19DB + X]--;
		P &= ~0x20;
	}

	public void L8381D5()
	{
		return;
	}

	public void L838442()
	{
		X = [0x1A7F];
		A = [0x1A1B + X];
		[0x8F] = A;
		A = [0x1A1C + X];
		[0x90] = A;
		A = [[0x9B]];
		A &= 0x00FF;
		[[]] = A;
		[0xAE9BE6] = A;
		Cpu.TDC();
		A++;
		P |= 0x20;
		A = [[0x9B]];
		[0x19DB + X] = A;
		P &= ~0x20;
		[0x9B]++;
		return;
	}

	public void L838EE1()
	{
		A = [0x150C];
		temp = A & 0x4000;

		if (Z == 0)
			return this.L838EFF();

		A = [0x197A];
		[0x12] = A;
		A = 0x0000;
		[0x14] = A;
		A = [0x1986];
		[0x16] = A;
		A = 0x0000;
		[0x18] = A;
		return this.L838F15();
	}

	public void L838EFF()
	{
		A = [0x14DC];
		[0x12] = A;
		A = 0xFFD8;
		[0x14] = A;
		A = [0x14EA];
		[0x16] = A;
		A = 0xFFE8;
		[0x18] = A;
		return this.L838F15();
	}

	public void L838F15()
	{
		A = [0x14DC];
		C = 1;
		A -= [0x12] - !C;
		[0x7E5BC3] = A;
		C = 0;
		A += 0x0080 + C;
		C = 0;
		A += [0x14] + C;
		C = 0;
		A += [0x14F6] + C;
		[0x14D8] = A;
		A = [0x14EA];
		C = 1;
		A -= [0x16] - !C;
		[0x7E5BC5] = A;
		C = 0;
		A += [0x1500] + C;
		C = 0;
		A += [0x1508] + C;
		C = 0;
		A += [0x150A] + C;
		C = 0;
		A += [0x18] + C;
		C = 0;
		A += [0x14F8] + C;
		[0x14E6] = A;
		A = [0x7E5BC3];
		C = 0;
		A += [0x7E5BCB] + C;
		[0x7E5BC3] = A;
		A = [0x7E5BC5];
		C = 0;
		A += [0x7E5BCD] + C;
		[0x7E5BC5] = A;
		A = [0x14D8];
		[0x1502] = A;
		A = [0x1500];
		C = 1;
		A -= [0x16] - !C;
		C = 0;
		A += [0x1506] + C;
		C = 0;
		A += [0x150A] + C;
		C = 0;
		A += [0x18] + C;
		[0x1504] = A;
		return;
	}

	public void L83955A()
	{
		A = [0x014C];
		A >>= 1;

		if (C == 0)
			return this.L839563();

		return this.L8396AE();
	}

	public void L839563()
	{
		A = [0x7E3963];

		if (Z == 1)
			return this.L83958C();

		A = [0x7E3903];
		[0x12] = A;
		A = [0x7E3923];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 0)
			return this.L83958C();

		A = [0x7E3943];
		[0x16] = A;
		this.L839B44();
	}

	public void L83958C()
	{
		A = [0x7E3967];

		if (Z == 1)
			return this.L8395B5();

		A = [0x7E3907];
		[0x12] = A;
		A = [0x7E3927];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 0)
			return this.L8395B5();

		A = [0x7E3947];
		[0x16] = A;
		this.L839B44();
	}

	public void L8395B5()
	{
		A = [0x7E396B];

		if (Z == 1)
			return this.L8395DE();

		A = [0x7E390B];
		[0x12] = A;
		A = [0x7E392B];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 0)
			return this.L8395DE();

		A = [0x7E394B];
		[0x16] = A;
		this.L839B44();
	}

	public void L8395DE()
	{
		A = [0x7E396F];

		if (Z == 1)
			return this.L839607();

		A = [0x7E390F];
		[0x12] = A;
		A = [0x7E392F];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 0)
			return this.L839607();

		A = [0x7E394F];
		[0x16] = A;
		this.L839B44();
	}

	public void L839607()
	{
		A = [0x7E3973];

		if (Z == 1)
			return this.L839630();

		A = [0x7E3913];
		[0x12] = A;
		A = [0x7E3933];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 0)
			return this.L839630();

		A = [0x7E3953];
		[0x16] = A;
		this.L839B44();
	}

	public void L839630()
	{
		A = [0x7E3977];

		if (Z == 1)
			return this.L839659();

		A = [0x7E3917];
		[0x12] = A;
		A = [0x7E3937];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 0)
			return this.L839659();

		A = [0x7E3957];
		[0x16] = A;
		this.L839B44();
	}

	public void L839659()
	{
		A = [0x7E397B];

		if (Z == 1)
			return this.L839682();

		A = [0x7E391B];
		[0x12] = A;
		A = [0x7E393B];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 0)
			return this.L839682();

		A = [0x7E395B];
		[0x16] = A;
		this.L839B44();
	}

	public void L839682()
	{
		A = [0x7E397F];

		if (Z == 1)
			return this.L8396AB();

		A = [0x7E391F];
		[0x12] = A;
		A = [0x7E393F];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 0)
			return this.L8396AB();

		A = [0x7E395F];
		[0x16] = A;
		this.L839B44();
	}

	public void L8396AB()
	{
		return this.L8397F6();
	}

	public void L8396AE()
	{
		A = [0x7E3965];

		if (Z == 1)
			return this.L8396D7();

		A = [0x7E3905];
		[0x12] = A;
		A = [0x7E3925];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 0)
			return this.L8396D7();

		A = [0x7E3945];
		[0x16] = A;
		this.L839B44();
	}

	public void L8396D7()
	{
		A = [0x7E3969];

		if (Z == 1)
			return this.L839700();

		A = [0x7E3909];
		[0x12] = A;
		A = [0x7E3929];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 0)
			return this.L839700();

		A = [0x7E3949];
		[0x16] = A;
		this.L839B44();
	}

	public void L839700()
	{
		A = [0x7E396D];

		if (Z == 1)
			return this.L839729();

		A = [0x7E390D];
		[0x12] = A;
		A = [0x7E392D];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 0)
			return this.L839729();

		A = [0x7E394D];
		[0x16] = A;
		this.L839B44();
	}

	public void L839729()
	{
		A = [0x7E3971];

		if (Z == 1)
			return this.L839752();

		A = [0x7E3911];
		[0x12] = A;
		A = [0x7E3931];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 0)
			return this.L839752();

		A = [0x7E3951];
		[0x16] = A;
		this.L839B44();
	}

	public void L839752()
	{
		A = [0x7E3975];

		if (Z == 1)
			return this.L83977B();

		A = [0x7E3915];
		[0x12] = A;
		A = [0x7E3935];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 0)
			return this.L83977B();

		A = [0x7E3955];
		[0x16] = A;
		this.L839B44();
	}

	public void L83977B()
	{
		A = [0x7E3979];

		if (Z == 1)
			return this.L8397A4();

		A = [0x7E3919];
		[0x12] = A;
		A = [0x7E3939];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 0)
			return this.L8397A4();

		A = [0x7E3959];
		[0x16] = A;
		this.L839B44();
	}

	public void L8397A4()
	{
		A = [0x7E397D];

		if (Z == 1)
			return this.L8397CD();

		A = [0x7E391D];
		[0x12] = A;
		A = [0x7E393D];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 0)
			return this.L8397CD();

		A = [0x7E395D];
		[0x16] = A;
		this.L839B44();
	}

	public void L8397CD()
	{
		A = [0x7E3981];

		if (Z == 1)
			return this.L8397F6();

		A = [0x7E3921];
		[0x12] = A;
		A = [0x7E3941];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 0)
			return this.L8397F6();

		A = [0x7E3961];
		[0x16] = A;
		this.L839B44();
	}

	public void L8397F6()
	{
		return;
	}

	public void L8397F7()
	{
		A = [0x014C];
		A >>= 1;

		if (C == 0)
			return this.L839800();

		return this.L83994B();
	}

	public void L839800()
	{
		A = [0x7E3963];

		if (Z == 1)
			return this.L839829();

		A = [0x7E3903];
		[0x12] = A;
		A = [0x7E3923];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 1)
			return this.L839829();

		A = [0x7E3943];
		[0x16] = A;
		this.L839BC3();
	}

	public void L839829()
	{
		A = [0x7E3967];

		if (Z == 1)
			return this.L839852();

		A = [0x7E3907];
		[0x12] = A;
		A = [0x7E3927];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 1)
			return this.L839852();

		A = [0x7E3947];
		[0x16] = A;
		this.L839BC3();
	}

	public void L839852()
	{
		A = [0x7E396B];

		if (Z == 1)
			return this.L83987B();

		A = [0x7E390B];
		[0x12] = A;
		A = [0x7E392B];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 1)
			return this.L83987B();

		A = [0x7E394B];
		[0x16] = A;
		this.L839BC3();
	}

	public void L83987B()
	{
		A = [0x7E396F];

		if (Z == 1)
			return this.L8398A4();

		A = [0x7E390F];
		[0x12] = A;
		A = [0x7E392F];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 1)
			return this.L8398A4();

		A = [0x7E394F];
		[0x16] = A;
		this.L839BC3();
	}

	public void L8398A4()
	{
		A = [0x7E3973];

		if (Z == 1)
			return this.L8398CD();

		A = [0x7E3913];
		[0x12] = A;
		A = [0x7E3933];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 1)
			return this.L8398CD();

		A = [0x7E3953];
		[0x16] = A;
		this.L839BC3();
	}

	public void L8398CD()
	{
		A = [0x7E3977];

		if (Z == 1)
			return this.L8398F6();

		A = [0x7E3917];
		[0x12] = A;
		A = [0x7E3937];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 1)
			return this.L8398F6();

		A = [0x7E3957];
		[0x16] = A;
		this.L839BC3();
	}

	public void L8398F6()
	{
		A = [0x7E397B];

		if (Z == 1)
			return this.L83991F();

		A = [0x7E391B];
		[0x12] = A;
		A = [0x7E393B];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 1)
			return this.L83991F();

		A = [0x7E395B];
		[0x16] = A;
		this.L839BC3();
	}

	public void L83991F()
	{
		A = [0x7E397F];

		if (Z == 1)
			return this.L839948();

		A = [0x7E391F];
		[0x12] = A;
		A = [0x7E393F];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 1)
			return this.L839948();

		A = [0x7E395F];
		[0x16] = A;
		this.L839BC3();
	}

	public void L839948()
	{
		return this.L839A93();
	}

	public void L83994B()
	{
		A = [0x7E3965];

		if (Z == 1)
			return this.L839974();

		A = [0x7E3905];
		[0x12] = A;
		A = [0x7E3925];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 1)
			return this.L839974();

		A = [0x7E3945];
		[0x16] = A;
		this.L839BC3();
	}

	public void L839974()
	{
		A = [0x7E3969];

		if (Z == 1)
			return this.L83999D();

		A = [0x7E3909];
		[0x12] = A;
		A = [0x7E3929];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 1)
			return this.L83999D();

		A = [0x7E3949];
		[0x16] = A;
		this.L839BC3();
	}

	public void L83999D()
	{
		A = [0x7E396D];

		if (Z == 1)
			return this.L8399C6();

		A = [0x7E390D];
		[0x12] = A;
		A = [0x7E392D];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 1)
			return this.L8399C6();

		A = [0x7E394D];
		[0x16] = A;
		this.L839BC3();
	}

	public void L8399C6()
	{
		A = [0x7E3971];

		if (Z == 1)
			return this.L8399EF();

		A = [0x7E3911];
		[0x12] = A;
		A = [0x7E3931];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 1)
			return this.L8399EF();

		A = [0x7E3951];
		[0x16] = A;
		this.L839BC3();
	}

	public void L8399EF()
	{
		A = [0x7E3975];

		if (Z == 1)
			return this.L839A18();

		A = [0x7E3915];
		[0x12] = A;
		A = [0x7E3935];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 1)
			return this.L839A18();

		A = [0x7E3955];
		[0x16] = A;
		this.L839BC3();
	}

	public void L839A18()
	{
		A = [0x7E3979];

		if (Z == 1)
			return this.L839A41();

		A = [0x7E3919];
		[0x12] = A;
		A = [0x7E3939];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 1)
			return this.L839A41();

		A = [0x7E3959];
		[0x16] = A;
		this.L839BC3();
	}

	public void L839A41()
	{
		A = [0x7E397D];

		if (Z == 1)
			return this.L839A6A();

		A = [0x7E391D];
		[0x12] = A;
		A = [0x7E393D];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 1)
			return this.L839A6A();

		A = [0x7E395D];
		[0x16] = A;
		this.L839BC3();
	}

	public void L839A6A()
	{
		A = [0x7E3981];

		if (Z == 1)
			return this.L839A93();

		A = [0x7E3921];
		[0x12] = A;
		A = [0x7E3941];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;

		if (Z == 1)
			return this.L839A93();

		A = [0x7E3961];
		[0x16] = A;
		this.L839BC3();
	}

	public void L839A93()
	{
		A = [0x7E3963];

		if (Z == 1)
			return this.L839A9E();

		A--;
		[0x7E3963] = A;
	}

	public void L839A9E()
	{
		A = [0x7E3965];

		if (Z == 1)
			return this.L839AA9();

		A--;
		[0x7E3965] = A;
	}

	public void L839AA9()
	{
		A = [0x7E3967];

		if (Z == 1)
			return this.L839AB4();

		A--;
		[0x7E3967] = A;
	}

	public void L839AB4()
	{
		A = [0x7E3969];

		if (Z == 1)
			return this.L839ABF();

		A--;
		[0x7E3969] = A;
	}

	public void L839ABF()
	{
		A = [0x7E396B];

		if (Z == 1)
			return this.L839ACA();

		A--;
		[0x7E396B] = A;
	}

	public void L839ACA()
	{
		A = [0x7E396D];

		if (Z == 1)
			return this.L839AD5();

		A--;
		[0x7E396D] = A;
	}

	public void L839AD5()
	{
		A = [0x7E396F];

		if (Z == 1)
			return this.L839AE0();

		A--;
		[0x7E396F] = A;
	}

	public void L839AE0()
	{
		A = [0x7E3971];

		if (Z == 1)
			return this.L839AEB();

		A--;
		[0x7E3971] = A;
	}

	public void L839AEB()
	{
		A = [0x7E3973];

		if (Z == 1)
			return this.L839AF6();

		A--;
		[0x7E3973] = A;
	}

	public void L839AF6()
	{
		A = [0x7E3975];

		if (Z == 1)
			return this.L839B01();

		A--;
		[0x7E3975] = A;
	}

	public void L839B01()
	{
		A = [0x7E3977];

		if (Z == 1)
			return this.L839B0C();

		A--;
		[0x7E3977] = A;
	}

	public void L839B0C()
	{
		A = [0x7E3979];

		if (Z == 1)
			return this.L839B17();

		A--;
		[0x7E3979] = A;
	}

	public void L839B17()
	{
		A = [0x7E397B];

		if (Z == 1)
			return this.L839B22();

		A--;
		[0x7E397B] = A;
	}

	public void L839B22()
	{
		A = [0x7E397D];

		if (Z == 1)
			return this.L839B2D();

		A--;
		[0x7E397D] = A;
	}

	public void L839B2D()
	{
		A = [0x7E397F];

		if (Z == 1)
			return this.L839B38();

		A--;
		[0x7E397F] = A;
	}

	public void L839B38()
	{
		A = [0x7E3981];

		if (Z == 1)
			return this.L839B43();

		A--;
		[0x7E3981] = A;
	}

	public void L839B43()
	{
		return;
	}

	public void L839B44()
	{
		A = [0x1866 + X];

		if (N == 1)
			return this.L839BA0();

		A = [[0x00]];
		temp = A & 0x0080;

		if (Z == 0)
			return this.L839B55();

		A &= 0x007F;
		return this.L839B58();
	}

	public void L839B55()
	{
		A |= 0xFF80;
	}

	public void L839B58()
	{
		C = 0;
		A += [0x15A6 + X] + C;
		[0xB0] = A;
		C = 0;
		A += 0x0020 + C;
		temp = A - 0x0140;

		if (C == 1)
			return this.L839BA0();

		Y = 0x0001;
		A = [[0x00] + Y];
		temp = A & 0x0080;

		if (Z == 0)
			return this.L839B76();

		A &= 0x007F;
		return this.L839B79();
	}

	public void L839B76()
	{
		A |= 0xFF80;
	}

	public void L839B79()
	{
		C = 0;
		A += [0x15E6 + X] + C;
		[0xB2] = A;
		C = 0;
		A += 0x0020 + C;
		temp = A - 0x00E8;

		if (C == 1)
			return this.L839BA0();

		A = 0xC1FF;
		[0xA8] = A;
		A = [0x14D6];
		A <<= 1;
		X = A;
		A = [0x839BA1 + X];
		[0xAA] = A;
		A = [0x16];
		[0xB4] = A;
		this.L8280C2();
	}

	public void L839BA0()
	{
		return;
	}

	public void L839BC3()
	{
		A = [0x1866 + X];

		if (N == 1)
			return this.L839C1F();

		A = [[0x00]];
		temp = A & 0x0080;

		if (Z == 0)
			return this.L839BD4();

		A &= 0x007F;
		return this.L839BD7();
	}

	public void L839BD4()
	{
		A |= 0xFF80;
	}

	public void L839BD7()
	{
		C = 0;
		A += [0x15A6 + X] + C;
		[0xB0] = A;
		C = 0;
		A += 0x0020 + C;
		temp = A - 0x0140;

		if (C == 1)
			return this.L839C1F();

		Y = 0x0001;
		A = [[0x00] + Y];
		temp = A & 0x0080;

		if (Z == 0)
			return this.L839BF5();

		A &= 0x007F;
		return this.L839BF8();
	}

	public void L839BF5()
	{
		A |= 0xFF80;
	}

	public void L839BF8()
	{
		C = 0;
		A += [0x15E6 + X] + C;
		[0xB2] = A;
		C = 0;
		A += 0x0020 + C;
		temp = A - 0x00E8;

		if (C == 1)
			return this.L839C1F();

		A = 0xC1FF;
		[0xA8] = A;
		A = [0x14D6];
		A <<= 1;
		X = A;
		A = [0x839C20 + X];
		[0xAA] = A;
		A = [0x16];
		[0xB4] = A;
		this.L8280C2();
	}

	public void L839C1F()
	{
		return;
	}

	public void L839C42()
	{
		A = [0x7E3901];
		[0x01] = A;
		A = [0x7E3900];
		[0x00] = A;
		A = [0x12];
		A <<= 1;
		X = A;
		A = [0x1666 + X];
		A <<= 1;
		Y = A;
		A = [[0x00] + Y];
		C = 0;
		A += [0x00] + C;
		[0x00] = A;
		A = [0x14];
		A <<= 1;
		C = 0;
		A += [0x14] + C;
		C = 0;
		A += [0x00] + C;
		[0x00] = A;
		return;
	}

	public void L839C9C()
	{
		A = [0x1A81];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L839CB0();

		A &= 0x7FFF;
		[0x1A81] = A;
		X = 0x0000;
		this.L839F1E();
	}

	public void L839CB0()
	{
		A = [0x1A83];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L839CC4();

		A &= 0x7FFF;
		[0x1A83] = A;
		X = 0x0002;
		this.L839F1E();
	}

	public void L839CC4()
	{
		A = [0x1A85];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L839CD8();

		A &= 0x7FFF;
		[0x1A85] = A;
		X = 0x0004;
		this.L839F1E();
	}

	public void L839CD8()
	{
		A = [0x1A87];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L839CEC();

		A &= 0x7FFF;
		[0x1A87] = A;
		X = 0x0006;
		this.L839F1E();
	}

	public void L839CEC()
	{
		A = [0x1A89];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L839D00();

		A &= 0x7FFF;
		[0x1A89] = A;
		X = 0x0008;
		this.L839F1E();
	}

	public void L839D00()
	{
		A = [0x1A8B];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L839D14();

		A &= 0x7FFF;
		[0x1A8B] = A;
		X = 0x000A;
		this.L839F1E();
	}

	public void L839D14()
	{
		A = [0x1A8D];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L839D28();

		A &= 0x7FFF;
		[0x1A8D] = A;
		X = 0x000C;
		this.L839F1E();
	}

	public void L839D28()
	{
		A = [0x1A8F];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L839D3C();

		A &= 0x7FFF;
		[0x1A8F] = A;
		X = 0x000E;
		this.L839F1E();
	}

	public void L839D3C()
	{
		A = [0x1A91];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L839D50();

		A &= 0x7FFF;
		[0x1A91] = A;
		X = 0x0010;
		this.L839F1E();
	}

	public void L839D50()
	{
		A = [0x1A93];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L839D64();

		A &= 0x7FFF;
		[0x1A93] = A;
		X = 0x0012;
		this.L839F1E();
	}

	public void L839D64()
	{
		A = [0x1A95];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L839D78();

		A &= 0x7FFF;
		[0x1A95] = A;
		X = 0x0014;
		this.L839F1E();
	}

	public void L839D78()
	{
		A = [0x1A97];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L839D8C();

		A &= 0x7FFF;
		[0x1A97] = A;
		X = 0x0016;
		this.L839F1E();
	}

	public void L839D8C()
	{
		A = [0x1A99];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L839DA0();

		A &= 0x7FFF;
		[0x1A99] = A;
		X = 0x0018;
		this.L839F1E();
	}

	public void L839DA0()
	{
		A = [0x1A9B];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L839DB4();

		A &= 0x7FFF;
		[0x1A9B] = A;
		X = 0x001A;
		this.L839F1E();
	}

	public void L839DB4()
	{
		A = [0x1A9D];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L839DC8();

		A &= 0x7FFF;
		[0x1A9D] = A;
		X = 0x001C;
		this.L839F1E();
	}

	public void L839DC8()
	{
		A = [0x1A9F];
		temp = A & 0x8000;

		if (Z == 1)
			return this.L839DDC();

		A &= 0x7FFF;
		[0x1A9F] = A;
		X = 0x001E;
		this.L839F1E();
	}

	public void L839DDC()
	{
		return;
	}

	public void L839DDD()
	{
		A = [0x1A81];
		temp = A & 0x4000;

		if (Z == 1)
			return this.L839DF1();

		A &= 0xBFFF;
		[0x1A81] = A;
		X = 0x0000;
		this.L839F1E();
	}

	public void L839DF1()
	{
		A = [0x1A83];
		temp = A & 0x4000;

		if (Z == 1)
			return this.L839E05();

		A &= 0xBFFF;
		[0x1A83] = A;
		X = 0x0002;
		this.L839F1E();
	}

	public void L839E05()
	{
		A = [0x1A85];
		temp = A & 0x4000;

		if (Z == 1)
			return this.L839E19();

		A &= 0xBFFF;
		[0x1A85] = A;
		X = 0x0004;
		this.L839F1E();
	}

	public void L839E19()
	{
		A = [0x1A87];
		temp = A & 0x4000;

		if (Z == 1)
			return this.L839E2D();

		A &= 0xBFFF;
		[0x1A87] = A;
		X = 0x0006;
		this.L839F1E();
	}

	public void L839E2D()
	{
		A = [0x1A89];
		temp = A & 0x4000;

		if (Z == 1)
			return this.L839E41();

		A &= 0xBFFF;
		[0x1A89] = A;
		X = 0x0008;
		this.L839F1E();
	}

	public void L839E41()
	{
		A = [0x1A8B];
		temp = A & 0x4000;

		if (Z == 1)
			return this.L839E55();

		A &= 0xBFFF;
		[0x1A8B] = A;
		X = 0x000A;
		this.L839F1E();
	}

	public void L839E55()
	{
		A = [0x1A8D];
		temp = A & 0x4000;

		if (Z == 1)
			return this.L839E69();

		A &= 0xBFFF;
		[0x1A8D] = A;
		X = 0x000C;
		this.L839F1E();
	}

	public void L839E69()
	{
		A = [0x1A8F];
		temp = A & 0x4000;

		if (Z == 1)
			return this.L839E7D();

		A &= 0xBFFF;
		[0x1A8F] = A;
		X = 0x000E;
		this.L839F1E();
	}

	public void L839E7D()
	{
		A = [0x1A91];
		temp = A & 0x4000;

		if (Z == 1)
			return this.L839E91();

		A &= 0xBFFF;
		[0x1A91] = A;
		X = 0x0010;
		this.L839F1E();
	}

	public void L839E91()
	{
		A = [0x1A93];
		temp = A & 0x4000;

		if (Z == 1)
			return this.L839EA5();

		A &= 0xBFFF;
		[0x1A93] = A;
		X = 0x0012;
		this.L839F1E();
	}

	public void L839EA5()
	{
		A = [0x1A95];
		temp = A & 0x4000;

		if (Z == 1)
			return this.L839EB9();

		A &= 0xBFFF;
		[0x1A95] = A;
		X = 0x0014;
		this.L839F1E();
	}

	public void L839EB9()
	{
		A = [0x1A97];
		temp = A & 0x4000;

		if (Z == 1)
			return this.L839ECD();

		A &= 0xBFFF;
		[0x1A97] = A;
		X = 0x0016;
		this.L839F1E();
	}

	public void L839ECD()
	{
		A = [0x1A99];
		temp = A & 0x4000;

		if (Z == 1)
			return this.L839EE1();

		A &= 0xBFFF;
		[0x1A99] = A;
		X = 0x0018;
		this.L839F1E();
	}

	public void L839EE1()
	{
		A = [0x1A9B];
		temp = A & 0x4000;

		if (Z == 1)
			return this.L839EF5();

		A &= 0xBFFF;
		[0x1A9B] = A;
		X = 0x001A;
		this.L839F1E();
	}

	public void L839EF5()
	{
		A = [0x1A9D];
		temp = A & 0x4000;

		if (Z == 1)
			return this.L839F09();

		A &= 0xBFFF;
		[0x1A9D] = A;
		X = 0x001C;
		this.L839F1E();
	}

	public void L839F09()
	{
		A = [0x1A9F];
		temp = A & 0x4000;

		if (Z == 1)
			return this.L839F1D();

		A &= 0xBFFF;
		[0x1A9F] = A;
		X = 0x001E;
		this.L839F1E();
	}

	public void L839F1D()
	{
		return;
	}

	public void L839F1E()
	{
		A = [0x7E5C2C + X];
		[0xB0] = A;
		C = 0;
		A += 0x0020 + C;
		temp = A - 0x0140;

		if (C == 1)
			return this.L839F52();

		A = [0x7E5C4C + X];
		[0xB2] = A;
		C = 0;
		A += 0x0020 + C;
		temp = A - 0x00E8;

		if (C == 1)
			return this.L839F52();

		A = [0x7E5C6C + X];
		[0xB4] = A;
		A = [0x7E5C8C + X];
		[0xA8] = A;
		A = [0x7E5CAC + X];
		[0xAA] = A;
		this.L8280C2();
	}

	public void L839F52()
	{
		return;
	}

	public void L908453()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		this.L91B091();
		this.L908907();
		this.L908DCF();
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L908907()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		this.L909245();
		this.L909492();
		this.L9094EE();
		this.L90941C();
		this.L9097A0();
		this.L9096CC();
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L908DCF()
	{
		Stack.Push(P);
		A = 0x9000;
		[0x01] = A;
		A = 0x8DE0;
		[0x00] = A;
		this.L8087A4();
		P = Stack.Pop();
		return;
	}

	public void L90916D()
	{
		A &= 0x00FF;
		A <<= 1;
		X = A;
		A = [0x9B60 + X];
		A &= 0x00FF;
		C = 0;
		A += 0x0090 + C;
		A |= 0x2000;
		Stack.Push(X);
		X = Y;
		Y = Stack.Pop();
		[0x7E3000 + X] = A;
		return;
	}

	public void L909187()
	{
		A &= 0x00FF;
		A <<= 1;
		X = A;
		A = [0x9B61 + X];
		A &= 0x00FF;
		C = 0;
		A += 0x0090 + C;
		A |= 0x2000;
		Stack.Push(X);
		X = Y;
		Y = Stack.Pop();
		[0x7E3000 + X] = A;
		Stack.Push(X);
		X = Y;
		Y = Stack.Pop();
		A = [0x9B60 + X];
		A &= 0x00FF;
		C = 0;
		A += 0x0090 + C;
		A |= 0x2000;
		Stack.Push(X);
		X = Y;
		Y = Stack.Pop();
		[0x7E3002 + X] = A;
		return;
	}

	public void L909245()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x1BC7];
		A--;

		if (Z == 1)
			return this.L909252();

		this.L909258();
	}

	public void L909252()
	{
		this.L909335();
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L909258()
	{
		A = [0x0375];
		temp = A - [0x0379];

		if (Z == 1)
			return this.L90926A();


		if (N == 0)
			return this.L909267();

		[0x0379]--;
		return this.L90926A();
	}

	public void L909267()
	{
		[0x0379]++;
	}

	public void L90926A()
	{
		A = 0x3089;
		[0x7E30CC] = A;
		[0x7E30CE] = A;
		[0x7E30D0] = A;
		[0x7E30D2] = A;
		[0x7E30D4] = A;
		[0x7E30D6] = A;
		[0x7E30D8] = A;
		[0x7E30DA] = A;
		[0x7E30DC] = A;
		[0x7E30DE] = A;
		[0x7E30E0] = A;
		[0x7E30E2] = A;
		[0x7E30E4] = A;
		[0x7E30E6] = A;
		[0x7E30E8] = A;
		[0x7E30EA] = A;
		A = [0x0379];
		temp = A - 0x0080;

		if (Z == 1)
			return this.L909312();

		A &= 0x00F8;
		A >>= 1;
		A >>= 1;
		X = A;
		A = [0x0379];
		A &= 0x0007;
		C = 0;
		A += 0x0081 + C;
		A |= 0x3000;
		[0x7E30CC + X] = A;
		A = 0x3081;
		return [(0x9313 + X)]();
	}

	public void L909312()
	{
		return;
	}

	public void L909335()
	{
		A = [0x0377];
		temp = A - [0x037B];

		if (Z == 1)
			return this.L909347();


		if (N == 0)
			return this.L909344();

		[0x037B]--;
		return this.L909347();
	}

	public void L909344()
	{
		[0x037B]++;
	}

	public void L909347()
	{
		A = 0x3089;
		[0x7E310C] = A;
		[0x7E310E] = A;
		[0x7E3110] = A;
		[0x7E3112] = A;
		[0x7E3114] = A;
		[0x7E3116] = A;
		[0x7E3118] = A;
		[0x7E311A] = A;
		[0x7E311C] = A;
		[0x7E311E] = A;
		[0x7E3120] = A;
		[0x7E3122] = A;
		[0x7E3124] = A;
		[0x7E3126] = A;
		[0x7E3128] = A;
		[0x7E312A] = A;
		A = [0x037B];
		temp = A - 0x0080;

		if (Z == 1)
			return this.L9093EF();

		A &= 0x00F8;
		A >>= 1;
		A >>= 1;
		X = A;
		A = [0x037B];
		A &= 0x0007;
		C = 0;
		A += 0x0081 + C;
		A |= 0x3000;
		[0x7E310C + X] = A;
		A = 0x3081;
		return [(0x93F0 + X)]();
	}

	public void L9093EF()
	{
		return;
	}

	public void L90941C()
	{
		A = [0x1968];

		if (N == 1)
			return this.L90947F();

		A = [0x026D];
		temp = A - 0x00D2;

		if (Z == 1)
			return this.L90947F();

		A = 0x0080;
		[0x7E31AE] = A;
		[0x7E31B0] = A;
		[0x7E31B2] = A;
		[0x7E31B4] = A;
		[0x7E31B6] = A;
		[0x7E31B8] = A;
		[0x7E31BA] = A;
		[0x7E31BC] = A;
		A = [0x03FE];
		temp = A - 0x0008;

		if (C == 1)
			return this.L90945C();

		A <<= 1;
		X = A;
		A = 0x30FE;
		return [(0x9480 + X)]();
	}

	public void L90945C()
	{
		A = 0x30FE;
		[0x7E31AE] = A;
		[0x7E31B0] = A;
		[0x7E31B2] = A;
		[0x7E31B4] = A;
		[0x7E31B6] = A;
		[0x7E31B8] = A;
		[0x7E31BA] = A;
		[0x7E31BC] = A;
	}

	public void L90947F()
	{
		return;
	}

	public void L909492()
	{
		A = [0x014C];
		A &= 0x0007;
		temp = A - 0x0007;

		if (Z == 0)
			return this.L9094C5();

		A = [0x03DE];
		A--;

		if (N == 0)
			return this.L9094A6();

		A = 0x0004;
	}

	public void L9094A6()
	{
		[0x03DE] = A;
		A <<= 1;
		C = 0;
		A += [0x03DE] + C;
		A <<= 1;
		X = A;
		A = [0x94C6 + X];
		[0x7E35C2] = A;
		A = [0x94C8 + X];
		[0x7E35CE] = A;
		A = [0x94CA + X];
		[0x7E35D0] = A;
	}

	public void L9094C5()
	{
		return;
	}

	public void L9094EE()
	{
		A = [0x0458];

		if (N == 0)
			return this.L9094F7();

		A ^= 0xFFFF;
		A++;
	}

	public void L9094F7()
	{
		A &= 0x000E;
		A ^= 0x000E;
		A >>= 1;
		[0x12] = A;
		A = [0x03E2];
		[0x03E2]++;
		temp = A - [0x12];

		if (C == 0)
			return this.L90952D();

		[0x03E2] = 0;
		A = [0x03E0];
		A--;

		if (N == 0)
			return this.L909516();

		A = 0x0003;
	}

	public void L909516()
	{
		[0x03E0] = A;
		A <<= 1;
		C = 0;
		A += [0x03E0] + C;
		X = A;
		A = [0x952F + X];
		[0x01] = A;
		A = [0x952E + X];
		[0x00] = A;
		this.L8087A4();
	}

	public void L90952D()
	{
		return;
	}

	public void L9096CC()
	{
		A = [0x0367];
		temp = A - 0x0007;

		if (Z == 1)
			return this.L909735();

		A = [0x0456];
		[0x28] = A;
		A = [0x0458];
		[0x2A] = A;

		if (N == 0)
			return this.L9096F6();

		A = [0x0456];
		A ^= 0xFFFF;
		C = 0;
		A += 0x0001 + C;
		[0x28] = A;
		A = [0x2A];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x2A] = A;
	}

	public void L9096F6()
	{
		A = [0x28];
		A = (A >> 4) | (A << 4);
		A >>= 1;
		A >>= 1;
		A >>= 1;
		A >>= 1;
		A >>= 1;
		A &= 0x0007;
		Y = 0x0678;
		this.L90916D();
		A = [0x2A];
		A <<= 1;
		A <<= 1;
		A <<= 1;
		C = 0;
		A += [0x2A] + C;
		temp = A - 0x0064;

		if (C == 0)
			return this.L909723();

		C = 1;
		A -= 0x0064 - !C;
		[0x26] = A;
		A = 0x2091;
		[0x7E3670] = A;
		return this.L90972C();
	}

	public void L909723()
	{
		[0x26] = A;
		A = 0x2090;
		[0x7E3670] = A;
	}

	public void L90972C()
	{
		Y = 0x0672;
		A = [0x26];
		this.L909187();
		return;
	}

	public void L909735()
	{
		A = [0x0452];
		[0x26] = A;
		A = [0x0454];
		[0x28] = A;

		if (N == 0)
			return this.L909745();

		[0x26] = 0;
		[0x28] = 0;
	}

	public void L909745()
	{
		A = [0x27];
		A &= 0x0FFF;
		[0x2C] = A;
		A <<= 1;
		C = 0;
		A += [0x2C] + C;
		[0x2C] = A;
		temp = A - 0x270F;

		if (C == 0)
			return this.L90975C();

		A = 0x270F;
		[0x2C] = A;
	}

	public void L90975C()
	{
		Y = 0x0670;
		A = 0x03E8;
		[0x2E] = A;
		this.L8086B1();
		A = [0x2C];
		this.L90916D();
		Y = 0x0672;
		A = [0x26];
		[0x2C] = A;
		A = 0x0064;
		[0x2E] = A;
		this.L8086B1();
		A = [0x2C];
		this.L90916D();
		Y = 0x0674;
		A = [0x26];
		[0x2C] = A;
		A = 0x000A;
		[0x2E] = A;
		this.L8086B1();
		A = [0x2C];
		this.L90916D();
		Y = 0x0678;
		A = [0x26];
		this.L90916D();
		return;
	}

	public void L9097A0()
	{
		A = [0x14D8];
		C = 1;
		A -= 0x0080 - !C;
		[0x0385] = A;
		A = [0x0385];

		if (N == 0)
			return this.L9097B3();

		A ^= 0xFFFF;
		A++;
	}

	public void L9097B3()
	{
		[0x28] = A;
		A >>= 1;
		A >>= 1;
		A >>= 1;
		temp = A - 0x0064;

		if (N == 1)
			return this.L9097C0();

		A = 0x0063;
	}

	public void L9097C0()
	{
		[0x26] = A;
		Y = 0x060E;
		this.L909187();
		A = 0x208A;
		[0x7E3604] = A;
		[0x7E3606] = A;
		[0x7E3608] = A;
		[0x7E360A] = A;
		A = [0x28];

		if (Z == 1)
			return this.L909828();

		temp = A - 0x003F;

		if (N == 0)
			return this.L909815();

		A = 0x003F;
		C = 1;
		A -= [0x28] - !C;
		A >>= 1;
		A >>= 1;
		A >>= 1;
		A &= 0xFFFE;
		X = A;
		A = [0x28];
		A &= 0xFFF0;
		C = 1;
		A -= [0x28] - !C;
		A ^= 0xFFFF;
		A++;
		A >>= 1;
		A >>= 1;
		C = 0;
		A += 0x208A + C;
		[0x7E3604 + X] = A;
		A = 0x208E;
		return [(0x980D + X)]();
	}

	public void L909815()
	{
		A = 0x208E;
		[0x7E3604] = A;
		[0x7E3606] = A;
		[0x7E3608] = A;
		[0x7E360A] = A;
	}

	public void L909828()
	{
		A = [0x0385];

		if (N == 0)
			return this.L909835();

		A = 0x388F;
		[0x7E360C] = A;
		return;
	}

	public void L909835()
	{
		A = 0x788F;
		[0x7E360C] = A;
		return;
	}

	public void L91B091()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x0B00];
		temp = A - [0x0B02];

		if (Z == 0)
			return this.L91B0D2();

		temp = A - 0xFFFF;

		if (Z == 1)
			return this.L91B0C9();

		A = [0x0B04];
		A |= [0x0B06];
		A |= [0x0B08];
		A |= [0x0B0A];
		A |= [0x0B0C];
		A |= [0x0B0E];

		if (Z == 0)
			return this.L91B0BB();

		A = [0x0B34];

		if (Z == 0)
			return this.L91B0CC();

	}

	public void L91B0BB()
	{
		X = 0x000A;
	}

	public void L91B0BE()
	{
		A = [0x0B04 + X];

		if (Z == 1)
			return this.L91B0C5();


		if (N == 0)
			return this.L91B117();

	}

	public void L91B0C5()
	{
		X--;
		X--;

		if (N == 0)
			return this.L91B0BE();

	}

	public void L91B0C9()
	{
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L91B0CC()
	{
		A = 0xFFFF;
		[0x0B00] = A;
	}

	public void L91B0D2()
	{
		[0x0B0E] = 0;
		[0x0B26] = 0;
		A = [0x0B00];
		[0x0B02] = A;
		temp = A - 0xFFFF;

		if (Z == 1)
			return this.L91B0F0();

		[0x12] = A;
		A <<= 1;
		C = 0;
		A += [0x12] + C;
		X = A;
		this.L91B104();
		return this.L91B0BB();
	}

	public void L91B0F0()
	{
		[0x0B04] = 0;
		[0x0B06] = 0;
		[0x0B08] = 0;
		[0x0B0A] = 0;
		[0x0B0C] = 0;
		[0x0B0E] = 0;
		return this.L91B0C9();
	}

	public void L91B104()
	{
		A = [0xB2A5 + X];
		[0x00] = A;
		P |= 0x20;
		A = [0xB2A7 + X];
		[0x02] = A;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		return [[0x0000]]();    //24-Bit Address
	}

	public void L91B117()
	{
		A = [0x0B1C + X];

		if (Z == 1)
			return this.L91B121();

		[0x0B1C + X]--;
		return this.L91B0C5();
	}

	public void L91B121()
	{
		A = [0x0B10 + X];
		[0x00] = A;
		A = [(0x00)];
		A &= 0x00FF;
		temp = A - 0x0081;

		if (Z == 0)
			return this.L91B133();

		return this.L91B17E();
	}

	public void L91B133()
	{
		temp = A - 0x0083;

		if (Z == 0)
			return this.L91B13B();

		return this.L91B216();
	}

	public void L91B13B()
	{
		Y = A;
		A &= 0x00C0;
		temp = A - 0x00C0;

		if (Z == 0)
			return this.L91B147();

		return this.L91B221();
	}

	public void L91B147()
	{
		A = Y;
		A &= 0x00A0;
		temp = A - 0x00A0;

		if (Z == 0)
			return this.L91B153();

		return this.L91B23B();
	}

	public void L91B153()
	{
		A = Y;
		temp = A - 0x0085;

		if (Z == 0)
			return this.L91B15C();

		return this.L91B29F();
	}

	public void L91B15C()
	{
		temp = A - 0x0086;

		if (Z == 0)
			return this.L91B164();

		return this.L91B263();
	}

	public void L91B164()
	{
		temp = A - 0x0087;

		if (Z == 0)
			return this.L91B16C();

		return this.L91B281();
	}

	public void L91B16C()
	{
		temp = A - 0x0082;

		if (Z == 0)
			return this.L91B174();

		return this.L91B1C8();
	}

	public void L91B174()
	{
		A &= 0x0080;

		if (Z == 0)
			return this.L91B17C();

		return this.L91B208();
	}

	public void L91B17C()
	{
		return this.L91B17C();
	}

	public void L91B17E()
	{
		Stack.Push(X);
		Y = 0x0001;
		A = [(0x00) + Y];
		A &= 0x00FF;
		A <<= 1;
		[0x12] = A;
		Y++;
		A = [(0x00) + Y];
		A &= 0x00FF;
		[0x14] = A;
		Y++;
		A = [(0x00) + Y];
		A <<= 1;
		[0x16] = A;
	}

	public void L91B198()
	{
		X = [0x16];
		A = [0x7F0761 + X];
		Y = A;
		A = [0x7F1261 + X];
		X = [0x12];
		[0x7F1061 + X] = A;
		A = Y;
		[0x7F0561 + X] = A;
		[0x12]++;
		[0x12]++;
		[0x16]++;
		[0x16]++;
		[0x14]--;

		if (Z == 0)
			return this.L91B198();

		X = Stack.Pop();
		A = [0x0B10 + X];
		C = 0;
		A += 0x0005 + C;
		[0x0B10 + X] = A;
		return this.L91B121();
	}

	public void L91B1C8()
	{
		Stack.Push(X);
		Y = 0x0001;
		A = [(0x00) + Y];
		A &= 0x00FF;
		A <<= 1;
		[0x12] = A;
		Y++;
		A = [(0x00) + Y];
		A &= 0x00FF;
		[0x14] = A;
		Y++;
		A = [(0x00) + Y];
		A <<= 1;
		[0x16] = A;
	}

	public void L91B1E2()
	{
		X = [0x16];
		A = [0x7F0761 + X];
		X = [0x12];
		[0x7F0561 + X] = A;
		[0x12]++;
		[0x12]++;
		[0x16]++;
		[0x16]++;
		[0x14]--;

		if (Z == 0)
			return this.L91B1E2();

		X = Stack.Pop();
		A = [0x0B10 + X];
		C = 0;
		A += 0x0005 + C;
		[0x0B10 + X] = A;
		return this.L91B121();
	}

	public void L91B208()
	{
		A = [(0x00)];
		A &= 0x00FF;
		[0x0B1C + X] = A;
		[0x0B10 + X]++;
		return this.L91B0C5();
	}

	public void L91B216()
	{
		Y = 0x0001;
		A = [(0x00) + Y];
		[0x0B10 + X] = A;
		return this.L91B121();
	}

	public void L91B221()
	{
		A = [(0x00)];
		A &= 0x001F;
		A <<= 1;
		Y = A;
		[0x00]++;
		A = [(0x00)];
		A &= 0x00FF;
		[0x0B28 + Y] = A;
		[0x0B10 + X]++;
		[0x0B10 + X]++;
		return this.L91B121();
	}

	public void L91B23B()
	{
		A = [(0x00)];
		A &= 0x001F;
		A <<= 1;
		Y = A;
		A = [0x0B28 + Y];
		A--;
		[0x0B28 + Y] = A;

		if (Z == 1)
			return this.L91B256();

		Y = 0x0001;
		A = [(0x00) + Y];
		[0x0B10 + X] = A;
		return this.L91B121();
	}

	public void L91B256()
	{
		A = [0x0B10 + X];
		C = 0;
		A += 0x0003 + C;
		[0x0B10 + X] = A;
		return this.L91B121();
	}

	public void L91B263()
	{
		Y = 0x0001;
		A = [(0x00) + Y];
		Y = A;
		A = [0x0B04 + Y];

		if (Z == 1)
			return this.L91B274();

		A = 0xFFFF;
		[0x0B04 + Y] = A;
	}

	public void L91B274()
	{
		A = [0x0B10 + X];
		C = 0;
		A += 0x0002 + C;
		[0x0B10 + X] = A;
		return this.L91B0C5();
	}

	public void L91B281()
	{
		Y = 0x0001;
		A = [(0x00) + Y];
		Y = A;
		A = [0x0B04 + Y];

		if (Z == 1)
			return this.L91B292();

		A = 0x0001;
		[0x0B04 + Y] = A;
	}

	public void L91B292()
	{
		A = [0x0B10 + X];
		C = 0;
		A += 0x0002 + C;
		[0x0B10 + X] = A;
		return this.L91B0C5();
	}

	public void L91B29F()
	{
		[0x0B04 + X] = 0;
		return this.L91B0C5();
	}

}
